
using RabbitMQ.Client;

using System;

namespace Mobiliva.Common.EventBus
{
    public interface IRabbitMQPersistentConnection
       : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
