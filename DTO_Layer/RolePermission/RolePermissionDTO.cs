using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.RolePermission
{
    public class RolePermissionDTO
    {
        public int RoleID { get; set; }
        public int PermissionID { get; set; }

        public RolePermissionDTO(int roleID, int permissionID)
        {
            RoleID = roleID;
            PermissionID = permissionID;
        }
    }
}
