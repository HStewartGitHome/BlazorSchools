CREATE PROCEDURE [dbo].[spSchools_GetOne]
	@Id int
AS
begin
      SELECT Id,name, street, city, state, state
      FROM dbo.Schools
      WHERE Id = @Id
end
