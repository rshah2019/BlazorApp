using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp.Data;
using BlazorApp.Service;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ICapitalService, CapitalService>();
builder.Services.AddSingleton<IPriceService, PriceService>();
builder.Services.AddSingleton<IBasisPointService, BasisPointService>();
builder.Services.AddSingleton<ISecurityService, SecurityService>();
builder.Services.AddSingleton<IReferenceDataService, ReferenceDataService>();
builder.Services.AddSingleton<IBorrrowRateService, BorrrowRateService>();
builder.Services.AddSingleton<IHoldingService, MockServerHoldingService>();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTM5OTYxQDMxMzkyZTMzMmUzMGdmQXZpVmhPSi9UbEtQRWtiQnprU3k2R1VaT0k0VWRvVEU2ZnlCcU83S2s9");

builder.Services.AddSyncfusionBlazor(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
