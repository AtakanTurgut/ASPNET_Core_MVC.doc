using System.Net;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Controller -View
builder.Services.AddControllersWithViews();

// Razor Pages
builder.Services.AddRazorPages();

// Database Connection
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("StoreApp"));
});

// Session Management
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => 
{
    options.Cookie.Name = "StoreApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);  // 10min
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Repositories
// IoC -> Register - Resolve - Dispose
builder.Services.AddScoped<IRepositoryManager, RepositoryManage>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
// Session Management

// Services
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

//Razor Pages
//builder.Services.AddSingleton<Cart>();  // All users have 1 cart.
builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Pages
app.UseStaticFiles();

// Session Management
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

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

app.Run();
