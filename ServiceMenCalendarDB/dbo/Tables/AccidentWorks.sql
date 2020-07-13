CREATE TABLE [dbo].[AccidentWorks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AccidentDate] DATE NOT NULL, 
    [EmployeeId] INT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_AccidentWorks_Employees]  FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id])
)
