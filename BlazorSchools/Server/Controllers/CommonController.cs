using BlazorSchools.Shared.Data;
using BlazorSchools.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Controllers
{
    public class CommonControllerSupport
    {
        public string ErrorString { get; set; }

        public int MaxListCount { get; set; }

        public async Task<Schools> GetJson(IHttpClientFactory clientFactory)
        {
            Schools schoolList = null;

            ErrorString = "";
            var client = clientFactory.CreateClient("school");

            try
            {
                // gets cast exception
                schoolList = await client.GetFromJsonAsync<Schools>("");
                ErrorString = null;
            }
            catch (System.InvalidCastException ex)
            {
                ErrorString = $"Invalid Cast Exception getting our schools: { ex.Message }";
            }
            catch (Exception ex)
            {
                ErrorString = $"Exception getting our schools: { ex.Message }";
            }

            return schoolList;
        }

        public async Task<Schools> GetData(ISchoolsDataService dataService,
                                           int startIndex,
                                           int maxIndex)
        {
            Schools schoolList = new Schools();
            List<SchoolItem> schools;
            int index = 0;
            int indexCounter = 0;
            int schoolCount;
            ErrorString = "";

            try
            {
                schools = await dataService.GetSchoolsAsync();
                MaxListCount = schools.Count;
                if (maxIndex == 0)
                    schoolCount = schools.Count;
                else if (maxIndex > schools.Count)
                    schoolCount = schools.Count;
                else
                    schoolCount = maxIndex;
                schoolList.schools = null;
                if (schools.Count > 0)
                    schoolList.schools = new SchoolItem[schoolCount];

                foreach (SchoolItem school in schools)
                {
                    if (((indexCounter++ >= startIndex) && (index < maxIndex)) || (maxIndex == 0))
                    {
                        SchoolItem newSchool = new SchoolItem
                        {
                            Id = school.Id,
                            name = school.name,
                            street = school.street,
                            city = school.city,
                            state = school.state,
                            zip = school.zip
                        };
                        schoolList.schools[index++] = newSchool;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorString = $"Exception getting our schools database: { ex.Message }";
            }

            return schoolList;
        }

        public async Task UpdateData(Schools schoolList, ISchoolsDataService dataService)
        {
            ErrorString = "";
            try
            {
                await dataService.Create(schoolList);
            }
            catch (Exception ex)
            {
                ErrorString = $"Exception creating our schools database: { ex.Message }";
            }
        }
    }
}