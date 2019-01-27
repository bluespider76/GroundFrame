/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\wtt.TCALLINGPOINT.sql
** Name:	wtt.TCALLINGPOINT
** Desc:	Table to the store the calling points for a train
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

CREATE TABLE [wtt].[TCALLINGPOINT]
(
	[itemno]							INT NOT NULL IDENTITY(1,1),
	[train_itemno]						INT NOT NULL,
	[location_itemno]					INT NOT NULL,
	[arr]								BIGINT NOT NULL CONSTRAINT DF_WTT_TCALLINGPOINT_ARR DEFAULT 0,
	[dep]								BIGINT NOT NULL CONSTRAINT DF_WTT_TCALLINGPOINT_DEP DEFAULT 0,
	[setdownonly]						BIT NOT NULL CONSTRAINT DF_WTT_TCALLINGPOINT_SETDOWNONLY DEFAULT 0,
	[pickuponly]						BIT NOT NULL CONSTRAINT DF_WTT_TCALLINGPOINT_PICKUPONLY DEFAULT 0,
	[mindwelltime]						BIGINT NOT NULL CONSTRAINT DF_WTT_TCALLINGPOINT_MINDWELLTIME DEFAULT 0,
	[order]								SMALLINT NOT NULL
);

ALTER TABLE [wtt].[TCALLINGPOINT]
ADD CONSTRAINT PK_WTT_TCALLINGPOINT PRIMARY KEY ([itemno] ASC);
GO
