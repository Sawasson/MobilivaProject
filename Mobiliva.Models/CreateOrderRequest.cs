using Mobiliva.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.Models
{
    public class CreateOrderRequest
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerGSM { get; set; }

        public List<ProductDetail> ProductDetails { get; set; }

    }
}
