

insert into Community(CountyId,FirstLetter,Name)
values(1,'a','Abc')

declare @i int = 1
while @i < 10
begin
	insert into Account(LoginName,Password,AccountType)values('test'+cast(@i as varchar),'111111',1)
	insert into Shop(Id,CountyId,IsIntegral,Name)values(@@IDENTITY,1,0,'test'+cast(@i as varchar))	
	set @i = @i + 1
end

insert into Customer (Name,PhoneNumber) values ('zhangsan','13988888888')
insert into Customer (Name,PhoneNumber) values ('lisiaaaa','13988888666')

insert into SkuCategory values('����')
insert into SkuCategory values('����')

insert into SkuType (SkuCategoryId,Name) values(1,'��')
insert into SkuType (SkuCategoryId,Name) values(1,'����')
insert into SkuType (SkuCategoryId,Name) values(2,'����')
insert into SkuType (SkuCategoryId,Name) values(2,'��ˮ')

insert into SkuUnit values('ƿ')
insert into SkuUnit values('��')
insert into SkuUnit values('��')

insert into Brand values('���ϼ�')
insert into Brand values('ͳһ')


insert into Sku (IsPublic,ShopId,SkuCategoryId,SkuTypeId,BrandId,UnitId,Name,SupplierName,Specification,Price,DiscountPrice,ImageFileName)
			values (1,8,2,1,1,1,'��Ʒ1','aaa', '600g',3.5,2.0,'a.jpg')
			
insert into Sku (IsPublic,ShopId,SkuCategoryId,SkuTypeId,BrandId,UnitId,Name,SupplierName,Specification,Price,DiscountPrice,ImageFileName)
			values (1,8,2,1,1,1,'��Ʒ2','aaa', '600g',3.5,2.0,'a.jpg')
insert into Sku (IsPublic,ShopId,SkuCategoryId,SkuTypeId,BrandId,UnitId,Name,SupplierName,Specification,Price,DiscountPrice,ImageFileName)
			values (1,8,2,1,1,1,'��Ʒ3','aaa', '600g',3.5,2.0,'a.jpg')						

insert into RecipientAddress (CustomerId,DetailAddress)values(1,'�찲�Ź㳡')
insert into RecipientAddress (CustomerId,DetailAddress)values(2,'������԰3��¥')



insert into OrderHead (Status,OrderNumber,FromDeviceType,ShopId,CustomerId, AddressId)		
values (1,'356467',1,8,1,1)
insert into OrderBody(OrderId,SkuId,Quantity,Price)values(1,1,2,1.5)
insert into OrderBody(OrderId,SkuId,Quantity,Price)values(1,2,1,3.5)

insert into OrderHead (Status,OrderNumber,FromDeviceType,ShopId,CustomerId, AddressId)		
values (1,'3244',1,8,1,1)
insert into OrderBody(OrderId,SkuId,Quantity,Price)values(2,3,2,1.5)

insert into OrderHead (Status,OrderNumber,FromDeviceType,ShopId,CustomerId, AddressId)		
values (1,'3244',1,8,2,1)
insert into OrderBody(OrderId,SkuId,Quantity,Price)values(2,3,4,4.5)


			insert into cashback (customerid,amount) values(1,30)
