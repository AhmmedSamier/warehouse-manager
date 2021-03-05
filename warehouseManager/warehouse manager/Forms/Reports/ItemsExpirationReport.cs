using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace warehouse_manager.Forms.Reports
{
    public partial class ItemsExpirationReport : Form
    {
        private readonly Model _model;

        public ItemsExpirationReport()
        {
            InitializeComponent();

            _model = new Model();
            lblHeader.Text = $"Items having expiration daty before: {DateTime.Today.ToString("yyyy-MM-dd")}";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var expirationDate = DateTime.Today;
            expirationDate = expirationDate.AddYears((int)nUpDownYears.Value);
            expirationDate = expirationDate.AddMonths((int)nUpDownMonths.Value);
            expirationDate = expirationDate.AddDays((int)nUpDownDays.Value);

            var items = _model.Items.Include("Product").Where(i => DbFunctions.AddDays(i.ProductionDate, i.Expiry).Value < expirationDate);
            var display = items.Select(i => new
            {
                productName = i.Product.Name,
                i.Warehouse,
                providerName = i.Provider.Name,
                i.AvailableQuantity,
                i.ProductionDate,
                ExpiryInDays = i.Expiry
            });

            dgvItems.DataSource = display.ToList();
        }

        private void nUpDown_ValueChanged(object sender, EventArgs e)
        {
            var expirationDate = DateTime.Today;
            expirationDate = expirationDate.AddYears((int)nUpDownYears.Value);
            expirationDate = expirationDate.AddMonths((int)nUpDownMonths.Value);
            expirationDate = expirationDate.AddDays((int)nUpDownDays.Value);

            lblHeader.Text = $"Items having expiration daty before: {expirationDate.ToString("yyyy-MM-dd")}";
        }
    }
}
