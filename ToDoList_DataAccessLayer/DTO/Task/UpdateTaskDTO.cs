using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_DataAccessLayer.DTO.Task
{
    public class UpdateTaskDTO
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DueDate { get; set; }
        public bool? IsImportant { get; set; }
        public int StatusID { get; set; }

        public UpdateTaskDTO(int taskID, string title, string? description,
            DateOnly? dueDate, bool? isImportant, int statusID)
        {
            TaskID = taskID;
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsImportant = isImportant;
            StatusID = statusID;
        }
    }
}
