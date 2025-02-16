using ToDoList_DataAccessLayer.DTO.User;
using ToDoList_DataAccessLayer.Interfaces;

namespace ToDoList_BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        private readonly IUserData _userData;

        public UserDTO UserDTO
        {
            get
            {
                return new UserDTO(this.UserID, this.UserName, this.Password, this.Email);
            }
        }

        public UserLoginDTO UserLoginDTO
        {
            get
            {
                return new UserLoginDTO(this.UserName, this.Password);
            }
        }


        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public clsUser(IUserData userData)
        {
            _userData = userData;

            UserName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
        }

        public void Initialize(UserDTO userDTO, enMode mode = enMode.AddNew)
        {
            UserID = userDTO.UserID;
            UserName = userDTO.UserName;
            Password = userDTO.Password;
            Email = userDTO.Email;

            Mode = mode;
        }

        public clsUser? Find(int userID)
        {
            UserDTO? userDTO = _userData.GetUserByID(userID);

            if (userDTO != null)
            {
                var user = new clsUser(_userData);
                user.Initialize(userDTO, enMode.Update);
                return user;
            }
            return null;
        }

        private bool _AddNewUser()
        {
            this.UserID = _userData.AddNewUser(this.UserDTO);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return _userData.UpdateUser(this.UserID, UserDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                
                
                case enMode.Update:
                    return _UpdateUser();
                
                
                default:
                    return false;
            }
        }

        public bool DeleteUser(int userID)
        {
            return _userData.DeleteUser(userID);
        }

        public int Login(UserLoginDTO userLoginDTO)
        {
            return _userData.ChkUsernameAndPassword(userLoginDTO);
        }
    }
}
