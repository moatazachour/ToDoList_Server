CREATE PROCEDURE [dbo].[Task_GetAllTasksByUser]  
    @UserID INT  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    SELECT  
        TaskID,  
        Title,  
        Description,  
        DueDate,  
        IsImportant,  
        Tasks.StatusID,  
        Statuses.StatusName  
    FROM Tasks  
    INNER JOIN Statuses ON Tasks.StatusID = Statuses.StatusID  
    WHERE UserID = @UserID  
    ORDER BY DueDate;  
END;