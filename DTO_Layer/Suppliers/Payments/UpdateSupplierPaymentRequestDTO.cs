using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.Suppliers.Payments
{
    public class UpdateSupplierPaymentRequestDTO
    {
        public int PaymentID { get; set; }
        public string PaymentNote { get; set; }
        public string UpdatedBy { get; set; }

        public UpdateSupplierPaymentRequestDTO(int paymentID, string paymentNote, string updatedBy)
        {
            PaymentID = paymentID;
            PaymentNote = paymentNote;
            UpdatedBy = updatedBy;
        }
    }
    
}
