using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using warehouse_manager.Forms;
using warehouse_manager.Forms.ExchangeOrder;
using warehouse_manager.Forms.PaymentOrder;
using warehouse_manager.Forms.Reports;

namespace warehouse_manager
{
    public partial class Home : Form
    {
        public Home()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Program.InputLanguage);
            InitializeComponent();

            btnChangeLanguage.Text = Program.InputLanguage == "en-US" ? "عربى" : "English";
            this.RightToLeft = Program.InputLanguage == "en-US" ? RightToLeft.No : RightToLeft.Yes;
            this.RightToLeftLayout = Program.InputLanguage == "ar-EG";
        }

        private void btnChangeLanguage_Click(object sender, EventArgs e)
        {
            Program.InputLanguage = Program.InputLanguage == "en-US" ? "ar-EG" : "en-US";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Program.InputLanguage);
            this.Controls.Clear();
            InitializeComponent();
            this.RightToLeft = Program.InputLanguage == "en-US" ? RightToLeft.No : RightToLeft.Yes;
            this.RightToLeftLayout = Program.InputLanguage == "ar-EG";
            btnChangeLanguage.Text = Program.InputLanguage == "en-US" ? "عربى" : "English";
        }

        private void tsbViewWarehouses_Click(object sender, EventArgs e)
        {
            var form = new Warehouses();
            form.Show();
        }

        private void tsbViewProducts_Click(object sender, EventArgs e)
        {
            var form = new Products();
            form.Show();
        }

        private void tsbViewUnits_Click(object sender, EventArgs e)
        {
            var form = new Units();
            form.Show();
        }

        private void tsbViewProviders_Click(object sender, EventArgs e)
        {
            var form = new PersonList(PersonType.Provider);
            form.Show();
        }

        private void tsbViewCustomers_Click(object sender, EventArgs e)
        {
            var form = new PersonList(PersonType.Customer);
            form.Show();
        }

        private void btnSupplyingOrders_Click(object sender, EventArgs e)
        {
            var form = new SupplyingOrdersList();
            form.Show();
        }

        private void btnNewSupplyingOrder_Click(object sender, EventArgs e)
        {
            var form = new AddEditSupplyingOrder();
            form.Show();
        }

        private void btnPaymentOrders_Click(object sender, EventArgs e)
        {
            var form = new PaymentOrdersList();
            form.Show();
        }

        private void btnNewPaymentOrder_Click(object sender, EventArgs e)
        {
            var form = new AddEditPaymentOrder();
            form.Show();
        }

        private void btnExchangeOrders_Click(object sender, EventArgs e)
        {
            var form = new ExchangeOrdersList();
            form.Show();
        }

        private void btnNewExchangeOrder_Click(object sender, EventArgs e)
        {
            var form = new AddEditExchangeOrder();
            form.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var form = new ReportsList();
            form.Show();
        }
    }
}
