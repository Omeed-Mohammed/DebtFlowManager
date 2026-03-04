using DebtFlowManager_DA.Suppliers;
using DTO_Layer.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_BL.Suppliers
{
    public class SupplierInvoiceService
    {
        public static SupplierPaymentInvoiceDTO GetInvoiceByReceiptNo(string receiptNo)
        {
            if (string.IsNullOrEmpty(receiptNo))
                throw new ArgumentNullException(nameof(receiptNo));

            return SupplierInvoicesRepository.GetInvoiceByReceiptNo(receiptNo);
        }
    }
}
