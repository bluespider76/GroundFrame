/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\wtt.TTRAINTRACTIONALLOCATION.sql
** Name:	wtt.TTRAINTRACTIONALLOCATION
** Desc:	Table to the book allocation(s) for the train
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

CREATE TABLE [wtt].[TTRAINTRACTIONALLOCATION]
(
	[itemno]							INT NOT NULL IDENTITY(1,1),
	[start_ymdv]						INT NOT NULL,
	[end_ymdv]							INT NULL,
	[train_itemno]						INT NOT NULL,
	[traction_class_itemno]				INT NOT NULL,
	[sector_itemno]						INT NULL,
	[depot_location_itemno]				INT NULL,
	[region_itemno]						INT NULL,
	[perc]								NUMERIC(16,6),
	[booked_traction]					BIT NOT NULL CONSTRAINT DF_WTT_TTRAINTRACTIONALLOCATION_BOOKEDTRACTION DEFAULT 0,
);

ALTER TABLE [wtt].[TTRAINTRACTIONALLOCATION]
ADD CONSTRAINT PK_WTT_TTRAINTRACTIONALLOCATION PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [wtt].[TTRAINTRACTIONALLOCATION] ([train_itemno], [traction_class_itemno], [depot_location_itemno], [sector_itemno] ASC) INCLUDE ([perc]);
GO

