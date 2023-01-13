using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Net_6.Database;
using Net_6.Database.Entities;
using Net_6.Database.Seeders;
using Net_6.Logic;
using Net_6.Logic.Commands.Request;
using Net_6.Logic.MappingProfile;
using Net_6.Ultils.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCookiesAuthenticate(builder.Configuration);
builder.Services.AddSqlServerDatabase<AppDatabase>(builder.Configuration.GetConnectionString("Database"));
builder.Services.AddIdentityConfig<User, IdentityRole, AppDatabase>();
builder.Services.AddMediatR(typeof(Login).Assembly);
builder.Services.AddAutoMapper(typeof(AuthorMappingProfile).Assembly);
builder.Services.AddQueries();

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var database = scope.ServiceProvider.GetRequiredService<AppDatabase>();
    await database.Database.MigrateAsync();
    await AppSeeder.InitializeAsync(database, userManager, roleManager);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Site}/{action=Index}/{id?}");

app.Run();