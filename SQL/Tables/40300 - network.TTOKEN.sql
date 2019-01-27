/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\network.TLOCATION.sql
** Name:	network.TSYSTEMLOCATION
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

CREATE TABLE [network].[TTOKEN] 
(
	[itemno]					INT NOT NULL IDENTITY(1,1),
	[token_name]				NVARCHAR(128) NOT NULL,
	[token_description]			NVARCHAR(1024) NOT NULL,
	[system_token]				BIT NOT NULL CONSTRAINT DF_NETWORK_TOKEN_SYSTEM_TOKEN DEFAULT 0
);

ALTER TABLE [network].[TTOKEN] 
ADD CONSTRAINT PK_NETWORK_TOKEN PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [network].[TTOKEN] ([token_name] ASC);
GO
