using BlazorSchools.Server.Data;
using BlazorSchools.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorSchools.Server.Controllers
{
    public class CommonControllerSupport
    {
        public string errorString { get; set; }

        public int MaxListCount { get; set; }

        public async Task<Schools> GetJson(IHttpClientFactory clientFactory)
        {
            Schools schoolList = null;

            errorString = "";
            var client = clientFactory.CreateClient("school");

            try
            {
                // gets cast exception
                schoolList = await client.GetFromJsonAsync<Schools>("");
                errorString = null;
            }
            catch (System.InvalidCastException ex)
            {
                errorString = $"Invalid Cast Exception getting our schools: { ex.Message }";
            }
            catch (Exception ex)
            {
                errorString = $"Exception getting our schools: { ex.Message }";
            }

            return schoolList;

        }

        public async Task<Schools> GetData(ISchoolsDataService dataService,
                                           int startIndex,
                                           int maxIndex)
        {
            Schools schoolList = new Schools();
            List<School> schools;
            int index = 0;
            int indexCounter = 0;
            int schoolCount = 0;
            errorString = "";

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
                    schoolList.schools = new School[schoolCount];

                foreach (School school in schools)
                {
                    if (((indexCounter++ >= startIndex) && (index < maxIndex)) || (maxIndex == 0))
                    {
                        School newSchool = new School();
                        newSchool.id = school.id;
                        newSchool.name = school.name;
                        newSchool.street = school.street;
                        newSchool.city = school.city;
                        newSchool.state = school.state;
                        newSchool.zip = school.zip;
                        schoolList.schools[index++] = newSchool;
                    }
                }
            }
            catch (Exception ex)
            {
                errorString = $"Exception getting our schools database: { ex.Message }";
            }

            return schoolList;
        }

        public async Task UpdateData(Schools schoolList, ISchoolsDataService dataService)
        {
            errorString = "";
            try
            {
                await dataService.Create(schoolList);
            }
            catch (Exception ex)
            {
                errorString = $"Exception creating our schools database: { ex.Message }";
            }
        }

    }
}
