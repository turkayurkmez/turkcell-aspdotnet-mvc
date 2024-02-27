using eshop.API.Security;
using eshop.MVC.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddNecessaryInecjtions(connectionString);

builder.Services.AddCors(option => option.AddPolicy("allow", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    /*
     * http://www.turkcell.com.tr/deneme
     * https://www.turkcell.com.tr
     * https://customer.turkcell.com.tr
     * http://www.turkcell.com.tr:8854
     */
}));


//builder.Services.AddAuthentication("Basic")
//                .AddScheme<BasicOption, BasicHandler>("Basic", null);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    ValidIssuer = "server.myapp",
                    ValidAudience = "client.myapp",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cümle-bizim-için-kritik-bir-cümle")),
                    ValidateIssuerSigningKey = true
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allow");
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
