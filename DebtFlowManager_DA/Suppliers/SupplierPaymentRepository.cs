using DTO_Layer.Suppliers;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_DA.Suppliers
{
    public class SupplierPaymentRepository
    {
        public static string AddSupplierPayment(SupplierPaymentInvoiceDTO invoiceDTO , CreateSupplierPaymentRequestDTO paymentRequestDTO)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_SupplierPayment_Add", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@SupplierID", SqlDbType.Int).Value =  invoiceDTO.SupplierID;

                var amountParam = command.Parameters.Add("@Amount", SqlDbType.Decimal);
                amountParam.Precision = 18;
                amountParam.Scale = 2;
                amountParam.Value = invoiceDTO.InvoiceAmount;

                command.Parameters.Add("@InvoiceNote", SqlDbType.NVarChar, 250)
                 .Value = (object)invoiceDTO.InvoiceNote ?? DBNull.Value;

                command.Parameters.Add("@PaymentNote", SqlDbType.NVarChar, 250)
                 .Value = (object)paymentRequestDTO.PaymentNote ?? DBNull.Value;

                command.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 100)
                .Value = invoiceDTO.CreatedBy;

                command.Parameters.Add("@ReceiverName", SqlDbType.NVarChar, 150)
                .Value = invoiceDTO.ReceiverName;

                command.Parameters.Add("@SignaturePath", SqlDbType.NVarChar, 300)
                .Value = (object)invoiceDTO.SignaturePath ?? DBNull.Value;

                connection.Open();
                var receiptNo = command.ExecuteScalar();

                return receiptNo?.ToString();
            }
        }


        public static List<SupplierPaymentViewDTO> GetPaymentsBySupplierID(int supplierID)
        {
            var SupplierPaymentsList = new List<SupplierPaymentViewDTO>();
           

            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_SupplierPayment_GetBySupplierID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierID;

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        int PaymentIDIndex = reader.GetOrdinal("PaymentID");
                        int InvoiceIDIndex = reader.GetOrdinal("InvoiceID");

                        int receiptNoIndex = reader.GetOrdinal("ReceiptNo");

                        int InvoiceDateIndex = reader.GetOrdinal("InvoiceDate");

                        int TotalAmountIndex = reader.GetOrdinal("TotalAmount");
                        int InvoiceNoteIndex = reader.GetOrdinal("InvoiceNote");
                        int ReceiverNameIndex = reader.GetOrdinal("ReceiverName");
                        int SignaturePathIndex = reader.GetOrdinal("SignaturePath");

                        int CreatedByIndex = reader.GetOrdinal("CreatedBy");
                        int CreatedAtIndex = reader.GetOrdinal("CreatedAt");

                        int PaymentNoteIndex = reader.GetOrdinal("PaymentNote");

                        int UpdatedByIndex = reader.GetOrdinal("UpdatedBy");
                        int UpdatedAtIndex = reader.GetOrdinal("UpdatedAt");


                        while (reader.Read())
                        {
                            string invoiceNote = reader.IsDBNull(InvoiceNoteIndex)
                                ? null
                                : reader.GetString(InvoiceNoteIndex);

                            string paymentNote = reader.IsDBNull(PaymentNoteIndex)
                                ? null
                                : reader.GetString(PaymentNoteIndex);

                            string updatedBy = reader.IsDBNull(UpdatedByIndex)
                                ? null
                                : reader.GetString(UpdatedByIndex);

                            DateTime? updatedAt = reader.IsDBNull(UpdatedAtIndex)
                                ? (DateTime?)null
                                : reader.GetDateTime(UpdatedAtIndex);

                            string signaturePath = reader.IsDBNull(SignaturePathIndex)
                                ? null
                                : reader.GetString(SignaturePathIndex);



                            SupplierPaymentsList.Add(new SupplierPaymentViewDTO(
                                reader.GetInt32(PaymentIDIndex),
                                reader.GetInt32(InvoiceIDIndex),

                                reader.GetString(receiptNoIndex),
                                reader.GetDateTime(InvoiceDateIndex),

                                reader.GetDecimal(TotalAmountIndex),

                                invoiceNote,
                                reader.GetString(ReceiverNameIndex),
                                signaturePath,
                                reader.GetString(CreatedByIndex),

                                reader.GetDateTime(CreatedAtIndex),

                                paymentNote,
                                updatedBy,
                                updatedAt
                                ));

                        }

                    }

                    return SupplierPaymentsList;
                }
            }
        }


        public static bool UpdateSupplierPayments(SupplierPaymentDTO paymentDTO)
        {
            using (var connection = new SqlConnection(DataAccessSettings.ConnectionString))
            using (var command = new SqlCommand("SP_SupplierPayment_Update", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PaymentID", SqlDbType.Int)
                .Value = paymentDTO.PaymentID;

                command.Parameters.Add("@PaymentNote", SqlDbType.NVarChar , 250).Value = 
                    (object)paymentDTO.PaymentNote ?? DBNull.Value; 

                command.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar , 100).Value =
                   paymentDTO.UpdatedBy;

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
