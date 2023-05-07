using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WalletsList.Data;
using WalletsList.Services;
using WalletsList.Services.Interfeces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IWalletsService, WalletsService>();
builder.Services.AddSingleton<WeatherForecastService>();
var LocalApi = builder.Configuration.GetValue<string>("ApiUrl:LocalApi");
var AzureApi = builder.Configuration.GetValue<string>("ApiUrl:AzureApi");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(LocalApi) });

var app = builder.Build();

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
