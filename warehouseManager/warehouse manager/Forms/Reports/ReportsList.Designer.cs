
namespace warehouse_manager.Forms.Reports
{
    partial class ReportsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsList));
            this.btnReportSingleWarehouse = new System.Windows.Forms.Button();
            this.btnReportSingleProduct = new System.Windows.Forms.Button();
            this.btnReportItemsMovement = new System.Windows.Forms.Button();
            this.btnReportProductsAges = new System.Windows.Forms.Button();
            this.btnReportExpiration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReportSingleWarehouse
            // 
            resources.ApplyResources(this.btnReportSingleWarehouse, "btnReportSingleWarehouse");
            this.btnReportSingleWarehouse.Name = "btnReportSingleWarehouse";
            this.btnReportSingleWarehouse.UseVisualStyleBackColor = true;
            // 
            // btnReportSingleProduct
            // 
            resources.ApplyResources(this.btnReportSingleProduct, "btnReportSingleProduct");
            this.btnReportSingleProduct.Name = "btnReportSingleProduct";
            this.btnReportSingleProduct.UseVisualStyleBackColor = true;
            // 
            // btnReportItemsMovement
            // 
            resources.ApplyResources(this.btnReportItemsMovement, "btnReportItemsMovement");
            this.btnReportItemsMovement.Name = "btnReportItemsMovement";
            this.btnReportItemsMovement.UseVisualStyleBackColor = true;
            // 
            // btnReportProductsAges
            // 
            resources.ApplyResources(this.btnReportProductsAges, "btnReportProductsAges");
            this.btnReportProductsAges.Name = "btnReportProductsAges";
            this.btnReportProductsAges.UseVisualStyleBackColor = true;
            // 
            // btnReportExpiration
            // 
            resources.ApplyResources(this.btnReportExpiration, "btnReportExpiration");
            this.btnReportExpiration.Name = "btnReportExpiration";
            this.btnReportExpiration.UseVisualStyleBackColor = true;
            this.btnReportExpiration.Click += new System.EventHandler(this.btnReportExpiration_Click);
            // 
            // ReportsList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReportExpiration);
            this.Controls.Add(this.btnReportProductsAges);
            this.Controls.Add(this.btnReportItemsMovement);
            this.Controls.Add(this.btnReportSingleProduct);
            this.Controls.Add(this.btnReportSingleWarehouse);
            this.Name = "ReportsList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReportSingleWarehouse;
        private System.Windows.Forms.Button btnReportSingleProduct;
        private System.Windows.Forms.Button btnReportItemsMovement;
        private System.Windows.Forms.Button btnReportProductsAges;
        private System.Windows.Forms.Button btnReportExpiration;
    }
}