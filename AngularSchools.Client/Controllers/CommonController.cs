using BlazorSchools.Shared.Services;
using System.Net.Http;

namespace AngularSchools.Client.Controllers
{
    public class CommonController
    {
        public static HttpClient GetHttplClient(string str)
        {
            HttpClient client = ClientFactory.GetHttplClient(str);
            return client;
        }
    }
}