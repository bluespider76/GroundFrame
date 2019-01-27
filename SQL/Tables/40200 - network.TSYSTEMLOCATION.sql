/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\network.TSYSTEMLOCATION.sql
** Name:	network.TSYSTEMLOCATION
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

CREATE TABLE [network].[TSYSTEMLOCATION] 
(
	[system_itemno]				INT NOT NULL IDENTITY(1,1),
	[system_name]				NVARCHAR(128) NOT NULL
);
GO

ALTER TABLE [network].[TSYSTEMLOCATION] 
ADD CONSTRAINT PK_NETWORK_SYSTEMLOCATION PRIMARY KEY ([system_itemno] ASC)
GO
