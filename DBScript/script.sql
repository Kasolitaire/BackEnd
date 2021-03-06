USE [master]
GO
/****** Object:  Database [CarRentalDatabase]    Script Date: 5/17/2022 2:46:28 PM ******/
CREATE DATABASE [CarRentalDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRentalDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarRentalDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRentalDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarRentalDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarRentalDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRentalDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRentalDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRentalDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRentalDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRentalDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRentalDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarRentalDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [CarRentalDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRentalDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRentalDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRentalDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRentalDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRentalDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CarRentalDatabase] SET QUERY_STORE = OFF
GO
USE [CarRentalDatabase]
GO
/****** Object:  Table [dbo].[RentalOrderDetails]    Script Date: 5/17/2022 2:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentalOrderDetails](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[PickUpDate] [nvarchar](50) NOT NULL,
	[DropOffDate] [nvarchar](50) NOT NULL,
	[DateOfficiallyReturned] [nvarchar](50) NULL,
	[UserID] [int] NOT NULL,
	[SerialNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RentalOrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/17/2022 2:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserRole] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[ID] [nvarchar](9) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[BirthDate] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ProfilePicture] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleInventory]    Script Date: 5/17/2022 2:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleInventory](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTypeID] [int] NOT NULL,
	[Kilometers] [int] NOT NULL,
	[CarPhotograph] [bit] NULL,
	[Operational] [bit] NOT NULL,
	[Available] [bit] NOT NULL,
	[SerialNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VehicleInventory] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 5/17/2022 2:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleType](
	[VehicleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](100) NOT NULL,
	[CostPerDay] [decimal](18, 0) NOT NULL,
	[CostPerDayDelayed] [decimal](18, 0) NOT NULL,
	[DateManufactured] [nvarchar](50) NOT NULL,
	[Gear] [nvarchar](50) NULL,
 CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED 
(
	[VehicleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RentalOrderDetails] ON 

INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (1, N'5/1/2022', N'5/3/2022', N'5/3/2022', 1, N'1')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (2, N'5/5/2022', N'5/7/2022', N'5/7/2022', 2, N'2')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (3, N'5/8/2022', N'5/10/2022', N'5/10/2022', 3, N'3')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (4, N'5/10/2022', N'5/11/2022', N'5/11/2022', 4, N'4')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (5, N'6/1/2022', N'6/4/2022', NULL, 1, N'1')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (6, N'6/1/2022', N'6/3/2022', NULL, 2, N'2')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (7, N'6/24/2022', N'6/29/2022', NULL, 3, N'3')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (8, N'6/26/2022', N'6/30/2022', NULL, 4, N'4')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (9, N'5/15/2022', N'5/17/2022', NULL, 1, N'1')
INSERT [dbo].[RentalOrderDetails] ([OrderID], [PickUpDate], [DropOffDate], [DateOfficiallyReturned], [UserID], [SerialNumber]) VALUES (10, N'5/13/2022', N'5/15/2022', NULL, 2, N'2')
SET IDENTITY_INSERT [dbo].[RentalOrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserRole], [FullName], [ID], [Username], [BirthDate], [Gender], [Email], [Password], [ProfilePicture]) VALUES (1, N'admin', N'admin', N'000000000', N'admin', N'admin', N'other', N'admin@gmail.com', N'admin', NULL)
INSERT [dbo].[Users] ([UserID], [UserRole], [FullName], [ID], [Username], [BirthDate], [Gender], [Email], [Password], [ProfilePicture]) VALUES (2, N'standard', N'Omari Gibbons', N'123456789', N'Gibbondigo', N'2/10/2000', N'male', N'OmariGibbons@gmail.com', N'1234', NULL)
INSERT [dbo].[Users] ([UserID], [UserRole], [FullName], [ID], [Username], [BirthDate], [Gender], [Email], [Password], [ProfilePicture]) VALUES (3, N'standard', N'Devnote Lim', N'542359394', N'DenmarkLimbo', N'2/6/1999', N'female', N'DevnoteLim@gmail.com', N'1234', NULL)
INSERT [dbo].[Users] ([UserID], [UserRole], [FullName], [ID], [Username], [BirthDate], [Gender], [Email], [Password], [ProfilePicture]) VALUES (4, N'standard', N'Emer Mayo', N'123412412', N'Mayonnaise', N'1/1/1999', N'other', N'EmerMayo@gmail.com', N'1234', NULL)
INSERT [dbo].[Users] ([UserID], [UserRole], [FullName], [ID], [Username], [BirthDate], [Gender], [Email], [Password], [ProfilePicture]) VALUES (5, N'standard', N'RidaWebster', N'123123124', N'WebsterRampa', N'6/5/2001', N'female', N'RidaWebster@gmail.com', N'1234', NULL)
INSERT [dbo].[Users] ([UserID], [UserRole], [FullName], [ID], [Username], [BirthDate], [Gender], [Email], [Password], [ProfilePicture]) VALUES (6, N'standard', N'ElmalexanderAunder', N'784678467', N'Aumderarms', N'6/8/2004', N'male', N'ElmalexanderAunder@gmail.com', N'1234', NULL)
INSERT [dbo].[Users] ([UserID], [UserRole], [FullName], [ID], [Username], [BirthDate], [Gender], [Email], [Password], [ProfilePicture]) VALUES (7, N'employee', N'Hayecackle Dumblehaye', N'546367635', N'HayeTwinkle', N'1/23/2003', N'female', N'HayecackleDumblehaye@gmail.com', N'1234', NULL)
INSERT [dbo].[Users] ([UserID], [UserRole], [FullName], [ID], [Username], [BirthDate], [Gender], [Email], [Password], [ProfilePicture]) VALUES (8, N'employee', N'Lilmark Zuckerbudall', N'456345643', N'Zuckerstinkie', N'11/13/2002', N'other', N'LilmarkZuckerbudall@gmail.com', N'1234', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleInventory] ON 

INSERT [dbo].[VehicleInventory] ([VehicleID], [VehicleTypeID], [Kilometers], [CarPhotograph], [Operational], [Available], [SerialNumber]) VALUES (1, 1, 20000, 1, 1, 1, N'1')
INSERT [dbo].[VehicleInventory] ([VehicleID], [VehicleTypeID], [Kilometers], [CarPhotograph], [Operational], [Available], [SerialNumber]) VALUES (2, 2, 30000, 1, 1, 1, N'2')
INSERT [dbo].[VehicleInventory] ([VehicleID], [VehicleTypeID], [Kilometers], [CarPhotograph], [Operational], [Available], [SerialNumber]) VALUES (3, 3, 90000, 1, 1, 1, N'3')
INSERT [dbo].[VehicleInventory] ([VehicleID], [VehicleTypeID], [Kilometers], [CarPhotograph], [Operational], [Available], [SerialNumber]) VALUES (4, 4, 50000, 1, 1, 1, N'4')
INSERT [dbo].[VehicleInventory] ([VehicleID], [VehicleTypeID], [Kilometers], [CarPhotograph], [Operational], [Available], [SerialNumber]) VALUES (5, 5, 35000, 1, 1, 1, N'5')
SET IDENTITY_INSERT [dbo].[VehicleInventory] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleType] ON 

INSERT [dbo].[VehicleType] ([VehicleTypeID], [BrandName], [Model], [CostPerDay], [CostPerDayDelayed], [DateManufactured], [Gear]) VALUES (1, N'Nissan', N'Micra', CAST(60 AS Decimal(18, 0)), CAST(90 AS Decimal(18, 0)), N'2017', N'automatic')
INSERT [dbo].[VehicleType] ([VehicleTypeID], [BrandName], [Model], [CostPerDay], [CostPerDayDelayed], [DateManufactured], [Gear]) VALUES (2, N'Volkswagen', N'Super Beetle', CAST(100 AS Decimal(18, 0)), CAST(150 AS Decimal(18, 0)), N'1938', N'manual')
INSERT [dbo].[VehicleType] ([VehicleTypeID], [BrandName], [Model], [CostPerDay], [CostPerDayDelayed], [DateManufactured], [Gear]) VALUES (3, N'Jeep', N'Wrangler', CAST(90 AS Decimal(18, 0)), CAST(135 AS Decimal(18, 0)), N'1986', N'manual')
INSERT [dbo].[VehicleType] ([VehicleTypeID], [BrandName], [Model], [CostPerDay], [CostPerDayDelayed], [DateManufactured], [Gear]) VALUES (4, N'Tesla', N'Cyber Truck', CAST(150 AS Decimal(18, 0)), CAST(225 AS Decimal(18, 0)), N'2022', N'automatic')
INSERT [dbo].[VehicleType] ([VehicleTypeID], [BrandName], [Model], [CostPerDay], [CostPerDayDelayed], [DateManufactured], [Gear]) VALUES (5, N'Fiat', N'Polski 126P', CAST(25 AS Decimal(18, 0)), CAST(38 AS Decimal(18, 0)), N'1991', N'manual')
SET IDENTITY_INSERT [dbo].[VehicleType] OFF
GO
USE [master]
GO
ALTER DATABASE [CarRentalDatabase] SET  READ_WRITE 
GO
