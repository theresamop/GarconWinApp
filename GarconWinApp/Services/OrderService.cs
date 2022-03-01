using GarconWinApp.Models;

namespace GarconWinApp.Services
{
    public class OrderService : IOrderService
    {
        public async Task<OrderItem> AddItemAsync(MenuItem menuItem)
        {
            var newOrder = new OrderItem(menuItem);

            await Task.Delay(60000);

            return newOrder;
        }

        public void CancelItem(int orderitemId)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int orderitemId)
        {
            throw new NotImplementedException();
        }

        public List<CustomerOrderDTO> ViewCurrentOrders(List<OrderItem> item)
        {
            throw new NotImplementedException();
        }

        public List<OrderSummary> ViewOrderSummary()
        {
            throw new NotImplementedException();
        }


        public List<OrderSummary> BillOut()
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuItemById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}