using ToDoList_DataAccessLayer.DTO;

namespace ToDoList_DataAccessLayer
{
    public interface IUserData
    {
        UserDTO? GetUserByID(int userID);
        
        int AddNewUser(UserDTO userDTO);

        bool UpdateUser(int userID, UserDTO userDTO);

        bool DeleteUser(int userID);
    }
}
