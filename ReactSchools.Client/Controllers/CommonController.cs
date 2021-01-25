using BlazorSchools.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReactSchools.Client.Controllers
{
    public class CommonController
    {
        public static HttpClient GetHttplClient(string str)
        {
            ClientFactory factory = new ClientFactory();
            HttpClient client = factory.GetHttplClient(str);
            return client;

        }
    }
}
