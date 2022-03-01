using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Models
{
    public class OrderSummary
    {

        public List<OrderItem>? OrderItems { get; set; }

        public decimal TotalQuantity { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal InclusiveTax { get; set; }

        public decimal ServiceCharge { get; set; }
    }
}
