using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using warehouse_manager.Forms.ExchangeOrder;

namespace warehouse_manager.Forms
{
    public partial class ExchangeOrdersList : Form
    {
        // TODO: implement order Delete
        private readonly Model _model;

        public ExchangeOrdersList()
        {
            InitializeComponent();

            _model = new Model();

            _model.ExchangeOrders.Load();
            dgvOrders.DataSource = _model.ExchangeOrders.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddEditExchangeOrder();
            form.ShowDialog();

            _model.SupplyingOrders.Load();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = ((Models.ExchangeOrder)dgvOrders.SelectedRows[0].DataBoundItem).Id;
                var form = new AddEditExchangeOrder(orderId);
                form.Show();
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderId = ((Models.ExchangeOrder)dgvOrders.SelectedRows[0].DataBoundItem).Id;
            var form = new AddEditExchangeOrder(orderId);
            form.Show();
        }
    }
}
