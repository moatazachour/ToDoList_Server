CREATE PROCEDURE [dbo].[Task_GetTomorrowTasksByUser]  
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
        AND DueDate = CAST(DATEADD(DAY, 1, GETDATE()) AS DATE);  
END;