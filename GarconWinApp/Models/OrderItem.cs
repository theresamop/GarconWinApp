using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Models
{
    public class OrderItem
    {

        private static int StartingId = 1;

        public int OrderItemId { get; private set; }

        public MenuItem Item { get; set; }
        public string ItemDisplayMember { get { return Item.Name + " - " + Item.ItemPrice + " - " + Status.ToString(); } }
        public string OrderItemSummaryDisplayMember { get { return Item.Name + " - " + Item.ItemPrice + " - " + Item.ItemTax; } }

        public OrderItemStatus Status { get; set; }

        public enum OrderItemStatus
        {
            NEWORDER,
            INPREPARATION,
            READYTOSERVE,
            SERVED,
            CANCELLED

        }

        public OrderItem(MenuItem item)
        {
            this.OrderItemId = GetId();
            this.Item = item;
            this.Status = OrderItemStatus.NEWORDER;
        }

        private static int GetId()
        {
            return StartingId++;
        }

    }
}
