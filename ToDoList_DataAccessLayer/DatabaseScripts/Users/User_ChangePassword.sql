CREATE PROCEDURE [dbo].[User_ChangePassword]  
    @UserID      INT,  
    @NewPassword NVARCHAR(100)  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    UPDATE Users  
    SET Password = @NewPassword  
    WHERE UserID = @UserID;  
END;