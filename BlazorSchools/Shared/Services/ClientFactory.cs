using System;
using System.Net.Http;

namespace BlazorSchools.Shared.Services
{
    public class ClientFactory
    {
        public static HttpClient GetHttplClient(string str)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(str)
            };
            return client;
        }
    }
}
