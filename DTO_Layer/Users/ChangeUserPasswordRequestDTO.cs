using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.Users
{
    public class ChangeUserPasswordRequestDTO
    {
        public int UserID { get; set; }

        public string NewPassword { get; set; }

        public ChangeUserPasswordRequestDTO(int userID, string newPassword)
        {
            UserID = userID;
            NewPassword = newPassword;
        }
    }
}