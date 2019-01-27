/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\network.TDEPOT.sql
** Name:	network.TDEPOT
** Desc:	Table to store depot data
** Auth:	Tim Caceres
** Date:	2018-07-29
**************************
** Change History
**************************
** Ver	Date		Author		Description 
** ---  --------	-------		------------------------------------
** 1    2018-07-29  TC			Initial Script creation
**
*******************************/

CREATE TABLE [network].[TDEPOT] 
(
	[itemno]						INT IDENTITY(1,1) NOT NULL,
	[location_itemno]				INT NOT NULL,
	[start_ymdv]					INT NOT NULL,
	[end_ymdv]						INT NULL,
	[code]							NVARCHAR(16) NOT NULL,
	[ease_of_access]				DECIMAL(16,6) NOT NULL,
	[percentage_visible_from_train]	DECIMAL(16,6) NOT NULL,
	[capabilities]					INT NOT NULL
);

ALTER TABLE [network].[TDEPOT] 
ADD CONSTRAINT PK_NETWORK_DEPOT PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [network].[TDEPOT] ([location_itemno], [start_ymdv] ASC);
GO

