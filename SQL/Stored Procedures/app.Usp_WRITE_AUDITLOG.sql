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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('app.Usp_WRITE_AUDITLOG'))
BEGIN
	DROP PROC [app].[Usp_WRITE_AUDITLOG]
END
GO

CREATE PROC [app].[Usp_WRITE_AUDITLOG]
(
	@application_itemno TINYINT,
	@token NVARCHAR(256) = NULL,
	@audit_type_itemno TINYINT,
	@message NVARCHAR(2048),
	@error_number INT,
	@error_object_xml XML = NULL
)
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO app.TAUDIT
	(
		[application_itemno],
		[audit_type_itemno],
		[message],
		[error_number],
		[error_object_xml]
	)
	VALUES
	(
		@application_itemno,
		@audit_type_itemno,
		@message,
		@error_number,
		@error_object_xml
	);
	
	--Return the LogID. Return 0 if no error
	IF @audit_type_itemno IN (1,2)
	BEGIN
		SELECT
			itemno = 0;
	END
	ELSE
	BEGIN
		SELECT
			itemno = CONVERT(INT,SCOPE_IDENTITY());
	END
	
	SET NOCOUNT OFF;
END
GO
