CREATE PROCEDURE [dbo].[spSchools_Create]
    @name NVARCHAR(50), 
	@street NVARCHAR(50), 
    @city NVARCHAR(50), 
	@state NVARCHAR(50), 
	@zip NVARCHAR(50)
AS
BEGIN
    INSERT INTO Schools (name, street, city, state, zip)
    VALUES (@name, @street, @city, @state, @zip)
END
