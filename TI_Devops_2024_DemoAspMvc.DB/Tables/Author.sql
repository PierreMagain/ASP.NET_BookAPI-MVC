CREATE TABLE [dbo].[Author]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Firstname] VARCHAR(50) NOT NULL,
	[Lastname] VARCHAR(50) NOT NULL,
	[Pen_name] VARCHAR(50) NULL,
	[Birthdate] DATETIME2 NOT NULL,
	CONSTRAINT UK_Author UNIQUE (Firstname,Lastname,Birthdate),
	CONSTRAINT CK_Author__Birthdate CHECK (Birthdate < GETDATE())
)
