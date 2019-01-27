MERGE [rollingstock].[TTRACTIONTYPE] AS T
USING
(
	SELECT
		[itemno],
		[name]
	FROM
	(
		VALUES 
			(1, N'Loco'),
			(2, N'DMU'),
			(3, N'EMU'),
			(4, N'DEMU')
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
