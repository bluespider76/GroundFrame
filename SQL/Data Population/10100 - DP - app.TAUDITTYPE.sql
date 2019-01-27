MERGE [app].[TAUDITTYPE] AS T
USING
(
	SELECT
		[itemno],
		[name]
	FROM
	(
		VALUES 
			(1, N'Information'),
			(2, N'Warning'),
			(3, N'Error'),
			(4, N'Fatal')
	) AS A ([itemno],[name])
) AS S ([itemno], [name])
ON T.[itemno] = S.[itemno]
WHEN MATCHED THEN UPDATE
SET T.[name] = S.[name]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([itemno], [name])
VALUES (S. [itemno], S.[name])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
GO
