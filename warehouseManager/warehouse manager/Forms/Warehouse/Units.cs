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

namespace warehouse_manager.Forms
{
    public partial class Units : Form
    {
        private readonly Model _model;

        public Units()
        {
            InitializeComponent();

            _model = new Model();

            _model.Units.Load();
            dgvUnits.DataSource = _model.Units.Local.ToBindingList();
            dgvUnits.Columns["Id"].Visible = false;

            dgvUnits.Columns[1].FillWeight = 100;
            dgvUnits.Columns[2].FillWeight = 30;

            dgvUnits.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUnits.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUnits.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void Units_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
