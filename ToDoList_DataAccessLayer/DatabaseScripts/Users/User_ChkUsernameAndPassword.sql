CREATE PROCEDURE [dbo].[User_ChkUsernameAndPassword]  
    @Username NVARCHAR(50),  
    @Password NVARCHAR(100)  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    SELECT UserID  
    FROM Users  
    WHERE Username = @Username  
        AND Password = @Password;  
END;