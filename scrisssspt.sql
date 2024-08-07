USE [master]
GO
/****** Object:  Database [FUExchangeGoods]    Script Date: 07/07/2024 7:09:06 CH ******/
CREATE DATABASE [FUExchangeGoods]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FUExchangeGoods', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FUExchangeGoods.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FUExchangeGoods_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FUExchangeGoods_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FUExchangeGoods] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FUExchangeGoods].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FUExchangeGoods] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET ARITHABORT OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FUExchangeGoods] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FUExchangeGoods] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FUExchangeGoods] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FUExchangeGoods] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET RECOVERY FULL 
GO
ALTER DATABASE [FUExchangeGoods] SET  MULTI_USER 
GO
ALTER DATABASE [FUExchangeGoods] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FUExchangeGoods] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FUExchangeGoods] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FUExchangeGoods] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FUExchangeGoods] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FUExchangeGoods] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FUExchangeGoods', N'ON'
GO
ALTER DATABASE [FUExchangeGoods] SET QUERY_STORE = OFF
GO
USE [FUExchangeGoods]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buyer](
	[BuyerID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BuyerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartItem]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartItem](
	[CartItemID] [int] IDENTITY(1,1) NOT NULL,
	[CartID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserSend] [int] NULL,
	[UserReceive] [int] NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK__Contact__3213E83F901BC97B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[BuyerID] [int] NULL,
	[SellerID] [int] NULL,
	[TransactionID] [int] NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[SellerID] [int] NULL,
	[Description] [text] NULL,
	[Price] [float] NULL,
	[Quantity] [int] NULL,
	[CategoryID] [int] NULL,
	[DatePosted] [date] NULL,
	[Status] [int] NULL,
	[image] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[BuyerID] [int] NULL,
	[SellerID] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[ReportDate] [date] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK__Report__D5BD48E5F505C360] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seller](
	[SellerID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SellerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[BuyerID] [int] NULL,
	[SellerID] [int] NULL,
	[ProductID] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 07/07/2024 7:09:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (2, N'seller', N'123', N'lam@gmail.com', 1, 1)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (3, N'admin', N'123', N'hong@gmail.com', 1, 2)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (4, N'moderator', N'123', N'minh@gmail.com', 0, 3)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (5, N'seller2', N'123', N'kien@gmail.com', 1, 1)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (1008, N'buyer', N'123', N'phongcahaiduong@gmail.com', 1, 0)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (1009, N'buyer2', N'123', N'phong@gmail.com', 1, 0)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (1010, N'admin2', N'1234', N'juju@gmail.com', 1, 2)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (1011, N'mode2', N'123', N'longca2@gmail.com', 1, 3)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Buyer] ON 

INSERT [dbo].[Buyer] ([BuyerID], [UserID]) VALUES (1002, 1008)
INSERT [dbo].[Buyer] ([BuyerID], [UserID]) VALUES (1003, 1009)
SET IDENTITY_INSERT [dbo].[Buyer] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([CartId], [UserId]) VALUES (3, 2)
INSERT [dbo].[Cart] ([CartId], [UserId]) VALUES (4, 3)
INSERT [dbo].[Cart] ([CartId], [UserId]) VALUES (5, 4)
INSERT [dbo].[Cart] ([CartId], [UserId]) VALUES (7, 5)
INSERT [dbo].[Cart] ([CartId], [UserId]) VALUES (10, 1008)
INSERT [dbo].[Cart] ([CartId], [UserId]) VALUES (11, 1009)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[CartItem] ON 

INSERT [dbo].[CartItem] ([CartItemID], [CartID], [ProductID], [Quantity]) VALUES (13, 10, 4, 15)
INSERT [dbo].[CartItem] ([CartItemID], [CartID], [ProductID], [Quantity]) VALUES (14, 11, 1, 10)
INSERT [dbo].[CartItem] ([CartItemID], [CartID], [ProductID], [Quantity]) VALUES (17, 11, 4, 15)
SET IDENTITY_INSERT [dbo].[CartItem] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1, N'Fashion')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (2, N'Cooking')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (3, N'Electricity')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1002, N'Smothie')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1003, N'Smothie Ballon')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([id], [UserSend], [UserReceive], [Message]) VALUES (1, 1008, 2, N'alo')
INSERT [dbo].[Contact] ([id], [UserSend], [UserReceive], [Message]) VALUES (2, 2, 1008, N'hi')
INSERT [dbo].[Contact] ([id], [UserSend], [UserReceive], [Message]) VALUES (3, 1008, 2, N'anh bán quạt không')
INSERT [dbo].[Contact] ([id], [UserSend], [UserReceive], [Message]) VALUES (4, 1008, 2, N'em có đơn hàng bên phía anh,anh xác nhận được không')
INSERT [dbo].[Contact] ([id], [UserSend], [UserReceive], [Message]) VALUES (5, 1008, 5, N'alo anh ơi')
INSERT [dbo].[Contact] ([id], [UserSend], [UserReceive], [Message]) VALUES (6, 1008, 2, N'hi')
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [BuyerID], [SellerID], [TransactionID], [ProductID], [Quantity]) VALUES (1, 1002, 1, 3, 2, 10)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (1, 1, N'These shoes offer a perfect blend of style and comfort, featuring a modern design that suits any occasion. Made from durable materials, they provide excellent support and long-lasting wear. Whether for casual outings, work, or sports activities, these shoes ensure you stay comfortable and fashionable throughout the day', 25, 12, 1, CAST(N'2022-04-08' AS Date), 1, N'https://5.imimg.com/data5/SELLER/Default/2022/12/UA/WR/FR/28913860/shoes-photo-shoot-service-250x250.jpg')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (2, 1, N'This shirt combines elegance and comfort, making it an ideal choice for any occasion. Crafted from high-quality, breathable fabric, it ensures you stay cool and comfortable all day long. The timeless design and perfect fit make it a versatile addition to your wardrobe, suitable for both casual and formal settings. Elevate your style effortlessly with this must-have shirt', 30, 10, 1, CAST(N'2022-05-08' AS Date), 1, N'https://cdn.vectorstock.com/i/preview-1x/63/59/t-shirts-for-men-flat-icon-isolated-on-white-vector-50326359.jpg')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (3, 2, N'This knife is expertly crafted for precision and durability. Featuring a sharp, high-carbon stainless steel blade, it ensures exceptional cutting performance and longevity. The ergonomic handle provides a comfortable and secure grip, making it ideal for both professional chefs and home cooks. Perfect for all your kitchen needs, from slicing to dicing with ease', 28, 12, 2, CAST(N'2023-05-09' AS Date), 1, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCOxJKCTJlgIl_z8Yzl6ML_jGR-qhqk2__VA&s')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (4, 2, N'This fan is designed to deliver powerful and efficient cooling. With multiple speed settings, it allows you to customize airflow to your preference. The quiet operation ensures it won''t disrupt your environment, making it perfect for bedrooms, offices, and living spaces. Its sleek and compact design blends seamlessly with any decor, providing comfort and style', 15, 15, 3, CAST(N'2021-04-09' AS Date), 1, N'https://5.imimg.com/data5/SELLER/Default/2023/11/357889801/KR/II/NS/145038801/electric-table-fan-250x250.jpg')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (5, 1, N'This refrigerator offers ample storage space with adjustable shelves and bins to accommodate all your groceries. Equipped with advanced cooling technology, it maintains optimal freshness for your food. The sleek, energy-efficient design not only saves on utility bills but also complements any kitchen decor. A perfect blend of functionality and style', 16, 10, 3, CAST(N'2020-05-15' AS Date), 1, N'https://5.imimg.com/data5/SELLER/Default/2023/9/346840235/BP/QZ/KC/10087404/whirlpool-665-ltr-21183-four-door-refrigerator-250x250.jpg')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (1008, 2, N'No', 25, 25, 1, CAST(N'2024-07-07' AS Date), 0, N'https://th.bing.com/th?id=OIP.mbmfV7cZ-Tv7IThGLZCFZQHaEm&w=317&h=196&c=8&rs=1&qlt=90&o=6&pid=3.1&rm=2')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Report] ON 

INSERT [dbo].[Report] ([ReportID], [BuyerID], [SellerID], [Description], [ReportDate], [Status]) VALUES (4, 1002, NULL, N'Anh Kiên bán hàng rất láo', CAST(N'2022-04-08' AS Date), 1)
INSERT [dbo].[Report] ([ReportID], [BuyerID], [SellerID], [Description], [ReportDate], [Status]) VALUES (5, NULL, 1, N'Khách hàng tên Phong bùng hàng ', CAST(N'2022-04-08' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Report] OFF
GO
SET IDENTITY_INSERT [dbo].[Seller] ON 

INSERT [dbo].[Seller] ([SellerID], [UserID]) VALUES (1, 2)
INSERT [dbo].[Seller] ([SellerID], [UserID]) VALUES (2, 5)
SET IDENTITY_INSERT [dbo].[Seller] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON 

INSERT [dbo].[Transaction] ([TransactionID], [BuyerID], [SellerID], [ProductID], [Status]) VALUES (3, 1002, 1, 2, 2)
SET IDENTITY_INSERT [dbo].[Transaction] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (2, 2, N'Lam', NULL, N'DN')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (3, 3, N'Hong', NULL, N'CM')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (4, 4, N'Minh', NULL, N'BG')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (5, 5, N'Kien', NULL, N'BN')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (1008, 1008, N'Đoàn', N'Phong', N'HN')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (1009, 1009, N'Đoàn', N'Phong', N'HD')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (1010, 1010, N'Thien', N'Long', N'HN')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (1011, 1011, N'Long Hoang', N'Thien', N'HG')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [UQ__Order__B40CC6EC820043E9]    Script Date: 07/07/2024 7:09:06 CH ******/
ALTER TABLE [dbo].[Order] ADD UNIQUE NONCLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_AccountId]    Script Date: 07/07/2024 7:09:06 CH ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UK_AccountId] UNIQUE NONCLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Buyer]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD FOREIGN KEY([CartID])
REFERENCES [dbo].[Cart] ([CartId])
GO
ALTER TABLE [dbo].[CartItem]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK__Contact__UserSen__72C60C4A] FOREIGN KEY([UserSend])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK__Contact__UserSen__72C60C4A]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK__Contact__UserSen__73BA3083] FOREIGN KEY([UserSend])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK__Contact__UserSen__73BA3083]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([BuyerID])
REFERENCES [dbo].[Buyer] ([BuyerID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([SellerID])
REFERENCES [dbo].[Seller] ([SellerID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([TransactionID])
REFERENCES [dbo].[Transaction] ([TransactionID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([SellerID])
REFERENCES [dbo].[Seller] ([SellerID])
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK__Report__BuyerID__31EC6D26] FOREIGN KEY([BuyerID])
REFERENCES [dbo].[Buyer] ([BuyerID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK__Report__BuyerID__31EC6D26]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK__Report__SellerID__30F848ED] FOREIGN KEY([SellerID])
REFERENCES [dbo].[Seller] ([SellerID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK__Report__SellerID__30F848ED]
GO
ALTER TABLE [dbo].[Seller]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([BuyerID])
REFERENCES [dbo].[Buyer] ([BuyerID])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([SellerID])
REFERENCES [dbo].[Seller] ([SellerID])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
USE [master]
GO
ALTER DATABASE [FUExchangeGoods] SET  READ_WRITE 
GO
