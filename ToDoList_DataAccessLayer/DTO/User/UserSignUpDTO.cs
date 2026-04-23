namespace ToDoList_DataAccessLayer.DTO.User
{
    public class UserSignUpDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserSignUpDTO(string UserName, string Password, string Email)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.Email = Email;
        }
    }
}
