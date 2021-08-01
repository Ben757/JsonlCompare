using System;
using System.Net.Http;
using System.Threading.Tasks;
using JsonlCompare.Client.Interfaces;
using JsonlCompare.Client.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace JsonlCompare.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMatBlazor();

            builder.Services.AddSingleton<IPropertyInfoService, PropertyInfoService>();
            builder.Services.AddSingleton<IJsonContainer, JsonDummyContainer>();

            await builder.Build().RunAsync();
        }
    }
}
