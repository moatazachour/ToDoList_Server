using ToDoList_DataAccessLayer.DTO.User;

namespace ToDoList_DataAccessLayer.Interfaces
{
    public interface IUserData
    {
        UserDTO? GetUserByID(int userID);

        int AddNewUser(UserDTO userDTO);

        int ChkUsernameAndPassword(UserLoginDTO userLoginDTO);

        bool UpdateUser(int userID, UserDTO userDTO);

        bool DeleteUser(int userID);
    }
}
