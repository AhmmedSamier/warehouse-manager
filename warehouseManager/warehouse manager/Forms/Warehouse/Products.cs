using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using warehouse_manager.Models;

namespace warehouse_manager.Forms
{
    public partial class Products : Form
    {
        private readonly Model _model;

        public Products()
        {
            InitializeComponent();

            _model = new Model();

            _model.Products.Load();
            dgvProducts.DataSource = _model.Products.Local.ToBindingList();

            _model.Units.Load();
            clbUnits.DataSource = _model.Units.Local.ToBindingList();
            clbUnits.DisplayMember = "Name";
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            clbUnits.ItemCheck -= clbUnits_ItemCheck;
            if (dgvProducts.SelectedRows.Count > 0 && !dgvProducts.SelectedRows[0].IsNewRow)
            {
                var product = (Models.Product)dgvProducts.SelectedRows[0].DataBoundItem;
                if (product.Units != null)
                {
                    for (int i = 0; i < clbUnits.Items.Count; ++i)
                    {
                        clbUnits.SetItemChecked(i, product.Units.Contains(clbUnits.Items[i]));
                    }
                }
                else
                {
                    for (int i = 0; i < clbUnits.Items.Count; ++i)
                    {
                        clbUnits.SetItemChecked(i, false);
                    }
                }
            }
            else
            {
                for (int i = 0; i < clbUnits.Items.Count; ++i)
                {
                    clbUnits.SetItemChecked(i, false);
                }
            }

            clbUnits.ItemCheck += clbUnits_ItemCheck;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_model.ChangeTracker.HasChanges())
            {
                _model.SaveChanges();
                MessageBox.Show("Changes saved successful", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No changes made, already up to date !", "Up to date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Products_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_model.ChangeTracker.HasChanges())
            {
                var result = MessageBox.Show("Do you want to save changes", "unsaved changes",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _model.SaveChanges();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void clbUnits_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0 && !dgvProducts.SelectedRows[0].IsNewRow)
            {
                var product = (Models.Product)dgvProducts.SelectedRows[0].DataBoundItem;
                var unit = (Unit)clbUnits.Items[e.Index];

                if (e.NewValue == CheckState.Checked)
                {
                    if (product.Units == null)
                    {
                        product.Units = new List<Unit>() { unit };
                    }
                    else if (!product.Units.Contains(unit))
                    {
                        product.Units.Add(unit);
                    }
                }
                else
                {
                    if (product.Units != null && product.Units.Contains(unit))
                    {
                        product.Units.Remove(unit);
                    }
                }
            }
        }

        private void clbUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = (Unit) clbUnits.SelectedItem;
            dgvUnit.Rows.Clear();
            dgvUnit.Rows.Add(unit.Name, unit.Quantity);

            dgvUnit.ClearSelection();
        }
    }
}
