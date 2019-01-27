DECLARE @string NVARCHAR(128) = 'Test 123';
DECLARE @token_itemno INT = ISNULL((SELECT MAX(itemno) FROM [app].[TENCRYPTIONTOKEN]),0)

DECLARE @RESULTS TABLE
(
	token_itemno INT NOT NULL,
	hashed_value BINARY(64),
	encrypted_string CHAR(48)
)

IF @token_itemno > 0
BEGIN
	DECLARE @token UNIQUEIDENTIFIER = (SELECT [token] FROM [app].[TENCRYPTIONTOKEN] WHERE [itemno] = @token_itemno);

	INSERT INTO @RESULTS
	(
		token_itemno,
		hashed_value
	)
	SELECT
		@token_itemno,
		HASHBYTES('SHA2_512', @string+CAST(@token AS NVARCHAR(36)))

	UPDATE @RESULTS
	SET encrypted_string = CONVERT(CHAR(48), hashed_value, 2)
END

SELECT * FROM @RESULTS

DECLARE @encrypted_string CHAR(48) = (SELECT encrypted_string FROM @RESULTS);

SELECT CONVERT(BINARY(64),@encrypted_string)
	
