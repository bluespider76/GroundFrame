/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_SAVE_TOKEN.sql
** Name:	network.Usp_SAVE_TOKEN
** Desc:	Saves a Token record
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_SAVE_TOKEN'))
BEGIN
	DROP PROC [network].[Usp_SAVE_TOKEN]
END
GO

CREATE PROC [network].[Usp_SAVE_TOKEN]
(
	@itemno INT,
	@name NVARCHAR(128),
	@description NVARCHAR(1024),
	@system_token BIT
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @message NVARCHAR(512);
	
	IF EXISTS (SELECT 1 FROM network.TTOKEN WHERE [token_name] = @name) AND ISNULL(@itemno,0) = 0
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TOKEN]:- Token ' + @name + ' already exists in the database.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END

	IF ISNULL(@itemno,0) != 0
	BEGIN
		UPDATE network.TTOKEN
		SET
			[token_name] = ISNULL(NULLIF(@name,''),[token_name]),
			[token_description] = ISNULL(NULLIF(@description,''),[token_description]),
			[system_token] = ISNULL(@system_token,0)
		WHERE
			[itemno] = @itemno;
			
		SELECT
			[itemno] = @itemno;
	END
	ELSE
	BEGIN
		INSERT INTO network.TTOKEN
		(
			[token_name],
			[token_description],
			[system_token]
		)
		VALUES
		(
			NULLIF(@name,''),
			NULLIF(@description,''),
			ISNULL(@system_token,0)
		)
		
		SELECT
			[itemno] = CONVERT(INT, SCOPE_IDENTITY());
	END
			
	SET NOCOUNT OFF;
END
GO
