using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GarconWinApp.Models.MenuItem;

namespace GarconWinApp.Models
{
    public class CustomerOrderDTO
    {
        private static int StartingId = 1;

        public int OrderId { get; set; }

        public OrderItem? Item { get; set; }

        public CustomerOrderDTO(OrderItem? orderItem)
        {
            this.OrderId = GetId();
            this.Item = orderItem;
        }

        private static int GetId()
        {
            return StartingId++;
        }

    }
}
