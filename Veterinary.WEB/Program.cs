using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Veterinary.WEB;
using Veterinary.WEB.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://veterinaryapi2024.azurewebsites.net/") });

builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
