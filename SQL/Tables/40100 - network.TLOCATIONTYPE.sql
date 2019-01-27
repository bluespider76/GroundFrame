/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\network.TLOCATIONTYPE.sql
** Name:	network.TLOCATIONTYPE
** Desc:	Table to store the location type
** Auth:	Tim Caceres
** Date:	2018-07-19
**************************
** Change History
**************************
** Ver	Date		Author		Description 
** ---  --------	-------		------------------------------------
** 1    2018-07-19  TC			Initial Script creation
**
*******************************/

CREATE TABLE [network].[TLOCATIONTYPE] 
(
	[itemno]					SMALLINT NOT NULL,
	[name]						NVARCHAR(128)
);

ALTER TABLE [network].[TLOCATIONTYPE] 
ADD CONSTRAINT PK_NETWORK_LOCATIONTYPE PRIMARY KEY ([itemno] ASC);
GO
