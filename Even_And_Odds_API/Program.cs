using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Even_And_Odds_API.Data;
using Microsoft.AspNetCore.Identity;
using Even_And_Odds_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("conn_string")
        ));

builder
    .Services
           .AddIdentity<ApplicationUser, IdentityRole>(options =>
           {
               options.Password.RequireDigit = false;
               options.Password.RequiredLength = 5;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireUppercase = false;
               options.Password.RequireLowercase = false;
           })
           .AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders();
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
