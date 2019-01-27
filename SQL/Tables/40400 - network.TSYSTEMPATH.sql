/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\network.TSYSTEMPATH.sql
** Name:	network.TSYSTEMPATH
** Desc:	Table to store the path system name
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

CREATE TABLE [network].[TSYSTEMPATH] 
(
	[system_itemno]					INT NOT NULL IDENTITY(1,1),
	[system_name]					NVARCHAR(128) NOT NULL,
	[system_description]			NVARCHAR(2048) NULL,
	[system_start_location_itemno]	INT NOT NULL,
	[system_end_location_itemno]	INT NOT NULL
);
GO

ALTER TABLE [network].[TSYSTEMPATH] 
ADD CONSTRAINT PK_NETWORK_SYSTEMPATH PRIMARY KEY ([system_itemno] ASC)
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IDX_NONCLUSTERED_1' and object_id = OBJECT_ID('network.TSYSTEMPATH'))
BEGIN
	CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [network].[TSYSTEMPATH] ([system_start_location_itemno], [system_end_location_itemno] ASC)
END
GO



