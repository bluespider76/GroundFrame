/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\wtt.TTRAIN.sql
** Name:	wtt.TTRAIN
** Desc:	Table to store the trains
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

CREATE TABLE [wtt].[TTRAIN]
(
	[itemno]							INT NOT NULL IDENTITY(1,1),
	[start_ymdv]						INT NOT NULL,
	[end_ymdv]							INT NULL,
	[headcode]							NVARCHAR(8) NOT NULL,
	[description]						NVARCHAR(2048) NULL,
	[start_location_itemno]				INT NOT NULL,
	[end_location_itemno]				INT NOT NULL,
	[mp_next_train_itemno]				INT,
	[mp_next_train_perc]				DECIMAL(16,6),
	[mp_next_train_min_turnaround]		TINYINT,
	[stock_next_train_itemno]			INT,
	[stock_next_train_perc]				DECIMAL(16,6),
	[stock_next_train_min_turnaround]	TINYINT,
	[parent_train_itemno]				INT NULL,
	[mins_allocation_on_tops]			TINYINT,
	[start_time]						BIGINT NOT NULL, --Stored as Ticks
	[days]								TINYINT NOT NULL,
	[brake_types]						TINYINT NOT NULL,
	[heat_types]						TINYINT NOT NULL,
	[configuration]						BIGINT NOT NULL CONSTRAINT DF_WTT_TRAIN_CONFIGURATION DEFAULT 0,
	[max_speed]							SMALLINT NOT NULL,
	[max_speed_if_late]					SMALLINT,
	[run_as_required]					BIT NOT NULL CONSTRAINT DF_WTT_TRAIN_RUNASREQUIRED DEFAULT 0,
	[run_as_required_perc]				TINYINT NOT NULL CONSTRAINT DF_WTT_TRAIN_RUNASREQUIREDPERC DEFAULT 0,
	[runs_once]							BIT NOT NULL CONSTRAINT DF_WTT_TRAIN_RUNSONCE DEFAULT 0
);

ALTER TABLE [wtt].[TTRAIN]
ADD CONSTRAINT PK_WTT_TTRAIN PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [wtt].[TTRAIN] ([headcode], [start_location_itemno], [start_time] ASC);
GO

