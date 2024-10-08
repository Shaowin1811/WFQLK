USE [WFQLK]
GO
/****** Object:  Table [dbo].[Account]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[PassWord] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreaterBy] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[CategoryID] [int] NULL,
	[SupplierID] [int] NULL,
	[ProductName] [nvarchar](50) NULL,
	[Unit] [nvarchar](50) NULL,
	[Price] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierName] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nvarchar](50) NULL,
	[Zipcode] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Note] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([UserID], [UserName], [PassWord]) VALUES (1, N'admin', N'202cb962ac59075b964b07152d234b70')
INSERT [dbo].[Account] ([UserID], [UserName], [PassWord]) VALUES (3, N'123', N'202cb962ac59075b964b07152d234b70')
INSERT [dbo].[Account] ([UserID], [UserName], [PassWord]) VALUES (4, N'nhanvp1', N'202cb962ac59075b964b07152d234b70')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 2', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 2)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 1', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 3)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 3', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 4)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 3', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp1', 1, 8)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 3', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 10)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 3', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 13)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 3', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 16)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 3', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 17)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 3', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 18)
INSERT [dbo].[Category] ([CategoryName], [Description], [CreateDate], [UpdateDate], [CreaterBy], [Status], [CategoryID]) VALUES (N'loại 3', N'123', CAST(N'2024-07-01 15:56:39.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 19)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([CategoryID], [SupplierID], [ProductName], [Unit], [Price], [CreateDate], [UpdateDate], [CreatedBy], [Status], [ProductID]) VALUES (3, 1, N'Áo', N' VNG', N'100000', CAST(N'2024-07-01 15:58:07.000' AS DateTime), CAST(N'2024-07-01 16:40:21.000' AS DateTime), N'nhanvp', 2, 2)
INSERT [dbo].[Product] ([CategoryID], [SupplierID], [ProductName], [Unit], [Price], [CreateDate], [UpdateDate], [CreatedBy], [Status], [ProductID]) VALUES (2, 1, N'Quần', N'VNG', N'120000', CAST(N'2024-07-01 16:05:36.000' AS DateTime), CAST(N'2024-07-01 16:26:35.000' AS DateTime), N'nhanvp', 1, 4)
INSERT [dbo].[Product] ([CategoryID], [SupplierID], [ProductName], [Unit], [Price], [CreateDate], [UpdateDate], [CreatedBy], [Status], [ProductID]) VALUES (2, 1, N'Quần', N'VNG', N'120000', CAST(N'2024-07-01 16:05:36.000' AS DateTime), CAST(N'2024-07-01 16:26:46.000' AS DateTime), N'nhanvp', 1, 5)
INSERT [dbo].[Product] ([CategoryID], [SupplierID], [ProductName], [Unit], [Price], [CreateDate], [UpdateDate], [CreatedBy], [Status], [ProductID]) VALUES (2, 1, N'Quần', N'VNG', N'120000', CAST(N'2024-07-01 16:05:36.000' AS DateTime), CAST(N'2024-07-01 16:26:52.000' AS DateTime), N'nhanvp', 1, 6)
INSERT [dbo].[Product] ([CategoryID], [SupplierID], [ProductName], [Unit], [Price], [CreateDate], [UpdateDate], [CreatedBy], [Status], [ProductID]) VALUES (2, 1, N'Quần11', N'VNG', N'120000', CAST(N'2024-07-01 16:05:36.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 0, 7)
INSERT [dbo].[Product] ([CategoryID], [SupplierID], [ProductName], [Unit], [Price], [CreateDate], [UpdateDate], [CreatedBy], [Status], [ProductID]) VALUES (2, 1, N'áo', N'USD', N'12', CAST(N'2024-07-01 16:39:12.000' AS DateTime), CAST(N'2024-07-01 16:39:45.000' AS DateTime), N'nhanvp', 1, 8)
INSERT [dbo].[Product] ([CategoryID], [SupplierID], [ProductName], [Unit], [Price], [CreateDate], [UpdateDate], [CreatedBy], [Status], [ProductID]) VALUES (2, 1, N'áo111', N'VNG', N'120000', CAST(N'2024-11-30 13:12:04.000' AS DateTime), CAST(N'2024-12-16 13:19:02.000' AS DateTime), N'123', 1, 9)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierName], [ContactName], [Address], [City], [Zipcode], [Country], [Phone], [Note], [CreateDate], [UpdateDate], [CreatedBy], [Status], [SupplierID]) VALUES (N'Nhà cung cấp 1', N'contact 1', N'huế', N'VietTer', N'5000', N'việt nam', N'01111111111', N'123', CAST(N'2024-01-01 00:00:00.000' AS DateTime), CAST(N'2024-01-01 00:00:00.000' AS DateTime), N'nhanvp', 1, 1)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
/****** Object:  StoredProcedure [dbo].[SP_ListCategory_Detail]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListCategory_Detail]
	@SearchStr			NVARCHAR(50)
AS
SET NOCOUNT ON;

SELECT
	C.CategoryID
,	C.CategoryName
,	C.Description
,	C.CreateDate
,	C.UpdateDate
,	C.CreaterBy
,	C.Status
FROM
	Category As C
WHERE
	C.CategoryName LIKE '%' + @SearchStr +'%'
GO
/****** Object:  StoredProcedure [dbo].[SP_ListProduct_Detail]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListProduct_Detail]
	@SearchStr			NVARCHAR(50)
,	@Status				INT
AS
SET NOCOUNT ON;

SELECT
	P.ProductID
,	C.CategoryName
,	S.SupplierName
,	P.ProductName
,	p.Unit
,	P.Price
,	P.CreateDate
,	P.UpdateDate
,	P.CreatedBy
FROM
	Product As P
INNER JOIN
	Category As C
ON
	P.CategoryID = C.CategoryID
INNER JOIN
	Supplier As S
ON
	S.SupplierID = P.SupplierID
WHERE
	P.ProductName LIKE '%' + @SearchStr +'%'
AND	( P.Status = @Status OR @Status = -1)
GO
