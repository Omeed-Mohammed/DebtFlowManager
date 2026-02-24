using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.Suppliers
{
    public class SupplierDTO
    {
        public int SupplierID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }

        public SupplierDTO(
            int supplierID,
            string fullName,
            string phone,
            string address,
            string note,
            bool isActive)
        {
            SupplierID = supplierID;
            FullName = fullName;
            Phone = phone;
            Address = address;
            Note = note;
            IsActive = isActive;
        }
    }
}
