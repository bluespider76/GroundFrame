/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TTRACTIONTYPE.sql
** Name:	rollingstock.TTRACTIONTYPE
** Desc:	Table to store the traction type
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

CREATE TABLE [rollingstock].[TTRACTIONTYPE]
(
	[itemno]						TINYINT NOT NULL,
	[name]							NVARCHAR(128) NOT NULL,
	[description]					NVARCHAR(2048) NULL
);

ALTER TABLE [rollingstock].[TTRACTIONTYPE] 
ADD CONSTRAINT PK_ROLLINGSTOCK_TTRACTIONTYPE PRIMARY KEY ([itemno] ASC);
GO