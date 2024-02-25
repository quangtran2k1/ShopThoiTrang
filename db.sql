CREATE DATABASE [ShopThoiTrang]
GO

USE [ShopThoiTrang]
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
	[Orders] [int] NULL,
	[Metakey] [nvarchar](max) NOT NULL,
	[Metadesc] [nvarchar](max) NOT NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL,
	[Updated_At] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Categorys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL,
	[Updated_At] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menus]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Table] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[Orders] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Qty] [int] NOT NULL,
	[Amount] [float] NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[Created_At] [datetime] NOT NULL,
	[Updated_By] [int] NULL,
	[Updated_At] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopicId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Metakey] [nvarchar](max) NOT NULL,
	[Metadesc] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL,
	[Updated_At] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NOT NULL,
	[Metakey] [nvarchar](max) NOT NULL,
	[Metadesc] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NULL,
	[Number] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Pricesale] [float] NOT NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL,
	[Updated_At] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Link] [nvarchar](max) NOT NULL,
	[Img] [nvarchar](max) NULL,
	[Orders] [int] NOT NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL,
	[Updated_At] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topics]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[ParentId] [int] NOT NULL,
	[Orders] [int] NOT NULL,
	[Metakey] [nvarchar](max) NOT NULL,
	[Metadesc] [nvarchar](max) NOT NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL,
	[Updated_At] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 16/4/2023 11:43:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[rePassword] [nvarchar](max) NOT NULL,
	[oldPassword] [nvarchar](max) NULL,
	[Img] [nvarchar](max) NULL,
	[Roles] [nvarchar](max) NULL,
	[Created_By] [int] NULL,
	[Created_At] [datetime] NULL,
	[Updated_By] [int] NULL,
	[Updated_At] [datetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categorys] ON 

INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (1, N'Thời trang nam', N'thoi-trang-nam', 0, NULL, N'Thời trang nam', N'Thời trang nam', 1, CAST(N'2022-12-11 23:13:37.950' AS DateTime), 1, CAST(N'2022-12-11 23:13:37.953' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (2, N'Thời trang nữ', N'thoi-trang-nu', 0, 1, N'Thời trang nữ', N'Thời trang nữ', 1, CAST(N'2022-12-11 23:13:55.440' AS DateTime), 1, CAST(N'2022-12-11 23:13:55.440' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (3, N'Thời trang thu đông', N'thoi-trang-thu-dong', 0, 2, N'Thời trang nữ', N'Thời trang nữ', 1, CAST(N'2022-12-11 23:14:22.850' AS DateTime), 1, CAST(N'2022-12-11 23:14:22.850' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (4, N'Giày dép nam', N'giay-dep-nam', 0, 3, N'Giày dép nam', N'Giày dép nam', 1, CAST(N'2022-12-11 23:14:55.140' AS DateTime), 1, CAST(N'2022-12-11 23:14:55.140' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (5, N'Giày dép nữ', N'giay-dep-nu', 0, 4, N'Giày dép nữ', N'Giày dép nữ', 1, CAST(N'2022-12-11 23:15:42.593' AS DateTime), 1, CAST(N'2022-12-11 23:15:42.593' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (6, N'Phụ kiện', N'phu-kien', 0, 5, N'Phụ kiện', N'Phụ kiện', 1, CAST(N'2022-12-11 23:16:00.243' AS DateTime), 1, CAST(N'2022-12-11 23:16:00.243' AS DateTime), 1)
INSERT [dbo].[Categorys] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (7, N'san pham moi', N'san-pham-moi', 0, NULL, N'san pham moi', N'spm', 3, CAST(N'2023-04-15 10:07:19.350' AS DateTime), 3, CAST(N'2023-04-15 10:07:19.350' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Categorys] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Content], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (1, N'test', N'123', N'123', N'test', N'test', 0, CAST(N'2023-04-08 23:26:05.397' AS DateTime), 0, CAST(N'2023-04-08 23:26:05.397' AS DateTime), 1)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Content], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (2, N'a', N'a', N'a', N'a', N'a', 0, CAST(N'2023-04-09 17:55:13.473' AS DateTime), 0, CAST(N'2023-04-09 17:55:13.473' AS DateTime), 1)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Content], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (3, N'Đăng ký nhận thông báo', N'c', N'c', N'Đăng ký nhận thông báo', N'Đăng ký nhận thông báo', 0, CAST(N'2023-04-09 18:39:58.693' AS DateTime), 0, CAST(N'2023-04-09 18:39:58.693' AS DateTime), 1)
INSERT [dbo].[Contacts] ([Id], [FullName], [Email], [Phone], [Title], [Content], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (4, N'quang', N'test@123', N'test', N'test', N'test', 4, CAST(N'2023-04-13 21:06:14.617' AS DateTime), 4, CAST(N'2023-04-13 21:06:14.617' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (1, 1, 9, 450000, 10, 4500000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (2, 2, 9, 450000, 5, 2250000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (3, 2, 7, 750000, 5, 3750000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (4, 2, 2, 350000, 3, 1050000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (5, 2, 8, 550000, 5, 2750000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (6, 2, 6, 300000, 4, 1200000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (7, 2, 4, 350000, 4, 1400000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (8, 3, 8, 550000, 1, 550000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (9, 4, 8, 550000, 1, 550000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Price], [Qty], [Amount]) VALUES (10, 4, 7, 750000, 5, 3750000)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [UserId], [Name], [Phone], [Email], [Note], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (1, 2, N'Quang', N'0123456789', N'0123@gmail.com', N'áđá', CAST(N'2023-04-11 14:28:18.767' AS DateTime), 3, CAST(N'2023-04-11 16:50:47.910' AS DateTime), 2)
INSERT [dbo].[Orders] ([Id], [UserId], [Name], [Phone], [Email], [Note], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (2, 2, N'Quang', N'0123456789', N'0123@gmail.com', N'', CAST(N'2023-04-11 14:28:19.683' AS DateTime), 3, CAST(N'2023-04-11 16:50:47.363' AS DateTime), 2)
INSERT [dbo].[Orders] ([Id], [UserId], [Name], [Phone], [Email], [Note], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (3, 2, N'Quang', N'0123456789', N'0123@gmail.com', N'', CAST(N'2023-04-11 14:28:20.257' AS DateTime), 3, CAST(N'2023-04-11 16:50:46.693' AS DateTime), 2)
INSERT [dbo].[Orders] ([Id], [UserId], [Name], [Phone], [Email], [Note], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (4, 2, N'Quang', N'0123456789', N'0123@gmail.com', N'Giao hàng vào giờ hành chính', CAST(N'2023-04-13 10:51:07.037' AS DateTime), 3, CAST(N'2023-04-13 21:02:38.003' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [TopicId], [Title], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (1, 1, N'Quần áo mùa hè siêu sale', N'quan-ao-mua-he-sieu-sale', N'Quần áo mùa hè siêu sale', N'Quần áo mùa hè siêu sale', N'Quần áo mùa hè siêu sale', N'quan-ao-mua-he-sieu-sale.jpg', 1, CAST(N'2023-04-10 16:59:44.000' AS DateTime), 3, CAST(N'2023-04-11 21:17:30.407' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (1, 1, N'Áo khoác kaki hai lớp mangto', N'ao-khoac-kaki-hai-lop-mangto', N'Áo khoác kaki hai lớp mangto', N'Áo khoác kaki hai lớp mangto', N'Áo khoác kaki hai lớp mangto', N'ao-khoac-kaki-hai-lop-mangto.jpg', 123432, 450000, 400000, 1, CAST(N'2022-12-11 23:18:30.947' AS DateTime), 1, CAST(N'2022-12-11 23:18:30.947' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (2, 1, N'Áo thun nam giarasv', N'ao-thun-nam-giarasv', N'Áo thun nam giarasv', N'Áo thun nam giarasv', N'Áo thun nam giarasv', N'ao-thun-nam-giarasv.jpg', 34234, 350000, 275000, 1, CAST(N'2022-12-11 23:19:22.120' AS DateTime), 1, CAST(N'2022-12-11 23:19:22.120' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (3, 2, N'Áo vest công sở', N'ao-vest-cong-so', N'Áo vest công sở', N'Áo vest công sở', N'Áo vest công sở', N'ao-vest-cong-so.jpg', 34234, 425000, 350000, 1, CAST(N'2022-12-11 23:20:01.740' AS DateTime), 1, CAST(N'2022-12-11 23:20:01.740' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (4, 2, N'Đầm thời trang công sở', N'dam-thoi-trang-cong-so', N'Đầm thời trang công sở', N'Đầm thời trang công sở', N'Đầm thời trang công sở', N'dam-thoi-trang-cong-so.jpg', 5252, 350000, 300000, 1, CAST(N'2022-12-11 23:20:40.513' AS DateTime), 1, CAST(N'2022-12-11 23:20:40.513' AS DateTime), 1)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (5, 6, N'Đồng hồ nam Economicxi', N'dong-ho-nam-economicxi', N'Đồng hồ nam Economicxi', N'Đồng hồ nam Economicxi', N'Đồng hồ nam Economicxi', N'dong-ho-nam-economicxi.jpg', 12314, 550000, 450000, 1, CAST(N'2022-12-11 23:21:25.057' AS DateTime), 4, CAST(N'2023-04-13 21:04:52.897' AS DateTime), 2)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (6, 5, N'Giày cao gót nữ', N'giay-cao-got-nu', N'Giày cao gót nữ', N'Giày cao gót nữ', N'Giày cao gót nữ', N'giay-cao-got-nu.jpg', 12312, 300000, 225000, 1, CAST(N'2022-12-11 23:22:39.000' AS DateTime), 4, CAST(N'2023-04-13 21:04:47.907' AS DateTime), 2)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (7, 4, N'Giày da nam cao cấp', N'giay-da-nam-cao-cap', N'Giày da nam cao cấp', N'Giày da nam cao cấp', N'Giày da nam cao cấp', N'giay-da-nam-cao-cap.jpg', 4321, 750000, 675000, 1, CAST(N'2022-12-11 23:23:31.223' AS DateTime), 4, CAST(N'2023-04-13 21:04:50.120' AS DateTime), 2)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (8, 4, N'Giày da nam cổ thấp', N'giay-da-nam-co-thap', N'Giày da nam cổ thấp', N'Giày da nam cổ thấp', N'Giày da nam cổ thấp', N'giay-da-nam-co-thap.jpg', 31241, 550000, 450000, 1, CAST(N'2022-12-11 23:24:09.293' AS DateTime), 4, CAST(N'2023-04-13 21:04:45.557' AS DateTime), 2)
INSERT [dbo].[Products] ([Id], [CatId], [Name], [Slug], [Detail], [Metakey], [Metadesc], [Img], [Number], [Price], [Pricesale], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (9, 2, N'Quần jean nữ', N'quan-jean-nu', N'Quần jean nữ', N'Quần jean nữ', N'Quần jean nữ', N'quan-jean-nu.png', 21442, 450000, 350000, 1, CAST(N'2022-12-11 23:24:51.000' AS DateTime), 4, CAST(N'2023-04-13 21:04:43.413' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Sliders] ON 

INSERT [dbo].[Sliders] ([Id], [Name], [Link], [Img], [Orders], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (1, N'a', N'a', N'a.jpg', 0, 1, CAST(N'2023-04-11 01:00:25.000' AS DateTime), 3, CAST(N'2023-04-14 13:34:03.050' AS DateTime), 2)
INSERT [dbo].[Sliders] ([Id], [Name], [Link], [Img], [Orders], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (2, N'acvc', N'https://www.facebook.com/', N'319880869_1256413284952198_7708248103397401340_n.jpg', 0, 3, CAST(N'2023-04-11 17:52:45.000' AS DateTime), 3, CAST(N'2023-04-15 09:57:58.967' AS DateTime), 2)
INSERT [dbo].[Sliders] ([Id], [Name], [Link], [Img], [Orders], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (3, N'zxcxc', N'https://chat.openai.com/chat', N'zxcxc.jpg', 0, 3, CAST(N'2023-04-11 18:00:47.000' AS DateTime), 3, CAST(N'2023-04-14 13:31:41.737' AS DateTime), 2)
INSERT [dbo].[Sliders] ([Id], [Name], [Link], [Img], [Orders], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (4, N'abc', N'abc', N'abc.jpg', 0, 3, CAST(N'2023-04-13 21:03:31.353' AS DateTime), 3, CAST(N'2023-04-14 13:30:11.577' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Sliders] OFF
SET IDENTITY_INSERT [dbo].[Topics] ON 

INSERT [dbo].[Topics] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (1, N'Hàng hot mùa hè', N'hang-hot-mua-he', 0, 0, N'hang-hot, mua-he, quan-ao-he', N'hàng hot, mùa hè, quần áo hè', 0, CAST(N'2023-04-13 10:32:58.677' AS DateTime), 1, CAST(N'2023-04-13 10:32:58.677' AS DateTime), 1)
INSERT [dbo].[Topics] ([Id], [Name], [Slug], [ParentId], [Orders], [Metakey], [Metadesc], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (2, N'Hàng hot mùa đông', N'hang-hot-mua-dong', 0, 0, N'mua-dong', N'Mùa đông', 3, CAST(N'2023-04-13 10:36:18.810' AS DateTime), 1, CAST(N'2023-04-13 21:02:19.507' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Topics] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FullName], [Email], [Phone], [Address], [Username], [Password], [rePassword], [oldPassword], [Img], [Roles], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (1, N'Trần Nhật Quang', N'trannhatquang107@gmail.com', N'0377092001', NULL, N'admin', N'JdVa0oOqQAr0ZMdtcTwHrQ==', N'JdVa0oOqQAr0ZMdtcTwHrQ==', N'JdVa0oOqQAr0ZMdtcTwHrQ==', N'user-default.jpg', N'Admin', 0, CAST(N'2022-12-11 23:12:21.797' AS DateTime), 0, CAST(N'2022-12-11 23:12:21.797' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FullName], [Email], [Phone], [Address], [Username], [Password], [rePassword], [oldPassword], [Img], [Roles], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (2, N'Quang', N'0123@gmail.com', N'0123456789', N'123141', N'quangtran2k1', N'ICy5YqxZB1uWSwcVLSNLcA==', N'ICy5YqxZB1uWSwcVLSNLcA==', N'ICy5YqxZB1uWSwcVLSNLcA==', N'quang.jpg', N'User', 0, CAST(N'2023-04-09 23:03:36.000' AS DateTime), 2, CAST(N'2023-04-11 18:46:34.377' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FullName], [Email], [Phone], [Address], [Username], [Password], [rePassword], [oldPassword], [Img], [Roles], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (3, N'áđá', N'qwe@xn--d-tfa', N'123131', NULL, N'a', N'xMpCOKC5I4INzFCab3WEmw==', N'xMpCOKC5I4INzFCab3WEmw==', N'JdVa0oOqQAr0ZMdtcTwHrQ==', N'user-default.jpg', N'Admin', 0, CAST(N'2023-04-09 23:03:36.000' AS DateTime), 1, CAST(N'2023-04-11 10:18:30.180' AS DateTime), 1)
INSERT [dbo].[Users] ([Id], [FullName], [Email], [Phone], [Address], [Username], [Password], [rePassword], [oldPassword], [Img], [Roles], [Created_By], [Created_At], [Updated_By], [Updated_At], [Status]) VALUES (4, N'quang', N'quang@mail.com', N'0123', NULL, N'abc', N'xMpCOKC5I4INzFCab3WEmw==', N'xMpCOKC5I4INzFCab3WEmw==', N'xMpCOKC5I4INzFCab3WEmw==', N'user-default.jpg', N'User', 0, CAST(N'2023-04-13 21:04:20.427' AS DateTime), 0, CAST(N'2023-04-13 21:04:20.427' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
