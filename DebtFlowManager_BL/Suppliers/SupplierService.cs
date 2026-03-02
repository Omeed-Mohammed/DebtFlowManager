using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtFlowManager_DA.Suppliers;
using DTO_Layer.Suppliers;

namespace DebtFlowManager_BL.Suppliers
{
    public class SupplierService
    {
       
        public static List<SupplierDTO> GetAllSuppliers(bool? isActive = true)
        {
            return SupplierRepository.GetAllSuppliers(isActive);
        }

        public static SupplierDTO GetSupplierById(int supplierId)
        {
            SupplierDTO supplierDTO = SupplierRepository.GetSupplierById(supplierId);

            return supplierDTO;
        }

        public static int AddSupplier(CreateSupplierRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Phone))
                return -1;

            var supplierDTO = new SupplierDTO(
                0,
                request.FullName,
                request.Phone,
                request.Address,
                request.Note,
                true);

            return SupplierRepository.AddSupplier(supplierDTO);
        }


        public static bool UpdateSupplier(UpdateSupplierRequestDTO request)
        {
            if (request.SupplierID <= 0 ||
                string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Phone))
                return false;

            var existingSupplier = SupplierRepository.GetSupplierById(request.SupplierID);
            if (existingSupplier == null)
                return false;

            var supplierDTO = new SupplierDTO(
                request.SupplierID,
                request.FullName,
                request.Phone,
                request.Address,
                request.Note,
                existingSupplier.IsActive); // لا نسمح بتعديل IsActive هنا

            return SupplierRepository.UpdateSupplier(supplierDTO);
        }



        public static bool DeactivateSupplier(int supplierId)
        {
            if (supplierId <= 0)
                return false;

            return SupplierRepository.DeactivateSupplier(supplierId);

        }

        public static bool ReactivateSupplier(int supplierId)
        {
            if (supplierId <= 0)
                return false;

            return SupplierRepository.ReactivateSupplier(supplierId);
        }

    }
}
