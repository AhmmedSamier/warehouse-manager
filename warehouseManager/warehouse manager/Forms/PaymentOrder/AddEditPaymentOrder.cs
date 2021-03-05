using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using warehouse_manager.Models;

namespace warehouse_manager.Forms.PaymentOrder
{
    public partial class AddEditPaymentOrder : Form
    {
        // TODO: Add validation code before save
        // TODO: implement order Update

        private readonly Model _model;

        public AddEditPaymentOrder()
        {
            InitializeComponent();

            _model = new Model();

            Initialize();
            this.Text = "Add New Payment Order";
        }

        public AddEditPaymentOrder(int orderId) : this()
        {
            var order = _model.PaymentOrders.Find(orderId);

            if (order != null)
            {
                this.Text = $"Payment Order Number: {order.Number} Details";

                dgvProducts.Visible = false;
                dgvItems.Visible = false;
                btnAdd.Visible = false;
                btnRemove.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnUpdate.Enabled = false;

                txtNumber.ReadOnly = true;
                dtpDate.Enabled = false;
                cbWarehouses.Enabled = false;
                cbCustomers.Enabled = false;

                dgvSelectedItems.Location = new Point(20, 100);
                dgvSelectedItems.Width = this.Width - 40;
                dgvSelectedItems.Height = this.Height - 140;

                dgvSelectedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSelectedItems.RowHeadersVisible = false;

                txtNumber.Text = order.Number;
                dtpDate.Value = order.Date;
                cbWarehouses.SelectedItem = order.Warehouse;
                cbCustomers.SelectedItem = order.Customer;

                foreach (var orderItem in order.InvoiceItems)
                {
                    dgvSelectedItems.Rows.Add();
                    var row = dgvSelectedItems.Rows[dgvSelectedItems.Rows.Count - 1];

                    row.Cells[0].Value = orderItem.Item.Id;
                    row.Cells[1].Value = orderItem.Item.Product.Name;
                    row.Cells[2].Value = orderItem.Quantity;

                    ((DataGridViewComboBoxCell)row.Cells[3]).DataSource = orderItem.Item.Product.Units.ToList();
                    ((DataGridViewComboBoxCell)row.Cells[3]).DisplayMember = "Name";
                    ((DataGridViewComboBoxCell)row.Cells[3]).ValueMember = "Id";
                    ((DataGridViewComboBoxCell)row.Cells[3]).ValueType = typeof(int);
                    ((DataGridViewComboBoxCell)row.Cells[3]).Value = orderItem.Unit.Id;

                    row.Cells[4].Value = orderItem.Item.ProductionDate.ToString("yyyy-MM-dd");
                    row.Cells[5].Value = orderItem.Item.Expiry;
                    row.Cells[6].Value = orderItem.Item.Provider.Name;
                }

                dgvSelectedItems.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("invalid supplying order ID", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Initialize ComboBoxes items
        /// </summary>
        private void Initialize()
        {
            cbWarehouses.ValueMember = "Id";
            cbWarehouses.DisplayMember = "Name";
            cbWarehouses.DataSource = _model.Warehouses.ToList();

            cbCustomers.DisplayMember = "Name";
            cbCustomers.ValueMember = "Id";
            cbCustomers.DataSource = _model.Customers.ToList();

            dgvProducts.DataSource = _model.Products.ToList();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0 && !dgvProducts.SelectedRows[0].IsNewRow)
            {
                var product = (Models.Product)dgvProducts.SelectedRows[0].DataBoundItem;

                dgvItems.DataSource = product.Items.Where(i => i.AvailableQuantity > 0).ToList();
                dgvItems.Columns["SuppliedQuantity"].Visible = false;
                dgvItems.Columns["Unit"].Visible = false;
            }
        }

        /// <summary>
        /// Add item to Selected items of this order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0 && !dgvProducts.SelectedRows[0].IsNewRow)
            {
                bool exists = false;
                var item = (Models.Item)dgvItems.SelectedRows[0].DataBoundItem;

                foreach (DataGridViewRow dataGridViewRow in dgvSelectedItems.Rows)
                {
                    if ((int)dataGridViewRow.Cells[0].Value == item.Id)
                    {
                        exists = true;
                    }
                }

                if (!exists)
                {
                    dgvSelectedItems.Rows.Add();

                    var row = dgvSelectedItems.Rows[dgvSelectedItems.Rows.Count - 1];

                    row.Cells[0].Value = item.Id;
                    row.Cells[1].Value = item.Product.Name;
                    row.Cells[2].Value = 0;

                    ((DataGridViewComboBoxCell)row.Cells[3]).DataSource = item.Product.Units.ToList();
                    ((DataGridViewComboBoxCell)row.Cells[3]).DisplayMember = "Name";
                    ((DataGridViewComboBoxCell)row.Cells[3]).ValueMember = "Id";
                    ((DataGridViewComboBoxCell)row.Cells[3]).ValueType = typeof(int);

                    row.Cells[4].Value = item.ProductionDate.ToString("yyyy-MM-dd");
                    row.Cells[5].Value = item.Expiry;
                    row.Cells[6].Value = item.Provider.Name;
                }
                else
                {
                    MessageBox.Show("item is added before, add the required quantity to it instead", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var order = new Models.PaymentOrder()
            {
                Number = txtNumber.Text,
                Date = dtpDate.Value.Date,
                Warehouse = (Warehouse)cbWarehouses.SelectedItem,
                Customer = (Customer)cbCustomers.SelectedItem
            };

            order.InvoiceItems = new List<InvoiceItem>();

            foreach (DataGridViewRow row in dgvSelectedItems.Rows)
            {
                var item = _model.Items.Find((int)row.Cells[0].Value);

                int quantity = int.Parse(row.Cells[2].Value.ToString());

                int? unitId = (int?)((DataGridViewComboBoxCell)row.Cells[3]).Value;
                Unit unit = null;
                if (unitId != null)
                {
                    unit = _model.Units.Find(unitId.Value);
                    item.AvailableQuantity -= (quantity * unit.Quantity);
                }
                else
                {
                    item.AvailableQuantity -= quantity;
                }

                order.InvoiceItems.Add(new InvoiceItem()
                {
                    Item = item,
                    Quantity = quantity,
                    Unit = unit
                });
            }

            _model.PaymentOrders.Add(order);
            _model.SaveChanges();
            MessageBox.Show("Saved payment order", "Saved");
            this.Close();
        }

        /// <summary>
        /// Remove item from Selected items of this order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvSelectedItems.SelectedRows.Count > 0)
            {
                dgvSelectedItems.Rows.Remove(dgvSelectedItems.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("No selected rows, select full row to remove", "Empty");
            }
        }
    }
}
