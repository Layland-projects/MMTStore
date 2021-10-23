USE MMTShop 
Go

If Object_ID('ProductCategories', 'U') Is Null
	Create Table ProductCategories(
		Id int Identity(1, 1) Not Null Primary Key,
		Name nvarchar(100) Not Null,
		CreatedAt Datetime2 Not Null Default GetUtcDate(),
		CreatedBy nvarchar(100) Not Null,
		UpdatedAt Datetime2 Null,
		UpdatedBy nvarchar(100) Null
		) 

If Object_ID('Currencies', 'U') Is Null
	Create Table Currencies(
		Code nvarchar(10) Not Null Primary Key,
		Name nvarchar(100) Not Null,
		Symbol nvarchar(1) Not Null) 

If Object_ID('Products', 'U') Is Null
	Create Table Products (
		Id int Identity(1, 1) Not Null Primary Key,
		SKU As Concat(Cast(CategoryId as nvarchar(25)), '-',
			Case
				When (Len(Name) < 3) Then Substring(Name, 0, Len(Name))
				Else Substring(Name, 0, 4)
			End,
			'-',
			Cast(Id as nvarchar(25))) Persisted,
		Name nvarchar(100) Not Null,
		Description nvarchar(2000) Null,
		CurrencyCode nvarchar(10) Foreign Key References Currencies(Code),
		Price decimal(9, 6) Not Null,
		CategoryId int Foreign Key References ProductCategories(Id),
		CreatedAt Datetime2 Not Null Default GetUtcDate(),
		CreatedBy nvarchar(100) Not Null,
		UpdatedAt Datetime2 Null,
		UpdatedBy nvarchar(100) Null
		) 

If Object_ID('FeaturedProductCategories', 'U') Is Null
	Create Table FeaturedProductCategories(
		Id int Identity(1, 1) Primary Key,
		CategoryId int Foreign Key References ProductCategories(Id),
		ValidFrom Datetime2 Not Null Default GetUtcDate(),
		ValidUntil DateTime2 Null,
		CreatedAt Datetime2 Not Null Default GetUtcDate(),
		CreatedBy nvarchar(100) Not Null,
		UpdatedAt Datetime2 Null,
		UpdatedBy nvarchar(100) Null
		)

If (Select TOP 1 Code From Currencies) Is Null
	Insert Into Currencies(Code, Name, Symbol)
	Values('GBP', 'Pound Sterling', '£') 

If (Select TOP 1 Id From ProductCategories) Is Null
	Insert Into ProductCategories(Name, CreatedBy)
	Values('Home', 'Seed'),
	('Garden', 'Seed'),
	('Electronics', 'Seed'),
	('Fitness', 'Seed'),
	('Toys', 'Seed') 

If (Select TOP 1 Id From FeaturedProductCategories) Is Null
	Insert Into FeaturedProductCategories(CategoryId, CreatedBy)
	Values(1, 'Seed'),
	(2, 'Seed'),
	(3, 'Seed') 

If (Select TOP 1 Id From Products) Is Null
	Insert Into Products(Name, Description, CurrencyCode, Price, CategoryId, CreatedBy)
	Values('Table', 'A place to put stuff', 'GBP', 129.99, 1, 'Seed'),
	('Chair', 'A thing to sit on', 'GBP', 59.99, 1, 'Seed'),
	('Lawn Mower', 'It Cuts stuff', 'GBP', 59.99, 2, 'Seed'),
	('Wired mouse', 'It just works', 'GBP', 9.99, 3, 'Seed'),
	('Tablet', 'Mobile computing', 'GBP', 130.00, 3, 'Seed'),
	('Treadmill', 'Helps you sweat', 'GBP', 250.00, 4, 'Seed'),
	('Action man', 'He''s an action man', 'GBP', 22.99, 5, 'Seed') 