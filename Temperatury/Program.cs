using Application.Mapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;
using System.Reflection;
using Temperatury.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();
builder.Services.AddDbContext<PomTempContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("TempConnection")));
builder.Services.AddDbContext<SettingsContext>();

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();

//Ensure SQLITE is created
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var dbContext = services.GetRequiredService<SettingsContext>();
dbContext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
