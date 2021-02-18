using BlazorSchools.Shared.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WpfSchools.Client.Models;

namespace WpfSchools.Client.Support
{
    public class PerformancePageContentSupport : PageContentSupport
    {
        private PerformanceRecord currentPerf;
        public string TitleMessage { get; set; }
        public string HtmlClientApi { get; set; }

        public PerformancePageContentSupport(IConfiguration configuration)
        {
            TitleMessage = "School API Performance Data";
  
            HtmlClientApi = configuration["htmlclient"];
        }

        public IPageDataModel CreatePageDataModel()
        {
            IPageDataModel Data = new PageDataModel();

            // First setup field
            AddField("Performance", 36);
            AddField("Update", 10);
            AddField("Read", 8);
            AddField("Read2", 8);

            Data.Title = TitleMessage;
            Data.HasMessage = false;

            // Make header
            Data.Header = MakeHeader();
            Data.HasHeader = true;

            Task.Run(async () =>
            {
                HttpClient http = GetHttplClient(HtmlClientApi);
                currentPerf = await http.GetFromJsonAsync<PerformanceRecord>("SchoolPerformance");
            }).Wait();

            if (currentPerf != null)
            {
                // Create content
                Data.HasContent = true;
                Data.ContentFontSize = 24;
                Data.Content = new string[11];

                List<string> strings = new List<string>
                {
                    "Initialize Performance",
                    "",
                    currentPerf.InitPerformance.ToString()
                };
                string str = MakeContent(strings);
                Data.Content[0] = str;
                strings = new List<string>
                {
                    "Json Performance",
                    "",
                    currentPerf.JsonPerformance.ToString(),
                    currentPerf.JsonPerformance2.ToString()
                };
                str = MakeContent(strings);
                Data.Content[1] = str;
                strings = new List<string>
                {
                    "Dapper Performance",
                    currentPerf.DapperUpdatePerformance.ToString(),
                    currentPerf.DapperPerformance.ToString(),
                    currentPerf.DapperPerformance2.ToString()
                };
                str = MakeContent(strings);
                Data.Content[2] = str;
                strings = new List<string>
                {
                    "Entity Framework Performance",
                    currentPerf.EFUpdatePerformance.ToString(),
                    currentPerf.EFPerformance.ToString(),
                    currentPerf.EFPerformance2.ToString()
                };
                ;
                str = MakeContent(strings);
                Data.Content[3] = str;
                strings = new List<string>
                {
                    "Simulated Performance",
                    currentPerf.SimUpdatePerformance.ToString(),
                    currentPerf.SimPerformance.ToString(),
                    currentPerf.SimPerformance2.ToString()
                };
                str = MakeContent(strings);
                Data.Content[4] = str;
                strings = new List<string>
                {
                    "Use Simulated",
                    "",
                    currentPerf.UseSIM.ToString()
                };
                str = MakeContent(strings);
                Data.Content[5] = str;
                strings = new List<string>
                {
                    "Use Entity Framework",
                    "",
                    currentPerf.UseEF.ToString()
                };
                str = MakeContent(strings);
                Data.Content[6] = str;
                strings = new List<string>
                {
                    "Use Dapper Framework",
                    "",
                    currentPerf.UseDapper.ToString()
                };
                str = MakeContent(strings);
                Data.Content[7] = str;
                strings = new List<string>
                {
                    "Allow Entity Framework",
                    "",
                    currentPerf.AllowEF.ToString()
                };
                str = MakeContent(strings);
                Data.Content[8] = str;
                strings = new List<string>
                {
                    "Allow Dapper Framework",
                    "",
                    currentPerf.AllowDapper.ToString()
                };
                str = MakeContent(strings);
                Data.Content[9] = str;
                strings = new List<string>
                {
                    "Max Records",
                    "",
                    currentPerf.MaxPage.ToString(),
                    currentPerf.Records.ToString()
                };
                str = MakeContent(strings);
                Data.Content[10] = str;
            }

            return Data;
        }
    }
}