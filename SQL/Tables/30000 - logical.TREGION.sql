/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\logical.TREGION.sql
** Name:	logical.TREGION
** Desc:	Table to the regions
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

CREATE TABLE [logical].[TREGION]
(
	[itemno]							INT NOT NULL IDENTITY(1,1),
	[start_ymdv]						INT NOT NULL,
	[end_ymdv]							INT NULL,
	[name]								NVARCHAR(128) NOT NULL,
	[description]						NVARCHAR(2056) NULL
);

ALTER TABLE [logical].[TREGION]
ADD CONSTRAINT PK_LOGICAL_TREGION PRIMARY KEY ([itemno] ASC);
GO
