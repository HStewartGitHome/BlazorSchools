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

namespace RazorSchools.Client.Pages
{
    public class SchoolDataModel : PageContentSupport
    {
        public Schools currentSchools { get; set; }
        public string errorString { get; set; }

        public string HtmlClientApi { get; set; }

        public SchoolDataModel(IConfiguration configuration)
        {
            HtmlClientApi = configuration["htmlclient"];

        }
        public async Task OnGet()
        {
            try
            {
                HttpClient http = GetHttplClient(HtmlClientApi);
                currentSchools = await http.GetFromJsonAsync<Schools>("SchoolModel");

                errorString = null;
            }
            catch (Exception ex)
            {
                errorString = $"There was an error getting our schools: { ex.Message }";
            }
        }
    }
}
