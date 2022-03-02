using GarconWinApp.Enums;
using GarconWinApp.Models;
using System.Text;

namespace GarconWinApp.Services
{
    public class OrderService : BaseServiceClass<OrderItem>
    {
        List<OrderItem> items = new List<OrderItem>();
      
        public override void AddItem(OrderItem orderItem)
        {
            items.Add(orderItem);
        }
       
        public override OrderItem? GetItem(int Id)
        {
           return items.Where(c=> c.Id == Id).FirstOrDefault();
        }

        public override List<OrderItem> GetItems()
        {
            return items;
        }

        public override void RemoveItem(int Id)
        {
            items = items.Where(c => c.Id != Id).ToList();
        }

        public void ChangeStatus(OrderItemStatus orderItemStatus)
        {
            items.ForEach(c => c.Status = orderItemStatus);
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
        public string CalculateOrderSummary()
        {
            StringBuilder sbText = new StringBuilder();
            decimal grandTotalPrice = 0;
            decimal grandTotalTax = 0;
            foreach (var orderItem in items)
            {
                sbText.Append(orderItem.OrderItemSummaryDisplayMember + Environment.NewLine);
                grandTotalPrice += orderItem.Item.ItemPrice;
                grandTotalTax += orderItem.GetTax();
            }
            var svcCharge = (grandTotalPrice * 5) / 100;
            sbText.Append("--------------------------" + Environment.NewLine);

            sbText.Append("Total Amount: " + grandTotalPrice + Environment.NewLine);
            sbText.Append("Service Charge (5%): " + svcCharge.ToString("0.00") + Environment.NewLine);
            sbText.Append("Total Tax: " + grandTotalTax + Environment.NewLine);
            sbText.Append("Grand Total: " + (grandTotalPrice + grandTotalTax + svcCharge).ToString("0.00"));

            return sbText.ToString();
        }
    }
}