using BlazorSchools.Server.Data;
using BlazorSchools.Server.Data.EnitityFramework;
using BlazorSchools.Server.Data.Sim;
using BlazorSchools.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolPageController : ControllerBase
    {
        public string errorString { get; set; }

        private IHttpClientFactory _clientFactory = null;
        private ILogger<SchoolPageController> _logger = null;
        private ISchoolsDataService _dataService = null;
        private CommonControllerSupport _support = null;
        private int MaxPage = 0;


        public SchoolPageController(ILogger<SchoolPageController> logger,
                                       IHttpClientFactory clientFactory,
                                       IConfiguration configuration,
                                       SchoolsSqlDataService sqlService,
                                       SchoolEFDataService efService,
                                       SchoolsSimDataService simService)
        {
            _logger = logger;
            _clientFactory = clientFactory;

            try
            {
                string useSim = configuration.GetValue<string>("UseSIM");
                if (useSim == "1")
                    _dataService = simService;
                else
                {
                    string useEF = configuration.GetValue<string>("UseEF");
                    if (useEF == "1")
                        _dataService = efService;
                    else
                        _dataService = sqlService;
                }

                string maxPage = configuration.GetValue<string>("MaxPage");
                MaxPage = Convert.ToInt32(maxPage);
            }
            catch (Exception e)
            {
                logger.LogError("Exception loading configuration", e);
            }


            _support = new CommonControllerSupport();

        }




        [HttpGet]
        public async Task<Schools> Get(string param)
        {
            Schools schoolList = null;
            int startIndex = 0;
            int maxIndex = 0;
            string start = "0";
            string max = "0";

            try
            {
                string[] values = param.Split(',').Select(sValue => sValue.Trim()).ToArray();
                if (values.Length > 0)
                {
                    start = values[0];
                    if (values.Length > 1)
                        max = values[1];
                }
                _logger.LogInformation("Start Index ={start} max = {max}", start, max);
                startIndex = Convert.ToInt32(start);
                maxIndex = Convert.ToInt32(max);
                if (maxIndex == 0)
                {
                    _logger.LogInformation("Using default of max of {max}", MaxPage);
                    maxIndex = MaxPage;
                }
                else if (maxIndex > MaxPage)
                {
                    _logger.LogWarning("Using default of max of {max} becasue specific of {maxIndex} is too high", MaxPage, maxIndex);
                    maxIndex = MaxPage;
                }
                schoolList = await GetData(startIndex, maxIndex);
                if ((schoolList.schools == null) || (schoolList.schools.Length == 0))
                {
                    schoolList = await GetJson();
                    await UpdateData(schoolList);
                    schoolList = null;
                    schoolList = await GetData(startIndex, maxIndex);
                }

                if (schoolList.schools != null)
                {
                    schoolList.CurrentIndex = startIndex;
                    schoolList.MaxIndex = _support.MaxListCount;
                    schoolList.MaxPage = maxIndex;
                }

            }
            catch (Exception ex)
            {
                errorString = $"Exception getting our schools: { ex.Message }";
                _logger.LogError(errorString);
            }

            return schoolList;

        }

        public async Task<Schools> GetJson()
        {
            Schools schoolList = await _support.GetJson(_clientFactory);
            errorString = _support.errorString;

            return schoolList;

        }

        public async Task<Schools> GetData(int startIndex, int maxIndex)
        {
            Schools schoolList = await _support.GetData(_dataService, startIndex, maxIndex);
            errorString = _support.errorString;

            return schoolList;

        }

        public async Task UpdateData(Schools schoolList)
        {
            await _support.UpdateData(schoolList, _dataService);
            errorString = _support.errorString;

        }
    }
}

