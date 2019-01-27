/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\users.TUSER.sql
** Name:	users.TUSER
** Desc:	Table to store the location system name
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

CREATE TABLE [users].[TUSER]
(
	[itemno]						INT IDENTITY(1,1) NOT NULL,
	[unique_id_rowversion]			VARBINARY(8) NOT NULL,
	[last_name]						NVARCHAR(256) NOT NULL,
	[first_name]					NVARCHAR(128) NOT NULL,
	[display_name]					NVARCHAR(256) NOT NULL,
	[contact_email]					NVARCHAR(512) NOT NULL,
	[contact_preferences]			INT NOT NULL CONSTRAINT DF_TUSER_CONTACT_PREFERENCES DEFAULT 0,
	[account_locked]				BIT NOT NULL CONSTRAINT DF_TUSER_ACCOUNT_LOCKED DEFAULT 0,
	[token]							UNIQUEIDENTIFIER	
);

ALTER TABLE [users].[TUSER] 
ADD CONSTRAINT PK_USERS_TUSER PRIMARY KEY ([itemno] ASC);

ALTER TABLE [users].[TUSER] 
ADD CONSTRAINT UQ_USERS_DISPLAYNAME UNIQUE ([display_name]);

ALTER TABLE [users].[TUSER] 
ADD CONSTRAINT UQ_USERS_EMAIL UNIQUE ([contact_email]);
GO
