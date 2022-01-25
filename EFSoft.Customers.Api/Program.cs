

var builder = WebApplication.CreateBuilder(args);


if (!builder.Environment.IsDevelopment())
{
    var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationUrl");

    var azureAppConfigurationUri = new Uri(appConfigurationConnectionString);
    builder.Configuration.AddAzureAppConfiguration(config =>
    {
        config.Connect(azureAppConfigurationUri, new DefaultAzureCredential());
    });
}
//var appConfigurationConnectionString = "Endpoint=https://efsoft-appconfiguration.azconfig.io;Id=noHe-l9-s0:M3rnORTPG+I2K+r8P1R8;Secret=mbEznka9bwqQ5kUvaffE9MvcmXX8kl1+yssvKC9aByg=";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Customers Microservice", Version = "v1" });
    });

builder.Services.RegisterLocalServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Microservice V1");
    });
}

app.UseAzureAppConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
