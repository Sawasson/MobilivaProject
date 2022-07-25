using AutoMapper;

using Mobiliva.Business.Contracts;
using Mobiliva.Business.Event;
using Mobiliva.Common;
using Mobiliva.Common.EventBus;
using Mobiliva.DataAccess.Data;
using Mobiliva.Models;

namespace Mobiliva.Business.Implementaion
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MobilivaDbContext _dbContext;

        private readonly IMapper _mapper;

        IEventBus eventBus;

        public OrderRepository(MobilivaDbContext dbContext, IMapper mapper, IEventBus eventBus)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            this.eventBus = eventBus;
        }

        public ApiResponse<CreateOrderRequest> CreateOrder(CreateOrderRequest orderRequest)
        {
            try
            {
                var newOrder = _mapper.Map<CreateOrderRequest, Order>(orderRequest);

                _dbContext.Add(newOrder);
                _dbContext.SaveChanges();

                decimal totalPrice = 0;

                foreach (var productDetail in orderRequest.ProductDetails)
                {
                    OrderDetail orderDetail = new OrderDetail();

                    orderDetail.OrderId = newOrder.Id;
                    orderDetail.ProductId = productDetail.ProductId;
                    orderDetail.UnitPrice = productDetail.UnitPrice * productDetail.Amount;
                    totalPrice = totalPrice + orderDetail.UnitPrice;

                    Product product = _dbContext.Products.Find(orderDetail.ProductId);
                    product.Unit = product.Unit - productDetail.Amount;

                    _dbContext.Add(orderDetail);
                    _dbContext.Update(product);
                    _dbContext.SaveChanges();

                }

                newOrder.TotalAmount = totalPrice;

                _dbContext.SaveChanges();

                orderRequest.Id = newOrder.Id;

                this.eventBus.Publish(new OrderCreatedEvent(newOrder.CustomerEmail, newOrder.CustomerName));

                return new ApiResponse<CreateOrderRequest>(Status.Success, ResponseConstant.RecordCreateSuccessfully, orderRequest, null);
            }
            catch (Exception)
            {
                return new ApiResponse<CreateOrderRequest>(Status.Failed, ResponseConstant.RecordCreateNotSuccessfully);
            }

        }
    }
}
