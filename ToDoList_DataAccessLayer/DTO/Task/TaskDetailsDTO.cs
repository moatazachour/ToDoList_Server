namespace ToDoList_DataAccessLayer.DTO.Task
{
    public class TaskDetailsDTO
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public bool? IsImportant { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public int UserID { get; set; }


        public TaskDetailsDTO(int taskID, string title, string? description, DateTime issueDate,
            DateOnly? dueDate, bool? isImportant, int statusID, string statusName, int userID)
        {
            TaskID = taskID;
            Title = title;
            Description = description;
            IssueDate = issueDate;
            DueDate = dueDate;
            IsImportant = isImportant;
            StatusID = statusID;
            StatusName = statusName;
            UserID = userID;
        }
    }
}
