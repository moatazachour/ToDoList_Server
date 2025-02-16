using ToDoList_DataAccessLayer.DTO.User;

namespace ToDoList_DataAccessLayer.Interfaces
{
    public interface IUserData
    {
        UserDTO? GetUserByID(int userID);

        int AddNewUser(UserDTO userDTO);

        bool UpdateUser(int userID, UserDTO userDTO);

        bool DeleteUser(int userID);
    }
}
