/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\logical.TSECTOR.sql
** Name:	common.TPOWERTYPE
** Desc:	Table to store the power types
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

CREATE TABLE [common].[TPOWERTYPE] 
(
	[itemno]					INT NOT NULL,
	[name]						NVARCHAR(256) NOT NULL,
	[description]				NVARCHAR(2048) NULL
);

ALTER TABLE [common].[TPOWERTYPE]
ADD CONSTRAINT PK_COMMON_TPOWERTYPE PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [common].[TPOWERTYPE] ([itemno] ASC);
GO

