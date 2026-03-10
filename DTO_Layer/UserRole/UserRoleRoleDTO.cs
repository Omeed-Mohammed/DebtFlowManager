using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.UserRole
{
    public class UserRoleRoleDTO
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public UserRoleRoleDTO(int userID, int roleID, string roleName)
        {
            UserID = userID;
            RoleID = roleID;
            RoleName = roleName;
        }
    }
}
