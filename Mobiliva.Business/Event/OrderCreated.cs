
using Mobiliva.Common.EventBus;

namespace Mobiliva.Business.Event
{
    public  class ProductAddedEvent : IFEvent
    {
        public string Mail { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }
        public ProductAddedEvent(string Mail,string Name)
        {
            this.Mail = Mail;
            this.Name = Name;
        }
    }
}
