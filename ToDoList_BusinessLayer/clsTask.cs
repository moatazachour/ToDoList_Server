using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_DataAccessLayer.DTO.Task;
using ToDoList_DataAccessLayer.Interfaces;

namespace ToDoList_BusinessLayer
{
    public class clsTask
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        private readonly ITask _taskData;

        public CreateTaskDTO CreateTaskDTO
        {
            get
            {
                return new CreateTaskDTO(Title, Description, IssueDate, DueDate, IsImportant,
                    StatusID, UserID);
            }
        }

        public TaskDetailsDTO TaskDetailsDTO
        {
            get
            {
                return new TaskDetailsDTO(TaskID, Title, Description, IssueDate, DueDate, IsImportant,
                    StatusID, StatusName, UserID);
            }
        }

        public TaskListDTO TaskListDTO
        {
            get
            {
                return new TaskListDTO(TaskID, Title, Description, DueDate, IsImportant, StatusID, StatusName);
            }
        }

        public UpdateTaskDTO UpdateTaskDTO
        {
            get
            {
                return new UpdateTaskDTO(TaskID, Title, Description, DueDate, IsImportant, StatusID);
            }
        }


        public int TaskID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public bool? IsImportant { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public int UserID { get; set; }

        public clsTask(ITask taskData)
        {
            _taskData = taskData;

            Title = string.Empty;
            StatusName = string.Empty;
        }

        public void Initialize(CreateTaskDTO createTaskDTO, enMode mode = enMode.AddNew)
        {
            Title = createTaskDTO.Title;
            Description = createTaskDTO.Description;
            IssueDate = createTaskDTO.IssueDate;
            DueDate = createTaskDTO.DueDate;
            IsImportant = createTaskDTO.IsImportant;
            StatusID = createTaskDTO.StatusID;
            UserID = createTaskDTO.UserID;

            Mode = mode;
        }

        public void Initialize(TaskDetailsDTO taskDetailsDTO, enMode mode = enMode.AddNew)
        {
            TaskID = taskDetailsDTO.TaskID;
            Title = taskDetailsDTO.Title;
            Description = taskDetailsDTO.Description;
            IssueDate = taskDetailsDTO.IssueDate;
            DueDate = taskDetailsDTO.DueDate;
            IsImportant = taskDetailsDTO.IsImportant;
            StatusID = taskDetailsDTO.StatusID;
            StatusName = taskDetailsDTO.StatusName;
            UserID = taskDetailsDTO.UserID;

            Mode = mode;
        }

        public void Initialize(UpdateTaskDTO updateTaskDTO, enMode mode = enMode.Update)
        {
            TaskID = updateTaskDTO.TaskID;
            Title = updateTaskDTO.Title;
            Description = updateTaskDTO.Description;
            DueDate = updateTaskDTO.DueDate;
            IsImportant = updateTaskDTO.IsImportant;
            StatusID = updateTaskDTO.StatusID;

            Mode = mode;
        }


        public clsTask? Find(int taskID)
        {
            TaskDetailsDTO? taskDetailsDTO = _taskData.GetTaskByID(taskID);

            if (taskDetailsDTO != null)
            {
                clsTask task = new clsTask(_taskData);
                task.Initialize(taskDetailsDTO, enMode.Update);
                return task;
            }

            return null;
        }


        public List<TaskListDTO> GetAllTasksByUser(int userID)
        {
            return _taskData.GetAllTasksByUser(userID);
        }

        public List<TaskListDTO> GetEarlierTasksByUser(int userID)
        {
            return _taskData.GetEarlierTasksByUser(userID);
        }

        public List<TaskListDTO> GetTodayTasksByUser(int userID)
        {
            return _taskData.GetTodayTasksByUser(userID);
        }

        public List<TaskListDTO> GetImportantTasksByUser(int userID)
        {
            return _taskData.GetImportantTasksByUser(userID);
        }

        public List<TaskListDTO> GetTomorrowTasksByUser(int userID)
        {
            return _taskData.GetTomorrowTasksByUser(userID);
        }


        private bool _AddNewTask()
        {
            TaskID = _taskData.AddNewTask(this.CreateTaskDTO);

            return (TaskID != -1);
        }

        private bool _Update()
        {
            return _taskData.UpdateTask(TaskID, UpdateTaskDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTask())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                
                case enMode.Update:
                    return _Update();   
                
                default:
                    return false;
            }
        }

        public bool Delete(int taskID)
        {
            return _taskData.DeleteTask(taskID);
        }
    }
}
