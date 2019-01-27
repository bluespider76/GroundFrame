/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\app.Usp_GENERATE_ENCRYPTION_TOKEN.sql
** Name:	network.Usp_GENERATE_ENCRYPTION_TOKEN
** Desc:	Retieves all depot records for a given system location and ymdv.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('app.Usp_GENERATE_ENCRYPTION_TOKEN'))
BEGIN
	DROP PROC [app].[Usp_GENERATE_ENCRYPTION_TOKEN]
END
GO

CREATE PROC [app].[Usp_GENERATE_ENCRYPTION_TOKEN]
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(1024);
	
	BEGIN TRY		
		INSERT INTO [app].[TENCRYPTIONTOKEN]
		(
			[token]
		)
		SELECT
			NEWID();
	END TRY
	BEGIN CATCH
		SET @message = 'Error trying to issue a new encryption token:- ' + ERROR_MESSAGE();
		RAISERROR (@message, 16, 1);
		
		/*To Do*/
		
		/*Application needs to be disabled*/
		
		RETURN;
	END CATCH
			
	DECLARE @itemno INT = CONVERT(INT, ISNULL((SELECT SCOPE_IDENTITY()),0));
	
	IF (@itemno = 0)
	BEGIN
		RAISERROR ('Cannot issue a new encrytion token', 16, 1);
		RETURN;
	END
	
	--Delete old tokents but only if a new token was create in the last 60 minutes.
	
	DECLARE @hour_ago DATETIME2 = DATEADD(MINUTE,-60, GETUTCDATE());
	
	IF EXISTS (SELECT 1 FROM [app].[TENCRYPTIONTOKEN] WHERE [db_createdon] > @hour_ago AND [itemno] != @itemno)
	BEGIN		
		DELETE FROM [app].[TENCRYPTIONTOKEN]
		WHERE
			[db_createdon] <= @hour_ago;
	END
	
	SET NOCOUNT OFF;
END
GO
