using eshop.DataAccess.Repositories;
using eshop.Services;
using eshop.Services.MapProfiler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, FakeProductRepository>();
builder.Services.AddTransient<ICategoryRepository, FakeCategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
//TODO 2: IoC LifeTime P.O.C çalışması yap
//1. Transient: Nesneye her ihtiyaç duyulduğunda bellekte yeni bir tane üretsin.
//2. Singleton: Sadece bellekte bir adet üretsin. Her ihtiyaç duyduğunda aynı nesneyi kullansın.
//3. Scoped: HttpRequest içerisinde bir tane üretsin, aynı request içinde aynı nesneyi kullansın fakat request yenilendiğinde başka bir nesne oluştursun.

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(8);
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
app.UseSession();
app.UseAuthorization();


app.MapControllerRoute("paging", "Category{category}/Page{page}", defaults: new { controller = "Home", action = "Index", page = 1 });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
