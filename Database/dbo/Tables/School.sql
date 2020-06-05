CREATE TABLE [dbo].[Schools]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] NVARCHAR(50) NULL, 
    [street] NVARCHAR(50) NULL, 
    [city] NVARCHAR(50) NULL, 
    [state] NVARCHAR(50) NULL, 
    [zip] NVARCHAR(50) NULL
)
