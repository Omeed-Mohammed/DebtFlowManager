using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.UserRole
{
    /// <summary>
    /// DTO used to represent users assigned to a specific role.
    /// 
    /// This object is returned when retrieving all users belonging to a role
    /// (e.g., SP_UserRole_GetByRoleID).
    /// 
    /// It was created because the stored procedure returns additional data
    /// from the Users table (Username) in addition to UserID and RoleID,
    /// which does not exist in the base UserRoleDTO.
    /// </summary>
    /// 
    public class UserRoleUserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public int RoleID { get; set; }

        public UserRoleUserDTO(int userID, string username, int roleID)
        {
            UserID = userID;
            Username = username;
            RoleID = roleID;
        }
    }
}
