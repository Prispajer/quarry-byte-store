global using Microsoft.EntityFrameworkCore;
global using ECommerce.Shared;
global using ECommerce.Server.Data;
global using ECommerce.Server.Services.ProductService;
global using ECommerce.Server.Services.CategoryService;
global using ECommerce.Server.Services.CartService;
using ECommerce.Server.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECommerce.Server.Services.TokenService;
using ECommerce.Server.Requirements;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using ECommerce.Server.Services.ProductTypeService;
using ECommerce.Server.Services.ProductVariantService;
using ECommerce.Server.Authorization.Handlers;
using ECommerce.Server.Authorization.Requirements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

//The IUserService interface registered with the UserService
builder.Services.AddScoped<IUserService, UserService>();
//The IProductService interface registered with the ProductService
builder.Services.AddScoped<IProductService, ProductService>();
//The IProductTypeService interface registered with the ProductTypeService
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();
//The IProductVariantService interface registered with the ProductVariantService
builder.Services.AddScoped<IProductVariantService, ProductVariantService>();
//The ICategoryService interface registered with the CategoryService
builder.Services.AddScoped<ICategoryService, CategoryService>();
// The ICartService interface registered with the CartService
builder.Services.AddScoped<ICartService, CartService>();
// The ITokenService interface registered with the TokenService
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAnAdmin", policy =>
        policy.Requirements.Add(new IsAdminRequirement()));
    options.AddPolicy("IsSameUser", policy =>
    policy.Requirements.Add(new IsSameUserRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, IsAdminRequirementHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, IsSameUserRequirementHandler>();

var app = builder.Build();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
