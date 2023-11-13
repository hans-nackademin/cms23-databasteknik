DROP TABLE Products

CREATE TABLE Products (
	[Id] int not null identity primary key,
	[Name] nvarchar(max) not null,
	[Description] nvarchar(max) null,
	[Price] money not null
)

