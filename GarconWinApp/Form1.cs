using GarconWinApp.Models;

namespace GarconWinApp
{
    public partial class Form1 : Form
    {
        List<MenuItem> menuItems = new List<MenuItem>();
        List<OrderItem> OrderItems = new List<OrderItem>();
        decimal TotalOrderPrice = 0;
        public Form1()
        {
            InitializeComponent();
            PopulateMenuListBox();
        }

        private void PopulateMenuListBox()
        {
            menuItems = new List<MenuItem>();
            menuItems = SeedData.PopulateMenu();
            ((ListBox)this.clbMenu).DataSource = menuItems;
            ((ListBox)this.clbMenu).DisplayMember = "DisplayMember";
            ((ListBox)this.clbMenu).ValueMember = "MenuItemId";


        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            var myOrders = clbMenu.CheckedItems;
           
            var menuItemIds = new List<int>();
            foreach (var item in myOrders)
            {
                OrderItems.Add(new OrderItem((MenuItem)item));
                TotalOrderPrice += ((MenuItem)item).ItemPrice;
            }
            for (int i = 0; i < clbMenu.Items.Count; i++)
            {
                clbMenu.SetItemChecked(i, false);
            }
            lbOrder.DataSource = null;
            lbOrder.DataSource = OrderItems;
            lbOrder.DisplayMember = "ItemDisplayMember";
            lbOrder.ValueMember = "OrderItemId";
            lblTotal.Text = TotalOrderPrice.ToString("0.00");
        }

       
        void lbOrder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //int index = this.lbOrder.IndexFromPoint(e.Location);
            //menuOrderItems = menuOrderItems.Where(c => c.MenuItemId.ToString() != ((ListBox)sender).SelectedValue.ToString()).ToList();
            //lbOrder.DataSource = menuOrderItems;

            lbOrder.DataSource = OrderItems;
        }
    }
}