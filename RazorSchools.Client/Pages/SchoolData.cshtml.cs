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

namespace RazorSchools.Client.Pages
{
    public class SchoolDataModel : PageContentSupport
    {
        public Schools CurrentSchools { get; set; }
        public string ErrorString { get; set; }

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
                CurrentSchools = await http.GetFromJsonAsync<Schools>("SchoolModel");

                ErrorString = null;
            }
            catch (IOException ex)
            {
                ErrorString = $"There was an error getting our schools: { ex.Message }";
            }
        }
    }
}
