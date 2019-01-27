/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TTRACTION.sql
** Name:	rollingstock.TTRACTION
** Desc:	Table to store individual traction
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

CREATE TABLE [rollingstock].[TTRACTION]
(
	[itemno]							INT NOT NULL IDENTITY(1,1),
	[start_ymdv]						INT NOT NULL,
	[end_ymdv]							INT NULL,
	[traction_itemno]					INT NOT NULL,
	[display_name]						NVARCHAR(16) NOT NULL,
	[name]								NVARCHAR(256) NULL,
	[depot_itemno]						INT NOT NULL,
	[sector_itemno]						INT NULL,
	[brake_itemno]						SMALLINT NOT NULL,
	[heat_itemno]						SMALLINT NOT NULL,
	[eth_index]							TINYINT NULL,
	[coupling_itemno]					SMALLINT NOT NULL,
	[livery_itemno]						SMALLINT NOT NULL,
	[multiple_working_type_itemno]		SMALLINT NULL
);

ALTER TABLE [rollingstock].[TTRACTION]
ADD CONSTRAINT PK_ROLLINGSTOCK_TTRACTION PRIMARY KEY ([itemno] ASC);
GO
