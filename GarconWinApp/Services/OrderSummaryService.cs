using GarconWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarconWinApp.Services
{
    public class OrderSummaryService: BaseServiceClass<OrderSummary>
    {
        List<OrderItem> _orderItems = new List<OrderItem>();
        List<OrderSummary> _orderSummaryItems = new List<OrderSummary>();
        public void SetOrderItems(List<OrderItem> orderItems)
        {
            _orderItems = orderItems;
        }


        public string CalculateOrderSummary()
        {
            StringBuilder sbText = new StringBuilder();
            decimal grandTotalPrice = 0;
            decimal grandTotalTax = 0;

            sbText.Append("Value Added Tax is at " + ApplicationSettings.InclusiveTax+ "%" + Environment.NewLine);
            sbText.Append("_____________________" + Environment.NewLine);
            foreach (var orderItem in _orderItems)
            {
                sbText.Append(orderItem.OrderItemSummaryDisplayMember + Environment.NewLine);
                grandTotalPrice += orderItem.Item.ItemPrice;
                grandTotalTax += orderItem.GetTax();
            }
            var svcCharge = (grandTotalPrice * ApplicationSettings.ServiceCharge) / 100;
            var grandTotalWTaxPrice = grandTotalPrice + grandTotalTax;
            sbText.Append("--------------------------" + Environment.NewLine);

            sbText.Append("Total Amount: " + grandTotalPrice.ToString(ApplicationSettings.CurrencyFormat) + Environment.NewLine);
            sbText.Append("Total VAT: " + grandTotalTax.ToString(ApplicationSettings.CurrencyFormat) + Environment.NewLine);
            sbText.Append(string.Format("Service Charge({0}%): {1} " , 
                ApplicationSettings.ServiceCharge, 
                svcCharge.ToString(ApplicationSettings.CurrencyFormat))
                + Environment.NewLine);
            sbText.Append("==========================" + Environment.NewLine);
            sbText.Append("Grand Total: " + (grandTotalWTaxPrice + svcCharge).ToString(ApplicationSettings.CurrencyFormat));

            OrderSummary orderSummary = new OrderSummary()
            {
                TotalPrice = grandTotalWTaxPrice,
                TotalQuantity = _orderItems.Count,
                TotalInclusiveTax = grandTotalTax,
                TotalServiceCharge = svcCharge,
                OrderItems = _orderItems,
            };
            AddItem(orderSummary);

            return sbText.ToString();
        }

        public override void AddItem(OrderSummary item)
        {
            _orderSummaryItems.Add(item);
        }

        
        public override OrderSummary? GetItem(int Id)
        {
            throw new NotImplementedException();
        }

        public override List<OrderSummary> GetItems()
        {
            return _orderSummaryItems;
        }

        public override void RemoveItem(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }

      
    }
}
