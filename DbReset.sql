IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DbReset')
      DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS
 BEGIN
	DELETE FROM Purchases;
	DELETE FROM Vehicles;
	DELETE FROM Models;
	DELETE FROM Makes;
	DELETE FROM ConditionTypes;
	DELETE FROM BodyStyles;
	DELETE FROM Specials;
	DELETE FROM Transmissions;
	DELETE FROM ExteriorColors;
	DELETE FROM InteriorColors;
	DELETE FROM States;
	DELETE FROM PurchaseTypes;
	DELETE FROM Contacts;
	DELETE FROM AspNetUsers WHERE Id IN ('00000000-0000-0000-0000-000000000000', '11111111-1111-1111-1111-111111111111');


	DBCC CHECKIDENT ('Vehicles', RESEED, 1)


	SET IDENTITY_INSERT Makes ON;

	INSERT INTO Makes(MakeID, MakeName, EmailAddress, UserID)
	VALUES (1, 'Buick', 'testadmin@test.com', '1fced243-bfd4-45e9-a78d-ce39062004c1'),
	(2, 'Ford', 'testadmin@test.com', '1fced243-bfd4-45e9-a78d-ce39062004c1'),
	(3, 'Honda', 'testadmin@test.com', '1fced243-bfd4-45e9-a78d-ce39062004c1');

	SET IDENTITY_INSERT Makes OFF;

	SET IDENTITY_INSERT Models ON;

	INSERT INTO Models(ModelID, MakeID, MakeName, ModelName, EmailAddress, UserID)
	VALUES (1, 1, 'Buick', 'Regal', 'testadmin@test.com', '1fced243-bfd4-45e9-a78d-ce39062004c1'),
	(2, 2, 'Ford', 'Mustang', 'testadmin@test.com', '1fced243-bfd4-45e9-a78d-ce39062004c1'),
	(3, 3, 'Honda', 'Civic', 'testadmin@test.com', '1fced243-bfd4-45e9-a78d-ce39062004c1');

	SET IDENTITY_INSERT Models OFF;

	SET IDENTITY_INSERT ConditionTypes ON;

	INSERT INTO ConditionTypes(ConditionTypeID, ConditionTypeName)
	VALUES (1, 'New'),
	(2, 'Used')

	SET IDENTITY_INSERT ConditionTypes OFF;


	SET IDENTITY_INSERT BodyStyles ON;

	INSERT INTO BodyStyles(BodyStyleID, BodyStyleName)
	VALUES (1, 'Car'),
	(2, 'SUV'),
	(3, 'Truck'),
	(4, 'Van');

	SET IDENTITY_INSERT BodyStyles OFF;


	SET IDENTITY_INSERT Specials ON;

	INSERT INTO Specials(SpecialID, SpecialTitle, SpecialDescription)
	VALUES (1, 'Summer Deal', 'These prices are hot!!!'),
	(2, 'Winter Deal', 'These prices are soooo cool!!!'),
	(3, 'New Year Deal', 'We need to get rid of last year''s models!!!');

	SET IDENTITY_INSERT Specials OFF;


	SET IDENTITY_INSERT Transmissions ON;

	INSERT INTO Transmissions(TransmissionID, TransmissionName)
	VALUES (1, 'Automatic'),
	(2, 'Manual');

	SET IDENTITY_INSERT Transmissions OFF;


	SET IDENTITY_INSERT ExteriorColors ON;

	INSERT INTO ExteriorColors(ExteriorColorID, ExteriorColorName)
	VALUES (1, 'White'),
	(2, 'Black'),
	(3, 'Green'),
	(4, 'Red'),
	(5, 'Blue');

	SET IDENTITY_INSERT ExteriorColors OFF;

	SET IDENTITY_INSERT InteriorColors ON;

	INSERT INTO InteriorColors(InteriorColorID, InteriorColorName)
	VALUES (1, 'White'),
	(2, 'Black'),
	(3, 'Green'),
	(4, 'Red'),
	(5, 'Blue');

	SET IDENTITY_INSERT InteriorColors OFF;

	SET IDENTITY_INSERT Vehicles ON;

	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName) values (1, 1, 1, 1, 1, 2008, 1, 5, 2, 1000, 'ABCDEFGH123456789', 21000, 20000, 'Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.', 'placeholder.png');
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName) values (2, 2, 2, 2, 2, 2009, 2, 4, 3, 2000, 'BCDEFGHI234567890', 22000, 21000, 'Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.', 'placeholder.png');
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName) values (3, 3, 3, 1, 3, 2010, 1, 3, 4, 500, 'CDEFGHIJ345678901', 23000, 22000, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png');
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName) values (4, 1, 1, 2, 4, 2011, 2, 2, 5, 4000, 'DEFGHIJK456789012', 24000, 23000, 'Integer tincidunt ante vel ipsum. Praesent blandit lacinia erat. Vestibulum sed magna at nunc commodo placerat.', 'placeholder.png');
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName) values (5, 2, 2, 1, 1, 2012, 1, 1, 4, 400, 'EFGHIJKL567890123', 25000, 24000, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png');
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName,Featured) values (6, 3, 3, 2, 2, 2013, 2, 5, 3, 6000, 'FGHIJKLM678901234', 26000, 25000, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png',1);
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName,Featured) values (7, 1, 1, 1, 3, 2014, 1, 4, 2, 700, 'GHIJKLMN789012345', 27000, 26000, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png',1);
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName,Featured) values (8, 2, 2, 2, 4, 2015, 2, 3, 1, 8000, 'HIJKLMNO890123456', 28000, 27000, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png',1);
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName,Featured) values (9, 3, 3, 1, 1, 2016, 1, 2, 5, 900, 'JKLMNOPQ901234567', 29000, 28000, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png',1);
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName,Featured) values (10, 1, 1, 2, 2, 2017, 2, 1, 4, 10000, 'KLMNOPQR012345678', 30000, 29000, 'Vestibulum quam sapien, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png',1);
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName,Featured) values (11, 2, 2, 2, 4, 2018, 2, 3, 1, 11000, 'LMNOPQRS123456789', 31000, 30000, 'Vestibulum ooga booga, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png',1);
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName,Featured) values (12, 3, 3, 1, 1, 2019, 1, 2, 5, 200, 'MNOPQRST234567890', 32000, 31000, 'Vestibulum ham and cheese, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png',1);
	insert into dbo.Vehicles (VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, Year, TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName,Featured) values (13, 1, 1, 2, 2, 2020, 2, 1, 4, 13000, 'NOPQRSTU345678901', 33000, 32000, 'Vestibulum diet soda, varius ut, blandit non, interdum in, ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio. Curabitur convallis.', 'placeholder.png',1);
	
	SET IDENTITY_INSERT Vehicles OFF;

	
	INSERT INTO States(StateID, StateName)
	VALUES ('OH', 'Ohio'),
	('KY', 'Kentucky'),
	('MN','Minnesota');

	SET IDENTITY_INSERT PurchaseTypes ON;

	INSERT INTO PurchaseTypes (PurchaseTypeID, PurchaseTypeName)
	VALUES (1, 'Bank Finance'),
	(2, 'Cash'),
	(3, 'Dealer Finance')

	SET IDENTITY_INSERT PurchaseTypes OFF;


	SET IDENTITY_INSERT Purchases ON;
	
	insert into Purchases (PurchaseID, VehicleID, UserID, Name, EmailAddress, PhoneNumber, StreetAddress1, StreetAddress2, City, StateID, ZipCode, PurchasePrice, PurchaseTypeID, PurchaseDate) values (1, 1, '00000000-0000-0000-0000-000000000000', 'Gregor Gibbe', 'ggibbe0@oakley.com', '210-859-4326', '0 Bayside Crossing', null, 'San Antonio', 'KY', '78285', 49863.56, 3, '2018/11/26');
	insert into Purchases (PurchaseID, VehicleID, UserID, Name, EmailAddress, PhoneNumber, StreetAddress1, StreetAddress2, City, StateID, ZipCode, PurchasePrice, PurchaseTypeID, PurchaseDate) values (2, 2, '11111111-1111-1111-1111-111111111111', 'Aindrea Ogilby', 'aogilby1@imgur.com', '361-563-9613', '71049 Caliangt Road', null, 'Corpus Christi', 'MN', '78475', 14702.35, 2, '2018/07/11');
	insert into Purchases (PurchaseID, VehicleID, UserID, Name, EmailAddress, PhoneNumber, StreetAddress1, StreetAddress2, City, StateID, ZipCode, PurchasePrice, PurchaseTypeID, PurchaseDate) values (3, 3, '00000000-0000-0000-0000-000000000000', 'Yetta Cater', 'ycater2@webmd.com', '713-257-0284', '72 Kim Court', null, 'Houston', 'OH', '77010', 38466.97, 3, '2019/01/23');

	SET IDENTITY_INSERT Purchases OFF;

	SET IDENTITY_INSERT Contacts ON;

	INSERT INTO Contacts(ContactID, ContactName, [Message])
	VALUES (1, 'Brad Smith', 'I am really interested in the blue Honda Civic!'),
	(2, 'Shelly Jones', 'I am really interested in the white Mustang!'),
	(3, 'David Morgan', 'I am really interested in the Black Regal!');

	SET IDENTITY_INSERT Contacts OFF;



	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName)
	VALUES('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test', 'John', 'Smith');

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName)
	VALUES('11111111-1111-1111-1111-111111111111', 0, 0, 'test2@test.com', 0, 0, 0, 'test2', 'David', 'Jones');

	insert into dbo.AspNetUserRoles(UserId,RoleId)
	values('00000000-0000-0000-0000-000000000000',1),
	('11111111-1111-1111-1111-111111111111',2)

 END