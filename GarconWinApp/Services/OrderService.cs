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

       
    }
}