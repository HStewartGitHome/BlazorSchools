using BlazorSchools.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ReactSchools.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolDataController : CommonController
    {
        private readonly ILogger<SchoolDataController> _logger;
        private readonly IConfiguration _configuration;
        public string HtmlClientApi { get; set; }
        public string ErrorString { get; set; }

        public SchoolDataController(ILogger<SchoolDataController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            HtmlClientApi = configuration["htmlclient"];
        }

        [HttpGet]
        public async Task<IEnumerable<School>> GetAsync()
        {
            List<School> schoolList = new List<School>();
            Schools schools;


            try
            {
                HttpClient http = GetHttplClient(HtmlClientApi);
                schools = await http.GetFromJsonAsync<Schools>("SchoolModel");

                foreach (School obj in schools.schools)
                {
                    schoolList.Add(obj);
                }

                ErrorString = null;
            }
            catch (IOException ex)
            {
                ErrorString = $"There was an error getting our schools API performance data: { ex.Message }";
            }



            return schoolList.ToArray();
        }
    }
}
