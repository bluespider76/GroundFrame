/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TRAKEREGION.sql
** Name:	rollingstock.TRAKEREGION
** Desc:	Table to store the regions a rake can be sourced from
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

CREATE TABLE [rollingstock].[TRAKEREGION]
(
	[itemno]					INT NOT NULL IDENTITY,
	[rake_itemno]				INT NOT NULL,
	[region_itemno]				INT NOT NULL
);

ALTER TABLE [rollingstock].[TRAKEREGION]
ADD CONSTRAINT PK_ROLLINGSTOCK_TRAKEREGION PRIMARY KEY ([itemno] ASC);

CREATE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [rollingstock].[TRAKEREGION] ([rake_itemno] ASC) INCLUDE ([region_itemno]);
GO

