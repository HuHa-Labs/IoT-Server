using IoT_Server.KafkaBackgroundService;

var builder = WebApplication.CreateBuilder(args);

#region Logging Configuration
builder.Logging.SetMinimumLevel(LogLevel.Information);
#endregion

#region Dependency Injection
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true; // returns 406 for not supported file response request
});
// .AddXmlDataContractSerializerFormatters(); // supports XML

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Extensions.Add("Server Name", Environment.MachineName);
    };
});

builder.Services.AddHostedService<KafkaService>();
builder.Services.AddSwaggerGen();
#endregion

#region Middleware Configuration
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseRouting();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
#pragma warning restore ASP0014
#endregion

app.Run();