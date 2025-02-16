CREATE PROCEDURE [dbo].[Task_AddNew]  
 @Title Nvarchar(50),  
 @Description Nvarchar(100),  
 @IssueDate Datetime,  
 @DueDate Date ,  
 @IsImportant bit,  
 @StatusID int,  
 @UserID int,  
 @NewTaskID int Output  
AS  
Begin  
 SET NOCOUNT ON;  
  
 Insert Into Tasks(Title, Description, IssueDate, DueDate, IsImportant, StatusID, UserID)  
 Values (@Title, @Description, @IssueDate, @DueDate, @IsImportant, @StatusID, @UserID)  
  
 Set @NewTaskID = SCOPE_IDENTITY();  
End;