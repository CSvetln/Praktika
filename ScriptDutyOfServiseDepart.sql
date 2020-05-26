USE [master]
GO
/****** Object:  Database [DUTYOFSERVICEDAPART]    Script Date: 26.05.2020 16:23:26 ******/
CREATE DATABASE [DUTYOFSERVICEDAPART]

GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DUTYOFSERVICEDAPART].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET ARITHABORT OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET  MULTI_USER 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DUTYOFSERVICEDAPART] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DUTYOFSERVICEDAPART]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 26.05.2020 16:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Accesses]    Script Date: 26.05.2020 16:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accesses](
	[AccessId] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[AllowedEdit] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Accesses] PRIMARY KEY CLUSTERED 
(
	[AccessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DutyLists]    Script Date: 26.05.2020 16:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DutyLists](
	[DutyId] [int] IDENTITY(1,1) NOT NULL,
	[DateDuty] [datetime] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.DutyLists] PRIMARY KEY CLUSTERED 
(
	[DutyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 26.05.2020 16:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Login] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExtremIncidents]    Script Date: 26.05.2020 16:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExtremIncidents](
	[IncidentId] [int] IDENTITY(1,1) NOT NULL,
	[DateIncident] [datetime] NOT NULL,
	[EmployeeEmployeId] [int] NOT NULL,
	[DecsIncident] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ExtremIncidents] PRIMARY KEY CLUSTERED 
(
	[IncidentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Holidays]    Script Date: 26.05.2020 16:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holidays](
	[Holiday] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Holidays] PRIMARY KEY CLUSTERED 
(
	[Holiday] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vacations]    Script Date: 26.05.2020 16:23:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacations](
	[IdVacation] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NOT NULL,
	[Finish] [datetime] NOT NULL,
	[Employee_EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Vacations] PRIMARY KEY CLUSTERED 
(
	[IdVacation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_EmployeeId]    Script Date: 26.05.2020 16:23:27 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeId] ON [dbo].[DutyLists]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeEmployeId]    Script Date: 26.05.2020 16:23:27 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeEmployeId] ON [dbo].[ExtremIncidents]
(
	[EmployeeEmployeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_EmployeeId]    Script Date: 26.05.2020 16:23:27 ******/
CREATE NONCLUSTERED INDEX [IX_Employee_EmployeeId] ON [dbo].[Vacations]
(
	[Employee_EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DutyLists]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DutyLists_dbo.Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DutyLists] CHECK CONSTRAINT [FK_dbo.DutyLists_dbo.Employees_EmployeeId]
GO
ALTER TABLE [dbo].[ExtremIncidents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExtremIncidents_dbo.Employees_EmployeeEmployeId] FOREIGN KEY([EmployeeEmployeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExtremIncidents] CHECK CONSTRAINT [FK_dbo.ExtremIncidents_dbo.Employees_EmployeeEmployeId]
GO
ALTER TABLE [dbo].[Vacations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vacations_dbo.Employees_Employee_EmployeeId] FOREIGN KEY([Employee_EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vacations] CHECK CONSTRAINT [FK_dbo.Vacations_dbo.Employees_Employee_EmployeeId]
GO
USE [master]
GO
ALTER DATABASE [DUTYOFSERVICEDAPART_b194c3f80b1e4bd6a96d1951da99b6b4] SET  READ_WRITE 
GO
