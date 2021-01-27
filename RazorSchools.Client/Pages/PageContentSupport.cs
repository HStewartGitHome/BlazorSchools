using BlazorSchools.Shared.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;


namespace RazorSchools.Client.Pages
{
    public class PageContentSupport : PageModel
    {
        public static HttpClient GetHttplClient(string str)
        {
            HttpClient client = ClientFactory.GetHttplClient(str);
            return client;

        }
    }
}
