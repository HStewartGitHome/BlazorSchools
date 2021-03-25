using BlazorSchools.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WpfSchools.Client.Models;

namespace WpfSchools.Client.Support
{
    public class SchoolsContentSupport : PageContentSupport
    {
        public string TitleMessage { get; set; }
        public int CurrentIndex { get; set; }
        public int MaxIndex { get; set; }
        public int MaxIndexPerPage { get; set; }
        public string StatusMessage { get; set; }
        public string HtmlClientApi { get; set; }

        public SchoolsContentSupport(IConfiguration configuration)
        {
            TitleMessage = "School API Data";
            StatusMessage = "Loading...";
            CurrentIndex = 0;
            MaxIndex = -1;
            MaxIndexPerPage = 14;
            HtmlClientApi = configuration["htmlclient"];
        }

        public IPageDataModel CreatePageDataModel()
        {
            IPageDataModel Data = new PageDataModel();

            Schools currentSchools = GetCurrentSchools();

            CreateHeader(Data, TitleMessage);

            StatusMessage = $"  Start {CurrentIndex} of {MaxIndex}";
            CreateDataContentStrings(Data, currentSchools, currentSchools.schools.Length);

            return Data;
        }

        public Schools GetCurrentSchools()
        {
            Schools currentSchools = null;

            // need better way for this
            Task.Run(async () =>
            {
                HttpClient http = GetHttplClient(HtmlClientApi);

                currentSchools = await http.GetFromJsonAsync<Schools>("SchoolModel");
                MaxIndex = currentSchools.MaxIndex;
            }).Wait();

            return currentSchools;
        }
    }
}