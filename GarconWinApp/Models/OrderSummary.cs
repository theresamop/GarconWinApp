using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Models
{
    public class OrderSummary : IGarcon
    {

        public List<OrderItem>? OrderItems { get; set; }

        public decimal TotalQuantity { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal InclusiveTax { get; set; }

        public decimal ServiceCharge { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string DisplayMember{ get { return "Date Ordered: " + OrderDate.ToString("dd/MM/yyyy hh:mm") + " - Total Amount: " + TotalPrice.ToString("0.00") + " - No of Items: " + TotalQuantity; } }
    }
}
