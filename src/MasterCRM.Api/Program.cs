using DotNetEnv;
using MasterCRM.Api.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../../.env");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]?>();
builder.Services.AddCustomCors(corsOrigins);

builder.Services.AddCustomAuth();

var uploadsPath = Path.Combine(builder.Environment.ContentRootPath, "Uploads");
builder.Services.AddInfrastructureLayer(uploadsPath);
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

Directory.CreateDirectory(uploadsPath);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(uploadsPath),
    RequestPath = "/uploads"
});

app.MapControllers();

app.Run();