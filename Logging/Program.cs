using LoggingService.Contracts;
using LoggingService.Services;
using MessageService.Message;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ILogService, LogService>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("LogEndpoint");
    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    var persistence = endpointConfiguration.UsePersistence<LearningPersistence>();
    var routing = transport.Routing();
    routing.RouteToEndpoint(typeof(Log), "LogEndpoint");
    endpointConfiguration.EnableInstallers();
    return endpointConfiguration;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();