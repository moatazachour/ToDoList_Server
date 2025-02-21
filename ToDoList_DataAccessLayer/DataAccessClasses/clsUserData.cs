using Microsoft.Data.SqlClient;
using System.Data;
using ToDoList_DataAccessLayer.DTO.User;
using ToDoList_DataAccessLayer.Interfaces;

namespace ToDoList_DataAccessLayer.DataAccessClasses
{
    public class clsUserData : IUserData
    {
        public readonly DatabaseConnectionService _dbConnectionService;

        public clsUserData(DatabaseConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService;
        }

        public UserDTO? GetUserByID(int userID)
        {
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("User_GetByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO
                                (
                                    userID,
                                    reader.GetString(reader.GetOrdinal("Username")),
                                    reader.GetString(reader.GetOrdinal("Password")),
                                    reader.GetString(reader.GetOrdinal("Email"))
                                );
                        }

                        return null;
                    }
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine($"Database Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }
        }

        public int AddNewUser(UserDTO userDTO)
        {
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("User_AddNew", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", userDTO.UserName);
                    cmd.Parameters.AddWithValue("@Password", userDTO.Password);
                    cmd.Parameters.AddWithValue("@Email", userDTO.Email);

                    SqlParameter outputParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    return (int)cmd.Parameters["@NewUserID"].Value;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }
        }

        public int ChkUsernameAndPassword(UserLoginDTO userLoginDTO)
        {
            int userID = -1;

            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("User_ChkUsernameAndPassword", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", userLoginDTO.UserName);
                    cmd.Parameters.AddWithValue("@Password", userLoginDTO.Password);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userID = (int)reader["UserID"];
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }

            return userID;
        }

        public bool UpdateUser(int userID, UserDTO userDTO)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("User_Update", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Username", userDTO.UserName);
                    cmd.Parameters.AddWithValue("@Password", userDTO.Password);
                    cmd.Parameters.AddWithValue("@Email", userDTO.Email);

                    connection.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }

            return rowsAffected > 0;
        }

        public bool DeleteUser(int userID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("User_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                throw;
            }

            return rowsAffected > 0;
        }
    }
}
