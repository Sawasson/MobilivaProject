using Mobiliva.Common;
using Mobiliva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Business.Contracts
{
    public interface IOrderRepository
    {
        public ApiResponse<CreateOrderRequest> CreateOrder(CreateOrderRequest orderRequest);

    }
}
