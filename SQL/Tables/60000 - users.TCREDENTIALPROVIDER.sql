/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\users.TCREDENTIALPROVIDER.sql
** Name:	users.TCREDENTIALPROVIDER
** Desc:	Table to store the various credential providers that can be used to log in
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

CREATE TABLE [users].[TCREDENTIALPROVIDER]
(
	[itemno]						TINYINT NOT NULL,
	[provider_name]					NVARCHAR(128) NOT NULL,
	[provider_description]			NVARCHAR(1024) NOT NULL
);

ALTER TABLE [users].[TCREDENTIALPROVIDER] 
ADD CONSTRAINT PK_USERS_TCREDENTIALPROVIDER PRIMARY KEY ([itemno] ASC);

ALTER TABLE [users].[TCREDENTIALPROVIDER] 
ADD CONSTRAINT UQ_USERS_TCREDENTIALPROVIDER_NAME UNIQUE ([provider_name]);
GO
