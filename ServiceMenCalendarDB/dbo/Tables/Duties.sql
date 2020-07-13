CREATE TABLE [dbo].[Duties]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DutyDate] DATE NOT NULL, 
    [EmployeeId] INT NULL, 
    CONSTRAINT [FK_Duties_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id])
)
