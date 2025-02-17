global using System.Net.Http.Json;
global using ECommerce.Client.Services.ProductService;
global using ECommerce.Client.Services.CategoryService;
using Blazored.LocalStorage;
using ECommerce.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ECommerce.Client.Services.CartService;
using ECommerce.Client.Services.ModalService;
using ECommerce.Client.Services.UserService;
using ECommerce.Client.Services.SessionService;
using ECommerce.Client.Services.AuthService;
using ECommerce.Client.Services.HttpService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//registred localStorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//registered ProductService
builder.Services.AddScoped<IProductService, ProductService>();
//registered CategoryService
builder.Services.AddScoped<ICategoryService, CategoryService>();
//registered CartService
builder.Services.AddScoped<ICartService, CartService>();
//registered ModalService
builder.Services.AddScoped<IModalService, ModalService>();
//registered UserService    
builder.Services.AddScoped<IUserService, UserService>();
//registered SessionService
builder.Services.AddScoped<ISessionService, SessionService>();
//registered AuthService
builder.Services.AddScoped<IAuthService, AuthService>();
//registered HttpService
builder.Services.AddScoped<IHttpService, HttpService>();



await builder.Build().RunAsync();
