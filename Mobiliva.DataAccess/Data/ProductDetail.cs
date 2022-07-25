using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.DataAccess.Data
{
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

    }
}
