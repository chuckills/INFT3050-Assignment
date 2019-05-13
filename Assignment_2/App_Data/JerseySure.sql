-- Gregory Choice, Christopher Booth, Dylan Cawsey
-- INFT3050 Assignment 1
-- Database creation script


--==================================================================================
-- This section was used to create the database on SQL Server Developer Edition
-- Uncomment if you need to run. I don't think this is needed though.
--==================================================================================
use master
go

CREATE DATABASE JerseySure
GO

USE JerseySure
GO


--==================================================================================
--==================================================================================
--**********************************************************************************
--**********************************************************************************
-- Ben said it was OK to leave the login part commented for now
--**********************************************************************************
--**********************************************************************************

--==================================================================================
-- This section was used to create the database user login
-- Uncomment if you need to run it
--==================================================================================
CREATE LOGIN jerseysure WITH PASSWORD = N'password'
GO	

EXECUTE	sp_addsrvrolemember jerseysure, dbcreator
GO

EXECUTE	sp_addsrvrolemember jerseysure, sysadmin
GO

CREATE USER jerseysure
	FOR	LOGIN jerseysure
	WITH DEFAULT_SCHEMA = dbo
GO


--===================================================================================
    -- Database Types, Procedures and Functions
--===================================================================================

-- TVP for inserting player details
CREATE TYPE PLAYERTYPE AS TABLE
(
    playID INT,
    playFirstName VARCHAR(30),
    playLastName VARCHAR(30),
    teamID CHAR(3),
    jerNumber INT,
    PRIMARY KEY (playFirstName, playLastName, teamID, jerNumber)
)
GO

-- Stored procedure to insert player details
CREATE PROCEDURE usp_addPlayers
  @player PLAYERTYPE READONLY
AS
BEGIN
  INSERT INTO Player (playID, playFirstName, playLastName)
  SELECT playID, playFirstName, playLastName
  FROM @player
  INSERT INTO JerseyNumber (playID, jerNumber, teamID)
  SELECT playID, jerNumber, teamID
  FROM @player
END
GO

CREATE PROCEDURE usp_addNewPlayer
  @player PLAYERTYPE READONLY
AS
BEGIN
  INSERT INTO Player (playFirstName, playLastName)
  SELECT playFirstName, playLastName
  FROM @player
  INSERT INTO JerseyNumber (playID, jerNumber, teamID)
  SELECT SCOPE_IDENTITY(), jerNumber, teamID
  FROM @player
END
GO

CREATE PROCEDURE usp_getProducts
AS
BEGIN
    SELECT pr.prodNumber, pr.prodDescription, pr.prodPrice, t.teamID, t.teamLocale, t.teamName, pl.playFirstName, pl.playLastName, i.imgFront, i.imgBack, i.imgSmall
    FROM Product pr, Team t, Player pl, Image i
    WHERE pr.teamID = t.teamID AND pr.playID = pl.playID AND pr.imgID = i.imgID
END
GO

CREATE PROCEDURE usp_selectProduct
    @productNumber VARCHAR(8)
AS
BEGIN
    SELECT pr.prodNumber, pr.prodDescription, pr.prodPrice, t.teamID, t.teamLocale, t.teamName, pl.playFirstName, pl.playLastName, i.imgFront, i.imgBack, i.imgSmall
    FROM Product pr, Team t, Player pl, Image i
    WHERE pr.teamID = t.teamID AND pr.playID = pl.playID AND pr.imgID = i.imgID and pr.prodNumber = @productNumber
END
GO

CREATE PROCEDURE usp_userLogin
 @user VARCHAR(255), @pass VARCHAR(255), @result INT OUTPUT, @status BIT OUTPUT
AS
BEGIN
    DECLARE @password VARCHAR(255)
    IF EXISTS (SELECT userUserName FROM Users WHERE @user = userUserName)
        BEGIN
            SELECT @password = userPassword, @result = userID, @status = userAdmin FROM Users WHERE userUserName = @user
            IF (@pass != @password)
                BEGIN
                    SET @status = 0
                    SET @result = -1
                END
        END
    ELSE
        BEGIN
            SET @status = 0
            SET @result = 0
        END
END
GO

/*DECLARE
  @playerData PLAYERTYPE
INSERT INTO @playerData(playFirstName, playLastName, teamID, jerNumber)
    VALUES ('Mike', 'Hunt', 'UTA', 11)

EXEC usp_addNewPlayer @playerData
GO*/

--===================================================================================
    -- Database Build
--===================================================================================

-- Table of available teams that merchandise is carried for
CREATE TABLE Team
(
    teamID CHAR(3) PRIMARY KEY, -- 3 Letter abbreviation of team name
    teamLocale VARCHAR(30) NOT NULL, -- Home base of team
    teamName VARCHAR(30) NOT NULL, -- Team name
    UNIQUE (teamLocale, teamName)
)

-- Table of player names that merchandise is carried for
CREATE TABLE Player
(
    playID INT IDENTITY PRIMARY KEY,
    playFirstName VARCHAR(30) NOT NULL,
    playLastName VARCHAR(30) NOT NULL,
    UNIQUE (playID, playFirstName, playLastName)
)

-- Jersey number the player carries for a particular team
CREATE TABLE JerseyNumber
(
    jerNumber INT,
    teamID CHAR(3),
    playID INT,
    PRIMARY KEY (teamID, playID, jerNumber),
    FOREIGN KEY (teamID) REFERENCES Team(teamID),
    FOREIGN KEY (playID) REFERENCES Player(playID),
    CHECK (jerNumber >= 0)
)

-- Filenames for image files related to the product
CREATE TABLE Image
(
    imgID INT IDENTITY PRIMARY KEY,
    imgFront VARCHAR(40) NOT NULL, -- Front view file
    imgBack VARCHAR(40) NOT NULL, -- Back view file
    imgSmall VARCHAR(40) NOT NULL -- Small size
)

-- Details to identify the products carried
CREATE TABLE Product
(
    prodID INT IDENTITY,
    prodNumber AS cast(teamID + replicate('0', 5 - len(prodID)) + cast (prodID AS VARCHAR) AS VARCHAR(8)) PERSISTED PRIMARY KEY, -- Generates a value such as GSW00001
    prodDescription TEXT NOT NULL, -- Describes the product
    prodPrice MONEY NOT NULL,
    teamID CHAR(3) NOT NULL,
    playID INT NOT NULL,
    imgID INT NOT NULL,
    UNIQUE (playID, teamID),
    FOREIGN KEY (teamID) REFERENCES Team(teamID),
    FOREIGN KEY (playID) REFERENCES Player(playID),
    FOREIGN KEY (imgID) REFERENCES Image(imgID),
    CHECK (prodPrice >= 0),
)

CREATE TABLE Size
(
    sizeID VARCHAR(3) PRIMARY KEY,
    CHECK (sizeID IN ('S', 'M', 'L', 'XL', 'XXL'))
)

CREATE TABLE Stock
(
    sizeID VARCHAR(3) NOT NULL,
    prodNumber VARCHAR(8) NOT NULL,
    stkLevel INT NOT NULL DEFAULT 0,
    PRIMARY KEY (sizeID, prodNumber),
    FOREIGN KEY (sizeID) REFERENCES Size(sizeID),
    FOREIGN KEY (prodNumber) REFERENCES Product(prodNumber),
    CHECK (stkLevel >= 0)
)

-- Table of users, both admin and customer
CREATE TABLE Users
(
    userID INT IDENTITY PRIMARY KEY,
    userFirstName VARCHAR(30) NOT NULL,
    userLastName VARCHAR(30) NOT NULL,
    userEmail VARCHAR(255) NOT NULL,
    userPhone CHAR(10) NOT NULL,
    userUserName VARCHAR(255) UNIQUE NOT NULL,
    userPassword VARCHAR(255) NOT NULL,
    userAdmin BIT DEFAULT 0 NOT NULL,
    UNIQUE (userEmail, userAdmin), -- User can hold one of each account type
    CHECK (len(userPassword) >= 6)
)

-- Table of user addresses
CREATE TABLE Address
(
    addID INT IDENTITY PRIMARY KEY,
    addStreet VARCHAR(255) NOT NULL,
    addSuburb VARCHAR(30) NOT NULL,
    addState VARCHAR(3) NOT NULL,
    addZip INT NOT NULL,
    UNIQUE (addStreet, addSuburb, addState, addZip)
)

-- Table to allow multiple address types for each user
CREATE TABLE AddressTypes
(
    atType CHAR(1) NOT NULL, -- The type of address either postal or billing
    userID INT NOT NULL,
    addID INT NOT NULL,
    PRIMARY KEY (atType, userID, addID),
    FOREIGN KEY (userID) REFERENCES Users(userID),
    FOREIGN KEY (addID) REFERENCES Address(addID),
    CHECK (atType IN ('B', 'P'))
)

-- Table of shipping methods
CREATE TABLE Shipping
(
    shipID INT IDENTITY PRIMARY KEY,
    shipType VARCHAR(15) NOT NULL, -- Type of shipping
    shipDays INT NOT NULL, -- Average number of days to ship
    shipCost MONEY NOT NULL,
    UNIQUE (shipType, shipDays),
    CHECK (shipDays >= 0),
    CHECK (shipCost >= 0)
)

-- Table of customer orders
CREATE TABLE Orders
(
    ordID INT IDENTITY PRIMARY KEY,
    ordDate DATE NOT NULL DEFAULT getdate(),
    ordSubTotal MONEY NOT NULL, -- Subtotal of all products
    ordTotal MONEY NOT NULL, -- Total price, Subtotal + Shipping
    ordGST MONEY NOT NULL, -- ordTotal * 0.1
    ordPaid BIT DEFAULT 0 NOT NULL, -- Paid or not paid?
    shipID INT NOT NULL, -- ID of the shipping method
	userID INT NOT NULL, -- ID of the user,
	UNIQUE(ordID, userID),
    FOREIGN KEY (shipID) REFERENCES Shipping(shipID),
    FOREIGN KEY (userID) REFERENCES Users(userID)
)

-- Table to allow multiple items on the one order
CREATE TABLE CartItem
(
    userID INT NOT NULL,
    ordID INT NOT NULL,
    prodNumber VARCHAR(8) NOT NULL,
    sizeID VARCHAR(3) NOT NULL,
    cartQuantity INT NOT NULL, -- Quantity of the product to order
    cartProductTotal MONEY NOT NULL, -- cartQuantity * prodPrice
    PRIMARY KEY (userID, ordID, sizeID, prodNumber),
    FOREIGN KEY (userID) REFERENCES Users(userID),
    FOREIGN KEY (ordID) REFERENCES Orders(ordID),
    FOREIGN KEY (prodNumber) REFERENCES Product(prodNumber),
    FOREIGN KEY (sizeID) REFERENCES Size(sizeID),
    CHECK (cartQuantity >= 0)
)

-- Table of credit card information for order payment
CREATE TABLE CreditCardPM
(
    ccNumber CHAR(16) PRIMARY KEY,
    ccType VARCHAR(5) NOT NULL,
    ccHolderName VARCHAR(60) NOT NULL,
    ccExpiryMM INT NOT NULL,
    ccExpiryYYYY INT NOT NULL,
    ordID INT UNIQUE NOT NULL,
    FOREIGN KEY (ordID) REFERENCES Orders(ordID),
    CHECK (ccType IN ('MCARD', 'VISA', 'AMEX')),
    CHECK (ccExpiryYYYY >= year(getdate()) AND ccExpiryMM >= 1 AND ccExpiryMM <= 12),
    CHECK (isnumeric(ccNumber) = 1)
)

-- Table of PayPal information for order payment
CREATE TABLE PayPalPM
(
    ppUsername VARCHAR(255) PRIMARY KEY,
    ordID INT UNIQUE NOT NULL,
    FOREIGN KEY (ordID) REFERENCES Orders(ordID),
)

--===================================================================================
    -- Database Populate
--===================================================================================

-- Team
--===================================================================================
INSERT INTO Team (teamID, teamLocale, teamName)
    VALUES ('ATL', 'Atlanta', 'Hawks'),
           ('BKN', 'Brooklyn', 'Nets'),
           ('BOS', 'Boston', 'Celtics'),
           ('CHA', 'Charlotte', 'Hornets'),
           ('CHI', 'Chicago', 'Bulls'),
           ('CLE', 'Cleveland', 'Cavaliers'),
           ('DAL', 'Dallas', 'Mavericks'),
           ('DEN', 'Denver', 'Nuggets'),
           ('DET', 'Detroit', 'Pistons'),
           ('GSW', 'Golden State', 'Warriors'),
           ('HOU', 'Houston', 'Rockets'),
           ('IND', 'Indiana', 'Pacers'),
           ('LAC', 'Los Angeles', 'Clippers'),
           ('LAL', 'Los Angeles', 'Lakers'),
           ('MEM', 'Memphis', 'Grizzlies'),
           ('MIA', 'Miami', 'Heat'),
           ('MIL', 'Milwaukee', 'Bucks'),
           ('MIN', 'Minnesota', 'Timberwolves'),
           ('NOP', 'New Orleans', 'Pelicans'),
           ('NYK', 'New York', 'Knicks'),
           ('OKC', 'Oklahoma City', 'Thunder'),
           ('ORL', 'Orlando', 'Magic'),
           ('PHI', 'Philadelphia', '76ers'),
           ('PHX', 'Phoenix', 'Suns'),
           ('POR', 'Portland', 'Trail Blazers'),
           ('SAC', 'Sacramento', 'Kings'),
           ('SAS', 'San Antonio', 'Spurs'),
           ('TOR', 'Toronto', 'Raptors'),
           ('UTA', 'Utah', 'Jazz'),
           ('WAS', 'Washington', 'Wizards')
GO

-- Image
--===================================================================================

SET IDENTITY_INSERT Image ON
GO

INSERT INTO Image (imgID, imgFront, imgBack, imgSmall)
    VALUES (1, 'kyrie-irving-front.jpg', 'kyrie-irving-back.jpg', 'bos-small.jpg'),
           (2, 'steph-curry-front.png', 'steph-curry-back.png', 'gsw-small.jpg'),
           (3, 'lebron-james-front.jpg', 'lebron-james-back.jpg', 'lal-small.jpg'),
           (4, 'james-harden-front.png', 'james-harden-back.png', 'hou-small.jpg'),
           (5, 'devin-booker-front.png', 'devin-booker-back.png', 'phx-small.jpg'),
           (6, 'russell-westbrook-front.png', 'russell-westbrook-back.png', 'okc-small.jpg'),
           (7, 'kemba-walker-front.png', 'kemba-walker-back.png', 'cha-small.jpg'),
           (8, 'victor-oladipo-front.jpg', 'victor-oladipo-back.jpg', 'ind-small.jpg')

SET IDENTITY_INSERT Image OFF
GO

-- Player
--===================================================================================

SET IDENTITY_INSERT Player ON
GO

DECLARE
  @playerData PLAYERTYPE
INSERT INTO @playerData
    VALUES (1, 'Kyrie', 'Irving', 'BOS', 11),
           (2, 'Steph', 'Curry', 'GSW', 30),
           (3, 'Lebron', 'James', 'LAL', 23),
           (4, 'James', 'Harden', 'HOU', 13),
           (5, 'Devin', 'Booker', 'PHX', 1),
           (6, 'Russell', 'Westbrook', 'OKC', 0),
           (7, 'Kemba', 'Walker', 'CHA', 15),
           (8, 'Victor', 'Oladipo', 'IND', 4)

EXEC usp_addPlayers @playerData
GO

SET IDENTITY_INSERT Player OFF
GO

-- Size
--===================================================================================
INSERT INTO Size
    VALUES ('S'),
           ('M'),
           ('L'),
           ('XL'),
           ('XXL')
GO

-- Product
--===================================================================================

INSERT INTO Product (prodDescription, prodPrice, teamID, playID, imgID)
    VALUES ('Number 11 Swingman Jersey', 100, 'BOS', 1, 1),
           ('Number 30 Swingman Jersey', 100, 'GSW', 2, 2),
           ('Number 23 Swingman Jersey', 100, 'LAL', 3, 3),
           ('Number 13 Swingman Jersey', 100, 'HOU', 4, 4),
           ('Number 1 Swingman Jersey', 100, 'PHX', 5, 5),
           ('Number 0 Swingman Jersey', 100, 'OKC', 6, 6),
           ('Number 15 Swingman Jersey', 100, 'CHA', 7, 7),
           ('Number 4 Swingman Jersey', 100, 'IND', 8, 8)
GO

-- Stock
--===================================================================================
INSERT INTO Stock (prodNumber, sizeID, stkLevel)
    VALUES ('BOS00001', 'S', 0),
           ('BOS00001', 'M', 1),
           ('BOS00001', 'L', 2),
           ('BOS00001', 'XL', 3),
           ('BOS00001', 'XXL', 4),
           ('GSW00002', 'S', 5),
           ('LAL00003', 'L', 6),
           ('HOU00004', 'M', 7),
           ('PHX00005', 'S', 8),
           ('OKC00006', 'S', 9),
           ('CHA00007', 'M', 10),
           ('IND00008', 'M', 11)

-- Shipping
--===================================================================================

SET IDENTITY_INSERT Shipping ON
GO

INSERT INTO Shipping (shipID, shipType, shipDays, shipCost)
    VALUES (1, 'Regular', 7, 10.00),
           (2, 'Express', 3, 15.00),
           (3, 'Courier', 1, 20.00),
           (4, 'The Flash', 0, 99.99)
GO

SET IDENTITY_INSERT Shipping OFF
GO

-- Users
--===================================================================================

SET IDENTITY_INSERT Users ON
GO

INSERT INTO Users (userID, userFirstName, userLastName, userEmail, userPhone, userUserName, userPassword, userAdmin)
    VALUES (1, 'Tyrrion', 'Lannister', 'shorty@kingslanding.co.uk', '0421224567', 'shorty69', 'sizematters', 0),
           (2, 'John', 'Smith', 'johnsmith@jerseysure.com.au', '0434434434', 'username', 'password', 1),
           (3, 'John', 'Smith', 'johnsmith@jerseysure.com.au', '0434434434', 'johnsmith', 'MoreSecurePassword', 0)
GO

SET IDENTITY_INSERT Users OFF
GO

-- Address
--===================================================================================

SET IDENTITY_INSERT Address ON
GO

INSERT INTO Address (addID, addStreet, addSuburb, addState, addZip)
    VALUES (1, '13 Headpike Row', 'Kings Landing', 'NSW', 2222),
           (2, 'PO Box 2212', 'Kings Landing', 'NSW', 2222),
           (3, '1 Generic St', 'Newcastle', 'NSW', 2300)
GO

SET IDENTITY_INSERT Address OFF
GO

-- AddressTypes
--===================================================================================

INSERT INTO AddressTypes
    VALUES ('P', 1, 1),
           ('B', 1, 2),
           ('P', 2, 3),
           ('P', 3, 3),
           ('B', 3, 3)
GO

-- Orders
--===================================================================================

SET IDENTITY_INSERT Orders ON
GO

INSERT INTO Orders (ordID, ordSubTotal, ordTotal, ordGST, ordPaid, shipID, userID)
    VALUES (1, 200, 210, 21, 1, 1, 1),
           (2, 100, 199.99, 19.99, 1, 4, 3)
GO

SET IDENTITY_INSERT Orders OFF
GO

-- CartItem
--===================================================================================

INSERT INTO CartItem (userID, ordID, prodNumber, sizeID, cartQuantity, cartProductTotal)
    VALUES (1, 1, 'BOS00001', 'L', 1, 100),
           (1, 1, 'BOS00001', 'S', 1, 100),
           (3, 2, 'LAL00003', 'XXL', 1, 100)
GO

-- CreditCardPM
--===================================================================================

INSERT INTO CreditCardPM
    VALUES ('9876543210123456', 'MCARD', 'Tyrrion B Lannister', 8, 2020, 1)
GO

-- PayPalPM
--===================================================================================

INSERT INTO PayPalPM
    VALUES ('johnsmith@jerseyshure.com.au', 2)
GO