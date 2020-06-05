using BlazorSchools.Shared;
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
        private Performance currentPerf;
        public string TitleMessage { get; set; }
        public string HtmlClientApi { get; set; }
        private IConfiguration _configuration = null;


        public PerformancePageContentSupport(IConfiguration configuration)
        {
            TitleMessage = "School API Performance Data";
            _configuration = configuration;
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
                currentPerf = await http.GetFromJsonAsync<Performance>("SchoolPerformance");

            }).Wait();

            if (currentPerf != null)
            {
                // Create content
                Data.HasContent = true;
                Data.ContentFontSize = 24;
                Data.Content = new string[11];

                List<string> strings = new List<string>();
                strings.Add("Initialize Performance");
                strings.Add("");
                strings.Add(currentPerf.InitPerformance.ToString());
                string str = MakeContent(strings);
                Data.Content[0] = str;
                strings = new List<string>();
                strings.Add("Json Performance");
                strings.Add("");
                strings.Add(currentPerf.JsonPerformance.ToString());
                strings.Add(currentPerf.JsonPerformance2.ToString());
                str = MakeContent(strings);
                Data.Content[1] = str;
                strings = new List<string>();
                strings.Add("Dapper Performance");
                strings.Add(currentPerf.DapperUpdatePerformance.ToString());
                strings.Add(currentPerf.DapperPerformance.ToString());
                strings.Add(currentPerf.DapperPerformance2.ToString());
                str = MakeContent(strings);
                Data.Content[2] = str;
                strings = new List<string>();
                strings.Add("Entity Framework Performance");
                strings.Add(currentPerf.EFUpdatePerformance.ToString());
                strings.Add(currentPerf.EFPerformance.ToString());
                strings.Add(currentPerf.EFPerformance2.ToString()); ;
                str = MakeContent(strings);
                Data.Content[3] = str;
                strings = new List<string>();
                strings.Add("Simulated Performance");
                strings.Add(currentPerf.SimUpdatePerformance.ToString());
                strings.Add(currentPerf.SimPerformance.ToString());
                strings.Add(currentPerf.SimPerformance2.ToString());
                str = MakeContent(strings);
                Data.Content[4] = str;
                strings = new List<string>();
                strings.Add("Use Simulated");
                strings.Add("");
                strings.Add(currentPerf.UseSIM.ToString());
                str = MakeContent(strings);
                Data.Content[5] = str;
                strings = new List<string>();
                strings.Add("Use Entity Framework");
                strings.Add("");
                strings.Add(currentPerf.UseEF.ToString());
                str = MakeContent(strings);
                Data.Content[6] = str;
                strings = new List<string>();
                strings.Add("Use Dapper Framework");
                strings.Add("");
                strings.Add(currentPerf.UseDapper.ToString());
                str = MakeContent(strings);
                Data.Content[7] = str;
                strings = new List<string>();
                strings.Add("Allow Entity Framework");
                strings.Add("");
                strings.Add(currentPerf.AllowEF.ToString());
                str = MakeContent(strings);
                Data.Content[8] = str;
                strings = new List<string>();
                strings.Add("Allow Dapper Framework");
                strings.Add("");
                strings.Add(currentPerf.AllowDapper.ToString());
                str = MakeContent(strings);
                Data.Content[9] = str;
                strings = new List<string>();
                strings.Add("Max Records");
                strings.Add("");
                strings.Add(currentPerf.MaxPage.ToString());
                strings.Add(currentPerf.Records.ToString());
                str = MakeContent(strings);
                Data.Content[10] = str;
            }

            return Data;
        }
    }
}
