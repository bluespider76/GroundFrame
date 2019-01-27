/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TSTOCK.sql
** Name:	rollingstock.TSTOCK
** Desc:	Table to store the stock
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

CREATE TABLE [rollingstock].[TSTOCK]
(
	[itemno]					INT NOT NULL IDENTITY,
	[start_ymdv]				INT NOT NULL,
	[end_ymdv]					INT NULL,
	[type_itemno]				TINYINT NOT NULL,
	[name]						NVARCHAR(128) NOT NULL,
	[description]				NVARCHAR(2048),
	[coupling_types]			SMALLINT NOT NULL,
	[brake_types]				SMALLINT NOT NULL,
	[heating_types]				SMALLINT NOT NULL,
	[max_speed]					SMALLINT NOT NULL,
	[length]					NUMERIC(16,6) NOT NULL,
	[options]					INT NOT NULL CONSTRAINT DF_ROLLINGSTOCK_TSTOCK_OPTIONS DEFAULT 0,
	[eth_index]					SMALLINT NOT NULL,
	[weight]					SMALLINT NOT NULL
);

ALTER TABLE [rollingstock].[TSTOCK]
ADD CONSTRAINT PK_ROLLINGSTOCK_TSTOCK PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [rollingstock].[TSTOCK] ([type_itemno], [name], [start_ymdv] ASC);
GO
