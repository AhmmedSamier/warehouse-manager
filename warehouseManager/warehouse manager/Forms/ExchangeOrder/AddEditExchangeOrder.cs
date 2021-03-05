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

namespace warehouse_manager.Forms.ExchangeOrder
{
    public partial class AddEditExchangeOrder : Form
    {
        // TODO: Add validation code before save
        // TODO: implement order Update

        private readonly Model _model;

        public AddEditExchangeOrder()
        {
            InitializeComponent();

            _model = new Model();

            Initialize();
            this.Text = "Add New Exchange Order";
        }

        public AddEditExchangeOrder(int orderId) : this()
        {
            var order = _model.ExchangeOrders.Find(orderId);

            if (order != null)
            {
                this.Text = $"Exchange Order with ID: {order.Id}";

                dgvProducts.Visible = false;
                dgvItems.Visible = false;
                btnAdd.Visible = false;
                btnRemove.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnUpdate.Enabled = false;

                dtpDate.Enabled = false;
                cbSourceWarehouses.Enabled = false;
                cbDestinationWarehouses.Enabled = false;

                dgvSelectedItems.Location = new Point(20, 80);
                dgvSelectedItems.Width = this.Width - 40;
                dgvSelectedItems.Height = this.Height - 140;

                dgvSelectedItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSelectedItems.RowHeadersVisible = false;

                dtpDate.Value = order.Date;
                cbSourceWarehouses.SelectedItem = order.SourceWarehouse;
                cbDestinationWarehouses.SelectedItem = order.DestinationWarehouse;

                foreach (var orderItem in order.Items)
                {
                    dgvSelectedItems.Rows.Add();
                    var row = dgvSelectedItems.Rows[dgvSelectedItems.Rows.Count - 1];

                    row.Cells[0].Value = orderItem.Id;
                    row.Cells[1].Value = orderItem.Product.Name;
                    row.Cells[2].Value = orderItem.SuppliedQuantity;

                    ((DataGridViewComboBoxCell)row.Cells[3]).DataSource = orderItem.Product.Units.ToList();
                    ((DataGridViewComboBoxCell)row.Cells[3]).DisplayMember = "Name";
                    ((DataGridViewComboBoxCell)row.Cells[3]).ValueMember = "Id";
                    ((DataGridViewComboBoxCell)row.Cells[3]).ValueType = typeof(int);
                    ((DataGridViewComboBoxCell)row.Cells[3]).Value = orderItem.Unit.Id;

                    row.Cells[4].Value = orderItem.ProductionDate.ToString("yyyy-MM-dd");
                    row.Cells[5].Value = orderItem.Expiry;
                    row.Cells[6].Value = orderItem.Provider.Name;
                }

                dgvSelectedItems.ReadOnly = true;
            }
        }

        /// <summary>
        /// Initialize ComboBoxes items
        /// </summary>
        private void Initialize()
        {
            cbSourceWarehouses.ValueMember = "Id";
            cbSourceWarehouses.DisplayMember = "Name";
            cbSourceWarehouses.DataSource = _model.Warehouses.ToList();

            cbDestinationWarehouses.ValueMember = "Id";
            cbDestinationWarehouses.DisplayMember = "Name";
            cbDestinationWarehouses.DataSource = _model.Warehouses.ToList();

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0 && !dgvProducts.SelectedRows[0].IsNewRow)
            {
                var item = (Models.Item)dgvItems.SelectedRows[0].DataBoundItem;

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var order = new Models.ExchangeOrder()
            {
                Date = dtpDate.Value.Date,
                SourceWarehouse = (Warehouse)cbSourceWarehouses.SelectedItem,
                DestinationWarehouse = (Warehouse)cbDestinationWarehouses.SelectedItem,
            };

            order.Items = new List<Item>();

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
                
                order.Items.Add(new Item()
                {
                    Warehouse = (Warehouse)cbDestinationWarehouses.SelectedItem,
                    Provider = item.Provider,
                    Product = item.Product,
                    SuppliedQuantity = quantity,
                    AvailableQuantity = quantity,
                    ProductionDate = item.ProductionDate,
                    Expiry = item.Expiry,
                    Unit = unit
                });
            }

            _model.ExchangeOrders.Add(order);
            _model.SaveChanges();
            MessageBox.Show("Saved Exchange Order", "Saved");
            this.Close();
        }
    }
}
