using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace warehouse_manager.Forms.Reports
{
    public partial class ReportsList : Form
    {
        public ReportsList()
        {
            InitializeComponent();
        }

        private void btnReportExpiration_Click(object sender, EventArgs e)
        {
            var form = new ItemsExpirationReport();
            form.Show();
        }
    }
}
