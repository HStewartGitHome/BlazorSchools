using BlazorSchools.Shared;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WpfSchools.Client.Models;

namespace WpfSchools.Client.Support
{
    public class SchoolsPagedContentSupport : PageContentSupport
    {
        public string TitleMessage { get; set; }
        public int CurrentIndex { get; set; }
        public int MaxIndex { get; set; }
        public int MaxIndexPerPage { get; set; }
        public string StatusMessage { get; set; }
        public string HtmlClientApi { get; set; }
        private IConfiguration _configuration = null;


        public SchoolsPagedContentSupport(IConfiguration configuration)
        {
            TitleMessage = "School Data";
            CurrentIndex = -1;
            MaxIndex = -1;
            MaxIndexPerPage = 14;
            StatusMessage = "Loading...";
            _configuration = configuration;
            HtmlClientApi = configuration["htmlclient"];
        }

        public int NextIndex()
        {
            int index = CurrentIndex + MaxIndexPerPage;
            if (MaxIndex < 0)
                index = 0;
            else if (index > MaxIndex)
                index = CurrentIndex;
            return index;
        }

        public int PrevIndex()
        {
            int index = 0;
            if (CurrentIndex >= 0)
            {
                index = CurrentIndex - MaxIndexPerPage;
                if (index < 0)
                    index = 0;
            }
            return index;
        }

        public IPageDataModel CreatePageDataModel(int nextIndex)
        {
            Schools currentSchools = null;
            IPageDataModel Data = new PageDataModel();
            string str;

            // First setup field
            AddField("Name", 28);
            AddField("Update", 28);
            AddField("City", 12);
            AddField("State", 7);
            AddField("Zip", 5);

            Data.Title = TitleMessage;
            Data.HasMessage = false;

            // Make header
            Data.Header = MakeHeader();
            Data.HasHeader = true;



            Task.Run(async () =>
            {
                HttpClient http = GetHttplClient(HtmlClientApi);

                string str = "SchoolPage?param=" + nextIndex.ToString() + "," + MaxIndexPerPage.ToString();
                currentSchools = await http.GetFromJsonAsync<Schools>(str);
                CurrentIndex = nextIndex;
                MaxIndex = currentSchools.MaxIndex;
                if (MaxIndexPerPage > currentSchools.MaxPage)
                    MaxIndexPerPage = currentSchools.MaxPage;


            }).Wait();

            StatusMessage = "  Start " + CurrentIndex.ToString() + " of " + MaxIndex.ToString();

            Data.HasContent = true;
            int count = currentSchools.schools.Length;
            if (count > MaxIndexPerPage)
                count = currentSchools.MaxPage;
            Data.Content = new string[count];
            Data.ContentFontSize = 18;



            List<string> strings = null;
            for (int Index = 0; Index < count; Index++)
            {
                strings = new List<string>();
                strings.Add(currentSchools.schools[Index].name);
                strings.Add(currentSchools.schools[Index].street);
                strings.Add(currentSchools.schools[Index].city);
                strings.Add(currentSchools.schools[Index].state);
                strings.Add(currentSchools.schools[Index].zip);
                str = MakeContent(strings);
                Data.Content[Index] = str;
            }

            return Data;
        }
    }
}
