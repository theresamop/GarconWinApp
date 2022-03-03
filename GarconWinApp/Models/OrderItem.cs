using GarconWinApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Models
{
    public class OrderItem : IGarcon
    {

        private static int StartingId = 1;
        private OrderItemStatus _status;
        private int _id;
        private MenuItem _item = new MenuItem();
        
        public string DisplayMember {  get { return Item.Name + " - " + GetItemPriceWTax(Item).ToString("0.00") + " - " + Status.ToString(); } }

        public string OrderItemSummaryDisplayMember { get { return String.Format("{0} - {1} (Net Price: {2} w/ tax: {3} at ({4}%)", 
            Item.Name, 
            Item.GetItemPriceWTax(Item.ItemPrice).ToString("0.00"), 
            Item.ItemPrice.ToString("0.00"), 
            GetTax(Item).ToString("0.00"),
            ApplicationSettings.InclusiveTax.ToString("0.00")); } }
        
        public int Id { get => _id; set => _id = value; }
        public OrderItemStatus Status { get => _status; set => _status = value; }
        public MenuItem Item { get => _item; set => _item = value; }

       

        public OrderItem(MenuItem menuitem)
        {
            this.Id = GetId();
            this.Item = menuitem;
            this.Status = OrderItemStatus.NEWORDER;
        }

        private static int GetId()
        {
            return StartingId++;
        }
        
        public decimal GetTax()
        {
            return (Item.ItemPrice * ApplicationSettings.InclusiveTax) / 100;
        }
        public decimal GetTax(MenuItem menuItem)
        {
            return (menuItem.ItemPrice * ApplicationSettings.InclusiveTax) / 100;
        }
        public decimal GetItemPriceWTax(MenuItem menuItem)
        {
            return (menuItem.ItemPrice + ((menuItem.ItemPrice * ApplicationSettings.InclusiveTax) / 100));
        }

    }
   
}
