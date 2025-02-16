CREATE PROCEDURE [dbo].[User_Delete]  
    @UserID INT  
AS  
BEGIN  
    DELETE FROM Users  
    WHERE UserID = @UserID;  
END;