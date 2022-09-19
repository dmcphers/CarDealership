IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StatesSelectAll')
      DROP PROCEDURE StatesSelectAll
GO

CREATE PROCEDURE StatesSelectAll AS
BEGIN
	SELECT StateID, StateName
	FROM States
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypesSelectAll')
      DROP PROCEDURE PurchaseTypesSelectAll
GO


CREATE PROCEDURE PurchaseTypesSelectAll AS
BEGIN
	SELECT PurchaseTypeID, PurchaseTypeName
	FROM PurchaseTypes
	ORDER BY PurchaseTypeName
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchasesSelectAll')
      DROP PROCEDURE PurchasesSelectAll
GO


CREATE PROCEDURE PurchasesSelectAll AS
BEGIN
	SELECT PurchaseID, VehicleID, UserID, [Name], EmailAddress, PhoneNumber, StreetAddress1, StreetAddress2, City, StateID, Zipcode, PurchasePrice, PurchaseTypeID, PurchaseDate
	FROM Purchases
	ORDER BY PurchaseID
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseInsert')
      DROP PROCEDURE PurchaseInsert
GO

CREATE PROCEDURE PurchaseInsert (
	@VehicleID int,
	@UserID nvarchar(128),
	@Name varchar(100),
	@EmailAddress varchar(50) = null,
	@PhoneNumber nvarchar(15) = null,
	@StreetAddress1 nvarchar(100),
	@StreetAddress2 nvarchar(100) = null,
	@City varchar(15),
	@StateID char(2),
	@ZipCode varchar(10),
	@PurchasePrice decimal(10,2),
	@PurchaseTypeID int

) AS
BEGIN
      INSERT INTO dbo.Purchases([VehicleID]
           ,[UserID]
           ,[Name]
           ,[EmailAddress]
           ,[PhoneNumber]
           ,[StreetAddress1]
           ,[StreetAddress2]
           ,[City]
           ,[StateID]
           ,[Zipcode]
           ,[PurchasePrice]
           ,[PurchaseTypeID]
		   )
	VALUES (@VehicleID ,
	@UserID ,
	@Name ,
	@EmailAddress ,
	@PhoneNumber ,
	@StreetAddress1 ,
	@StreetAddress2 ,
	@City ,
	@StateID ,
	@ZipCode ,
	@PurchasePrice,
	@PurchaseTypeID 
	)

END
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsSelectAll')
      DROP PROCEDURE ContactsSelectAll
GO


CREATE PROCEDURE ContactsSelectAll AS
BEGIN
	SELECT ContactID, ContactName, EmailAddress, PhoneNumber, [Message]
	FROM Contacts
	ORDER BY ContactName
END

GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialsSelectAll')
      DROP PROCEDURE SpecialsSelectAll
GO


CREATE PROCEDURE SpecialsSelectAll AS
BEGIN
	SELECT SpecialID, SpecialTitle, SpecialDescription
	FROM Specials
	ORDER BY SpecialTitle
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyStylesSelectAll')
      DROP PROCEDURE BodyStylesSelectAll
GO


CREATE PROCEDURE BodyStylesSelectAll AS
BEGIN
	SELECT BodyStyleID, BodyStyleName
	FROM BodyStyles
	ORDER BY BodyStyleName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ConditionTypesSelectAll')
      DROP PROCEDURE ConditionTypesSelectAll
GO


CREATE PROCEDURE ConditionTypesSelectAll AS
BEGIN
	SELECT ConditionTypeID, ConditionTypeName
	FROM ConditionTypes
	ORDER BY ConditionTypeName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelsSelectAll')
      DROP PROCEDURE ModelsSelectAll
GO


CREATE PROCEDURE ModelsSelectAll AS
BEGIN
	SELECT ModelID, mds.MakeName, ModelName, mds.CreatedDate, mds.EmailAddress
	FROM Models mds
	INNER JOIN Makes mks ON mds.MakeID = mks.MakeID
	ORDER BY ModelName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakesSelectAll')
      DROP PROCEDURE MakesSelectAll
GO


CREATE PROCEDURE MakesSelectAll AS
BEGIN
	SELECT MakeID, MakeName, CreatedDate, EmailAddress, UserId
	FROM Makes
	ORDER BY MakeName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelectByID')
      DROP PROCEDURE MakeSelectByID
GO


CREATE PROCEDURE MakeSelectByID (
	@MakeID int
)
AS
BEGIN
	SELECT MakeID, MakeName, CreatedDate, EmailAddress, UserId
	FROM Makes
	WHERE MakeID = @MakeID
	ORDER BY MakeName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'TransmissionsSelectAll')
      DROP PROCEDURE TransmissionsSelectAll
GO


CREATE PROCEDURE TransmissionsSelectAll AS
BEGIN
	SELECT TransmissionID, TransmissionName
	FROM Transmissions
	ORDER BY TransmissionName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ExteriorColorsSelectAll')
      DROP PROCEDURE ExteriorColorsSelectAll
GO


CREATE PROCEDURE ExteriorColorsSelectAll AS
BEGIN
	SELECT ExteriorColorID, ExteriorColorName
	FROM ExteriorColors
	ORDER BY ExteriorColorName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorsSelectAll')
      DROP PROCEDURE InteriorColorsSelectAll
GO


CREATE PROCEDURE InteriorColorsSelectAll AS
BEGIN
	SELECT InteriorColorID, InteriorColorName
	FROM InteriorColors
	ORDER BY InteriorColorName
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehiclesSelectAll')
      DROP PROCEDURE VehiclesSelectAll
GO


CREATE PROCEDURE VehiclesSelectAll AS
BEGIN
	SELECT VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, [Year], TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName, Featured, CreatedDate
	FROM Vehicles
	ORDER BY Mileage
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehiclesInsert')
      DROP PROCEDURE VehiclesInsert
GO


CREATE PROCEDURE VehiclesInsert (
	@VehicleID int output,
	@MakeID int,
	@ModelID int,
	@ConditionTypeID int,
	@BodyStyleID int,
	@Year int,
	@TransmissionID int,
	@ExteriorColorID int,
	@InteriorColorID int,
	@Mileage int,
	@VINNumber nvarchar(17),
	@MSRP decimal(10,2),
	@SalePrice decimal(10,2),
	@Description varchar(400),
	@ImageFileName varchar(50),
	@Featured bit
) AS
BEGIN
	insert into Vehicles (MakeID, ModelID, ConditionTypeID, BodyStyleID, [Year], 
		TransmissionID, ExteriorColorID, InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], 
		ImageFileName)
	VALUES (@MakeID, @ModelID, @ConditionTypeID, @BodyStyleID, @Year, @TransmissionID, @ExteriorColorID,
		@InteriorColorID, @Mileage, @VINNumber, @MSRP, @SalePrice, @Description, @ImageFileName)

	SET @VehicleID = SCOPE_IDENTITY();
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehiclesUpdate')
      DROP PROCEDURE VehiclesUpdate
GO


CREATE PROCEDURE VehiclesUpdate (
	@VehicleID int,
	@MakeID int,
	@ModelID int,
	@ConditionTypeID int,
	@BodyStyleID int,
	@Year int,
	@TransmissionID int,
	@ExteriorColorID int,
	@InteriorColorID int,
	@Mileage int,
	@VINNumber nvarchar(17),
	@MSRP decimal(10,2),
	@SalePrice decimal(10,2),
	@Description varchar(400),
	@ImageFileName varchar(50),
	@Featured bit
) AS
BEGIN
	UPDATE Vehicles SET
	 MakeID = @MakeID,
	 ModelID = @ModelID, 
	 ConditionTypeID = @ConditionTypeID,
	 BodyStyleID = @BodyStyleID,
	 [Year] = @Year, 
	 TransmissionID = @TransmissionID,
	 ExteriorColorID = @ExteriorColorID,
	 InteriorColorID = @InteriorColorID,
	 Mileage = @Mileage,
	 VINNumber = @VINNumber,
	 MSRP = @MSRP,
	 SalePrice = @SalePrice,
	 [Description] = @Description, 
	 ImageFileName = @ImageFileName,
	 Featured = @Featured
	WHERE VehicleID = @VehicleID
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehiclesDelete')
      DROP PROCEDURE VehiclesDelete
GO


CREATE PROCEDURE VehiclesDelete (
	@VehicleID int
) AS
BEGIN
		DELETE FROM Vehicles WHERE VehicleID = @VehicleID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehiclesSelect')
      DROP PROCEDURE VehiclesSelect
GO

CREATE PROCEDURE VehiclesSelect (
	@VehicleID int
) AS
BEGIN
	SELECT VehicleID, MakeID, ModelID, ConditionTypeID, BodyStyleID, [Year], TransmissionID, ExteriorColorID,
	InteriorColorID, Mileage, VINNumber, MSRP, SalePrice, [Description], ImageFileName, Featured
	FROM Vehicles
	WHERE VehicleID = @VehicleID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehiclesSelectFeatured')
      DROP PROCEDURE VehiclesSelectFeatured
GO


CREATE PROCEDURE VehiclesSelectFeatured AS
BEGIN
	SELECT TOP 5 VehicleID, Vehicles.MakeID, Makes.MakeName, Vehicles.ModelID, Models.ModelName, SalePrice, ImageFileName, [Year]
	
	FROM ((Vehicles
	INNER JOIN Makes ON Vehicles.MakeID = Makes.MakeID) 
	INNER JOIN Models ON Vehicles.ModelID = Models.ModelID)
	WHERE Vehicles.Featured = 1
	ORDER BY Vehicles.Year Desc
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehiclesSelectDetails')
      DROP PROCEDURE VehiclesSelectDetails
GO


CREATE PROCEDURE VehiclesSelectDetails (
	@VehicleID int
) AS
BEGIN
	SELECT v.VehicleID, pur.PurchaseID, v.MakeID, mk.MakeName, v.ModelID, md.ModelName,
	v.ConditionTypeID, c.ConditionTypeName, v.BodyStyleID, bd.BodyStyleName, [Year], v.TransmissionID,
	tr.TransmissionName, v.ExteriorColorID, ec.ExteriorColorName, v.InteriorColorID, ic.InteriorColorName, 
	Mileage, VINNumber, MSRP, SalePrice, ImageFileName, [Description], Featured
	
	FROM Vehicles v
	LEFT JOIN Purchases pur ON v.VehicleID = pur.VehicleID
	INNER JOIN Makes mk ON v.MakeID = mk.MakeID
	INNER JOIN Models md ON v.ModelID = md.ModelID
	INNER JOIN ConditionTypes c ON v.ConditionTypeID = c.ConditionTypeID
	INNER JOIN BodyStyles bd ON v.BodyStyleID = bd.BodyStyleID
	INNER JOIN Transmissions tr ON v.TransmissionID = tr.TransmissionID
	INNER JOIN ExteriorColors ec ON v.ExteriorColorID = ec.ExteriorColorID
	INNER JOIN InteriorColors ic ON v.InteriorColorID = ic.InteriorColorID

	WHERE v.VehicleID = @VehicleID
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactsInsert')
      DROP PROCEDURE ContactsInsert
GO


CREATE PROCEDURE ContactsInsert (
	@ContactName varchar(50),
	@EmailAddress varchar(50),
	@PhoneNumber nvarchar(15),
	@Message nvarchar(300)
	
) AS
BEGIN
	insert into Contacts (ContactName, EmailAddress, PhoneNumber, [Message])
	VALUES (@ContactName, @EmailAddress, @PhoneNumber, @Message)
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeInsert')
      DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert (
	@MakeName varchar(15),
	@EmailAddress varchar(100),
	@UserID nvarchar(128)
) AS
BEGIN
	INSERT INTO Makes(MakeName,EmailAddress, UserID)
	VALUES (@MakeName, @EmailAddress, @UserID)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelInsert')
      DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert (
	@MakeName varchar(15),
	@ModelName varchar(15),
	@EmailAddress varchar(100),
	@MakeID int,
	@UserID nvarchar(128)
) AS
BEGIN
	INSERT INTO Models(MakeName,ModelName,EmailAddress,MakeID,UserID)
	VALUES (@MakeName,@ModelName,@EmailAddress,@MakeID,@UserID)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialInsert')
      DROP PROCEDURE SpecialInsert
GO

CREATE PROCEDURE SpecialInsert (
	@SpecialTitle varchar(50),
	@SpecialDescription varchar(150)
) AS
BEGIN
	INSERT INTO Specials(SpecialTitle,SpecialDescription)
	VALUES (@SpecialTitle,@SpecialDescription)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialDelete')
      DROP PROCEDURE SpecialDelete
GO

CREATE PROCEDURE SpecialDelete (
	@SpecialID int
) AS
BEGIN
	DELETE FROM Specials WHERE SpecialID = @SpecialID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InventoryReport')
      DROP PROCEDURE InventoryReport
GO

CREATE PROCEDURE InventoryReport (
	@ConditionTypeID int
) AS 
BEGIN
	SELECT Veh.ConditionTypeID, T.ConditionTypeName, Veh.MakeID,Make.MakeName,Veh.ModelID,ModelName,[Year],Count([VehicleID]) as [Count],SUM(MSRP) as StockValue  
	FROM GuildCars.dbo.Vehicles as Veh
	INNER JOIN Makes as Make ON Veh.MakeID = Make.MakeID
	INNER JOIN Models as Model ON Veh.ModelID = Model.ModelID
	INNER JOIN ConditionTypes as T ON T.ConditionTypeID = Veh.ConditionTypeID
	WHERE Veh.ConditionTypeID = @ConditionTypeID
	GROUP BY Veh.ConditionTypeID, ConditionTypeName, Veh.MakeID,Make.MakeName,Veh.ModelID,ModelName,[Year]
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SalesReport')
      DROP PROCEDURE SalesReport
GO

CREATE PROCEDURE SalesReport
(
	  @UserName			NVARCHAR(256) = NULL	
	 ,@FromDate			DATE = NULL
	 ,@ToDate			DATE = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @SQL							NVARCHAR(MAX)
	DECLARE @ParameterDef					NVARCHAR(500)
    SET @ParameterDef =      '@UserName		NVARCHAR(256),
							 @FromDate			NVARCHAR(50),
							 @ToDate			NVARCHAR(50)
							'
							



			SET @SQL = 'SELECT UserID, U.UserName,SUM(PurchasePrice) AS TotalSales,COUNT(VehicleID) as TotalVehicles
						FROM Purchases P 
						INNER JOIN AspNetUsers U ON U.Id = P.UserID
						WHERE -1=-1
						'

			IF @UserName IS NOT NULL 
			SET @SQL = @SQL+ ' AND U.UserName = @UserName '
					
			IF @FromDate IS NOT NULL AND @FromDate <> ''
			SET @SQL = @SQL+ ' AND PurchaseDate >=''' + CAST(@FromDate as varchar(100)) + ''''
 
			IF @ToDate IS NOT NULL AND @ToDate <> ''
			SET @SQL = @SQL+ ' AND PurchaseDate <=''' + CAST(@ToDate as varchar(100)) + '''' 
 

			SET @SQL = @SQL + ' GROUP BY UserID,U.UserName'

			EXEC sp_Executesql     @SQL,  @ParameterDef, @UserName=@UserName,@FromDate=@FromDate,@ToDate=@ToDate 
END
 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SearchInventory')
      DROP PROCEDURE SearchInventory
GO

CREATE PROCEDURE SearchInventory
(
	  @QuickSearch					 NVARCHAR(50) = NULL
	 ,@ConditionTypeName             NVARCHAR(50) = NULL
	 ,@MinPrice						 NVARCHAR(50) = NULL
	 ,@MaxPrice						 NVARCHAR(50) = NULL
	 ,@MinYear						 NVARCHAR(50) = NULL
	 ,@MaxYear						 NVARCHAR(50) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @SQL							NVARCHAR(MAX)
	DECLARE @ParameterDef					NVARCHAR(500)
    SET @ParameterDef =      '@QuickSearch			    NVARCHAR(50),
							 @ConditionTypeName			NVARCHAR(50),
							 @MinPrice				    NVARCHAR(50) ,
							 @MaxPrice				    NVARCHAR(50) ,
							 @MinYear				    NVARCHAR(50) ,
							 @MaxYear				    NVARCHAR(50)
							'
							



			SET @SQL = 'SELECT TOP 20 VehicleID,Veh.MakeID,Make.MakeName,Model.ModelID,ModelName,[Year],VINNumber,MSRP,SalePrice,Mileage , BS.BodyStyleID, BS.BodyStyleName, T.TransmissionID,T.TransmissionName, Veh.ConditionTypeID,ConditionTypeName
					,EC.ExteriorColorID,EC.ExteriorColorName,IC.InteriorColorID,IC.InteriorColorName, Veh.ImageFileName
					FROM GuildCars.dbo.Vehicles as Veh
					INNER JOIN dbo.Makes as Make ON Veh.MakeID = Make.MakeID
					INNER JOIN dbo.Models as Model ON Veh.ModelID = Model.ModelID
					INNER JOIN dbo.BodyStyles as BS ON BS.BodyStyleID = Veh.BodyStyleID
					INNER JOIN dbo.Transmissions as T ON T.TransmissionID = Veh.TransmissionID
					INNER JOIN dbo.ExteriorColors as EC ON EC.ExteriorColorID = Veh.ExteriorColorID
					INNER JOIN dbo.InteriorColors as IC ON IC.InteriorColorID = Veh.InteriorColorID
					INNER JOIN dbo.ConditionTypes as CT on CT.ConditionTypeID = Veh.ConditionTypeID
					WHERE -1=-1'

			IF @ConditionTypeName IS NOT NULL 
			SET @SQL = @SQL+ ' AND ConditionTypeName = @ConditionTypeName '
					
			IF @QuickSearch IS NOT NULL 
			SET @SQL = @SQL+ ' AND (Make.MakeName like ''%'' + @QuickSearch + ''%'' OR ModelName like ''%'' + @QuickSearch + ''%'' OR Year like ''%'' + @QuickSearch + ''%'')'

			IF @MinPrice IS NOT NULL AND @MinPrice <> 0
			SET @SQL = @SQL+ ' AND SalePrice >=' + @MinPrice

			IF @MaxPrice IS NOT NULL AND @MaxPrice <> 0
			SET @SQL = @SQL+ ' AND SalePrice <=' + @MaxPrice

			IF @MinYear IS NOT NULL AND @MinYear <> 0
			SET @SQL = @SQL+ ' AND Year >=' + @MinYear

			IF @MaxYear IS NOT NULL AND @MaxYear <> 0
			SET @SQL = @SQL+ ' AND Year <=' + @MaxYear

			/*SET @SQL = @SQL + ' AND NOT EXISTS(SELECT * FROM dbo.Purchases WHERE VehicleID = Veh.VehicleID) ORDER BY MSRP DESC'*/

			EXEC sp_Executesql     @SQL,  @ParameterDef, @QuickSearch=@QuickSearch,@ConditionTypeName=@ConditionTypeName,@MinPrice=@MinPrice,@MaxPrice=@MaxPrice,@MinYear=@MinYear,@MaxYear=@MaxYear
			
 
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SearchInventoryAdmin')
      DROP PROCEDURE SearchInventoryAdmin
GO

CREATE PROCEDURE SearchInventoryAdmin
(
	  @QuickSearch					 NVARCHAR(50) = NULL
	 ,@ConditionTypeName             NVARCHAR(50) = NULL
	 ,@MinPrice						 NVARCHAR(50) = NULL
	 ,@MaxPrice						 NVARCHAR(50) = NULL
	 ,@MinYear						 NVARCHAR(50) = NULL
	 ,@MaxYear						 NVARCHAR(50) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @SQL							NVARCHAR(MAX)
	DECLARE @ParameterDef					NVARCHAR(500)
    SET @ParameterDef =      '@QuickSearch			    NVARCHAR(50),
							 @ConditionTypeName			NVARCHAR(50),
							 @MinPrice				    NVARCHAR(50) ,
							 @MaxPrice				    NVARCHAR(50) ,
							 @MinYear				    NVARCHAR(50) ,
							 @MaxYear				    NVARCHAR(50)
							'
							



			SET @SQL = 'SELECT TOP 20 VehicleID,Veh.MakeID,Make.MakeName,Model.ModelID,ModelName,[Year],VINNumber,MSRP,SalePrice,Mileage , BS.BodyStyleID, BS.BodyStyleName, T.TransmissionID,T.TransmissionName, Veh.ConditionTypeID,ConditionTypeName
					,EC.ExteriorColorID,EC.ExteriorColorName,IC.InteriorColorID,IC.InteriorColorName, Veh.ImageFileName
					FROM GuildCars.dbo.Vehicles as Veh
					INNER JOIN dbo.Makes as Make ON Veh.MakeID = Make.MakeID
					INNER JOIN dbo.Models as Model ON Veh.ModelID = Model.ModelID
					INNER JOIN dbo.BodyStyles as BS ON BS.BodyStyleID = Veh.BodyStyleID
					INNER JOIN dbo.Transmissions as T ON T.TransmissionID = Veh.TransmissionID
					INNER JOIN dbo.ExteriorColors as EC ON EC.ExteriorColorID = Veh.ExteriorColorID
					INNER JOIN dbo.InteriorColors as IC ON IC.InteriorColorID = Veh.InteriorColorID
					INNER JOIN dbo.ConditionTypes as CT on CT.ConditionTypeID = Veh.ConditionTypeID
					WHERE -1=-1'

			IF @ConditionTypeName IS NOT NULL 
			SET @SQL = @SQL+ ' AND ConditionTypeName = @ConditionTypeName '
					
			IF @QuickSearch IS NOT NULL 
			SET @SQL = @SQL+ ' AND (Make.MakeName like ''%'' + @QuickSearch + ''%'' OR ModelName like ''%'' + @QuickSearch + ''%'' OR Year like ''%'' + @QuickSearch + ''%'')'

			IF @MinPrice IS NOT NULL AND @MinPrice <> 0
			SET @SQL = @SQL+ ' AND SalePrice >=' + @MinPrice

			IF @MaxPrice IS NOT NULL AND @MaxPrice <> 0
			SET @SQL = @SQL+ ' AND SalePrice <=' + @MaxPrice

			IF @MinYear IS NOT NULL AND @MinYear <> 0
			SET @SQL = @SQL+ ' AND Year >=' + @MinYear

			IF @MaxYear IS NOT NULL AND @MaxYear <> 0
			SET @SQL = @SQL+ ' AND Year <=' + @MaxYear

			SET @SQL = @SQL + ' AND NOT EXISTS(SELECT * FROM dbo.Purchases WHERE VehicleID = Veh.VehicleID) ORDER BY MSRP DESC'

			EXEC sp_Executesql     @SQL,  @ParameterDef, @QuickSearch=@QuickSearch,@ConditionTypeName=@ConditionTypeName,@MinPrice=@MinPrice,@MaxPrice=@MaxPrice,@MinYear=@MinYear,@MaxYear=@MaxYear
			
 
END

 
GO