
using Mobiliva.Common.EventBus;

namespace Mobiliva.Business.Event
{
    public  class OrderCreatedEvent: IFEvent
    {
        public string Mail { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }
        public OrderCreatedEvent(string Mail,string Name)
        {
            this.Mail = Mail;
            this.Name = Name;
        }
    }
}
