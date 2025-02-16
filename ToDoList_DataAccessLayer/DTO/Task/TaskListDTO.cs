namespace ToDoList_DataAccessLayer.DTO.Task
{
    public class TaskListDTO
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? DueDate { get; set; }
        public bool? IsImportant { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }


        public TaskListDTO(int taskID, string title, string? description,
            DateOnly? dueDate, bool? isImportant, int statusID, string statusName)
        {
            TaskID = taskID;
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsImportant = isImportant;
            StatusID = statusID;
            StatusName = statusName;
        }
    }
}
