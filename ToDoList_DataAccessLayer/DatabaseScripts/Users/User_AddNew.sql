CREATE PROCEDURE [dbo].[User_AddNew]  
    @Username   NVARCHAR(50),  
    @Password   NVARCHAR(100),  
    @Email      VARCHAR(50),  
    @NewUserID  INT OUTPUT  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    INSERT INTO Users (Username, Password, Email)  
    VALUES (@Username, @Password, @Email);  
  
    SET @NewUserID = SCOPE_IDENTITY();  
END;
