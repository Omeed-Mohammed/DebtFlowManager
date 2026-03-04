using DebtFlowManager_DA.Suppliers;
using DTO_Layer.Suppliers;
using DTO_Layer.Suppliers.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_BL.Suppliers
{
    public class SupplierPaymentService
    {
        public static string AddSupplierPayment(CreateSupplierPaymentTransactionRequestDTO RequestDTO)
        {
            if (RequestDTO.SupplierID <= 0 ||
                RequestDTO.InvoiceAmount <= 0 ||
                string.IsNullOrWhiteSpace(RequestDTO.ReceiverName) ||
                string.IsNullOrWhiteSpace(RequestDTO.CreatedBy) )
                throw new ArgumentException("Invalid payment request.");


            return SupplierPaymentRepository.AddSupplierPayment(RequestDTO);
        }


        public static List<SupplierPaymentViewDTO> GetPaymentsBySupplierID(int supplierID)
        {
            if (supplierID <= 0)
                return new List<SupplierPaymentViewDTO>();

            return SupplierPaymentRepository.GetPaymentsBySupplierID(supplierID);
        }


        public static bool UpdateSupplierPayments(UpdateSupplierPaymentRequestDTO paymentDTO)
        {
            if (paymentDTO.PaymentID <= 0 ||
                string.IsNullOrWhiteSpace(paymentDTO.UpdatedBy))
                return false;

            return SupplierPaymentRepository.UpdateSupplierPayments(paymentDTO);
        }

    }
}
