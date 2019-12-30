MERGE [common].[TPOWERTYPE] AS T
USING
(
	SELECT
		[itemno],
		[name],
		[description]
	FROM
	(
		VALUES 
			(1, N'Steam', NULL),
			(2, N'Diesel', NULL),
			(4, N'3rd Rail 759v DC', NULL),
			(8, N'3rd Rail 1500v DC', NULL),
			(16, N'4th Rail 600v DC', NULL),
			(32, N'Overhead 1500v DC', NULL),
			(64, N'Overhead 6.25Kv AC', NULL),
			(128, N'Overhead 25kv AC', NULL),
			(256, N'Battery', NULL)
	) AS A ([itemno],[name], [description])
) AS S ([itemno], [name], [description])
ON T.[itemno] = S.[itemno]
WHEN MATCHED THEN UPDATE
SET T.[name] = S.[name], T.[description] = S.[description]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([itemno], [name], [description])
VALUES (S. [itemno], S.[name], S.[description])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
GO
