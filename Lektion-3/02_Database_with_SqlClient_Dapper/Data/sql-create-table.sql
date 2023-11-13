﻿DROP TABLE Users
DROP TABLE Addresses

CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(100) not null,
	PostalCode varchar(6) not null,
	City nvarchar(50) not null
)
GO

CREATE TABLE Users (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName  nvarchar(50) not null,
	Email varchar(100) not null unique,
	AddressId int not null references Addresses(Id)
)
