using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Mobiliva.Api;
using Mobiliva.Business.Contracts;
using Mobiliva.Business.Implementaion;
using Mobiliva.Business.Validations;
using Mobiliva.Common.Cache;
using Mobiliva.Common.EventBus;
using Mobiliva.DataAccess.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MyApplicationModule()));

// Add services to the container.

builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssembly(typeof(ProductDtoValidator).Assembly);
                    

                });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MobilivaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<ICacheService, MemoryCacheService> ();

RabbitMQConnectionSettings rabbitMQConnectionSettings = new RabbitMQConnectionSettings();
rabbitMQConnectionSettings.EventBusConnection = "localhost";
rabbitMQConnectionSettings.Port = "5672";
rabbitMQConnectionSettings.EventBusUserName = "guest";
rabbitMQConnectionSettings.EventBusPassword = "guest";

EventBusRabbitMQExtensions.AddRabbitMQEventBus(builder.Services, rabbitMQConnectionSettings, "mobilova");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
