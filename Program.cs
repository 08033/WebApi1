using Microsoft.AspNetCore.Localization;
using System.Globalization;
using WebApi1.Models;
using WebApi1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var supportedCulturez = new[] { "en-US", "es", "it" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCulturez[0]).AddSupportedCultures(supportedCulturez).AddSupportedUICultures(supportedCulturez);
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("es"),
        new CultureInfo("it")
    };

    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.Configure<FamilyTreeDatabaseSettings>(builder.Configuration.GetSection("FamilyTreeDatabase"));
builder.Services.AddSingleton<FamilyTreeService>();


var app = builder.Build();

app.UseRequestLocalization(localizationOptions);
app.UseRequestLocalization();
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
