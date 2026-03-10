using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.Roles
{
    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }

        public RoleDTO(int roleID, string roleName, string description,
                       DateTime createdAt, bool isActive, string createdBy)
        {
            RoleID = roleID;
            RoleName = roleName;
            Description = description;
            CreatedAt = createdAt;
            IsActive = isActive;
            CreatedBy = createdBy;
        }
    }
}
