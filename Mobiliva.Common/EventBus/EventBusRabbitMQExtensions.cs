using Autofac;

using Microsoft.Extensions.DependencyInjection;

using RabbitMQ.Client;

namespace Mobiliva.Common.EventBus
{
    public static class EventBusRabbitMQExtensions
    {
        public static void AddRabbitMQEventBus(this IServiceCollection services, RabbitMQConnectionSettings settings, string applicationName)
        {


            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {


                if (string.IsNullOrWhiteSpace(settings.EventBusConnection))
                {
                    throw new Exception(applicationName + " : Cannot read connection information for RabbitMQ");
                }

                var factory = new ConnectionFactory()
                {
                    HostName = settings.EventBusConnection
                };

                if (!string.IsNullOrEmpty(settings.EventBusUserName))
                {
                    factory.UserName = settings.EventBusUserName;
                }

                if (!string.IsNullOrEmpty(settings.EventBusPassword))
                {
                    factory.Password = settings.EventBusPassword;
                }

                var retryCount = 5;

                if (!string.IsNullOrEmpty(settings.EventBusRetryCount))
                {
                    retryCount = int.Parse(settings.EventBusRetryCount);
                }

                factory.Port = 5672;

                if (!string.IsNullOrEmpty(settings.Port))
                {
                    factory.Port = int.Parse(settings.Port);
                }


                return new DefaultRabbitMQPersistentConnection(factory, retryCount);
            });


            InitEventBus(services, settings.EventBusRetryCount, applicationName);

        }


        public static void AddRabbitMQEventBus( IServiceCollection services, RabbitMQTcpConnectionSettings settings, string applicationName)
        {


            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {


                if (settings.Servers == null && !settings.Servers.Any())
                {
                    throw new Exception(applicationName + " : Cannot read connection information for RabbitMQ");
                }


                var endpoints = new List<AmqpTcpEndpoint>();
                var ssl = new SslOption();
                ssl.Enabled = settings.IsSslEnabled;

                int defaultPort = 5672;

                foreach (var server in settings.Servers)
                {
                    int currentPort = 0;

                    if (server.Port == 0)
                    {
                        currentPort = defaultPort;
                    }
                    else
                    {
                        currentPort = server.Port;
                    }

                    endpoints.Add(new AmqpTcpEndpoint { HostName = server.EventBusConnection, Port = currentPort, Ssl = ssl });
                }

                var factory = new ConnectionFactory();


                if (!string.IsNullOrEmpty(settings.EventBusUserName))
                {
                    factory.UserName = settings.EventBusUserName;
                }

                if (!string.IsNullOrEmpty(settings.EventBusPassword))
                {
                    factory.Password = settings.EventBusPassword;
                }

                var retryCount = 5;

                if (!string.IsNullOrEmpty(settings.EventBusRetryCount))
                {
                    retryCount = int.Parse(settings.EventBusRetryCount);
                }




                return new DefaultRabbitMQPersistentConnection(factory,  retryCount);
            });


            InitEventBus( services, settings.EventBusRetryCount, applicationName);

        }

        private static void InitEventBus(IServiceCollection services, string RetryCount, string applicationName)
        {
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {

                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                //var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;

                if (!string.IsNullOrEmpty(RetryCount))
                {
                    retryCount = int.Parse(RetryCount);
                }



                return new EventBusRabbitMQ(null, rabbitMQPersistentConnection, iLifetimeScope, eventBusSubcriptionsManager,  applicationName, retryCount);
            });


            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

        }
    }


}
