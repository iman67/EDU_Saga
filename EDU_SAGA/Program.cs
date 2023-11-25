using EDU_SAGA.Contracts;
using EDU_SAGA.Services;
using MessageService.Message;
using OrderService.Contracts;
using OrderService.Services;
using PaymentService.Contracts;
using ShipmentService.Contracts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ISaveOrder, SaveOrder>();
builder.Services.AddScoped<IPaymentService, PaymentService.Services.PaymentService>();
builder.Services.AddScoped<IShipmentService,ShipmentService.Services.ShipmentService>();
builder.Services.AddScoped<ILogService,LogService>();

builder.Services.AddScoped<IOrchestrationService, OrchestrationService>();
builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("OrderEndpoint");
    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    var persistence = endpointConfiguration.UsePersistence<LearningPersistence>();
    var routing = transport.Routing();
    routing.RouteToEndpoint(typeof(StartOrder), "OrderEndpoint");

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