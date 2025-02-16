CREATE PROCEDURE [dbo].[Task_GetByID]  
    @TaskID INT  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    SELECT  
        TaskID,  
        Title,  
        Description,  
        IssueDate,  
        DueDate,  
        IsImportant,  
        Tasks.StatusID,  
        Statuses.StatusName,  
        UserID  
    FROM Tasks  
    INNER JOIN Statuses ON Tasks.StatusID = Statuses.StatusID  
    WHERE TaskID = @TaskID;  
END;