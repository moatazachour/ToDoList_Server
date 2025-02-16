CREATE PROCEDURE [dbo].[User_Update]  
    @UserID   INT,  
    @Username NVARCHAR(50),  
    @Password NVARCHAR(100),  
    @Email    VARCHAR(50)  
AS  
BEGIN  
    UPDATE Users  
    SET  
        Username = @Username,  
        Password = @Password,  
        Email    = @Email  
    WHERE UserID = @UserID;  
END;