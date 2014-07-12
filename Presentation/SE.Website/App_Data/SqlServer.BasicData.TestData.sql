

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

insert into SkuCategory values('饿了')
insert into SkuCategory values('渴了')

insert into SkuType (SkuCategoryId,Name) values(1,'膨化')
insert into SkuType (SkuCategoryId,Name) values(1,'点心')
insert into SkuType (SkuCategoryId,Name) values(2,'饮料')
insert into SkuType (SkuCategoryId,Name) values(2,'汽水')

insert into SkuUnit values('瓶')
insert into SkuUnit values('袋')
insert into SkuUnit values('盒')

insert into Brand values('王老吉')
insert into Brand values('统一')


insert into Sku (IsPublic,ShopId,SkuCategoryId,SkuTypeId,BrandId,UnitId,Name,SupplierName,Specification,Price,DiscountPrice,ImageFileName)
			values (1,8,2,1,1,1,'商品1','aaa', '600g',3.5,2.0,'a.jpg')
			
insert into Sku (IsPublic,ShopId,SkuCategoryId,SkuTypeId,BrandId,UnitId,Name,SupplierName,Specification,Price,DiscountPrice,ImageFileName)
			values (1,8,2,1,1,1,'商品2','aaa', '600g',3.5,2.0,'a.jpg')
insert into Sku (IsPublic,ShopId,SkuCategoryId,SkuTypeId,BrandId,UnitId,Name,SupplierName,Specification,Price,DiscountPrice,ImageFileName)
			values (1,8,2,1,1,1,'商品3','aaa', '600g',3.5,2.0,'a.jpg')						

insert into RecipientAddress (CustomerId,DetailAddress)values(1,'天安门广场')
insert into RecipientAddress (CustomerId,DetailAddress)values(2,'保利嘉园3号楼')



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
