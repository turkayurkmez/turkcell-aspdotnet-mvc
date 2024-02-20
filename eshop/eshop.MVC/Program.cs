using eshop.DataAccess.Repositories;
using eshop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, FakeProductRepository>();

//1. Transient: Nesneye her ihtiyaç duyulduğunda bellekte yeni bir tane üretsin.
//2. Singleton: Sadece bir adet bellekte üretsin. Her ihtiyaç duyduğunda aynı nesneyi kullansın.
//3. Scoped: HttpRequest içerisinde bir tane üretsin, aynı request içinde aynı nesneyi kullansın fakat request yenilendiğinde başka bir nesne oluştursun.

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
