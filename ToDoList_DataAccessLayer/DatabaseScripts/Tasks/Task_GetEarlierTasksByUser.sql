﻿CREATE PROCEDURE [dbo].[Task_GetEarlierTasksByUser]  
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
    FROM  
        Tasks  
    INNER JOIN  
        Statuses ON Tasks.StatusID = Statuses.StatusID  
    WHERE  
        UserID = @UserID  
        AND DueDate < CAST(GETDATE() AS DATE)  
    ORDER BY  
        DueDate ASC;  
END;  
