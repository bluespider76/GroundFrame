/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Schemas\rollingstock.sql
** Name:	rollingstock
** Desc:	Schema to hold objects related to Rolling Stock
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

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'rollingstock')
BEGIN 
	EXEC sp_ExecuteSQL @sql = N'CREATE SCHEMA [rollingstock];';
END
GO
