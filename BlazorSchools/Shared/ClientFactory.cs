using System;
using System.Net.Http;

namespace BlazorSchools.Shared
{
    public class ClientFactory
    {
        public HttpClient GetHttplClient(string str)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(str);
            return client;
        }

    }
}
