using ToDoList_DataAccessLayer.DTO.Task;

namespace ToDoList_DataAccessLayer.Interfaces
{
    public interface ITask
    {
        TaskDetailsDTO? GetTaskByID(int taskID);

        List<TaskListDTO> GetAllTasksByUser(int userID);

        List<TaskListDTO> GetEarlierTasksByUser(int userID);

        List<TaskListDTO> GetTodayTasksByUser(int userID);

        List<TaskListDTO> GetImportantTasksByUser(int userID);

        List<TaskListDTO> GetTomorrowTasksByUser(int userID);

        int AddNewTask(CreateTaskDTO createTaskDTO);

        bool UpdateTask(int taskID, UpdateTaskDTO updateTaskDTO);

        bool DeleteTask(int taskID);
    }
}
