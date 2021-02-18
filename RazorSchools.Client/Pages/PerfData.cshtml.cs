using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorSchools.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RazorSchools.Client.Pages
{
    public class PerfDataModel : PageContentSupport
    {
        public PerformanceRecord CurrentPerf { get; set; }
        public string ErrorString { get; set; }

        public string HtmlClientApi { get; set; }

        public PerfDataModel(IConfiguration configuration)
        {
            CurrentPerf = null;
            HtmlClientApi = configuration["htmlclient"];

        }

        public async Task OnGet()
        {
            try
            {
                HttpClient http = GetHttplClient(HtmlClientApi);
                CurrentPerf = await http.GetFromJsonAsync<PerformanceRecord>("SchoolPerformance");

                ErrorString = null;
            }
            catch (IOException ex)
            {
                ErrorString = $"There was an error getting our schools API performance data: { ex.Message }";
            }
        }

    }
}
