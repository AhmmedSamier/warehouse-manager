using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using warehouse_manager.Models;

namespace warehouse_manager.Forms
{
    public partial class PersonList : Form
    {
        private PersonType _type;
        private Model _model;

        public PersonList(PersonType personType)
        {
            InitializeComponent();

            _type = personType;
            _model = new Model();

            if (_type == PersonType.Provider)
            {
                _model.Providers.Load();
                dgvPersons.DataSource = _model.Providers.Local.ToBindingList();
            }
            else
            {
                _model.Customers.Load();
                dgvPersons.DataSource = _model.Customers.Local.ToBindingList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new Person(_type);
            form.ShowDialog();

            if (_type == PersonType.Provider)
            {
                _model.Providers.Load();
            }
            else
            {
                _model.Customers.Load();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPersons.SelectedRows.Count > 0)
            {
                _model.Dispose();
                _model = new Model();

                if (_type == PersonType.Provider)
                {
                    var id = ((Provider)dgvPersons.SelectedRows[0].DataBoundItem).Id;

                    var form = new Person(id, _type);
                    form.ShowDialog();

                    _model.Dispose();
                    _model = new Model();
                    _model.Providers.Load();
                    dgvPersons.DataSource = null;
                    dgvPersons.DataSource = _model.Providers.Local.ToBindingList();
                }
                else
                {
                    var id = ((Customer)dgvPersons.SelectedRows[0].DataBoundItem).Id;

                    var form = new Person(id, _type);
                    form.ShowDialog();

                    _model.Dispose();
                    _model = new Model();
                    _model.Customers.Load();
                    dgvPersons.DataSource = null;
                    dgvPersons.DataSource = _model.Customers.Local.ToBindingList();
                }
            }
        }
    }
}
