/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_HAS_LOCATION_GOT_CHILDREN.sql
** Name:	network.Usp_HAS_LOCATION_GOT_CHILDREN
** Desc:	Returns true if the location has child locations.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_HAS_LOCATION_GOT_CHILDREN'))
BEGIN
	DROP PROC [network].[Usp_HAS_LOCATION_GOT_CHILDREN]
END
GO

CREATE PROC [network].[Usp_HAS_LOCATION_GOT_CHILDREN]
(
	@itemno INT
)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [network].[TLOCATION] WHERE [parent_itemno] = @itemno)
	BEGIN
		SELECT
			[has_children] = CONVERT(BIT, 1);
	END
	ELSE
	BEGIN
		SELECT
			[has_children] = CONVERT(BIT, 0);
	END
END
GO
