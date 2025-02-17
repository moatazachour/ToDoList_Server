CREATE PROCEDURE [dbo].[User_AddNew]  
    @Username   NVARCHAR(50),  
    @Password   NVARCHAR(100),  
    @Email      VARCHAR(50),  
    @NewUserID  INT OUTPUT  
AS  
BEGIN  
    SET NOCOUNT ON;  

    -- Check if the username or email already exists  
    IF EXISTS (  
        SELECT Found = 1  
        FROM Users  
        WHERE Email = @Email OR Username = @Username  
    )  
    BEGIN  
        SET @NewUserID = -1;  
        RETURN;  
    END;  

    -- Insert the new user  
    INSERT INTO Users (Username, Password, Email)  
    VALUES (@Username, @Password, @Email);  

    -- Retrieve the newly inserted UserID  
    SET @NewUserID = SCOPE_IDENTITY();  
END;
