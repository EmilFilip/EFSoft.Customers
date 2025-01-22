var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

    _ = builder.Configuration.AddAzureAppConfiguration(options =>
    {
        _ = options.Connect(appConfigurationConnectionString)
                .ConfigureRefresh(refresh =>
                {
                    _ = refresh.Register("Settings:Sentinel", refreshAll: true).SetRefreshInterval(new TimeSpan(0, 1, 0));
                });
    });
}

builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddHealthChecks();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance =
        $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";

        _ = context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);

        var activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
        _ = context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
    };
});

builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customers Microservice", Version = "v1" });
    });

builder.Services.RegisterLocalServices(builder.Configuration);

var app = builder.Build();
app.MapCarter();


app.MapHealthChecks("/health");

if (app.Environment.IsDevelopment())
{
    app.SeedCustomerDb();
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers Microservice V1");
    });
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.Run();
