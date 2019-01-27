/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Schemas\network.sql
** Name:	common
** Desc:	Schema to hold objects related to the network
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

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'network')
BEGIN 
	EXEC sp_ExecuteSQL @sql = N'CREATE SCHEMA [network];';
END
GO
