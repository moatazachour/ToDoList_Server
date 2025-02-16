using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DataAccessLayer.DTO.User
{
    public class UserLoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserLoginDTO(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
