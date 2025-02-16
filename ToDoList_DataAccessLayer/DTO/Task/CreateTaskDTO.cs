namespace ToDoList_DataAccessLayer.DTO.Task
{
    public class CreateTaskDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime IssueDate { get; set; }
        public DateOnly? DueDate { get; set; }
        public bool? IsImportant { get; set; }
        public int StatusID { get; set; }
        public int UserID { get; set; }

        public CreateTaskDTO(string title, string? description, DateTime issueDate,
            DateOnly? dueDate, bool? isImportant, int statusID, int userID)
        {
            Title = title;
            Description = description;
            IssueDate = issueDate;
            DueDate = dueDate;
            IsImportant = isImportant;
            StatusID = statusID;
            UserID = userID;
        }
    }
}
