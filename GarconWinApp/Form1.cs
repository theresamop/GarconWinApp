using GarconWinApp.Enums;
using GarconWinApp.Models;
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
        public Form1()
        {
            InitializeComponent();
            ToggleOrderSummary(true);
            PopulateMenuListBox();
            RecalculateTotal();
        }

        private void ToggleOrderSummary(bool isHide)
        {
           
            if (isHide)
            {
                lblOrderSummary.Hide();
                lblSummary.Hide();
            } else
            {
                lblOrderSummary.Show();
                lblSummary.Show();
            }
            
        }

        private void PopulateMenuListBox()
        {
            menuItems = new List<MenuItem>();
            menuItems = SeedData.PopulateMenu();
            ((ListBox)this.clbMenu).DataSource = menuItems;
            ((ListBox)this.clbMenu).DisplayMember = "DisplayMember";
            ((ListBox)this.clbMenu).ValueMember = "Id";
            //Default checked all chef's recommendation
            for (var i = 0; i <= clbMenu.Items.Count - 1; i++)
            {
                if (((MenuItem)clbMenu.Items[i]).IsChefRecommendation)
                {
                    clbMenu.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            isConfirmed = false;
            if(ValidateForm(true))
            {
                var myOrders = clbMenu.CheckedItems;
                foreach (var item in myOrders)
                {
                    OrderItems.Add(new OrderItem((MenuItem)item));
                }
                ToggleOrderSummary(true);
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
            lbOrder.DataSource = null;
            lbOrder.DataSource = OrderItems;
            lbOrder.DisplayMember = "DisplayMember";
            lbOrder.ValueMember = "Id";

        }

        void lbOrder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isConfirmed)
            {
                OrderItems = OrderItems.Where(c => c.Id.ToString() != ((ListBox)sender).SelectedValue.ToString()).ToList();
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
                    OrderItems.ForEach(c => c.Status = OrderItemStatus.INPREPARATION);
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
        private void ShowMessage(MessageType messageType)
        {
            string msg = string.Empty;
            switch (messageType)
            {
                case MessageType.Successful:
                    msg = "Evrything is served! Thank you for your patronage!";
                    break;
                case MessageType.NoItemChecked:
                    msg = "Please choose at least one item from the Menu.";
                    break;
                case MessageType.NoOrderAdded:
                    msg = "Please add at least one item to your order.";
                    break;
            }
            
            MessageBox.Show(msg);
        }

        private void StartPreparation()
        {
            foreach(var orderItem in OrderItems)
            {
                myTimer = new System.Windows.Forms.Timer();
                myTimer.Interval = orderItem.Item.PrepTimeInMinutes * 1000; //I just sacled it down to seconds for demo purposes not to wait a lot of time.
             
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
              
                ShowBillOutOption();
                ShowMessage(MessageType.Successful);
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

        private void ShowBillOutOption()
        {
            ToggleOrderSummary(false);

            
            decimal grandTotalPrice = 0;
            decimal grandTotalTax = 0;
            lblSummary.Text = string.Empty;
            StringBuilder sbText = new StringBuilder();
          
            foreach (var orderItem in OrderItems)
            {
                sbText.Append(orderItem.OrderItemSummaryDisplayMember + Environment.NewLine);
                grandTotalPrice += orderItem.Item.ItemPrice;
                grandTotalTax += orderItem.GetTax();
            }
            sbText.Append("--------------" + Environment.NewLine);

            sbText.Append("Total Amount: " + grandTotalPrice + Environment.NewLine);
            sbText.Append("Total Tax : " + grandTotalTax + Environment.NewLine);
            sbText.Append("Grand Total : " + (grandTotalPrice + grandTotalTax).ToString("0.00"));
            lblSummary.Text = sbText.ToString();
            
        }
    }
}