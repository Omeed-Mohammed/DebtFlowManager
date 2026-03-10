using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.RolePermission
{
    public class RoleSummaryDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public RoleSummaryDTO(int roleID, string roleName, string description)
        {
            RoleID = roleID;
            RoleName = roleName;
            Description = description;
        }
    }
}
