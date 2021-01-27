using BlazorSchools.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ReactSchools.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerformanceController : CommonController
    {
        public string HtmlClientApi { get; set; }
        public string ErrorString { get; set; }

        public PerformanceController(IConfiguration configuration)
        {
           
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