CREATE TABLE [dbo].[Vacations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EmployeeId] INT NOT NULL, 
    [BeginDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    CONSTRAINT [FK_Vacations_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id])
)
