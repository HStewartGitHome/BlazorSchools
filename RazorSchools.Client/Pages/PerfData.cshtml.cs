using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorSchools.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RazorSchools.Client.Pages
{
    public class PerfDataModel : PageContentSupport
    {
        public Performance currentPerf { get; set; }
        public string errorString { get; set; }

        public string HtmlClientApi { get; set; }

        public PerfDataModel(IConfiguration configuration)
        {
            currentPerf = null;
            HtmlClientApi = configuration["htmlclient"];

        }

        public async Task OnGet()
        {
            try
            {
                HttpClient http = GetHttplClient(HtmlClientApi);
                currentPerf = await http.GetFromJsonAsync<Performance>("SchoolPerformance");

                errorString = null;
            }
            catch (Exception ex)
            {
                errorString = $"There was an error getting our schools API performance data: { ex.Message }";
            }
        }

    }
}
