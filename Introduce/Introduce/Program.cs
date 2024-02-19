var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

//app.MapGet("/", () => "Merhaba!");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();




