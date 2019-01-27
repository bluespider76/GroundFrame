/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\logical.TSECTOR.sql
** Name:	logical.TSECTOR
** Desc:	Table to store the sectors
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

CREATE TABLE [logical].[TSECTOR] 
(
	[itemno]					INT NOT NULL IDENTITY,
	[code_itemno]				INT NOT NULL,
	[start_ymdv]				INT NOT NULL,
	[end_ymdv]					INT NULL,
	[description]				NVARCHAR(2048) NOT NULL
);

ALTER TABLE [logical].[TSECTOR]
ADD CONSTRAINT PK_LOGICAL_TSECTOR PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [logical].[TSECTOR] ([code_itemno], [start_ymdv] ASC);
GO

