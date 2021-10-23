Use MMTShop;
Go

If Object_Id('dbo.sp_Currencies_GetAll') Is Null
	Exec('Create Procedure dbo.sp_Currencies_GetAll As Select 1')
Go
Alter Procedure dbo.sp_Currencies_GetAll 
As Begin
	Select *
	From Currencies
End
Go

If Object_Id('dbo.sp_ProductCategories_GetAll') Is Null
	Exec('Create Procedure dbo.sp_ProductCategories_GetAll As Select 1')
Go
Alter Procedure dbo.sp_ProductCategories_GetAll
As Begin
	Select *
	From ProductCategories
End
Go

If Object_Id('dbo.sp_ProductCategories_GetById') Is Null
	Exec('Create Procedure dbo.sp_ProductCategories_GetById As Select 1')
Go
Alter Procedure dbo.sp_ProductCategories_GetById 
	@id int
As Begin
	Select *
	From ProductCategories
	Where Id = @id
End
Go

If Object_Id('dbo.sp_ProductCategories_GetByName') Is Null
	Exec('Create Procedure dbo.sp_ProductCategories_GetByName As Select 1')
Go
Alter Procedure dbo.sp_ProductCategories_GetByName
	@name nvarchar(100)
As Begin
	Select * 
	From ProductCategories
	Where Name = Ltrim(RTRIM(@name))
End
Go

If Object_Id('dbo.sp_Products_GetFeaturedProducts') Is Null
	Exec('Create Procedure dbo.sp_Products_GetFeaturedProducts As Select 1')
Go
Alter Procedure dbo.sp_Products_GetFeaturedProducts
As Begin
	Select p.*, pc.Name As CategoryName
	From Products p
	Join FeaturedProductCategories fp on fp.CategoryId = p.CategoryId
	Join ProductCategories pc on pc.Id = p.CategoryId
	Where fp.ValidFrom < GETUTCDATE()
	And (fp.ValidUntil is null or fp.ValidUntil > GETUTCDATE()) 
End
Go

If Object_Id('dbo.sp_Products_GetProduct') Is Null
	Exec('Create Procedure dbo.sp_Products_GetProduct As Select 1')
Go
Alter Procedure dbo.sp_Products_GetProduct
	@id int
As Begin
	Select * 
	From Products p
	Where p.Id = @id
End
Go

If Object_Id('dbo.sp_Products_GetProducts') Is Null
	Exec('Create Procedure dbo.sp_Products_GetProducts As Select 1')
Go
Alter Procedure dbo.sp_Products_GetProducts
As Begin
	Select * 
	From Products p
End
Go

If Object_Id('dbo.sp_Products_GetProductsByCategoryId') Is Null
	Exec('Create Procedure dbo.sp_Products_GetProductsByCategoryId As Select 1')
Go
Alter Procedure dbo.sp_Products_GetProductsByCategoryId
	@categoryId int
As Begin
	Select p.*, pc.Name As CategoryName 
	From Products p
	Join ProductCategories pc on pc.Id = p.CategoryId
	Where p.CategoryId = @categoryId
End
Go

If Object_Id('dbo.sp_Products_GetProductsByCategoryName') Is Null
	Exec('Create Procedure dbo.sp_Products_GetProductsByCategoryName As Select 1')
Go
Alter Procedure dbo.sp_Products_GetProductsByCategoryName
	@categoryName int
As Begin
	Select p.*, pc.Name As CategoryName 
	From Products p
	Join ProductCategories pc on pc.Id = p.CategoryId
	Where pc.Name = @categoryName
End
Go

If Type_Id('type_FeaturedProductCreate') Is Null
	Create Type type_FeaturedProductCreate As Table(
		CategoryId int,
		ValidFrom datetime2,
		ValidUntil datetime2 null)

If Object_Id('dbo.sp_FeaturedProductCategories_Add') Is Null
	Exec('Create Procedure dbo.sp_FeaturedProductCategories_Add As Select 1')
Go
Alter Procedure dbo.sp_FeaturedProductCategories_Add
	@timestamp datetime2 = null,
	@username nvarchar(100),
	@data type_FeaturedProductCreate readonly
As Begin
	If (@timestamp is null)
		Set @timestamp = GETUTCDATE()
	Insert Into FeaturedProductCategories(CategoryId, ValidFrom, ValidUntil, CreatedBy, CreatedAt)
	Select CategoryId,
		ValidFrom,
		ValidUntil,
		@username,
		@timestamp
	From @data
End