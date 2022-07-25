using Autofac;
using Autofac.Extensions.DependencyInjection;
using MailService;

using Mobiliva.Business.Event;
using Mobiliva.Common.EventBus;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MyApplicationModule()));



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<OrderMailEventHandler>();

RabbitMQConnectionSettings rabbitMQConnectionSettings = new RabbitMQConnectionSettings();
rabbitMQConnectionSettings.EventBusConnection = "localhost";
rabbitMQConnectionSettings.Port = "5672";
rabbitMQConnectionSettings.EventBusUserName = "guest";
rabbitMQConnectionSettings.EventBusPassword = "guest";



EventBusRabbitMQExtensions.AddRabbitMQEventBus(builder.Services, rabbitMQConnectionSettings, "mobiliva");

var app = builder.Build();



var eventBus = app.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<OrderCreatedEvent, OrderMailEventHandler>();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();