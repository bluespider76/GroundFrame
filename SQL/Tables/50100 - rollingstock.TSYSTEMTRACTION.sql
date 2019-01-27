/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TSYSTEMTRACTION.sql
** Name:	rollingstock.TSYSTEMTRACTION
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

CREATE TABLE [rollingstock].[TSYSTEMTRACTION]
(
	[itemno]							INT NOT NULL IDENTITY(1,1),
	[traction_class_itemno]				INT NOT NULL,
	[parent_system_traction_itemno]		INT,
	[unique_number]						NVARCHAR(16) NOT NULL
);

ALTER TABLE [rollingstock].[TSYSTEMTRACTION]
ADD CONSTRAINT PK_ROLLINGSTOCK_TSYSTEMTRACTION PRIMARY KEY ([itemno] ASC);
GO
