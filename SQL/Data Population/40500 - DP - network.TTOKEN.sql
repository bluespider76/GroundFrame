SET IDENTITY_INSERT [network].[TTOKEN] ON;

MERGE [network].[TTOKEN] AS T
USING
(
	SELECT
		[itemno],
		[token_name],
		[token_description],
		[system_token]
	FROM
	(
		VALUES 
			(1, N'WILTSTH > TISBRYL', N'Wilton South - Tisbury Loop', 0),
			(2, N'TISBRYL > GLHM', N'Tisbury Loop - Gillingham (Dorset)', 0),
			(3, N'SALISBURY WEST', N'Handles conflicts on the western approach to Salisbury', 1)
	) AS A ([itemno],[token_name], [token_description], [system_token])
) AS S ([itemno], [token_name], [token_description], [system_token])
ON T.[itemno] = S.[itemno]
WHEN MATCHED THEN UPDATE
SET T.[token_name] = S.[token_name], T.[token_description] = S.[token_description], T.[system_token] = S.[system_token]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([itemno], [token_name], [token_description], [system_token])
VALUES (S.[itemno], S.[token_name], S.[token_description], S.[system_token])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
GO

SET IDENTITY_INSERT [network].[TTOKEN] OFF;
GO
