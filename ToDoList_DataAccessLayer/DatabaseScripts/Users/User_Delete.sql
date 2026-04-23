ALTER PROCEDURE [dbo].[User_Delete]  
    @UserID INT  
AS  
BEGIN

    DELETE FROM Tasks
    WHERE UserID = @UserID;

    DELETE FROM Users  
    WHERE UserID = @UserID;  
END;