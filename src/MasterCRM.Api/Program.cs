using System.Globalization;
using DotNetEnv;
using MasterCRM.Api.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../../.env");

const string newDateTimeFormat = "dd.MM.yyyy";
var newCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
newCulture.DateTimeFormat.ShortDatePattern = newDateTimeFormat;
CultureInfo.DefaultThreadCurrentCulture = newCulture;
CultureInfo.DefaultThreadCurrentUICulture = newCulture;

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]?>();
builder.Services.AddCustomCors(corsOrigins);

builder.Services.AddCustomAuth();

var uploadsPath = Path.Combine(builder.Environment.ContentRootPath, "Uploads");
builder.Services.AddInfrastructureLayer(builder.Configuration, uploadsPath);
builder.Services.AddApplicationLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("FrontendPolicy");

app.UseAuthentication();
app.UseAuthorization();

Directory.CreateDirectory(Path.Combine(uploadsPath, "Public"));
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(uploadsPath, "Public")),
    RequestPath = "/uploads"
});

Directory.CreateDirectory(Path.Combine(uploadsPath, "Templates"));
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(uploadsPath, "Templates")),
    RequestPath = "/uploads/templates"
});

app.MapControllers();

app.Run();