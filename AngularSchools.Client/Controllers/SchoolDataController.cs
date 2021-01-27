using BlazorSchools.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AngularSchools.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolDataController : CommonController
    {
        public string HtmlClientApi { get; set; }
        public string ErrorString { get; set; }

        public SchoolDataController(
            IConfiguration configuration)
        {
         
            HtmlClientApi = configuration["htmlclient"];
        }

        [HttpGet]
        public async Task<IEnumerable<SchoolItem>> GetAsync()
        {
            List<SchoolItem> schoolList = new List<SchoolItem>();
            Schools schools;

            try
            {
                HttpClient http = GetHttplClient(HtmlClientApi);
                schools = await http.GetFromJsonAsync<Schools>("SchoolModel");

                foreach (SchoolItem obj in schools.schools)
                {
                    schoolList.Add(obj);
                }

                ErrorString = null;
            }
            catch (IOException ex)
            {
                ErrorString = $"There was an error getting our schools API performance data: { ex.Message }";
            }

            return schoolList.ToArray();
        }
    }
}