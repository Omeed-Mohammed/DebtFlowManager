using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.RolePermission
{
    public class PermissionSummaryDTO
    {
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }

        public PermissionSummaryDTO(int permissionID, string permissionName, string description)
        {
            PermissionID = permissionID;
            PermissionName = permissionName;
            Description = description;
        }
    }
}
