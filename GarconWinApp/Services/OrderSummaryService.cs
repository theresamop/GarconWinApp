﻿using GarconWinApp.Models;
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
            foreach (var orderItem in _orderItems)
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

            OrderSummary orderSummary = new OrderSummary()
            {
                TotalPrice = grandTotalPrice,
                TotalQuantity = _orderItems.Count,
                InclusiveTax = grandTotalTax,
                ServiceCharge = svcCharge,
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
