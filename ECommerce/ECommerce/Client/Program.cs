global using ECommerce.Shared;
global using System.Net.Http.Json;
global using ECommerce.Client.Services.ProductService;
global using ECommerce.Client.Services.CategoryService;
using ECommerce.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//registered ProductService
builder.Services.AddScoped<IProductService, ProductService>();
//registered CategoryService
builder.Services.AddScoped<ICategoryService, CategoryService>();
await builder.Build().RunAsync();
