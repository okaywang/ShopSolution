	Create database ShopTest10
	go
	use ShopTest10
	--drop table SkuCategory
	
	--省
	create table ChinaProvince(
		Id int not null primary key,
		Name nvarchar(20) not null unique
	)
	
	--市
	create table ChinaCity(
		Id int not null primary key,
		ProvinceId int not null references ChinaProvince,
		Name nvarchar(20) not null unique	
	)
	
	--区县
	create table ChinaCounty(
		Id int not null primary key,
		CityId int not null references ChinaCity,
		Name nvarchar(20) not null
	) 
	
	--账号
	CREATE TABLE [dbo].[Account](
		[Id] [int] IDENTITY(1,1) primary key,
		[LoginName] [nvarchar](50) NOT NULL unique,
		[Password] [nvarchar](50) NOT NULL check(len(password)>=6),
		[AccountType] [int] NOT NULL CHECK(AccountType in (1,2))--1.For admin 2.For shop,
	)
	
	--系统管理人员
	Create Table AdminPerson(
		Id int primary key references Account,
		Name nvarchar(50) NOT NULL unique,
		Department nvarchar(50)
	)

	--商品大分类
	CREATE TABLE SkuCategory(
		Id int IDENTITY(1,1) primary key,
		Name nvarchar(50) not null unique
	)

	--商品小分类
	CREATE TABLE SkuType(
		Id int IDENTITY(1,1) primary key,
		SkuCategoryId int  not null references SkuCategory,
		Name NVARCHAR(50) NOT NULL,
		Constraint UQ_SkuType_SkuCategoryId_Name Unique (SkuCategoryId,Name)
	)  
 
	--品牌
	create table Brand(
		Id int IDENTITY(1,1) primary key,
		Name NVARCHAR(50) NOT NULL unique
	)

	--商店
	create table Shop(
		Id int primary key references Account,
		CountyId int not null references ChinaCounty,
		IsIntegral bit not null default(0),
		CooperationStatus int not null default(0), --open,closed,
		Name nvarchar(50) not null,
		DetailAddress nvarchar(100),
		ContactName nvarchar(20),
		ContactGender int check(ContactGender in(1,2)),
		MobilePhoneNumber nvarchar(11) ,
		TelePhoneNumber nvarchar(20) ,
		DailyOpeningTime time ,
		DailyClosingTime time ,
		DeliveryMinAmount int ,
		DeliveryRate int ,
		ImageFileName nvarchar(200) ,
		ShopOpenDateTime datetime ,
		TemporaryClosingBeginDate date,		 		
		TemporaryClosingEndDate date,
	)
	
	--单位
	create table SkuUnit(
		Id int Identity(1,1) primary key,
		Name nvarchar(5) Not Null unique
	)
	
	
	--商品
	Create table Sku(
		Id int IDENTITY(1,1) primary key,
		IsPublic bit not null,
		ShopId int references Shop,--如果ShopId，代表公共商品
		SkuCategoryId int not null references SkuCategory,
		SkuTypeId int not null references SkuType,
		BrandId int not null references Brand,
		UnitId int not null references SkuUnit,
		Name nvarchar(100) not null,
		SupplierName nvarchar(100) not null,
		Specification nvarchar(50) not null,
		Price decimal(10,2) not null,
		DiscountPrice decimal(10,2) not null,
		ImageFileName nvarchar(50) not null
	)

	--品牌和商品分类
	create table BrandSkuType(
		Id int IDENTITY(1,1)  primary key,
		BrandId int	 not null references Brand,
		SkuTypeId int  not null references SkuType,
		constraint UC_BrandId_SkuTypeId unique(BrandId,SkuTypeId)
	)
	

	--社区/楼宇
	create table Community(
		Id int IDENTITY(1,1) primary key,
		CountyId int not null references ChinaCounty(Id),
		FirstLetter nvarchar(3),
		Name nvarchar(50) not null,
		Longitude float,
		Latitude float,
		Constraint UQ_CountyId_Name unique(CountyId,Name)
	)
	
	
	--社区的送货商店
	create table CommunityShop(
		Id int IDENTITY(1,1) primary key,
		CommunityId int references Community,
		ShopId int references Shop
	)
	
	--会员
	create table Customer(
		Id int IDENTITY(1,1) primary key,
		Name nvarchar(50),
		PhoneNumber nvarchar(11) not null,
	)
	create table CashBack(
		Id int identity(1,1) primary key,
		CustomerId int not null references Customer,
		Amount decimal(10,2)
	)

	--收货地址
	create table RecipientAddress(
		Id int IDENTITY(1,1) primary key,
		CustomerId int not null references Customer,
		DetailAddress nvarchar(100)
	)
	
	--订单头
	create table OrderHead(
		Id int IDENTITY(1,1) primary key,
		Status int not null,
		OrderNumber nvarchar(20) not null,
		FromDeviceType int not null check(FromDeviceType in (1,2)),
		ShopId int not null references Shop,
		CustomerId int not null references Customer,
		AddressId int not null references RecipientAddress,
		TransactionDateTime datetime not null default(getdate()),
		Remarks nvarchar(300)
	)
	
	--订单体
	create table OrderBody(
		Id int IDENTITY(1,1) primary key,
		OrderId int not null references OrderHead,
		SkuId int not null references Sku,
		Quantity int not null,
		Price decimal(10,2) not null
	)
	
	--权限
	create table Authority(
		Id int IDENTITY(1,1) primary key,
		AuthorityType int not null,
		Name nvarchar(20) not null
	)
	
	--用户权限
	create table AccountAuthority(
		Id int IDENTITY(1,1) primary key,
		AccountId int references Account,
		AuthorityId int not null references Authority,
		Constraint UQ_Account_Authority unique(AccountId,AuthorityId)
	)
