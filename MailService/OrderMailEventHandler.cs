using Mobiliva.Business.Event;
using Mobiliva.Common.EventBus;

namespace MailService
{

    public class OrderMailEventHandler : IIFEventHandler<OrderCreatedEvent>
    {


        public async Task Handle(OrderCreatedEvent @event)
        {

            //Email gönder
        }
    }
}
