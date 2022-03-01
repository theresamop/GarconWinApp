namespace GarconWinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.clbMenu = new System.Windows.Forms.CheckedListBox();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.lbOrder = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.lblOrderSummary = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu (Selected items are Chef\'s Recommendations)";
            // 
            // clbMenu
            // 
            this.clbMenu.FormattingEnabled = true;
            this.clbMenu.Location = new System.Drawing.Point(23, 32);
            this.clbMenu.Name = "clbMenu";
            this.clbMenu.Size = new System.Drawing.Size(623, 290);
            this.clbMenu.TabIndex = 1;
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.Location = new System.Drawing.Point(456, 328);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(190, 29);
            this.btnAddToOrder.TabIndex = 2;
            this.btnAddToOrder.Text = "Add to my ORDER";
            this.btnAddToOrder.UseVisualStyleBackColor = true;
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);
            // 
            // lbOrder
            // 
            this.lbOrder.FormattingEnabled = true;
            this.lbOrder.ItemHeight = 20;
            this.lbOrder.Location = new System.Drawing.Point(25, 386);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(621, 104);
            this.lbOrder.TabIndex = 3;
            this.lbOrder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbOrder_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "My ORDER (double click an item to remove/cancel from order)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(522, 493);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 20);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "label4";
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmOrder.Location = new System.Drawing.Point(461, 523);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(185, 29);
            this.btnConfirmOrder.TabIndex = 7;
            this.btnConfirmOrder.Text = "Confirm ORDER";
            this.btnConfirmOrder.UseVisualStyleBackColor = true;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            // 
            // lblOrderSummary
            // 
            this.lblOrderSummary.AutoSize = true;
            this.lblOrderSummary.Location = new System.Drawing.Point(30, 555);
            this.lblOrderSummary.Name = "lblOrderSummary";
            this.lblOrderSummary.Size = new System.Drawing.Size(132, 20);
            this.lblOrderSummary.TabIndex = 9;
            this.lblOrderSummary.Text = "ORDER SUMMARY";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Location = new System.Drawing.Point(46, 596);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(50, 20);
            this.lblSummary.TabIndex = 10;
            this.lblSummary.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 797);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblOrderSummary);
            this.Controls.Add(this.btnConfirmOrder);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbOrder);
            this.Controls.Add(this.btnAddToOrder);
            this.Controls.Add(this.clbMenu);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private CheckedListBox clbMenu;
        private Button btnAddToOrder;
        private ListBox lbOrder;
        private Label label2;
        private Label label3;
        private Label lblTotal;
        private Button btnConfirmOrder;
        private Label lblOrderSummary;
        private Label lblSummary;
    }
}