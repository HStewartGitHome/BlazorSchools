using BlazorSchools.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RazorSchools.Client.Pages
{
    public class SchoolPageDataModel : PageContentSupport
    {
        public IConfiguration _configuration = null;

        public Schools CurrentSchools { get; set; }
        public string ErrorString { get; set; }

        static public string HtmlClientApi { get; set; }

        static public int CurrentIndex { get; set; } = 0;
        static public int MaxPage { get; set; } = 0;
        static public int MaxIndex { get; set; } = 0;

        [BindProperty(SupportsGet = true)]
        public string Check { get; set; }

        public SchoolPageDataModel(IConfiguration configuration)
        {
            _configuration = configuration;
            CurrentSchools = null;

            Check = "";
        }

        public async Task OnGet()
        {
            if (Check.CompareTo("Next") == 0)
                await OnNext();
            else if (Check.CompareTo("Prev") == 0)
                await OnPrev();
            else
            {
                HtmlClientApi = _configuration["htmlclient"];
                MaxIndex = 0;
                MaxPage = 0;
                CurrentIndex = 0;
                await ShowPage(0);
            }
        }

        internal async Task ShowPage(int index)
        {
            try
            {
                string str = "SchoolPage?param=" + index.ToString() + ",0";
                HttpClient http = GetHttplClient(HtmlClientApi);
                CurrentSchools = await http.GetFromJsonAsync<Schools>(str);
                CurrentIndex = index;
                MaxIndex = CurrentSchools.MaxIndex;
                MaxPage = CurrentSchools.MaxPage;

                ErrorString = null;
            }
            catch (IOException ex)
            {
                ErrorString = $"There was an error getting our schools: { ex.Message }";
            }
        }

        public async Task OnNext()
        {
            int newIndex = CurrentIndex + MaxPage;
            if (newIndex <= MaxIndex)
                CurrentIndex = newIndex;

            await ShowPage(CurrentIndex);
        }

        public async Task OnPrev()
        {
            int newIndex = CurrentIndex - MaxPage;
            if (newIndex < 0)
                newIndex = 0;
            CurrentIndex = newIndex;

            await ShowPage(CurrentIndex);
        }
    }
}