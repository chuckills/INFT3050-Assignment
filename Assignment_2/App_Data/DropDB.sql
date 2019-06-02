USE JerseySure
GO
DROP TABLE CreditCardPM
GO
DROP TABLE CartItem
GO
DROP TABLE Orders
GO
DROP TABLE Shipping
GO
DROP TABLE Stock
GO
DROP TABLE Product
GO
DROP TABLE Image
GO
DROP TABLE JerseyNumber
GO
DROP TABLE Player
GO
DROP TABLE Team
GO
DROP TABLE AddressTypes
GO
DROP TABLE Address
GO
DROP TABLE Users
GO
DROP PROCEDURE usp_addNewPlayer
GO
DROP PROCEDURE usp_addPlayers
GO
DROP PROCEDURE usp_getProducts
GO
DROP PROCEDURE usp_getProductsSearch
GO
DROP PROCEDURE usp_selectProduct
GO
DROP PROCEDURE usp_addProduct
GO
DROP PROCEDURE usp_getUser
GO
DROP PROCEDURE usp_getSingleUser
GO
DROP PROCEDURE usp_getUserByEmail
GO
DROP PROCEDURE usp_getUsers
GO
DROP PROCEDURE usp_addUser
GO
DROP PROCEDURE usp_updateUser
GO
DROP PROCEDURE usp_getTeams
GO
DROP PROCEDURE usp_getAddress
GO
DROP PROCEDURE usp_getProductStock
GO
DROP PROCEDURE usp_changeUserPassword
GO
DROP PROCEDURE usp_getShipping
GO
DROP PROCEDURE usp_getShipDetails
GO
DROP TYPE PLAYERTYPE
GO
DROP USER jerseysure
GO
USE master
GO
DROP LOGIN jerseysure
GO

DECLARE @command VARCHAR(MAX)
SELECT @command = 'KILL ' + CAST(session_id AS VARCHAR)
FROM sys.dm_exec_sessions
WHERE DB_NAME(database_id) = 'JerseySure'
EXECUTE (@command)
GO

DROP DATABASE JerseySure
GO
