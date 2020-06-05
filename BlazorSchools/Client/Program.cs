using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorSchools.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddHttpClient("BlazorSchools.ServerAPI",
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            // Other DI services
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorSchools.ServerAPI"));


            await builder.Build().RunAsync();
        }
    }
}
