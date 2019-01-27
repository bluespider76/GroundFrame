/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TTRACTIONCLASS.sql
** Name:	rollingstock.TTRACTIONCLASS
** Desc:	Table to store individual traction
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

CREATE TABLE [rollingstock].[TTRACTIONCLASS]
(
	[itemno]							INT NOT NULL IDENTITY(1,1),
	[start_ymdv]						INT NOT NULL,
	[end_ymdv]							INT NULL,
	[name]								NVARCHAR(128) NOT NULL,
	[description]						NVARCHAR(2048) NOT NULL,
	[parent_itemno]						INT NULL,
	[traction_type_itemno]				TINYINT NOT NULL,
	[length]							DECIMAL(16,6),
	[route_availability]				TINYINT NOT NULL
);

ALTER TABLE [rollingstock].[TTRACTIONCLASS]
ADD CONSTRAINT PK_ROLLINGSTOCK_TTRACTIONCLASS PRIMARY KEY ([itemno] ASC);
GO
