using BlazorSchools.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;


namespace RazorSchools.Client.Pages
{
    public class PageContentSupport : PageModel
    {


        public HttpClient GetHttplClient(string str)
        {
            HttpClient client = null;
            ClientFactory factory = new ClientFactory();
            client = factory.GetHttplClient(str);
            return client;

        }
    }
}
