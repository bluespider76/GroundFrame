/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\rollingstock.Usp_GET_RAKE_ELEMENTS.sql
** Name:	rollingstock.Usp_GET_RAKE_ELEMENTS
** Desc:	Gets a list of elements for the supplied rake itemno
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_RAKE_ELEMENTS'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_RAKE_ELEMENTS];
END
GO

CREATE PROC [rollingstock].[Usp_GET_RAKE_ELEMENTS]
(
	@rake_itemno INT
)
AS
BEGIN
	SELECT
		itemno
	FROM [rollingstock].[TRAKEELEMENT] AS RD
	WHERE
		RD.[rake_itemno] = @rake_itemno;
END
GO
