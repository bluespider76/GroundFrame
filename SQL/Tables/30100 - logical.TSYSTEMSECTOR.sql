/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\logical.TSYSTEMSECTOR.sql
** Name:	logical.TSYSTEMSECTOR
** Desc:	Table to store the system sector
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

CREATE TABLE [logical].[TSYSTEMSECTOR] 
(
	[itemno]					INT NOT NULL IDENTITY,
	[code]						NVARCHAR(4) NOT NULL
);

ALTER TABLE [logical].[TSYSTEMSECTOR]
ADD CONSTRAINT PK_LOGICAL_TSYSTEMSECTOR PRIMARY KEY ([itemno] ASC);

CREATE UNIQUE NONCLUSTERED INDEX IDX_NONCLUSTERED_1 ON [logical].[TSYSTEMSECTOR] ([code] ASC);
GO
