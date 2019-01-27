/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\users.TUSERCREDENTIALS.sql
** Name:	users.TUSERCREDENTIALS
** Desc:	Table to store the users credentials
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

CREATE TABLE [users].[TUSERCREDENTIALS]
(
	[itemno]						INT IDENTITY(1,1) NOT NULL,
	[user_itemno]					INT NOT NULL,
	[credential_provider_itemno]	TINYINT NOT NULL,
	[user_name]						NVARCHAR(256) NOT NULL,
	[passwordhash]					BINARY(64) NULL,		
	[last_login_date]				DATETIME2,
	[login_attempts]				TINYINT NOT NULL CONSTRAINT DF_TUSERCREDENTIALS_LOGIN_ATTEMPTS DEFAULT 0
);

ALTER TABLE [users].[TUSERCREDENTIALS] 
ADD CONSTRAINT PK_USERS_TUSERCREDENTIALS PRIMARY KEY ([itemno] ASC);
GO
