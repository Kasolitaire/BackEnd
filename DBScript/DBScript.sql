USE [CarRentalDatabase]
GO
/****** Object:  Table [dbo].[RentalOrderDetails]    Script Date: 5/17/2022 11:16:16 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 5/17/2022 11:16:16 AM ******/
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
/****** Object:  Table [dbo].[VehicleInventory]    Script Date: 5/17/2022 11:16:16 AM ******/
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
/****** Object:  Table [dbo].[VehicleType]    Script Date: 5/17/2022 11:16:16 AM ******/
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
