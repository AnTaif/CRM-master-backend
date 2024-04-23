using MasterCRM.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]?>();
builder.Services.AddCustomCors(corsOrigins);

builder.Services.AddCustomAuth();

// Changing database host depending on the running environment (Docker or Locally)
var hostName = Environment.GetEnvironmentVariable("DB_CONTAINER") ?? "localhost";
var connectionString = $"Host={hostName};" + builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddInfrastructureLayer(connectionString);
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

app.MapControllers();

app.Run();