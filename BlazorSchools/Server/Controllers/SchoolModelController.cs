using BlazorSchools.Shared.Data.EnitityFramework;
using BlazorSchools.Shared.Data;
using BlazorSchools.Shared.Data.Sim;
using BlazorSchools.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolModelController : ControllerBase
    {
        public string ErrorString { get; set; }

        private readonly IHttpClientFactory _clientFactory = null;
        private readonly ILogger<SchoolModelController> _logger = null;
        private readonly ISchoolsDataService _dataService = null;
        private readonly CommonControllerSupport _support = null;
        private readonly int MaxPage = 0;

        public SchoolModelController(ILogger<SchoolModelController> logger,
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
        public async Task<Schools> Get()
        {
            Schools schoolList = null;

            try
            {
                schoolList = await GetData();
                if ((schoolList.schools == null) || (schoolList.schools.Length == 0))
                {
                    schoolList = await GetJson();
                    await UpdateData(schoolList);
                }

                if (schoolList.schools != null)
                {
                    schoolList.CurrentIndex = 0;
                    schoolList.MaxIndex = schoolList.schools.Length;
                    schoolList.MaxPage = MaxPage;
                }
            }
            catch (Exception ex)
            {
                ErrorString = $"Exception getting our schools: { ex.Message }";
                _logger.LogError(ErrorString);
            }

            return schoolList;
        }

        public async Task<Schools> GetJson()
        {
            Schools schoolList = await _support.GetJson(_clientFactory);
            ErrorString = _support.ErrorString;

            return schoolList;
        }

        public async Task<Schools> GetData()
        {
            Schools schoolList = await _support.GetData(_dataService, 0, 0);
            ErrorString = _support.ErrorString;

            return schoolList;
        }

        public async Task UpdateData(Schools schoolList)
        {
            await _support.UpdateData(schoolList, _dataService);
            ErrorString = _support.ErrorString;
        }
    }
}