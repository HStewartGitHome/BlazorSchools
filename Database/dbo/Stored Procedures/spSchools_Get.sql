CREATE PROCEDURE [dbo].[spSchools_Get]	
AS
begin
      SELECT Id,name, street, city, state, zip
      FROM dbo.Schools
end
