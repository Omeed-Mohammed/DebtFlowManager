using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.Users
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public UserDTO(int userID, int personID, string username,
            bool isActive, DateTime createdAt, string createdBy)
        {
            UserID = userID;
            PersonID = personID;
            Username = username;
            IsActive = isActive;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
        }
    }
}
