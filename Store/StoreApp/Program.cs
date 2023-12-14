using System.Net;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Controller -View
builder.Services.AddControllersWithViews();

// Razor Pages
builder.Services.AddRazorPages();

// Database Connection - Extensions 
builder.Services.ConfigureDbContext(builder.Configuration);
// Identity
builder.Services.ConfigureIdentity();

// Session Management - Extensions 
builder.Services.ConfigureSession();

// Repositories - Extensions
// IoC -> Register - Resolve - Dispose
builder.Services.ConfigureRepositoryRegistration();
// Session Management

// Services Extensions
builder.Services.ConfigureServiceRegistration();

//Razor Pages
//builder.Services.AddSingleton<Cart>();  // All users have 1 cart.
//builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

// Lowecase Routing
builder.Services.ConfigureRouting();

// Application Cookie
builder.Services.ConfigureApplicationCookie();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Pages
app.UseStaticFiles();

// Session Management
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

// ^ Routing ^  ***
// Authentication - Authorization
app.UseAuthentication();
app.UseAuthorization();

// Areas
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    // Razor Pages
    endpoints.MapRazorPages();
});

// Extensions - Auto Migrate
app.ConfigureAndCheckMigration();

// Localization
app.ConfigureLocalization();

// Authentication - Authorization -- Default - Admin - User
app.ConfigureDefaultAdminUser();

app.Run();
