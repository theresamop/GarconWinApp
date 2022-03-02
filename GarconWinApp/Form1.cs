using GarconWinApp.Enums;
using GarconWinApp.Models;
using GarconWinApp.Services;
using System.Text;

namespace GarconWinApp
{
    public partial class Form1 : Form
    {
        private List<MenuItem> menuItems = new List<MenuItem>();
        private List<OrderItem> OrderItems = new List<OrderItem>();
        private System.Windows.Forms.Timer? myTimer;
        private decimal TotalOrderPrice = 0;
        private bool isConfirmed;
        private MenuService menuService = new MenuService();
        private OrderService orderService = new OrderService();
        OrderSummaryService orderSummaryService = new OrderSummaryService();
        public Form1()
        {
            InitializeComponent();
            PopulateMenuListBox();
            RecalculateTotal();
        }

        private void ToggleOrderSummary(string orderSummary)
        {
            ShowMessage(MessageType.Done, orderSummary);
        }

        private void PopulateMenuListBox()
        {

            menuItems = menuService.GetItems();
            ((ListBox)this.clbMenu).DataSource = menuItems;
            ((ListBox)this.clbMenu).DisplayMember = "DisplayMember";
            ((ListBox)this.clbMenu).ValueMember = "Id";
            ////Default checked all chef's recommendation
            //for (var i = 0; i <= clbMenu.Items.Count - 1; i++)
            //{
            //    if (((MenuItem)clbMenu.Items[i]).IsChefRecommendation)
            //    {
            //        clbMenu.SetItemCheckState(i, CheckState.Checked);
            //    }
            //}
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            isConfirmed = false;
            if(ValidateForm(true))
            {
                var myOrders = clbMenu.CheckedItems;
                foreach (var item in myOrders)
                {
                    orderService.AddItem(new OrderItem((MenuItem)item));
                    OrderItems = orderService.GetItems();
                }

                UpdateOrderItems();
                UncheckedAllSelectedMenuItem();
                RecalculateTotal();
            } else
            {
                ShowMessage(MessageType.NoItemChecked);
            }
            
        }

        private void UpdateOrderItems()
        {
            OrderItems = orderService.GetItems();
            lbOrder.DataSource = null;
            lbOrder.DataSource = OrderItems;
            lbOrder.DisplayMember = "DisplayMember";
            lbOrder.ValueMember = "Id";

        }

        void lbOrder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isConfirmed)
            {
                orderService.RemoveItem((int)((ListBox)sender).SelectedValue);
                UpdateOrderItems();
                RecalculateTotal();
                lbOrder.DataSource = OrderItems;
            }
        }

        private void RecalculateTotal()
        {
            TotalOrderPrice = 0;
            foreach (var orderItem in OrderItems)
            {
                TotalOrderPrice += ((OrderItem)orderItem).Item.ItemPrice;
            }
            lblTotal.Text = TotalOrderPrice.ToString("0.00");
        }
        private void UncheckedAllSelectedMenuItem()
        {
            for (int i = 0; i < clbMenu.Items.Count; i++)
            {
                clbMenu.SetItemChecked(i, false);
            }
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                var confirmResult = MessageBox.Show("Once you click Confirm you can't cancel an order, continue?", "Confirm Order",
                                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    isConfirmed = true;
                    orderService.ChangeStatus(OrderItemStatus.INPREPARATION);
                    UpdateOrderItems();
                    btnConfirmOrder.Enabled = false;
                    StartPreparation();
                }
            } else
            {
                ShowMessage(MessageType.NoOrderAdded);
            }

        }

        private bool ValidateForm(bool isMenuChecking=false)
        {
             
            return isMenuChecking ? clbMenu.CheckedItems.Count>0 :  OrderItems.Any();
            
        }
        private void ShowMessage(MessageType messageType, string message="")
        {
            string msg = message;
            string header = string.Empty;
            switch (messageType)
            {
                case MessageType.Successful:
                    header = "Success";
                    msg = "Evrything is served! Thank you for your patronage!";
                    break;
                case MessageType.NoItemChecked:
                    header = "Error";
                    msg = "Please choose at least one item from the Menu.";
                    break;
                case MessageType.NoOrderAdded:
                    header = "Error";
                    msg = "Please add at least one item to your order.";
                    break;
                case MessageType.Done:
                    header = "All Served! Thank you!";
                    break;
            }
            
            MessageBox.Show(msg, header);
        }

        private void StartPreparation()
        {
            foreach(var orderItem in OrderItems)
            {
                myTimer = new System.Windows.Forms.Timer();
                myTimer.Interval = orderItem.Item.PrepTimeInMinutes * 1000; //I just scaled it down to seconds for demo purposes not to wait a lot of time. there supposed to be client portal where they notify if ready na but since wala ganito muna
             
                myTimer.Tick += (object? s, EventArgs a) => MyTimer_Tick(s,a, orderItem, OrderItemStatus.READYTOSERVE);
                myTimer.Start();

            }
        }

        private void MyTimer_Tick(object? sender, EventArgs e, OrderItem orderItem, OrderItemStatus orderItemStatus)
        {
            if(sender!=null)
            {
               
                orderItem.Status = orderItemStatus;
                ((System.Windows.Forms.Timer)sender).Stop();
            }

            UpdateOrderItems();

            //for simulation purposes to complete / served
            if (orderItemStatus != OrderItemStatus.SERVED)
            {
                myTimer = new System.Windows.Forms.Timer();
                myTimer.Interval = orderItem.Item.PrepTimeInMinutes * 500;
                myTimer.Tick += (object? s, EventArgs a) => MyTimer_Tick(s, a, orderItem, OrderItemStatus.SERVED);
                myTimer.Start();
              
            } else
            {
                CheckAllOrdersForSummary();
            }
            
        }

        private void CheckAllOrdersForSummary()
        {
            var hasUnservedOrders = OrderItems.Any(c => c.Status != OrderItemStatus.SERVED);
            if (!hasUnservedOrders)
            {
                ProcessBillOutOption();
                ResetAll();
            }
        }

        private void ResetAll()
        {
            UncheckedAllSelectedMenuItem();
            OrderItems.Clear();
            lblTotal.Text = "0.00";
            btnConfirmOrder.Enabled = true;
            UpdateOrderItems();
        }

        private void ProcessBillOutOption()
        {           
            orderSummaryService.SetOrderItems(OrderItems);
            var orderSummary =  orderSummaryService.CalculateOrderSummary();
            ToggleOrderSummary(orderSummary);
            UpdateOrderSummary();
          
        }

        private void UpdateOrderSummary()
        {
            lbOrderHistory.DataSource = null;
            lbOrderHistory.DisplayMember = "DisplayMember";
            lbOrderHistory.ValueMember = "Id";
            lbOrderHistory.DataSource = orderSummaryService.GetItems();
        }
    }
}