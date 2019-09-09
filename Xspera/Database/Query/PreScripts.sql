SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Username] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BrandId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[Color] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[DateCreated] [datetime] NOT NULL,
	[AvailableStatus] [int] NOT NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_AvailableStatus]  DEFAULT ((0)) FOR [AvailableStatus]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO



CREATE TABLE [dbo].[Review](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[Email] [nvarchar](30) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_Product]
GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [FK_Review_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK_Review_User]
GO





Insert into Brand(Name,Description) values ('Tech','the information of technology')
Insert into Brand(Name,Description) values ('Book','the information of Books')
Insert into Brand(Name,Description) values ('Car','the information of Cars')
Insert into Brand(Name,Description) values ('Food','the information of Foods')
Insert into Brand(Name,Description) values ('Others','the information of Others')
-----------------------------------------------------------------------------------------------
go
Insert into [User]([Type],Username,Email,DateOfBirth)
values (1,'admin','admin@gmail.com','02-22-1994')
Insert into [User]([Type],Username,Email,DateOfBirth)
values (2,'member','member@gmail.com','02-22-1998')
go
-----------------------------------------------------------------------------------------------
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (1,'Dell Predator',1800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (1,'Dell Insprion',1500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (1,'Apple Watch',1600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (1,'Iphone XS MAX',1100,'red','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (1,'Lenovo WinMax',1200,'black','',DATEADD(day, -3, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (1,'Microservice',1400,'white','',DATEADD(day, -2, GETDATE()),0,1)

-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (4,'Bun bo',50,'','bun bo sai gon',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (4,'Com chien',80,'','com chien binh thanh',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (4,'Hu tiu',90,'','hu tieu go',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (4,'Mi xao gion',100,'','mi xao gion singapor',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (4,'Canh ga chien ',20,'','canh ga chien dai loan',DATEADD(day, -3, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (4,'Bo kho hot vit',120,'','bo kho hot vit binh phuoc',DATEADD(day, -2, GETDATE()),0,1)

-----------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (2,'Nha gia kim',280,'black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (2,'Dac nhan tam',250,'blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (2,'ElonMusk Story',260,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (2,'Pikachu Story',220,'red','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (2,'Captain marvel',220,'black','',DATEADD(day, -3, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (2,'Infinity wars',240,'white','',DATEADD(day, -2, GETDATE()),0,1)
------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (3,'Lamborgini Aventador',3800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (3,'Ferrari Advanced',3500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (3,'Dream Chien',3600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (3,'Exciter VietNam',3300,'red','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (3,'VinFast',3200,'black','',DATEADD(day, -3, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (3,'Suzuki yakamoto',3400,'white','',DATEADD(day, -2, GETDATE()),0,1)
------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Lamborgini Aventador others',5800,'red,black','',DATEADD(day, -7, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Ferrari Advanced others',5500,'red,blue','',DATEADD(day, -6, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Dream Chien others',5600,'white,black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Exciter VietNam others',5500,'red others','',DATEADD(day, -4, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'VinFast',5200,'black','',DATEADD(day, -5, GETDATE()),0,1)
Insert into Product(BrandId,Name,Price,Color,Description,DateCreated,AvailableStatus,CreatedBy)
values (5,'Suzuki yakamoto others',5400,'white','',DATEADD(day, -2, GETDATE()),0,1)
------------------------------------------------------------------------------------------------
go
Insert into Review(ProductId,UserId,Rating,Comment)
values (1,2,5,'Sản phẩm xịn lắm')
Insert into Review(ProductId,UserId,Rating,Comment)
values (10,2,5,'Sản phẩm chất lượng lắm')
Insert into Review(ProductId,UserId,Rating,Comment)
values (9,25,'Sản phẩm mắc quá')
Insert into Review(ProductId,UserId,Rating,Comment)
values (8,2,5,'Sản phẩm rẻ ghê')
Insert into Review(ProductId,UserId,Rating,Comment)
values (7,2,5,'Sản phẩm đẹp hú hồn')


