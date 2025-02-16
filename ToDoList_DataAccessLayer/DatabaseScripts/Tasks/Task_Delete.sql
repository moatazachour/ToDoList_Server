CREATE PROCEDURE [dbo].[Task_Delete]  
    @TaskID INT  
AS  
BEGIN  
    DELETE FROM Tasks  
    WHERE TaskID = @TaskID;  
END;
