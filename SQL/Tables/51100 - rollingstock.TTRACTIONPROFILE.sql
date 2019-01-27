/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\rollingstock.TTRACTIONPROFILE.sql
** Name:	rollingstock.TTRACTIONPROFILE
** Desc:	Table to store the location system name
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

CREATE TABLE [rollingstock].[TTRACTIONPROFILE]
(
	[itemno]						INT IDENTITY(1,1),
	[traction_class_itemno]			INT NOT NULL,
	[max_speed]						SMALLINT NOT NULL,
	[max_speed_light_loco]			SMALLINT NOT NULL,
	[power_itemno]					INT NOT NULL,
	[tractive_effort]				INT NOT NULL,
	[horse_power]					INT NOT NULL
);

ALTER TABLE [rollingstock].[TTRACTIONPROFILE] 
ADD CONSTRAINT PK_ROLLINGSTOCK_TRACTIONPROFILE PRIMARY KEY ([itemno] ASC);
GO
