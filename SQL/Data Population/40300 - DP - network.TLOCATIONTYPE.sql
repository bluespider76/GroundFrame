MERGE [network].[TLOCATIONTYPE] AS T
USING
(
	SELECT
		[itemno],
		[name]
	FROM
	(
		VALUES 
			(1, N'Station'),
			(2, N'Siding'),
			(3, N'Junction'),
			(4, N'Passing Loop'),
			(5, N'Depot'),
			(6, N'Reversing Point'),
			(7, N'Internal Timing Point'),
			(8, N'Ground frame')
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
