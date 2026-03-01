using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.Suppliers
{
    public class CreateSupplierInvoiceRequestDTO
    {
        public int SupplierID { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string Note { get; set; }
        public string ReceiverName { get; set; }

        public CreateSupplierInvoiceRequestDTO (int supplierID, decimal invoiceAmount, string note, string receiverName)
        {
            SupplierID = supplierID;
            InvoiceAmount = invoiceAmount;
            Note = note;
            ReceiverName = receiverName;
        }
    }
}
