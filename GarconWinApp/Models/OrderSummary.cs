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

        public decimal TotalInclusiveTax { get; set; }

        public decimal TotalServiceCharge { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string DisplayMember{ get { return String.Format("Date Ordered: {0} - Grand Total Amount: {1} - No of Items: {2}", 
            OrderDate.ToString("dd/MM/yyyy hh:mm"),
            (TotalPrice + TotalServiceCharge).ToString("0.00"),
            TotalQuantity); } }
    }
}
