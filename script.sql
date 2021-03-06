USE [master]
GO
/****** Object:  Database [webcaycanh]    Script Date: 8/28/2021 9:25:07 PM ******/
CREATE DATABASE [webcaycanh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'webcaycanh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\webcaycanh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'webcaycanh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\webcaycanh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [webcaycanh] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [webcaycanh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [webcaycanh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [webcaycanh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [webcaycanh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [webcaycanh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [webcaycanh] SET ARITHABORT OFF 
GO
ALTER DATABASE [webcaycanh] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [webcaycanh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [webcaycanh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [webcaycanh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [webcaycanh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [webcaycanh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [webcaycanh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [webcaycanh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [webcaycanh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [webcaycanh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [webcaycanh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [webcaycanh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [webcaycanh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [webcaycanh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [webcaycanh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [webcaycanh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [webcaycanh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [webcaycanh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [webcaycanh] SET  MULTI_USER 
GO
ALTER DATABASE [webcaycanh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [webcaycanh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [webcaycanh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [webcaycanh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [webcaycanh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [webcaycanh] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [webcaycanh] SET QUERY_STORE = OFF
GO
USE [webcaycanh]
GO
/****** Object:  Schema [webcaycanh]    Script Date: 8/28/2021 9:25:07 PM ******/
CREATE SCHEMA [webcaycanh]
GO
/****** Object:  Table [webcaycanh].[tbl_category]    Script Date: 8/28/2021 9:25:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [webcaycanh].[tbl_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NULL,
	[created_date] [datetime2](6) NULL,
	[status] [binary](1) NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime2](6) NULL,
	[description] [nvarchar](100) NULL,
	[name] [nvarchar](255) NOT NULL,
	[seo] [nvarchar](100) NOT NULL,
	[parent_id] [int] NULL,
	[avatar] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_category_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [webcaycanh].[tbl_contact]    Script Date: 8/28/2021 9:25:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [webcaycanh].[tbl_contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NULL,
	[created_date] [datetime2](6) NULL,
	[status] [binary](1) NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime2](6) NULL,
	[email] [nvarchar](45) NOT NULL,
	[first_name] [nvarchar](45) NOT NULL,
	[last_name] [nvarchar](45) NOT NULL,
	[message] [nvarchar](1000) NOT NULL,
	[request_type] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_tbl_contact_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [webcaycanh].[tbl_product]    Script Date: 8/28/2021 9:25:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [webcaycanh].[tbl_product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NULL,
	[created_date] [datetime2](6) NULL,
	[status] [binary](1) NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime2](6) NULL,
	[avatar] [nvarchar](200) NULL,
	[detail_description] [nvarchar](max) NOT NULL,
	[price] [decimal](13, 2) NULL,
	[price_sale] [decimal](19, 2) NULL,
	[seo] [nvarchar](1000) NULL,
	[short_description] [nvarchar](3000) NOT NULL,
	[title] [nvarchar](1000) NOT NULL,
	[category_id] [int] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_tbl_product_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [webcaycanh].[tbl_products_images]    Script Date: 8/28/2021 9:25:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [webcaycanh].[tbl_products_images](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NULL,
	[created_date] [datetime2](6) NULL,
	[status] [binary](1) NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime2](6) NULL,
	[path] [nvarchar](200) NOT NULL,
	[title] [nvarchar](500) NOT NULL,
	[product_id] [int] NOT NULL,
 CONSTRAINT [PK_tbl_products_images_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [webcaycanh].[tbl_saleorder]    Script Date: 8/28/2021 9:25:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [webcaycanh].[tbl_saleorder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NULL,
	[created_date] [datetime2](6) NULL,
	[status] [binary](1) NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime2](6) NULL,
	[code] [nvarchar](45) NOT NULL,
	[customer_address] [nvarchar](100) NULL,
	[customer_email] [nvarchar](100) NULL,
	[customer_name] [nvarchar](100) NULL,
	[customer_phone] [nvarchar](100) NULL,
	[seo] [nvarchar](1000) NULL,
	[total] [decimal](13, 2) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_tbl_saleorder_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [webcaycanh].[tbl_saleorder_products]    Script Date: 8/28/2021 9:25:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [webcaycanh].[tbl_saleorder_products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NULL,
	[created_date] [datetime2](6) NULL,
	[status] [binary](1) NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime2](6) NULL,
	[product_id] [int] NOT NULL,
	[saleorder_id] [int] NOT NULL,
	[quatity] [int] NULL,
 CONSTRAINT [PK_tbl_saleorder_products_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [webcaycanh].[tbl_user]    Script Date: 8/28/2021 9:25:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [webcaycanh].[tbl_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[created_by] [int] NULL,
	[created_date] [datetime2](6) NULL,
	[status] [binary](1) NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime2](6) NULL,
	[email] [nvarchar](45) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[username] [nvarchar](45) NOT NULL,
	[role] [nvarchar](45) NOT NULL,
	[avatar] [nvarchar](200) NULL,
	[address] [nvarchar](200) NULL,
	[phone] [char](14) NULL,
	[fullname] [nvarchar](200) NULL,
 CONSTRAINT [PK_tbl_user_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [webcaycanh].[tbl_category] ON 

INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (5, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama1', N'cây cảnh phong thủy', N'cây-cảnh-phong-thủy-1629990539892', NULL, N'cay-canh-phong-thuy-255x255.jpg')
INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (7, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama', N'cây cảnh trong nhà', N'cây-cảnh-trong-nhà-1629990624664', NULL, N'cay-canh-trong-nha-255x255.jpg')
INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (8, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama', N'cây cảnh để bàn', N'cây-cảnh-để-bàn-1629990631818', NULL, N'cay-canh-de-ban-255x255.jpg')
INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (9, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama', N'cây cảnh văn phòng', N'cây-cảnh-văn-phòng-1629990640223', NULL, N'cay-canh-van-phong-255x255.jpg')
INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (10, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama', N'cây cảnh loại to', N'cây-cảnh-loại-to-1629990764342', NULL, N'terrarium-255x255.jpg')
INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (11, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama', N'cây cảnh sen đá', N'cây-cảnh-sen-đá-1629990676898', NULL, N'cay-sen-da-255x255.jpg')
INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (12, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama', N'cây thủy sinh', N'cây-thủy-sinh-1629990687157', NULL, N'cay-thuy-sinh-255x255.jpg')
INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (13, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama', N'cây dây leo', N'cây-dây-leo-1629990743591', NULL, N'images.jpg')
INSERT [webcaycanh].[tbl_category] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [description], [name], [seo], [parent_id], [avatar]) VALUES (14, NULL, CAST(N'2021-08-25T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), N'minh sama', N'xương rồng cảnh', N'xương-rồng-cảnh-1629990756038', NULL, N'xuong-rong-255x255.jpg')
SET IDENTITY_INSERT [webcaycanh].[tbl_category] OFF
GO
SET IDENTITY_INSERT [webcaycanh].[tbl_product] ON 

INSERT [webcaycanh].[tbl_product] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [avatar], [detail_description], [price], [price_sale], [seo], [short_description], [title], [category_id], [quantity]) VALUES (1, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-27T00:00:00.0000000' AS DateTime2), N'cay-mini-monstera-400x400.jpg', N'Có lẽ trong thời gian vừa qua', CAST(249000.00 AS Decimal(13, 2)), CAST(0.00 AS Decimal(19, 2)), N'Cây-Mini-Monstera-1630030300061', N'Cây Mini Monstera khá nổi bật với những chiếc lá xanh đậm và khuyết. Cây không cần chậu quá to chính vì thế cây rất phù hợp để trang trí những góc nhỏ trong nhà, quán cà phê, quà tặng...', N'Cây Mini Monstera', 7, 10)
INSERT [webcaycanh].[tbl_product] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [avatar], [detail_description], [price], [price_sale], [seo], [short_description], [title], [category_id], [quantity]) VALUES (2, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-27T00:00:00.0000000' AS DateTime2), N'cay-truc-quan-tu-400x400.jpg', N'quân tử', CAST(75000.00 AS Decimal(13, 2)), CAST(0.00 AS Decimal(19, 2)), N'Cây-Trúc-Quân-Tử-1630026090751', N'Một trong những loại cây rất thích hợp để trồng hàng rào, thay thế các vách ngăn không gian, vừa thẩm mỹ, vừa lại có tác dụng phòng thủy và giúp không khí trong lành hơn.', N'Cây Trúc Quân Tử', 5, 5)
INSERT [webcaycanh].[tbl_product] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [avatar], [detail_description], [price], [price_sale], [seo], [short_description], [title], [category_id], [quantity]) VALUES (3, NULL, CAST(N'2021-08-26T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-27T00:00:00.0000000' AS DateTime2), N'hinh-dang-5-255x255.jpg', N'cây đế vương', CAST(159000.00 AS Decimal(13, 2)), CAST(0.00 AS Decimal(19, 2)), N'Cây-Đế-Vương-Hoàng-Kim-1630026084528', N'Cây Đế Vương Hoàng Kim là một trong những loại cây cảnh được yêu thích nhất hiện nay bởi vẻ đẹp mới mẻ. Đây cũng là cây phong thủy được ưa chuộng, phù hợp cho mệnh kim và mệnh thủy. Đế vương hoàng kim mang ý nghĩa hanh thông, thăng tiến.', N'Cây Đế Vương Hoàng Kim', 5, 9)
INSERT [webcaycanh].[tbl_product] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [avatar], [detail_description], [price], [price_sale], [seo], [short_description], [title], [category_id], [quantity]) VALUES (14, NULL, CAST(N'2021-08-27T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-27T00:00:00.0000000' AS DateTime2), N'cay-dua-canh-nen.jpg', N'Hình ảnh cây Dứa (cây Thơm) đã không còn xa lạ gì với chúng ta, thì cây Dứa Nến Cảnh (Phong Lộc Hoa) có hình dáng tương đồng với cây Dứa tuy nhiên lá cây Dứa Nến Cảnh có lá mềm hơn, không có gai và thay bằng quả Dứa (trái Thơm) mọc ở giữa thì là bông hoa có màu vàng, màu cam hoặc màu đỏ. Cây thường được trưng và tặng trong dịp tết với ý nghĩa phong thủy mang đến may mắn và tài lộc. Ngoài ra trong phong thủy 12 con giáp thì cây rất hợp với người tuổi Sửu, giúp mang đến vận khí tốt cho gia chủ. Cây Dứa Nến Cảnh phù hợp để bàn, để phòng khách, quầy thu ngân, trang trí quán cafe, làm quà tặng…', CAST(130000.00 AS Decimal(13, 2)), CAST(0.00 AS Decimal(19, 2)), N'Cây-Dứa-Cảnh-Nến-1630026018731', N' hay còn có tên gọi khác như: Cây Phong Lộc Hoa, Cây Ngôi Sao, Cây Dứa Cánh Sen…Cây có tên khoa học là Tillandsia imperalis thuộc họ thực vật Dứa Bromeliaceae có nguồn gốc từ châu Mỹ, nhiều nhất là các nước Mehico và Equador. Cây được trồng rất phổ biến làm cây cảnh nội thất ở nước ta.', N'Cây Dứa Cảnh Nến', 12, 3)
SET IDENTITY_INSERT [webcaycanh].[tbl_product] OFF
GO
SET IDENTITY_INSERT [webcaycanh].[tbl_user] ON 

INSERT [webcaycanh].[tbl_user] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [email], [password], [username], [role], [avatar], [address], [phone], [fullname]) VALUES (3, NULL, NULL, NULL, NULL, NULL, N'minhsama2k@gmail.com', N'minhsama', N'minhsama2k', N'user', NULL, NULL, NULL, NULL)
INSERT [webcaycanh].[tbl_user] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [email], [password], [username], [role], [avatar], [address], [phone], [fullname]) VALUES (4, NULL, NULL, NULL, NULL, NULL, N'minhsama2000@gmail.com', N'minhsama', N'minhsama2000', N'admin', NULL, NULL, NULL, NULL)
INSERT [webcaycanh].[tbl_user] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [email], [password], [username], [role], [avatar], [address], [phone], [fullname]) VALUES (5, NULL, NULL, NULL, NULL, NULL, N'minhsama1@gmail.com', N'minh', N'sadsad', N'user', NULL, NULL, NULL, NULL)
INSERT [webcaycanh].[tbl_user] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [email], [password], [username], [role], [avatar], [address], [phone], [fullname]) VALUES (6, NULL, NULL, NULL, NULL, NULL, N'minhsama2000@gmail.com', N'minh', N'hello', N'user', N'145341395_3038980546360663_2425006093442758408_n.jpg', N'ha noi', N'84962177082   ', N'Nguyễn Quang Minh1232')
INSERT [webcaycanh].[tbl_user] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [email], [password], [username], [role], [avatar], [address], [phone], [fullname]) VALUES (7, NULL, NULL, NULL, NULL, NULL, N'netflix881@saidiait.com', N'minhsama', N'minhsama0', N'user', NULL, NULL, NULL, NULL)
INSERT [webcaycanh].[tbl_user] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [email], [password], [username], [role], [avatar], [address], [phone], [fullname]) VALUES (8, NULL, CAST(N'2021-08-27T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, N'usa@gmail.com', N'provip', N'world', N'user', NULL, N'ha nam', N'0962177082    ', NULL)
INSERT [webcaycanh].[tbl_user] ([id], [created_by], [created_date], [status], [updated_by], [updated_date], [email], [password], [username], [role], [avatar], [address], [phone], [fullname]) VALUES (9, NULL, CAST(N'2021-08-28T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2021-08-28T00:00:00.0000000' AS DateTime2), N'minhsama1@gmail.com', N'vuong', N'vuong2k', N'user', N'145341395_3038980546360663_2425006093442758408_n.jpg', N'nghe an', N'32421423      ', N'vuong oc cho')
SET IDENTITY_INSERT [webcaycanh].[tbl_user] OFF
GO
/****** Object:  Index [FK6l2kfyw1kbyobvyqiwsrkc2g6]    Script Date: 8/28/2021 9:25:07 PM ******/
CREATE NONCLUSTERED INDEX [FK6l2kfyw1kbyobvyqiwsrkc2g6] ON [webcaycanh].[tbl_category]
(
	[parent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [FKl5l3hu2fh1ixbx8ejat9df13p]    Script Date: 8/28/2021 9:25:07 PM ******/
CREATE NONCLUSTERED INDEX [FKl5l3hu2fh1ixbx8ejat9df13p] ON [webcaycanh].[tbl_product]
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [FKjac7pn534bktj4tvkxqvydglf]    Script Date: 8/28/2021 9:25:07 PM ******/
CREATE NONCLUSTERED INDEX [FKjac7pn534bktj4tvkxqvydglf] ON [webcaycanh].[tbl_products_images]
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [FKbiu8ui4krw8j3gtn97w3rdq7v]    Script Date: 8/28/2021 9:25:07 PM ******/
CREATE NONCLUSTERED INDEX [FKbiu8ui4krw8j3gtn97w3rdq7v] ON [webcaycanh].[tbl_saleorder]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [FKnpyir3q973iv4wq49ltw0kcrd]    Script Date: 8/28/2021 9:25:07 PM ******/
CREATE NONCLUSTERED INDEX [FKnpyir3q973iv4wq49ltw0kcrd] ON [webcaycanh].[tbl_saleorder_products]
(
	[saleorder_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [FKnyfdau9vc46jkiwvrgj1ns85v]    Script Date: 8/28/2021 9:25:07 PM ******/
CREATE NONCLUSTERED INDEX [FKnyfdau9vc46jkiwvrgj1ns85v] ON [webcaycanh].[tbl_saleorder_products]
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [webcaycanh].[tbl_category] ADD  DEFAULT (NULL) FOR [created_by]
GO
ALTER TABLE [webcaycanh].[tbl_category] ADD  DEFAULT (NULL) FOR [created_date]
GO
ALTER TABLE [webcaycanh].[tbl_category] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [webcaycanh].[tbl_category] ADD  DEFAULT (NULL) FOR [updated_by]
GO
ALTER TABLE [webcaycanh].[tbl_category] ADD  DEFAULT (NULL) FOR [updated_date]
GO
ALTER TABLE [webcaycanh].[tbl_category] ADD  DEFAULT (NULL) FOR [description]
GO
ALTER TABLE [webcaycanh].[tbl_category] ADD  DEFAULT (NULL) FOR [parent_id]
GO
ALTER TABLE [webcaycanh].[tbl_contact] ADD  DEFAULT (NULL) FOR [created_by]
GO
ALTER TABLE [webcaycanh].[tbl_contact] ADD  DEFAULT (NULL) FOR [created_date]
GO
ALTER TABLE [webcaycanh].[tbl_contact] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [webcaycanh].[tbl_contact] ADD  DEFAULT (NULL) FOR [updated_by]
GO
ALTER TABLE [webcaycanh].[tbl_contact] ADD  DEFAULT (NULL) FOR [updated_date]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [created_by]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [created_date]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [updated_by]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [updated_date]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [avatar]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [price]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [price_sale]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [seo]
GO
ALTER TABLE [webcaycanh].[tbl_product] ADD  DEFAULT (NULL) FOR [category_id]
GO
ALTER TABLE [webcaycanh].[tbl_products_images] ADD  DEFAULT (NULL) FOR [created_by]
GO
ALTER TABLE [webcaycanh].[tbl_products_images] ADD  DEFAULT (NULL) FOR [created_date]
GO
ALTER TABLE [webcaycanh].[tbl_products_images] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [webcaycanh].[tbl_products_images] ADD  DEFAULT (NULL) FOR [updated_by]
GO
ALTER TABLE [webcaycanh].[tbl_products_images] ADD  DEFAULT (NULL) FOR [updated_date]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [created_by]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [created_date]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [updated_by]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [updated_date]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [customer_address]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [customer_email]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [customer_name]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [customer_phone]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [seo]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [total]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] ADD  DEFAULT (NULL) FOR [user_id]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products] ADD  DEFAULT (NULL) FOR [created_by]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products] ADD  DEFAULT (NULL) FOR [created_date]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products] ADD  DEFAULT (NULL) FOR [updated_by]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products] ADD  DEFAULT (NULL) FOR [updated_date]
GO
ALTER TABLE [webcaycanh].[tbl_user] ADD  DEFAULT (NULL) FOR [created_by]
GO
ALTER TABLE [webcaycanh].[tbl_user] ADD  DEFAULT (NULL) FOR [created_date]
GO
ALTER TABLE [webcaycanh].[tbl_user] ADD  DEFAULT (NULL) FOR [status]
GO
ALTER TABLE [webcaycanh].[tbl_user] ADD  DEFAULT (NULL) FOR [updated_by]
GO
ALTER TABLE [webcaycanh].[tbl_user] ADD  DEFAULT (NULL) FOR [updated_date]
GO
ALTER TABLE [webcaycanh].[tbl_category]  WITH CHECK ADD  CONSTRAINT [tbl_category$FK6l2kfyw1kbyobvyqiwsrkc2g6] FOREIGN KEY([parent_id])
REFERENCES [webcaycanh].[tbl_category] ([id])
GO
ALTER TABLE [webcaycanh].[tbl_category] CHECK CONSTRAINT [tbl_category$FK6l2kfyw1kbyobvyqiwsrkc2g6]
GO
ALTER TABLE [webcaycanh].[tbl_product]  WITH CHECK ADD  CONSTRAINT [tbl_product$FKl5l3hu2fh1ixbx8ejat9df13p] FOREIGN KEY([category_id])
REFERENCES [webcaycanh].[tbl_category] ([id])
GO
ALTER TABLE [webcaycanh].[tbl_product] CHECK CONSTRAINT [tbl_product$FKl5l3hu2fh1ixbx8ejat9df13p]
GO
ALTER TABLE [webcaycanh].[tbl_products_images]  WITH CHECK ADD  CONSTRAINT [tbl_products_images$FKjac7pn534bktj4tvkxqvydglf] FOREIGN KEY([product_id])
REFERENCES [webcaycanh].[tbl_product] ([id])
GO
ALTER TABLE [webcaycanh].[tbl_products_images] CHECK CONSTRAINT [tbl_products_images$FKjac7pn534bktj4tvkxqvydglf]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder]  WITH CHECK ADD  CONSTRAINT [tbl_saleorder$FKbiu8ui4krw8j3gtn97w3rdq7v] FOREIGN KEY([user_id])
REFERENCES [webcaycanh].[tbl_user] ([id])
GO
ALTER TABLE [webcaycanh].[tbl_saleorder] CHECK CONSTRAINT [tbl_saleorder$FKbiu8ui4krw8j3gtn97w3rdq7v]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products]  WITH CHECK ADD  CONSTRAINT [tbl_saleorder_products$FKnpyir3q973iv4wq49ltw0kcrd] FOREIGN KEY([saleorder_id])
REFERENCES [webcaycanh].[tbl_saleorder] ([id])
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products] CHECK CONSTRAINT [tbl_saleorder_products$FKnpyir3q973iv4wq49ltw0kcrd]
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products]  WITH CHECK ADD  CONSTRAINT [tbl_saleorder_products$FKnyfdau9vc46jkiwvrgj1ns85v] FOREIGN KEY([product_id])
REFERENCES [webcaycanh].[tbl_product] ([id])
GO
ALTER TABLE [webcaycanh].[tbl_saleorder_products] CHECK CONSTRAINT [tbl_saleorder_products$FKnyfdau9vc46jkiwvrgj1ns85v]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'webcaycanh.tbl_category' , @level0type=N'SCHEMA',@level0name=N'webcaycanh', @level1type=N'TABLE',@level1name=N'tbl_category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'webcaycanh.tbl_contact' , @level0type=N'SCHEMA',@level0name=N'webcaycanh', @level1type=N'TABLE',@level1name=N'tbl_contact'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'webcaycanh.tbl_product' , @level0type=N'SCHEMA',@level0name=N'webcaycanh', @level1type=N'TABLE',@level1name=N'tbl_product'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'webcaycanh.tbl_products_images' , @level0type=N'SCHEMA',@level0name=N'webcaycanh', @level1type=N'TABLE',@level1name=N'tbl_products_images'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'webcaycanh.tbl_saleorder' , @level0type=N'SCHEMA',@level0name=N'webcaycanh', @level1type=N'TABLE',@level1name=N'tbl_saleorder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'webcaycanh.tbl_saleorder_products' , @level0type=N'SCHEMA',@level0name=N'webcaycanh', @level1type=N'TABLE',@level1name=N'tbl_saleorder_products'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'webcaycanh.tbl_user' , @level0type=N'SCHEMA',@level0name=N'webcaycanh', @level1type=N'TABLE',@level1name=N'tbl_user'
GO
USE [master]
GO
ALTER DATABASE [webcaycanh] SET  READ_WRITE 
GO
