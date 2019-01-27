/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TRAKEDEPOT.sql
** Name:	rollingstock.TRAKEDEPOT
** Desc:	Table to store the rake elements
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

CREATE TABLE [rollingstock].[TRAKEDEPOT]
(
	[itemno]					INT NOT NULL IDENTITY,
	[rake_itemno]				INT NOT NULL,
	[depot_location_itemno]		INT NOT NULL
);

ALTER TABLE [rollingstock].[TRAKEDEPOT]
ADD CONSTRAINT PK_ROLLINGSTOCK_TDEPOT PRIMARY KEY ([itemno] ASC);

CREATE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [rollingstock].[TRAKEDEPOT] ([depot_location_itemno] ASC);
GO

