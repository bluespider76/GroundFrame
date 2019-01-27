/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\wtt.TTRAINRAKEALLOCATION.sql
** Name:	rollingstock.TTRAINRAKEALLOCATION
** Desc:	Table to store the train rake allocations
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

CREATE TABLE [wtt].[TTRAINRAKEALLOCATION]
(
	[itemno]					INT NOT NULL IDENTITY,
	[start_ymdv]				INT NOT NULL,
	[end_ymdv]					INT NULL,
	[train_itemno]				INT NOT NULL,
	[rake_itemno]				INT NOT NULL,
	[perc]						DECIMAL(16,6) NOT NULL,
	[booked_rake]				BIT NOT NULL CONSTRAINT DF_WTT_TTRAINRAKEALLOCATION_BOOKEDRAKE DEFAULT 0,
);

ALTER TABLE [wtt].[TTRAINRAKEALLOCATION]
ADD CONSTRAINT PK_WTT_TTRAINRAKEALLOCATION PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [wtt].[TTRAINRAKEALLOCATION] ([train_itemno], [rake_itemno] ASC) INCLUDE ([perc]);
GO
