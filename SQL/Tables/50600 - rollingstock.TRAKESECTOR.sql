/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TRAKESECTOR.sql
** Name:	rollingstock.TRAKESECTOR
** Desc:	Table to store the sectors a rake can be sourced from
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

CREATE TABLE [rollingstock].[TRAKESECTOR]
(
	[itemno]					INT NOT NULL IDENTITY,
	[rake_itemno]				INT NOT NULL,
	[sector_itemno]				INT NOT NULL
);

ALTER TABLE [rollingstock].[TRAKESECTOR]
ADD CONSTRAINT PK_ROLLINGSTOCK_TRAKESECTOR PRIMARY KEY ([itemno] ASC);

CREATE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [rollingstock].[TRAKESECTOR] ([rake_itemno] ASC) INCLUDE ([sector_itemno]);
GO

