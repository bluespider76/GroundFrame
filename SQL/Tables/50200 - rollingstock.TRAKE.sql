/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TRAKE.sql
** Name:	rollingstock.TRAKE
** Desc:	Table to store the stock rake
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

CREATE TABLE [rollingstock].[TRAKE]
(
	[itemno]					INT NOT NULL IDENTITY,
	[start_ymdv]				INT NOT NULL,
	[end_ymdv]					INT NULL,
	[name]						NVARCHAR(128) NOT NULL,
	[description]				NVARCHAR(2048)
);

ALTER TABLE [rollingstock].[TRAKE]
ADD CONSTRAINT PK_ROLLINGSTOCK_TRAKE PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [rollingstock].[TRAKE] ([name] ASC);
GO

