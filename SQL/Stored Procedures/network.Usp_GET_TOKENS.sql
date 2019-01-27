/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_TOKENS.sql
** Name:	network.Usp_GET_TOKENS
** Desc:	Saves a new instance of a location and closes and previous open record
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_TOKENS'))
BEGIN
	DROP PROC [network].[Usp_GET_TOKENS]
END
GO

CREATE PROC [network].[Usp_GET_TOKENS]

AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[token_name],
		[token_description],
		[system_token]
	FROM [network].[TTOKEN]
		
	SET NOCOUNT OFF;
END
GO
