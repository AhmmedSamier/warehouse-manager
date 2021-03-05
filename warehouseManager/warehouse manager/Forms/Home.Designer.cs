
namespace warehouse_manager
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbViewWarehouses = new System.Windows.Forms.ToolStripButton();
            this.tsbViewProducts = new System.Windows.Forms.ToolStripButton();
            this.tsbViewUnits = new System.Windows.Forms.ToolStripButton();
            this.tsbViewProviders = new System.Windows.Forms.ToolStripButton();
            this.tsbViewCustomers = new System.Windows.Forms.ToolStripButton();
            this.btnSupplyingOrders = new System.Windows.Forms.Button();
            this.btnPaymentOrders = new System.Windows.Forms.Button();
            this.btnNewPaymentOrder = new System.Windows.Forms.Button();
            this.btnNewSupplyingOrder = new System.Windows.Forms.Button();
            this.btnChangeLanguage = new System.Windows.Forms.Button();
            this.btnExchangeOrders = new System.Windows.Forms.Button();
            this.btnNewExchangeOrder = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbViewWarehouses,
            this.tsbViewProducts,
            this.tsbViewUnits,
            this.tsbViewProviders,
            this.tsbViewCustomers});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsbViewWarehouses
            // 
            resources.ApplyResources(this.tsbViewWarehouses, "tsbViewWarehouses");
            this.tsbViewWarehouses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbViewWarehouses.Name = "tsbViewWarehouses";
            this.tsbViewWarehouses.Click += new System.EventHandler(this.tsbViewWarehouses_Click);
            // 
            // tsbViewProducts
            // 
            resources.ApplyResources(this.tsbViewProducts, "tsbViewProducts");
            this.tsbViewProducts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbViewProducts.Name = "tsbViewProducts";
            this.tsbViewProducts.Click += new System.EventHandler(this.tsbViewProducts_Click);
            // 
            // tsbViewUnits
            // 
            resources.ApplyResources(this.tsbViewUnits, "tsbViewUnits");
            this.tsbViewUnits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbViewUnits.Name = "tsbViewUnits";
            this.tsbViewUnits.Click += new System.EventHandler(this.tsbViewUnits_Click);
            // 
            // tsbViewProviders
            // 
            resources.ApplyResources(this.tsbViewProviders, "tsbViewProviders");
            this.tsbViewProviders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbViewProviders.Name = "tsbViewProviders";
            this.tsbViewProviders.Click += new System.EventHandler(this.tsbViewProviders_Click);
            // 
            // tsbViewCustomers
            // 
            resources.ApplyResources(this.tsbViewCustomers, "tsbViewCustomers");
            this.tsbViewCustomers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbViewCustomers.Name = "tsbViewCustomers";
            this.tsbViewCustomers.Click += new System.EventHandler(this.tsbViewCustomers_Click);
            // 
            // btnSupplyingOrders
            // 
            resources.ApplyResources(this.btnSupplyingOrders, "btnSupplyingOrders");
            this.btnSupplyingOrders.Name = "btnSupplyingOrders";
            this.btnSupplyingOrders.UseVisualStyleBackColor = true;
            this.btnSupplyingOrders.Click += new System.EventHandler(this.btnSupplyingOrders_Click);
            // 
            // btnPaymentOrders
            // 
            resources.ApplyResources(this.btnPaymentOrders, "btnPaymentOrders");
            this.btnPaymentOrders.Name = "btnPaymentOrders";
            this.btnPaymentOrders.UseVisualStyleBackColor = true;
            this.btnPaymentOrders.Click += new System.EventHandler(this.btnPaymentOrders_Click);
            // 
            // btnNewPaymentOrder
            // 
            resources.ApplyResources(this.btnNewPaymentOrder, "btnNewPaymentOrder");
            this.btnNewPaymentOrder.Name = "btnNewPaymentOrder";
            this.btnNewPaymentOrder.UseVisualStyleBackColor = true;
            this.btnNewPaymentOrder.Click += new System.EventHandler(this.btnNewPaymentOrder_Click);
            // 
            // btnNewSupplyingOrder
            // 
            resources.ApplyResources(this.btnNewSupplyingOrder, "btnNewSupplyingOrder");
            this.btnNewSupplyingOrder.Name = "btnNewSupplyingOrder";
            this.btnNewSupplyingOrder.UseVisualStyleBackColor = true;
            this.btnNewSupplyingOrder.Click += new System.EventHandler(this.btnNewSupplyingOrder_Click);
            // 
            // btnChangeLanguage
            // 
            resources.ApplyResources(this.btnChangeLanguage, "btnChangeLanguage");
            this.btnChangeLanguage.Name = "btnChangeLanguage";
            this.btnChangeLanguage.UseVisualStyleBackColor = true;
            this.btnChangeLanguage.Click += new System.EventHandler(this.btnChangeLanguage_Click);
            // 
            // btnExchangeOrders
            // 
            resources.ApplyResources(this.btnExchangeOrders, "btnExchangeOrders");
            this.btnExchangeOrders.Name = "btnExchangeOrders";
            this.btnExchangeOrders.UseVisualStyleBackColor = true;
            this.btnExchangeOrders.Click += new System.EventHandler(this.btnExchangeOrders_Click);
            // 
            // btnNewExchangeOrder
            // 
            resources.ApplyResources(this.btnNewExchangeOrder, "btnNewExchangeOrder");
            this.btnNewExchangeOrder.Name = "btnNewExchangeOrder";
            this.btnNewExchangeOrder.UseVisualStyleBackColor = true;
            this.btnNewExchangeOrder.Click += new System.EventHandler(this.btnNewExchangeOrder_Click);
            // 
            // btnReports
            // 
            resources.ApplyResources(this.btnReports, "btnReports");
            this.btnReports.Name = "btnReports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // Home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnNewExchangeOrder);
            this.Controls.Add(this.btnChangeLanguage);
            this.Controls.Add(this.btnExchangeOrders);
            this.Controls.Add(this.btnNewPaymentOrder);
            this.Controls.Add(this.btnNewSupplyingOrder);
            this.Controls.Add(this.btnPaymentOrders);
            this.Controls.Add(this.btnSupplyingOrders);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Home";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbViewWarehouses;
        private System.Windows.Forms.ToolStripButton tsbViewProducts;
        private System.Windows.Forms.ToolStripButton tsbViewUnits;
        private System.Windows.Forms.ToolStripButton tsbViewProviders;
        private System.Windows.Forms.ToolStripButton tsbViewCustomers;
        private System.Windows.Forms.Button btnSupplyingOrders;
        private System.Windows.Forms.Button btnPaymentOrders;
        private System.Windows.Forms.Button btnNewPaymentOrder;
        private System.Windows.Forms.Button btnNewSupplyingOrder;
        private System.Windows.Forms.Button btnChangeLanguage;
        private System.Windows.Forms.Button btnExchangeOrders;
        private System.Windows.Forms.Button btnNewExchangeOrder;
        private System.Windows.Forms.Button btnReports;
    }
}

