using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DataAccessLayer.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserDTO(int UserID, string UserName, string Password, string Email)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;
        }
    }
}
