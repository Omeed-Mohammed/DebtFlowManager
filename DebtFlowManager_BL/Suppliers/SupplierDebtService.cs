using DebtFlowManager_DA.Suppliers;
using DTO_Layer.Suppliers;
using DTO_Layer.Suppliers.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtFlowManager_BL
{
    public class SupplierDebtService
    {
        public static SupplierDebtDTO GetDebtById(int debtId)
        {
            if (debtId <= 0)
                return null;

            return SupplierDebtRepository.GetDebtById(debtId);
        }

        public static List<SupplierDebtDTO> GetDebtsBySupplierID(int supplierId)
        {
            if (supplierId <= 0)
                return new List<SupplierDebtDTO>();

            return SupplierDebtRepository.GetDebtsBySupplierID(supplierId);
        }


        public static int AddDebt(CreateSupplierDebtRequestDTO DebtRequest)
        {
            if (DebtRequest.SupplierID <= 0 ||
                DebtRequest.Amount <= 0 ||
                string.IsNullOrWhiteSpace(DebtRequest.CreatedBy))
                return -1;

            var supplierDebtDTO = new SupplierDebtDTO(
             0,
            DebtRequest.SupplierID,
            DebtRequest.Amount,
            DebtRequest.Date,
            DebtRequest.Note,
            DebtRequest.CreatedBy,
            null,
            null,
            null);

            return SupplierDebtRepository.AddDebt(supplierDebtDTO);
        }


        public static bool UpdateDebt(UpdateSupplierDebtRequestDTO DebtRequest)
        {
            if (DebtRequest.DebtID <= 0 ||
                DebtRequest.Amount <= 0 ||
                string.IsNullOrWhiteSpace(DebtRequest.UpdatedBy))
                return false;

            var existing = SupplierDebtRepository.GetDebtById(DebtRequest.DebtID);
            if (existing == null)
                return false;

            var supplierDebtDTO = new SupplierDebtDTO(
                DebtRequest.DebtID,
                existing.SupplierID,
                DebtRequest.Amount,
                DebtRequest.Date,
                DebtRequest.Note,
                existing.CreatedBy,
                existing.CreatedAt,
                DebtRequest.UpdatedBy,
                null);

            return SupplierDebtRepository.UpdateDebt(supplierDebtDTO);
        }

    }
}
