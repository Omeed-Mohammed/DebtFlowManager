using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtFlowManager.Suppliers
{
    public partial class UserControlSuppliers : UserControl
    {
        public UserControlSuppliers()
        {
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSupplier frm = new frmAddSupplier();
            frm.ShowDialog();
        }

        
        
    }
}
