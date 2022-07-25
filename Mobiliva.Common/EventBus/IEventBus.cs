
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Common.EventBus
{
    public interface IEventBus
    {
        void Publish(IFEvent @event);

        void Subscribe<T, TH>()
            where T : IFEvent
            where TH : IIFEventHandler<T>;

        void SubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIFEventHandler;

        void UnsubscribeDynamic<TH>(string eventName)
            where TH : IDynamicIFEventHandler;

        void Unsubscribe<T, TH>()
            where TH : IIFEventHandler<T>
            where T : IFEvent;
    }

    public interface IEventLogService
    {
        Task SaveEventAsync(IFEvent @event, string serviceName, EventStateEnum eventState);

        Task<List<EventLog>> GetEventLogsBySourceIdAsync(Guid sourceId);


    }

    public interface IEventLog

    {

        int Id { get; set; }
        Guid EventId { get; set; }
        Guid SourceId { get; set; }
        string EventTypeName { get; set; }
        EventStateEnum State { get; set; }
        int TimesSent { get; set; }
        DateTime CreationTime { get; set; }
        string Content { get; set; }

        string ServiceName { get; set; }
    }

    public class EventLog : IEventLog
    {
        public int Id { get; set; }
        public Guid EventId { get; set; }
        public Guid SourceId { get; set; }
        public string EventTypeName { get; set; }
        public EventStateEnum State { get; set; }
        public int TimesSent { get; set; }
        public DateTime CreationTime { get; set; }
        public string Content { get; set; }

        public Guid UniqueId { get; set; }

        public string ServiceName { get; set; }
    }
}
