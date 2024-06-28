USE [master]
GO
/****** Object:  Database [FUExchangeGoods]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[Buyer]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[Cart]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[CartItem]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[Report]    Script Date: 29/06/2024 1:56:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[BuyerID] [int] NULL,
	[SellerID] [int] NULL,
	[Description] [text] NULL,
	[ReportDate] [date] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[Transaction]    Script Date: 29/06/2024 1:56:16 SA ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 29/06/2024 1:56:16 SA ******/
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

INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (1, N'buyer', N'123', N'phong@gmail.com', 1, 0)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (2, N'seller', N'123', N'lam@gmail.com', 1, 1)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (3, N'admin', N'123', N'hong@gmail.com', 1, 2)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (4, N'moderator', N'123', N'minh@gmail.com', 1, 3)
INSERT [dbo].[Account] ([AccountId], [Username], [Password], [Email], [Status], [Role]) VALUES (5, N'seller2', N'123', N'kien@gmail.com', 1, 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Buyer] ON 

INSERT [dbo].[Buyer] ([BuyerID], [UserID]) VALUES (2, 1)
SET IDENTITY_INSERT [dbo].[Buyer] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (1, N'Fashion')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (2, N'Cooking')
INSERT [dbo].[Category] ([CategoryID], [CategoryName]) VALUES (3, N'Electricity')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (1, 1, N'These shoes offer a perfect blend of style and comfort, featuring a modern design that suits any occasion. Made from durable materials, they provide excellent support and long-lasting wear. Whether for casual outings, work, or sports activities, these shoes ensure you stay comfortable and fashionable throughout the day', 25, 10, 1, CAST(N'2022-04-08' AS Date), 1, N'https://5.imimg.com/data5/SELLER/Default/2022/12/UA/WR/FR/28913860/shoes-photo-shoot-service-250x250.jpg')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (2, 1, N'This shirt combines elegance and comfort, making it an ideal choice for any occasion. Crafted from high-quality, breathable fabric, it ensures you stay cool and comfortable all day long. The timeless design and perfect fit make it a versatile addition to your wardrobe, suitable for both casual and formal settings. Elevate your style effortlessly with this must-have shirt', 30, 10, 1, CAST(N'2022-05-08' AS Date), 1, N'https://cdn.vectorstock.com/i/preview-1x/63/59/t-shirts-for-men-flat-icon-isolated-on-white-vector-50326359.jpg')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (3, 2, N'This knife is expertly crafted for precision and durability. Featuring a sharp, high-carbon stainless steel blade, it ensures exceptional cutting performance and longevity. The ergonomic handle provides a comfortable and secure grip, making it ideal for both professional chefs and home cooks. Perfect for all your kitchen needs, from slicing to dicing with ease', 28, 12, 2, CAST(N'2023-05-09' AS Date), 1, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCOxJKCTJlgIl_z8Yzl6ML_jGR-qhqk2__VA&s')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (4, 2, N'This fan is designed to deliver powerful and efficient cooling. With multiple speed settings, it allows you to customize airflow to your preference. The quiet operation ensures it won''t disrupt your environment, making it perfect for bedrooms, offices, and living spaces. Its sleek and compact design blends seamlessly with any decor, providing comfort and style', 15, 15, 3, CAST(N'2021-04-09' AS Date), 1, N'https://5.imimg.com/data5/SELLER/Default/2023/11/357889801/KR/II/NS/145038801/electric-table-fan-250x250.jpg')
INSERT [dbo].[Product] ([ProductID], [SellerID], [Description], [Price], [Quantity], [CategoryID], [DatePosted], [Status], [image]) VALUES (5, 1, N'This refrigerator offers ample storage space with adjustable shelves and bins to accommodate all your groceries. Equipped with advanced cooling technology, it maintains optimal freshness for your food. The sleek, energy-efficient design not only saves on utility bills but also complements any kitchen decor. A perfect blend of functionality and style', 16, 10, 3, CAST(N'2020-05-15' AS Date), 1, N'https://5.imimg.com/data5/SELLER/Default/2023/9/346840235/BP/QZ/KC/10087404/whirlpool-665-ltr-21183-four-door-refrigerator-250x250.jpg')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Seller] ON 

INSERT [dbo].[Seller] ([SellerID], [UserID]) VALUES (1, 2)
INSERT [dbo].[Seller] ([SellerID], [UserID]) VALUES (2, 5)
SET IDENTITY_INSERT [dbo].[Seller] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (1, 1, N'Phong', NULL, N'HN')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (2, 2, N'Lam', NULL, N'DN')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (3, 3, N'Hong', NULL, N'CM')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (4, 4, N'Minh', NULL, N'BG')
INSERT [dbo].[User] ([UserId], [AccountId], [FirstName], [LastName], [Address]) VALUES (5, 5, N'Kien', NULL, N'BN')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [UQ__CartItem__B40CC6EC969D513D]    Script Date: 29/06/2024 1:56:17 SA ******/
ALTER TABLE [dbo].[CartItem] ADD UNIQUE NONCLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Order__B40CC6EC820043E9]    Script Date: 29/06/2024 1:56:17 SA ******/
ALTER TABLE [dbo].[Order] ADD UNIQUE NONCLUSTERED 
(
	[ProductID] ASC
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
ALTER TABLE [dbo].[Report]  WITH CHECK ADD FOREIGN KEY([BuyerID])
REFERENCES [dbo].[Buyer] ([BuyerID])
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD FOREIGN KEY([SellerID])
REFERENCES [dbo].[Seller] ([SellerID])
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
