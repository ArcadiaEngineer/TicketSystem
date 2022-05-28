USE [master]
GO
/****** Object:  Database [TicketSystem]    Script Date: 29.05.2022 00:33:50 ******/
CREATE DATABASE [TicketSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TicketSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TicketSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TicketSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TicketSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TicketSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TicketSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TicketSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TicketSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TicketSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TicketSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TicketSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [TicketSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TicketSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TicketSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TicketSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TicketSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TicketSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TicketSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TicketSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TicketSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TicketSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TicketSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TicketSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TicketSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TicketSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TicketSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TicketSystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TicketSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TicketSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TicketSystem] SET  MULTI_USER 
GO
ALTER DATABASE [TicketSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TicketSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TicketSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TicketSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TicketSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TicketSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TicketSystem] SET QUERY_STORE = OFF
GO
USE [TicketSystem]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29.05.2022 00:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 29.05.2022 00:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 29.05.2022 00:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[Birthdate] [datetime2](7) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 29.05.2022 00:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmpoyeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmpUserName] [nvarchar](50) NOT NULL,
	[EmpPassword] [nvarchar](50) NOT NULL,
	[EmpName] [nvarchar](50) NOT NULL,
	[EmpSurname] [nvarchar](50) NOT NULL,
	[EmpAddress] [nvarchar](500) NULL,
	[EmpEmail] [nvarchar](100) NULL,
	[EmpBirthDate] [datetime2](7) NULL,
	[EmpPhoneNumber] [nvarchar](20) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmpoyeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 29.05.2022 00:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[MovieName] [nvarchar](100) NOT NULL,
	[MovieVisionDate] [datetime2](7) NOT NULL,
	[MovieBanner] [varbinary](max) NULL,
	[MovieCategoryId] [int] NOT NULL,
	[MovieIMDB] [int] NULL,
	[MovieReview] [nvarchar](500) NULL,
	[MovieAgeLimit] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scenes]    Script Date: 29.05.2022 00:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scenes](
	[SceneId] [int] IDENTITY(1,1) NOT NULL,
	[SceneType] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Scenes] PRIMARY KEY CLUSTERED 
(
	[SceneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 29.05.2022 00:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[SeatId] [int] IDENTITY(1,1) NOT NULL,
	[SceneId] [int] NOT NULL,
	[SeatNumber] [int] NOT NULL,
	[SessionId] [int] NOT NULL,
 CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED 
(
	[SeatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 29.05.2022 00:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[SessionId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[SceneId] [int] NOT NULL,
	[SessionTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 29.05.2022 00:33:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketId] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[SeatId] [int] NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_EmployeeId]    Script Date: 29.05.2022 00:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_EmployeeId] ON [dbo].[Movies]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_MovieCategoryId]    Script Date: 29.05.2022 00:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_MovieCategoryId] ON [dbo].[Movies]
(
	[MovieCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seats_SceneId]    Script Date: 29.05.2022 00:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Seats_SceneId] ON [dbo].[Seats]
(
	[SceneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seats_SessionId_SeatNumber]    Script Date: 29.05.2022 00:33:51 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Seats_SessionId_SeatNumber] ON [dbo].[Seats]
(
	[SessionId] ASC,
	[SeatNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sessions_MovieId]    Script Date: 29.05.2022 00:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Sessions_MovieId] ON [dbo].[Sessions]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sessions_SceneId]    Script Date: 29.05.2022 00:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Sessions_SceneId] ON [dbo].[Sessions]
(
	[SceneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_CustomerId]    Script Date: 29.05.2022 00:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_CustomerId] ON [dbo].[Tickets]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_SessionId]    Script Date: 29.05.2022 00:33:51 ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_SessionId] ON [dbo].[Tickets]
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Categories_MovieCategoryId] FOREIGN KEY([MovieCategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Categories_MovieCategoryId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmpoyeeId])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_Seats_Scenes_SceneId] FOREIGN KEY([SceneId])
REFERENCES [dbo].[Scenes] ([SceneId])
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_Seats_Scenes_SceneId]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Movies_MovieId]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Scenes_SceneId] FOREIGN KEY([SceneId])
REFERENCES [dbo].[Scenes] ([SceneId])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Scenes_SceneId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Sessions_SessionId] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([SessionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Sessions_SessionId]
GO
USE [master]
GO
ALTER DATABASE [TicketSystem] SET  READ_WRITE 
GO
