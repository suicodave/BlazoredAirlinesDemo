using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazoredAirlinesDemo;
using MudBlazor.Services;
using BlazoredAirlinesDemo.Pages.Passengers;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



builder.Services.AddHttpClient<PassengerHttpClient>(client =>
    client.BaseAddress = new Uri("https://api.instantwebtools.net"));



builder.Services.AddMudServices();

await builder.Build().RunAsync();
