CREATE PROCEDURE [dbo].[Task_Update]  
    @TaskID       INT,  
    @Title        NVARCHAR(50),  
    @Description  NVARCHAR(100),  
    @DueDate      DATE,  
    @IsImportant  BIT,  
    @StatusID     INT  
AS  
BEGIN  
    IF NOT EXISTS (SELECT 1 FROM Tasks WHERE TaskID = @TaskID)  
        RETURN;  
  
    UPDATE Tasks  
    SET  
        Title       = @Title,  
        Description = @Description,  
        DueDate     = @DueDate,  
        IsImportant = @IsImportant,  
        StatusID    = @StatusID  
    WHERE TaskID = @TaskID;  
END;