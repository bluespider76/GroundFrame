/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\users.TUSERUNIQUEID.sql
** Name:	users.TUSERUNIQUEID
** Desc:	Stores the unique ID of the user.
** Auth:	Tim Caceres
** Date:	2018-04-13
**************************
** Change History
**************************
** Ver	Date		Author		Description 
** ---  --------	-------		------------------------------------
** 1    2018-07-19  TC			Initial Script creation
**
*******************************/

CREATE TABLE [users].[TUSERUNIQUEID]
(
	[itemno]						INT IDENTITY(1,1) NOT NULL,
	[user_itemno]					INT NOT NULL,
	[unique_id]						UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_TUSERUNIQUEID_UNIQUEID DEFAULT NEWID(),
	[db_rowversion]					ROWVERSION,
	[db_createdon]					DATETIME2 NOT NULL CONSTRAINT DF_TUSERCREDENTIALS_CREATEDON DEFAULT GETUTCDATE(),
	[db_modifiedon]					DATETIME2 NOT NULL CONSTRAINT DF_TUSERCREDENTIALS_MODIFIEDON DEFAULT GETUTCDATE(),
);

ALTER TABLE [users].[TUSERUNIQUEID] 
ADD CONSTRAINT PK_USERS_TUSERUNIQUEID PRIMARY KEY ([itemno] ASC);
GO
