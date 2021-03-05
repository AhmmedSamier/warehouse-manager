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

namespace warehouse_manager.Forms
{
    public enum PersonType { Provider, Customer }

    public partial class Person : Form
    {
        private PersonType _type;
        private Provider _provider;
        private Customer _customer;

        private readonly Model _model;

        public Person(PersonType personType)
        {
            InitializeComponent();

            _type = personType;
            _model = new Model();

            if (personType == PersonType.Provider)
            {
                _provider = new Provider();
                _model.Providers.Add(_provider);
            }
            else
            {
                _customer = new Customer();
                _model.Customers.Add(_customer);
            }

            BindToEntity(personType);
        }

        public Person(int id, PersonType personType)
        {
            InitializeComponent();

            _model = new Model();

            if (personType == PersonType.Provider)
            {
                _provider = _model.Providers.Find(id);
                _type = PersonType.Provider;
            }
            else
            {
                _customer = _model.Customers.Find(id);
                _type = PersonType.Customer;
            }

            BindToEntity(personType);
        }

        private void BindToEntity(PersonType personType)
        {
            if (personType == PersonType.Provider)
            {
                txtName.DataBindings.Add("Text", _provider, "Name");
                txtPhone.DataBindings.Add("Text", _provider, "Phone");
                txtMobile.DataBindings.Add("Text", _provider, "Mobile");
                txtFax.DataBindings.Add("Text", _provider, "Fax");
                txtwebsite.DataBindings.Add("Text", _provider, "Website");
                txtEmail.DataBindings.Add("Text", _provider, "Email");
            }
            else
            {
                txtName.DataBindings.Add("Text", _customer, "Name");
                txtPhone.DataBindings.Add("Text", _customer, "Phone");
                txtMobile.DataBindings.Add("Text", _customer, "Mobile");
                txtFax.DataBindings.Add("Text", _customer, "Fax");
                txtwebsite.DataBindings.Add("Text", _customer, "Website");
                txtEmail.DataBindings.Add("Text", _customer, "Email");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _model.SaveChanges();
            MessageBox.Show("Saved successfuly", "Saved");

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Person_FormClosing(object sender, FormClosingEventArgs e)
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
