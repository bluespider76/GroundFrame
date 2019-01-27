/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\network.TPATH.sql
** Name:	network.TPATH
** Desc:	Table to store the path
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

CREATE TABLE [network].[TPATH] 
(
	[itemno]					INT IDENTITY(1,1),
	[path_itemno]				INT NOT NULL,
	[start_ymdv]				INT NOT NULL,
	[end_ymdv]					INT NULL,
	[start_location_itemno]		INT NOT NULL,
	[end_location_itemno]		INT NOT NULL,
	[distance]					NUMERIC(16,6) NOT NULL, --Meters
	[direction]					TINYINT NOT NULL,
	[token_itemno]				INT NULL,
	[type_itemno]				SMALLINT NOT NULL,
	[route_availability]		SMALLINT NOT NULL,
	[berths]					SMALLINT NOT NULL CONSTRAINT DF_NETWORK_PATH_BERTHS DEFAULT 0,
	[permissible_power]			SMALLINT NOT NULL,
	[crossing_count]			SMALLINT NOT NULL,
	[score]						SMALLINT NOT NULL,
	[freight_only]				BIT NOT NULL CONSTRAINT DF_NETWORK_PATH_FREIGHT_ONLY DEFAULT 0,
	[max_speed]					SMALLINT NOT NULL,
	[rating]					DECIMAL(16,6) NOT NULL CONSTRAINT DF_NETWORK_PATH_RATING DEFAULT 0,
	[signal_type_itemno]		SMALLINT NOT NULL CONSTRAINT DF_NETWORK_PATH_SIGNAL_TYPE DEFAULT 1,
	[options]					BIGINT  NOT NULL CONSTRAINT DF_NETWORK_PATH_OPTIONS DEFAULT 0
);
GO

ALTER TABLE [network].[TPATH] 
ADD CONSTRAINT PK_NETWORK_PATH PRIMARY KEY ([itemno] ASC)
GO
