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
    public partial class frmAddSupplier : Form
    {
        public frmAddSupplier()
        {
            InitializeComponent();
            toolTip1.SetToolTip(btnSaveSupplier, "Save and Close");
        }

        private void txtSupplierName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                e.Cancel = true;
                txtSupplierName.Focus();
                errorProvider1.SetError(txtSupplierName,"Please enter the Supplier Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSupplierName, null);
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if(ValidateChildren())
            {
                MessageBox.Show("This Option Will be Soon");
            }
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                MessageBox.Show("This Option Will be Soon");
            }
        }

        private void txtSupplierPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                e.Cancel = true;
                txtSupplierName.Focus();
                errorProvider1.SetError(txtSupplierName, "Please enter the Supplier Phone Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSupplierName, null);
            }
        }

        private void txtSupplierAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                e.Cancel = true;
                txtSupplierName.Focus();
                errorProvider1.SetError(txtSupplierName, "Please enter the Supplier Address");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSupplierName, null);
            }
        }

        private void txtSupplierPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(! char.IsControl(e.KeyChar) && ! char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if(char.IsDigit(e.KeyChar))
            {
                if((sender as TextBox).Text.Count(Char.IsDigit) >= 10)
                    e.Handled = true;
            }
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            txtSupplierName.Focus();
        }
    }
}
