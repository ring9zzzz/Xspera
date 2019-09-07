Insert into Brand(Name,Description) values ('Tech','the information of technology')
Insert into Brand(Name,Description) values ('Book','the information of Books')
Insert into Brand(Name,Description) values ('Car','the information of Cars')
Insert into Brand(Name,Description) values ('Food','the information of Foods')
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


