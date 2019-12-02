CREATE DATABASE ProductsBlazorDatabase;
GO

USE ProductsBlazorDatabase;
GO

CREATE TABLE Category(
	CategoryId INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(max) NOT NULL
);
GO

CREATE TABLE Product(
	ProductId INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(max) NOT NULL,
	Price DECIMAL(10,2) NOT NULL,
	Quantity INT,
	OrderDate DATETIME2,
	Color INT,
	IsChecked BIT,
	CategoryId INT,
	CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
);
GO

CREATE TABLE Customer (
    CustomerId INT  IDENTITY (1, 1) NOT NULL,
    Email			NVARCHAR (MAX) NOT NULL,
    [Password]		NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

INSERT INTO Category VALUES 
('Fruit'), 
('Vegetable'),
('Bread');
GO

INSERT INTO Product VALUES
('Banana',	4.00,  30,	'2019-10-1', 1,	1, 1),
('Pear',	8.00,  10,	'2019-11-1', 1,	0, 1),
('Apple',	5.00,  50,	'2019-11-2', 2,	1, 1),
('Orange',	6.00,  60,	'2019-11-5', 2,	0, 1),
('Lettuce',	9.00, 100,	'2019-11-2', 3,	1, 2),
('Tomato',	5.00,  50,	'2019-11-8', 3, 0, 2),
('Potato',	2.00, 200,	'2019-11-9', 1, 1, 2);
GO

INSERT INTO Customer VALUES
('abc@gmail.com','Passwd0'),
('def@yahoo.com','Passwd1');
GO