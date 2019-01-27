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

CREATE TABLE [network].[TLOCATION] 
(
	[itemno]					INT IDENTITY(1,1),
	[location_itemno]			INT NULL,
	[start_ymdv]				INT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_STARTYMV DEFAULT 18500101,
	[end_ymdv]					INT NULL,
	[name]						NVARCHAR(128) NOT NULL,
	[tiploc]					NVARCHAR(16) NULL,
	[stanox]					INT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_STANOX DEFAULT 0,
	[stanme]					NVARCHAR(32) NULL,
	[nlc]						INT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_NLC DEFAULT 0,
	[location_type_itemno]		SMALLINT NOT NULL,
	[latitude]					DECIMAL(16,6) NULL,
	[longitude]					DECIMAL(16,6) NULL,
	[parent_itemno]				INT NULL,
	[length]					DECIMAL(16,6) NOT NULL,
	[disembark_passengers]		BIT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_DISEMBARK_PASSENGERS DEFAULT 1,
	[embark_passengers]			BIT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_EMBARK_PASSENGERS DEFAULT 1,
	[freight_only]				BIT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_FREIGHT_ONLY_PASSENGERS DEFAULT 0,
	[single_train_working]		BIT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_SINGLE_TRAIN_WORKING DEFAULT 0,
	[token_itemno]				INT NULL,
	[berths]					SMALLINT NOT NULL,
	[direction]					TINYINT NOT NULL,
	[score]						SMALLINT CONSTRAINT DF_NETWORK_TLOCATION_SCORE DEFAULT 10,
	[use_as_timing_point]		BIT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_USE_AS_TIMING_POINT DEFAULT 1,
	[options]					BIGINT CONSTRAINT DF_NETWORK_TLOCATION_OPTIONS DEFAULT 0,
	[permissible_power]			BIGINT NOT NULL,
	[tops_office]				BIT NOT NULL CONSTRAINT DF_NETWORK_TLOCATION_TOPSOFFICE DEFAULT 0
);

ALTER TABLE [network].[TLOCATION] 
ADD CONSTRAINT PK_NETWORK_LOCATION PRIMARY KEY ([itemno] ASC);

ALTER TABLE [network].[TLOCATION]
ADD CONSTRAINT FK_NETWORK_LOCATION_NETWORK_SYSTEMLOCATION FOREIGN KEY ([location_itemno]) REFERENCES [network].[TSYSTEMLOCATION] ([system_itemno]);

ALTER TABLE [network].[TLOCATION]
ADD CONSTRAINT FK_NETWORK_LOCATION_NETWORK_LOCATIONTYPE FOREIGN KEY ([location_type_itemno]) REFERENCES [network].[TLOCATIONTYPE] ([itemno]);
GO

ALTER TABLE [network].[TLOCATION]
ADD CONSTRAINT FK_NETWORK_LOCATION_PARENT_NETWORK_LOCATION FOREIGN KEY ([parent_itemno]) REFERENCES [network].[TLOCATION] ([itemno]);
GO

ALTER TABLE [network].[TLOCATION]
ADD CONSTRAINT FK_NETWORK_LOCATION_NETWORK_TOKEN FOREIGN KEY ([token_itemno]) REFERENCES [network].[TTOKEN] ([itemno]);
GO

IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IDX_NONCLUSTERED_1' AND object_id = OBJECT_ID('network.TLOCATION'))
BEGIN
	DROP INDEX [IDX_NONCLUSTERED_1] ON [network].[TLOCATION];
END

CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [network].[TLOCATION] ([location_itemno], parent_itemno, [name] ASC) WHERE [end_ymdv] IS NULL
GO