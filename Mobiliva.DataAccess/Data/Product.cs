using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiliva.DataAccess.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public decimal Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public string Status { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
