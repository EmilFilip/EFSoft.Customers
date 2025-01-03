var builder = WebApplication.CreateBuilder(args);

//if (!builder.Environment.IsDevelopment())
//{
//var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

//builder.Configuration.AddAzureAppConfiguration(options =>
//{
//    options.Connect(appConfigurationConnectionString)
//            .ConfigureRefresh(refresh =>
//            {
//                refresh.Register("Settings:Sentinel", refreshAll: true)
//                    .SetCacheExpiration(new TimeSpan(0, 1, 0));
//            });
//});
//}

builder.Services.AddCarter();
// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customers Microservice", Version = "v1" });
    });

builder.Services.RegisterLocalServices(builder.Configuration);

var app = builder.Build();
app.MapCarter();
//app.MapCustomerEndpoints();
//app.SeedCustomerDb();
// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers Microservice V1");
    });

app.UseAuthorization();
app.UseHttpsRedirection();

app.Run();
