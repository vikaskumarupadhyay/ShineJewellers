
 

 if  not exists( select *  from sys.objects  where Name='ProductCategory')
Begin
Create table ProductCategory
(
ProductCategoryId int not null identity,
ProductCategoryName varchar(500),
IsActive bit ,
Primary Key (ProductCategoryId)
)
End



 if  not exists( select *  from sys.objects  where Name='ProductSubCategory')
Begin
Create table ProductSubCategory
( 
SubCategoryId int not null identity,
ProductCategoryId int, 
SubCategoryName varchar(500),
IsActive bit,
Primary Key (SubCategoryId),
Foreign Key (ProductCategoryId) References ProductCategory(ProductCategoryId)
 )
 End

 
 if  not exists( select *  from sys.objects  where Name='Findings')
Begin
 Create table Findings
 (
 FindingId int not null identity,
 FindingName varchar(500),
 IsActive bit

 Primary Key (FindingId)
 )
 End


 
 
 
if  not exists( select *  from sys.objects  where Name='Stone')
Begin
Create Table Stone 
(
StoneId int not null identity,
StoneName varchar(500),
IsActive bit

Primary Key (StoneId)
)

End


IF  not exists( select *  from sys.objects  where Name='Product')
Begin

create table Product
(
ProductId int not null identity,
DesignNo varchar(100),
DyeNo varchar(100),
StyleNo varchar(100),
ProductCode varchar(400),
CategoryId int,
SubCategoryId int,
MasterWeight decimal, 
WaxWeight decimal, 
DisplayForB2B bit,
DisplayForB2C bit,
DisplayForB2BExclusive bit,
ExtimatedWeight_14KT decimal,
ExtimatedWeight_18KT decimal,
ExtimatedWeight_22KT decimal,
GrossWeight decimal,
NetWeight decimal,
IsActive bit,
CreatedDate DateTime

Primary Key (ProductId)
)

End

IF  not exists( select *  from sys.objects  where Name='ProductFindingDetails')
Begin
 Create Table ProductFindingDetails
 (
 Id int not null identity,
 ProductId int,
 FindingId int,
 FindingItemValue decimal
 
 Primary Key(Id),
 Foreign Key (ProductId) References Product(ProductId),
 Foreign Key (FindingId) References Findings(FindingId)
 )

 End





IF  not exists( select *  from sys.objects  where Name='StoneAppliedOnProduct')
Begin
Create Table StoneAppliedOnProduct
(
Id int not null identity,
ProductId int ,
StoneId int,
StoneWeight decimal,
DiscountOnStone decimal

Primary Key (Id),
Foreign Key (ProductId) References Product(ProductId),
Foreign Key (StoneId) References Stone(StoneId)

)
End
