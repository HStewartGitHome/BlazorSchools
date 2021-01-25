using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorSchools.Shared;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.IO;
using System.Net.Http.Json;

namespace ReactSchools.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceController : CommonController
    {
     
        private readonly ILogger<PerformanceController> _logger;
        private readonly IConfiguration _configuration;
        public string HtmlClientApi { get; set; }
        public string ErrorString { get; set; }

        public PerformanceController(ILogger<PerformanceController> logger,
                                  IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            HtmlClientApi = configuration["htmlclient"];
        }

        [HttpGet]
        public async Task<IEnumerable<Performance>> GetAsync()
        {
            List<Performance> perfList = new List<Performance>();
            Performance perf = new Performance();

            try
            {
                HttpClient http = GetHttplClient(HtmlClientApi);
                perf = await http.GetFromJsonAsync<Performance>("SchoolPerformance");

                ErrorString = null;
            }
            catch (IOException ex)
            {
                ErrorString = $"There was an error getting our schools API performance data: { ex.Message }";
            }

            perfList.Add(perf);

            return perfList.ToArray();
        }
    }
}
