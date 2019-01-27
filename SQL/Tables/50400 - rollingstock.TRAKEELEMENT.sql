/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TRAKEELEMENT.sql
** Name:	rollingstock.TRAKEELEMENT
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

CREATE TABLE [rollingstock].[TRAKEELEMENT]
(
	[itemno]					INT NOT NULL IDENTITY,
	[rake_itemno]				INT NOT NULL,
	[stock_itemno]				INT NOT NULL,
	[number]					TINYINT
);

ALTER TABLE [rollingstock].[TRAKEELEMENT]
ADD CONSTRAINT PK_ROLLINGSTOCK_TRAKEELEMENT PRIMARY KEY ([itemno] ASC);

CREATE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [rollingstock].[TRAKEELEMENT] ([rake_itemno] ASC) INCLUDE ([stock_itemno]);
GO

