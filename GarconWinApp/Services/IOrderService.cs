using GarconWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Services
{
    public interface IOrderService
    {

        Task<OrderItem> AddItemAsync(MenuItem menuItemId);

        void CancelItem(int orderitemId);

        List<CustomerOrderDTO> ViewCurrentOrders(List<OrderItem> item);

        List<OrderSummary> ViewOrderSummary();

        List<OrderSummary> BillOut();

        List<MenuItem> GetMenuItemById(int Id);
    }
}
