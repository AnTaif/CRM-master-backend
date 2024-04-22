using MasterCRM.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication().AddBearerToken();
builder.Services.AddAuthorization();

builder.Services.AddAuth();

var hostName = "localhost";
if (builder.Environment.EnvironmentName == "Development.Docker")
{
    hostName = "mastercrm.db";
}
var connectionString = $"Host={hostName};" + builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddInfrastructureLayer(connectionString);

builder.Services.AddApplicationLayer();


var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Development.Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();