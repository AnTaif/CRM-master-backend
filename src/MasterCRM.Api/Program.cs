using System.Globalization;
using DotNetEnv;
using MasterCRM.Api.Extensions;
using MasterCRM.Api.Middlewares;
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

var uploadsContentRootPath = Path.Combine(builder.Environment.ContentRootPath, "Uploads");
var uploadsPath = Environment.GetEnvironmentVariable("FILES_PATH") ?? uploadsContentRootPath;

builder.Services.AddDomainLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration, uploadsPath, 
    Path.Combine(uploadsContentRootPath, "Templates"));

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
    FileProvider = new PhysicalFileProvider(Path.Combine(uploadsContentRootPath, "Templates")),
    RequestPath = "/uploads/templates"
});

Directory.CreateDirectory(Path.Combine(uploadsPath, "Websites"));
app.UseMiddleware<HtmlDefaultFileMiddleware>();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(uploadsPath, "Websites")),
    RequestPath = "/website"
});

app.MapControllers();

app.Run();