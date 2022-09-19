USE GuildCars

IF EXISTS(SELECT * FROM sys.tables WHERE name='Purchases')
	DROP TABLE Purchases
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicles')
	DROP TABLE Vehicles
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Models')
	DROP TABLE Models
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Makes')
	DROP TABLE Makes
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ConditionTypes')
	DROP TABLE [ConditionTypes]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyles')
	DROP TABLE BodyStyles
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmissions')
	DROP TABLE Transmissions
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ExteriorColors')
	DROP TABLE ExteriorColors
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='InteriorColors')
	DROP TABLE InteriorColors
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Contacts')
	DROP TABLE Contacts
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO




IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseTypes')
	DROP TABLE PurchaseTypes
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO


CREATE TABLE Makes (
	MakeID int identity(1,1) not null primary key,
	MakeName varchar(15) not null,
	EmailAddress varchar(100) not null,
	UserID nvarchar(128) not null,
	CreatedDate datetime2 not null default(getdate())
)

CREATE TABLE Models (
	ModelID int identity(1,1) not null primary key,
	MakeID int not null foreign key references Makes(MakeID),
	MakeName varchar(15) not null,
	ModelName varchar(15) not null,
	EmailAddress varchar(100) not null,
	UserID nvarchar(128) not null,
	CreatedDate datetime2 not null default(getdate())
)



CREATE TABLE ConditionTypes (
	ConditionTypeID int identity(1,1) not null primary key,
	ConditionTypeName varchar(15) not null
)

CREATE TABLE BodyStyles (
	BodyStyleID int identity(1,1) not null primary key,
	BodyStyleName varchar(15) not null
)

CREATE TABLE Transmissions (
	TransmissionID int identity(1,1) not null primary key,
	TransmissionName varchar(15) not null
)

CREATE TABLE ExteriorColors (
	ExteriorColorID int identity(1,1) not null primary key,
	ExteriorColorName varchar(30) not null
)

CREATE TABLE InteriorColors (
	InteriorColorID int identity(1,1) not null primary key,
	InteriorColorName varchar(30) not null
)


CREATE TABLE Vehicles(
	VehicleID int identity(1,1) not null primary key,
	MakeID int not null foreign key references Makes(MakeId),
	ModelID int not null foreign key references Models(ModelID),
	ConditionTypeID int not null foreign key references ConditionTypes(ConditionTypeID),
	BodyStyleID int not null foreign key references BodyStyles(BodyStyleID),
	[Year] int not null,
	TransmissionID int not null foreign key references Transmissions(TransmissionID),
	ExteriorColorID int not null foreign key references ExteriorColors(ExteriorColorID),
	InteriorColorID int not null foreign key references InteriorColors(InteriorColorID),
	Mileage int not null,
	VINNumber nvarchar(17) not null,
	MSRP decimal(10,2) not null,
	SalePrice decimal(10,2) null,
	Description varchar(400) not null,
	ImageFileName varchar(50),
	Featured bit default(0),
	CreatedDate datetime2 not null default(getdate())
)

CREATE TABLE Contacts (
	ContactID int not null identity(1,1) primary key,
	ContactName varchar(50) not null,
	EmailAddress varchar(50) null,
	PhoneNumber nvarchar(15) null,
	Message nvarchar(300) not null	
)

CREATE TABLE States (
	StateID char(2) not null primary key,
	StateName varchar(30) not null
)

CREATE TABLE PurchaseTypes (
	PurchaseTypeID int not null identity(1,1) primary key,
	PurchaseTypeName varchar(15) not null
)

CREATE TABLE Specials (
	SpecialID int not null identity(1,1) primary key,
	SpecialTitle varchar(50) not null,
	SpecialDescription varchar(150) not null
)


CREATE TABLE Purchases (
	PurchaseID int not null identity(1,1) primary key,
	VehicleID int not null foreign key references Vehicles(VehicleID),
	UserID nvarchar(128) not null,
	[Name] varchar(100) not null,
	EmailAddress varchar(50) null,
	PhoneNumber nvarchar(15) null,
	StreetAddress1 nvarchar(100) not null,
	StreetAddress2 nvarchar(100)  null,
	City varchar(15) not null,
	StateID char(2) not null foreign key references States(StateID),
	Zipcode varchar(10) not null,
	PurchasePrice decimal(10,2) not null,
	PurchaseTypeID  int foreign key references PurchaseTypes(PurchaseTypeID),
	PurchaseDate datetime2 not null default(getdate())
	)