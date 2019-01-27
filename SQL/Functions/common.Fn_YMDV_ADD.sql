/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Functions\common.Fn_YMDV_ADD.sql
** Name:	common.Usp_SAVE_TLOCATIONS
** Desc:	Returns the ymdv of the supplied ymdv +/- the number of days
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
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('common.Fn_YMDV_ADD'))
BEGIN
	DROP FUNCTION [common].[Fn_YMDV_ADD]
END
GO

CREATE FUNCTION [common].[Fn_YMDV_ADD]
(
	@ymdv	INT,
	@days	INT
)
RETURNS INT
AS
BEGIN
	DECLARE @date DATE = DATEADD(DAY,@days, (SELECT [ymdv_date] FROM [common].[TCALENDAR] WHERE [ymdv] = @ymdv));
	DECLARE @return_ymdv INT

	IF @days < 1
	BEGIN
		SELECT
			@return_ymdv = MAX([ymdv])
		FROM [common].[TCALENDAR]
		WHERE
			[ymdv_date] <= @date;
	END
	ELSE
	BEGIN
		SELECT
			@return_ymdv = MIN([ymdv])
		FROM [common].[TCALENDAR]
		WHERE
			[ymdv_date] > @date;	
	END
	
	RETURN @return_ymdv;
END
GO