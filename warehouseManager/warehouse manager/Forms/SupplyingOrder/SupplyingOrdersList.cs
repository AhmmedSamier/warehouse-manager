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
using warehouse_manager.Models;

namespace warehouse_manager.Forms
{
    public partial class SupplyingOrdersList : Form
    {
        // TODO: implement order Delete

        private readonly Model _model;

        public SupplyingOrdersList()
        {
            InitializeComponent();

            _model = new Model();

            _model.SupplyingOrders.Load();
            dgvOrders.DataSource = _model.SupplyingOrders.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddEditSupplyingOrder();
            form.ShowDialog();

            _model.SupplyingOrders.Load();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = ((SupplyingOrder)dgvOrders.SelectedRows[0].DataBoundItem).Id;
                var form = new AddEditSupplyingOrder(orderId);
                form.Show();
            }
        }
        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderId = ((SupplyingOrder)dgvOrders.SelectedRows[0].DataBoundItem).Id;
            var form = new AddEditSupplyingOrder(orderId);
            form.Show();
        }
    }
}
