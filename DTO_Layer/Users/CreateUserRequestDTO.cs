using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Layer.Users
{
    public class CreateUserRequestDTO
    {
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }

        public CreateUserRequestDTO(int personID, string username, 
            string password, string createdBy)
        {
            PersonID = personID;
            Username = username;
            Password = password;
            CreatedBy = createdBy;
        }
    }
}
