CREATE PROCEDURE [dbo].[spSchools_Delete]
	@Id int
AS
begin
	set nocount on;

	delete from dbo.Schools
	where Id = @Id;
end
