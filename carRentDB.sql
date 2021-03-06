USE [master]
GO
/****** Object:  Database [CarRent]    Script Date: 22.02.2021 09:58:33 ******/
CREATE DATABASE [CarRent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRent', FILENAME = N'C:\Users\ataka\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\CarRent.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRent_log', FILENAME = N'C:\Users\ataka\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\CarRent.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarRent] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRent] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [CarRent] SET ANSI_NULLS ON 
GO
ALTER DATABASE [CarRent] SET ANSI_PADDING ON 
GO
ALTER DATABASE [CarRent] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [CarRent] SET ARITHABORT ON 
GO
ALTER DATABASE [CarRent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRent] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [CarRent] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [CarRent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRent] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [CarRent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRent] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRent] SET RECOVERY FULL 
GO
ALTER DATABASE [CarRent] SET  MULTI_USER 
GO
ALTER DATABASE [CarRent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRent] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRent] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRent] SET QUERY_STORE = OFF
GO
USE [CarRent]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CarRent]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 22.02.2021 09:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] NOT NULL,
	[BrandName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 22.02.2021 09:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[ModelYear] [int] NOT NULL,
	[DailyPrice] [int] NOT NULL,
	[Description] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 22.02.2021 09:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Id] [int] NOT NULL,
	[ColorName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 22.02.2021 09:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] NOT NULL,
	[UserId] [int] NULL,
	[CompanyName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 22.02.2021 09:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[Id] [int] NOT NULL,
	[CarId] [int] NULL,
	[CustomerId] [int] NULL,
	[RentDate] [datetime2](7) NULL,
	[ReturnDate] [datetime2](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 22.02.2021 09:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (1, N'Meireless')
INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (2, N'BDW')
INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (3, N'Belesiyor')
INSERT [dbo].[Brand] ([Id], [BrandName]) VALUES (5, N'Postman2')
GO
SET IDENTITY_INSERT [dbo].[Car] ON 

INSERT [dbo].[Car] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (1, 1, 1, 1998, 500, N'Arabalarin Hasi')
INSERT [dbo].[Car] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2, 1, 2, 1980, 250, N'Eski Araba')
INSERT [dbo].[Car] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3, 2, 1, 1999, 450, N'DoksanDokuz')
INSERT [dbo].[Car] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (4, 2, 2, 2010, 600, N'Yeni Cillop')
INSERT [dbo].[Car] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (5, 1, 2, 1987, 150, N'4644')
SET IDENTITY_INSERT [dbo].[Car] OFF
GO
INSERT [dbo].[Color] ([Id], [ColorName]) VALUES (1, N'Mavi')
INSERT [dbo].[Color] ([Id], [ColorName]) VALUES (2, N'Siyah')
INSERT [dbo].[Color] ([Id], [ColorName]) VALUES (3, N'Kırmızı')
GO
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (1, 1, N'Deneme Şirketi2')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (5, 5, N'Deneme Şirketi1')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (2, 2, N'XYZ Şirketi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (3, 4, N'XYZ Şirketi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (6, 1, N'ABC Şirketi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (7, 3, N'BCD Şirketi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (4, 2, N'Merhaba Şirketi')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (8, 1, N'Deneme şirketi 3')
INSERT [dbo].[Customers] ([Id], [UserId], [CompanyName]) VALUES (9, 2, N'Postman Şirketi')
GO
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (1, 2, 1, CAST(N'1998-02-23T00:00:00.0000000' AS DateTime2), CAST(N'2000-02-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (2, 2, 2, CAST(N'2015-03-12T00:00:00.0000000' AS DateTime2), CAST(N'2016-03-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (3, 1, 6, CAST(N'2021-02-12T17:35:23.9297206' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (4, 5, 4, CAST(N'2021-02-12T17:45:05.9106351' AS DateTime2), CAST(N'2021-02-12T17:45:05.9124669' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (5, 1, 5, CAST(N'2021-02-12T17:34:51.6704250' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (7, 3, 1, CAST(N'2021-02-12T17:38:56.0148837' AS DateTime2), CAST(N'2021-02-12T17:38:56.0164474' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (8, 5, 4, CAST(N'2021-02-12T18:59:29.4834009' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (9, 3, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (10, 4, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-02-13T16:47:01.1948655' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (12, 2, 4, CAST(N'2021-02-13T16:54:42.0354805' AS DateTime2), CAST(N'2021-02-13T16:55:12.1332125' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (13, 2, 6, CAST(N'2021-02-13T16:54:42.0354805' AS DateTime2), CAST(N'2021-02-15T16:11:09.8285068' AS DateTime2))
INSERT [dbo].[Rentals] ([Id], [CarId], [CustomerId], [RentDate], [ReturnDate]) VALUES (11, 1, 2, CAST(N'2021-02-13T16:47:01.0258461' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (1, N'Atakan', N'Göçer', N'atakangcr@gmail.com', N'123456')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (2, N'Emre', N'Ersöz', N'emre@gmail.com', N'1234567')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (3, N'Bolbey', N'Bulan', N'bulan@gmail.com', N'1234')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (4, N'Hasan', N'Mustan', N'hasan@gmail.com', N'1234567')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (5, N'Mali', N'Malibo', N'mali@gmail.com', N'1541554')
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (6, N'Post', N'Man', N'postman@gmail.com', N'1998654')
GO
/****** Object:  Index [PK__Customer__3214EC06970A1C3E]    Script Date: 22.02.2021 09:58:33 ******/
ALTER TABLE [dbo].[Customers] ADD PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK__Rentals__3214EC06F5A2827C]    Script Date: 22.02.2021 09:58:33 ******/
ALTER TABLE [dbo].[Rentals] ADD PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CarRent] SET  READ_WRITE 
GO
