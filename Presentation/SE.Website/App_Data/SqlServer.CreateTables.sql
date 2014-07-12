	Create database ShopTest10
	go
	use ShopTest10
	--drop table SkuCategory
	
	--ʡ
	create table ChinaProvince(
		Id int not null primary key,
		Name nvarchar(20) not null unique
	)
	
	--��
	create table ChinaCity(
		Id int not null primary key,
		ProvinceId int not null references ChinaProvince,
		Name nvarchar(20) not null unique	
	)
	
	--����
	create table ChinaCounty(
		Id int not null primary key,
		CityId int not null references ChinaCity,
		Name nvarchar(20) not null
	) 
	
	--�˺�
	CREATE TABLE [dbo].[Account](
		[Id] [int] IDENTITY(1,1) primary key,
		[LoginName] [nvarchar](50) NOT NULL unique,
		[Password] [nvarchar](50) NOT NULL check(len(password)>=6),
		[AccountType] [int] NOT NULL CHECK(AccountType in (1,2))--1.For admin 2.For shop,
	)
	
	--ϵͳ������Ա
	Create Table AdminPerson(
		Id int primary key references Account,
		Name nvarchar(50) NOT NULL unique,
		Department nvarchar(50)
	)

	--��Ʒ�����
	CREATE TABLE SkuCategory(
		Id int IDENTITY(1,1) primary key,
		Name nvarchar(50) not null unique
	)

	--��ƷС����
	CREATE TABLE SkuType(
		Id int IDENTITY(1,1) primary key,
		SkuCategoryId int  not null references SkuCategory,
		Name NVARCHAR(50) NOT NULL,
		Constraint UQ_SkuType_SkuCategoryId_Name Unique (SkuCategoryId,Name)
	)  
 
	--Ʒ��
	create table Brand(
		Id int IDENTITY(1,1) primary key,
		Name NVARCHAR(50) NOT NULL unique
	)

	--�̵�
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
	
	--��λ
	create table SkuUnit(
		Id int Identity(1,1) primary key,
		Name nvarchar(5) Not Null unique
	)
	
	
	--��Ʒ
	Create table Sku(
		Id int IDENTITY(1,1) primary key,
		IsPublic bit not null,
		ShopId int references Shop,--���ShopId����������Ʒ
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

	--Ʒ�ƺ���Ʒ����
	create table BrandSkuType(
		Id int IDENTITY(1,1)  primary key,
		BrandId int	 not null references Brand,
		SkuTypeId int  not null references SkuType,
		constraint UC_BrandId_SkuTypeId unique(BrandId,SkuTypeId)
	)
	

	--����/¥��
	create table Community(
		Id int IDENTITY(1,1) primary key,
		CountyId int not null references ChinaCounty(Id),
		FirstLetter nvarchar(3),
		Name nvarchar(50) not null,
		Longitude float,
		Latitude float,
		Constraint UQ_CountyId_Name unique(CountyId,Name)
	)
	
	
	--�������ͻ��̵�
	create table CommunityShop(
		Id int IDENTITY(1,1) primary key,
		CommunityId int references Community,
		ShopId int references Shop
	)
	
	--��Ա
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

	--�ջ���ַ
	create table RecipientAddress(
		Id int IDENTITY(1,1) primary key,
		CustomerId int not null references Customer,
		DetailAddress nvarchar(100)
	)
	
	--����ͷ
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
	
	--������
	create table OrderBody(
		Id int IDENTITY(1,1) primary key,
		OrderId int not null references OrderHead,
		SkuId int not null references Sku,
		Quantity int not null,
		Price decimal(10,2) not null
	)
	
	--Ȩ��
	create table Authority(
		Id int IDENTITY(1,1) primary key,
		AuthorityType int not null,
		Name nvarchar(20) not null
	)
	
	--�û�Ȩ��
	create table AccountAuthority(
		Id int IDENTITY(1,1) primary key,
		AccountId int references Account,
		AuthorityId int not null references Authority,
		Constraint UQ_Account_Authority unique(AccountId,AuthorityId)
	)
