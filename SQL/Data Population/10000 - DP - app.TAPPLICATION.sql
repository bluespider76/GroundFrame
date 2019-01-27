MERGE [app].[TAPPLICATION] AS T
USING
(
	SELECT
		[itemno],
		[name],
		[app_type_itemno],
		[token]
	FROM
	(
		VALUES 
			(1, N'Sandpit', 1, CONVERT(UNIQUEIDENTIFIER, CAST(0 AS BINARY))),
			(2, N'Data Editor', 1, CONVERT(UNIQUEIDENTIFIER, CAST(0 AS BINARY)))
	) AS A ([itemno],[name], [app_type_itemno], [token])
) AS S ([itemno], [name], [app_type_itemno], [token])
ON T.[itemno] = S.[itemno]
WHEN MATCHED THEN UPDATE
SET T.[name] = S.[name], T.[app_type_itemno] = S.[app_type_itemno], T.[token] = S.[token]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([itemno], [name], [app_type_itemno], [token])
VALUES (S. [itemno], S.[name], S.[app_type_itemno], [token])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
GO
