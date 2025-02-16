CREATE PROCEDURE [dbo].[User_GetByID]  
    @UserID INT  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    SELECT  
        Username,  
        Password,  
        Email  
    FROM Users  
    WHERE UserID = @UserID;  
END;