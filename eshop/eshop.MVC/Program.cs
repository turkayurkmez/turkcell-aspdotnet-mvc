using eshop.MVC.Extensions;
using eshop.MVC.Models;
using eshop.Services.MapProfiler;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IProductRepository, EFProductRepository>();
//builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("db");
//builder.Services.AddDbContext<TurkcellDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddNecessaryInecjtions(connectionString);

//TODO 2: IoC LifeTime P.O.C çalışması yap
//1. Transient: Nesneye her ihtiyaç duyulduğunda bellekte yeni bir tane üretsin.
//2. Singleton: Sadece bellekte bir adet üretsin. Her ihtiyaç duyduğunda aynı nesneyi kullansın.
//3. Scoped: HttpRequest içerisinde bir tane üretsin, aynı request içinde aynı nesneyi kullansın fakat request yenilendiğinde başka bir nesne oluştursun.


builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(8);
});

LoginOptions loginOptions = new LoginOptions();
builder.Configuration.GetSection("LoginOptions").Bind(loginOptions);

//var accessDenied = builder.Configuration.GetSection("LoginOptions")["AccessDenied"];
//var loginUrl = builder.Configuration.GetSection("LoginOptions")["LoginUrl"];

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.AccessDeniedPath = loginOptions.AccessDenied;
                    option.LoginPath = loginOptions.LoginUrl;
                    option.ReturnUrlParameter = loginOptions.ReturnUrl;
                });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.MapControllerRoute("paging", "Page{page}", defaults: new { controller = "Home", action = "Index", page = 1 });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
