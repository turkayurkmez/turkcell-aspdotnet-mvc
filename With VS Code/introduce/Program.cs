var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapControllerRoute("default", "{controller=Home/}")


app.MapGet("/", () => "Hello World!");

app.Run();
