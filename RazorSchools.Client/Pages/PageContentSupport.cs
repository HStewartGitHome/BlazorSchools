using BlazorSchools.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;


namespace RazorSchools.Client.Pages
{
    public class PageContentSupport : PageModel
    {


        public static HttpClient GetHttplClient(string str)
        {
            ClientFactory factory = new ClientFactory();
            HttpClient client = factory.GetHttplClient(str);
            return client;

        }
    }
}
