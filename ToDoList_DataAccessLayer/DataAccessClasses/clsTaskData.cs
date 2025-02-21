using Microsoft.Data.SqlClient;
using System.Data;
using ToDoList_DataAccessLayer.DTO.Task;
using ToDoList_DataAccessLayer.Interfaces;

namespace ToDoList_DataAccessLayer.DataAccessClasses
{
    public class clsTaskData : ITask
    {
        public readonly DatabaseConnectionService _dbConnectionService;

        public clsTaskData(DatabaseConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService;
        }

        public TaskDetailsDTO? GetTaskByID(int taskID)
        {
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_GetByID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaskID", taskID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Try to clean this part later (Maybe Extension Methods)
                            string? description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null
                                : reader.GetString(reader.GetOrdinal("Description"));

                            DateOnly? dueDate = reader.IsDBNull(reader.GetOrdinal("DueDate")) ? null
                                : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DueDate")));

                            bool? isImportant = reader.IsDBNull(reader.GetOrdinal("IsImportant")) ? null
                                : reader.GetBoolean(reader.GetOrdinal("IsImportant"));

                            return new TaskDetailsDTO
                            (
                                taskID,
                                reader.GetString(reader.GetOrdinal("Title")),
                                description,
                                reader.GetDateTime(reader.GetOrdinal("IssueDate")),
                                dueDate,
                                isImportant,
                                reader.GetInt32(reader.GetOrdinal("StatusID")),
                                reader.GetString(reader.GetOrdinal("StatusName")),
                                reader.GetInt32(reader.GetOrdinal("UserID"))
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

        public List<TaskListDTO> GetAllTasksByUser(int userID)
        {
            List<TaskListDTO> TasksList = new List<TaskListDTO>();
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_GetAllTasksByUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Try to clean this part later (Maybe Extension Methods)
                            string? description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null
                                : reader.GetString(reader.GetOrdinal("Description"));

                            DateOnly? dueDate = reader.IsDBNull(reader.GetOrdinal("DueDate")) ? null
                                : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DueDate")));

                            bool? isImportant = reader.IsDBNull(reader.GetOrdinal("IsImportant")) ? null
                                : reader.GetBoolean(reader.GetOrdinal("IsImportant"));

                            TasksList.Add(new TaskListDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("TaskID")),
                                reader.GetString(reader.GetOrdinal("Title")),
                                description,
                                dueDate,
                                isImportant,
                                reader.GetInt32(reader.GetOrdinal("StatusID")),
                                reader.GetString(reader.GetOrdinal("StatusName"))
                            ));
                        }
                    }
                }
                return TasksList;
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

        public List<TaskListDTO> GetEarlierTasksByUser(int userID)
        {
            List<TaskListDTO> TasksList = new List<TaskListDTO>();
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_GetEarlierTasksByUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Try to clean this part later (Maybe Extension Methods)
                            string? description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null
                                : reader.GetString(reader.GetOrdinal("Description"));

                            DateOnly? dueDate = reader.IsDBNull(reader.GetOrdinal("DueDate")) ? null
                                : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DueDate")));

                            bool? isImportant = reader.IsDBNull(reader.GetOrdinal("IsImportant")) ? null
                                : reader.GetBoolean(reader.GetOrdinal("IsImportant"));

                            TasksList.Add(new TaskListDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("TaskID")),
                                reader.GetString(reader.GetOrdinal("Title")),
                                description,
                                dueDate,
                                isImportant,
                                reader.GetInt32(reader.GetOrdinal("StatusID")),
                                reader.GetString(reader.GetOrdinal("StatusName"))
                            ));
                        }
                    }
                }
                return TasksList;
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

        public List<TaskListDTO> GetTodayTasksByUser(int userID)
        {
            List<TaskListDTO> TasksList = new List<TaskListDTO>();
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_GetTodayTasksByUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Try to clean this part later (Maybe Extension Methods)
                            string? description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null
                                : reader.GetString(reader.GetOrdinal("Description"));

                            DateOnly? dueDate = reader.IsDBNull(reader.GetOrdinal("DueDate")) ? null
                                : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DueDate")));

                            bool? isImportant = reader.IsDBNull(reader.GetOrdinal("IsImportant")) ? null
                                : reader.GetBoolean(reader.GetOrdinal("IsImportant"));

                            TasksList.Add(new TaskListDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("TaskID")),
                                reader.GetString(reader.GetOrdinal("Title")),
                                description,
                                dueDate,
                                isImportant,
                                reader.GetInt32(reader.GetOrdinal("StatusID")),
                                reader.GetString(reader.GetOrdinal("StatusName"))
                            ));
                        }
                    }
                }
                return TasksList;
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

        public List<TaskListDTO> GetImportantTasksByUser(int userID)
        {
            List<TaskListDTO> TasksList = new List<TaskListDTO>();
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_GetImportantTasksByUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Try to clean this part later (Maybe Extension Methods)
                            string? description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null
                                : reader.GetString(reader.GetOrdinal("Description"));

                            DateOnly? dueDate = reader.IsDBNull(reader.GetOrdinal("DueDate")) ? null
                                : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DueDate")));

                            bool? isImportant = reader.IsDBNull(reader.GetOrdinal("IsImportant")) ? null
                                : reader.GetBoolean(reader.GetOrdinal("IsImportant"));

                            TasksList.Add(new TaskListDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("TaskID")),
                                reader.GetString(reader.GetOrdinal("Title")),
                                description,
                                dueDate,
                                isImportant,
                                reader.GetInt32(reader.GetOrdinal("StatusID")),
                                reader.GetString(reader.GetOrdinal("StatusName"))
                            ));
                        }
                    }
                }
                return TasksList;
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

        public List<TaskListDTO> GetTomorrowTasksByUser(int userID)
        {
            List<TaskListDTO> TasksList = new List<TaskListDTO>();
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_GetTomorrowTasksByUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Try to clean this part later (Maybe Extension Methods)
                            string? description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null
                                : reader.GetString(reader.GetOrdinal("Description"));

                            DateOnly? dueDate = reader.IsDBNull(reader.GetOrdinal("DueDate")) ? null
                                : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DueDate")));

                            bool? isImportant = reader.IsDBNull(reader.GetOrdinal("IsImportant")) ? null
                                : reader.GetBoolean(reader.GetOrdinal("IsImportant"));

                            TasksList.Add(new TaskListDTO
                            (
                                reader.GetInt32(reader.GetOrdinal("TaskID")),
                                reader.GetString(reader.GetOrdinal("Title")),
                                description,
                                dueDate,
                                isImportant,
                                reader.GetInt32(reader.GetOrdinal("StatusID")),
                                reader.GetString(reader.GetOrdinal("StatusName"))
                            ));
                        }
                    }
                }
                return TasksList;
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


        public int AddNewTask(CreateTaskDTO createTaskDTO)
        {
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_AddNew", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", createTaskDTO.Title);

                    if (createTaskDTO.Description == string.Empty)
                        cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Description", createTaskDTO.Description);

                    cmd.Parameters.AddWithValue("@IssueDate", createTaskDTO.IssueDate);

                    if (createTaskDTO.DueDate == null)
                        cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@DueDate", createTaskDTO.DueDate);

                    if (createTaskDTO.IsImportant == null)
                        cmd.Parameters.AddWithValue("@IsImportant", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@IsImportant", createTaskDTO.IsImportant);

                    cmd.Parameters.AddWithValue("@StatusID", createTaskDTO.StatusID);
                    cmd.Parameters.AddWithValue("@UserID", createTaskDTO.UserID);

                    SqlParameter outputParam = new SqlParameter("@NewTaskID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    return (int)cmd.Parameters["@NewTaskID"].Value;
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

        public bool UpdateTask(int taskID, UpdateTaskDTO updateTaskDTO)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_Update", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaskID", taskID);
                    cmd.Parameters.AddWithValue("@Title", updateTaskDTO.Title);

                    if (updateTaskDTO.Description == string.Empty)
                        cmd.Parameters.AddWithValue("@Description", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Description", updateTaskDTO.Description);

                    cmd.Parameters.AddWithValue("@DueDate", updateTaskDTO.DueDate);
                    cmd.Parameters.AddWithValue("@IsImportant", updateTaskDTO.IsImportant);
                    cmd.Parameters.AddWithValue("@StatusID", updateTaskDTO.TaskID);

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

        public bool DeleteTask(int taskID)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = _dbConnectionService.GetConnection())
                using (SqlCommand cmd = new SqlCommand("Task_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TaskID", taskID);

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

        //public string GetStatusName(int statusID)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = _dbConnectionService.GetConnection())
        //        using (SqlCommand cmd = new SqlCommand("Task_GetStatusName", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@StatusID", statusID);

        //            connection.Open();

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                    return reader.GetString(reader.GetOrdinal("StatusName"));
        //            }
        //            return string.Empty;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine($"Database Error: {ex.Message}");
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Unexpected Error: {ex.Message}");
        //        throw;
        //    }
        //}
    }
}
