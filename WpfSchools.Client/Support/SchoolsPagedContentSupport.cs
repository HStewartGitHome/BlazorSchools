using BlazorSchools.Shared.Models;
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

        public SchoolsPagedContentSupport(IConfiguration configuration)
        {
            TitleMessage = "School Data";
            CurrentIndex = -1;
            MaxIndex = -1;
            MaxIndexPerPage = 14;
            StatusMessage = "Loading...";
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
            IPageDataModel Data = new PageDataModel();

            Schools currentSchools = GetCurrentSchools(nextIndex);

            CreateHeader(Data, TitleMessage);
            StatusMessage = $"  Start {CurrentIndex} of {MaxIndex}";

            int count = GetCount(currentSchools, MaxIndexPerPage);
            CreateDataContentStrings(Data, currentSchools, count);

            return Data;
        }

        public Schools GetCurrentSchools(int nextIndex)
        {
            Schools currentSchools = null;

            // need better way for this 
            Task.Run(async () =>
            {
                HttpClient http = GetHttplClient(HtmlClientApi);
                string str = $"SchoolPage?param={nextIndex},{MaxIndexPerPage}";
                currentSchools = await http.GetFromJsonAsync<Schools>(str);
            }).Wait();

            CurrentIndex = nextIndex;
            MaxIndex = currentSchools.MaxIndex;
            if (MaxIndexPerPage > currentSchools.MaxPage)
                MaxIndexPerPage = currentSchools.MaxPage;

            return currentSchools;
        }

        public static int GetCount(Schools currentSchools,
                             int maxIndexPerPage)
        {
            int count = currentSchools.schools.Length;
            if (count > maxIndexPerPage)
                count = currentSchools.MaxPage;
            return count;
        }

        private void CreateDataContentStrings(IPageDataModel data,
                                                     Schools currentSchools,
                                                     int count)
        {
            data.HasContent = true;
            data.Content = new string[count];
            data.ContentFontSize = 18;

            for (int Index = 0; Index < count; Index++)
            {
                var strings = new List<string>
                {
                    currentSchools.schools[Index].name,
                    currentSchools.schools[Index].street,
                    currentSchools.schools[Index].city,
                    currentSchools.schools[Index].state,
                    currentSchools.schools[Index].zip
                };

                data.Content[Index] = MakeContent(strings);
            }
        }

        private void CreateHeader(IPageDataModel data,
                                   string titleMessage)
        {
            // First setup field
            AddField("Name", 28);
            AddField("Update", 28);
            AddField("City", 12);
            AddField("State", 7);
            AddField("Zip", 5);

            data.Title = titleMessage;
            data.HasMessage = false;

            // Make header
            data.Header = MakeHeader();
            data.HasHeader = true;
        }
    }
}