MERGE [logical].[TSYSTEMSECTOR] AS T
USING
(
	SELECT
		[code]
	FROM
	(
		VALUES 
			('SBY')
	) AS A ([code])
) AS S ([code])
ON T.[code] = S.[code]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([code])
VALUES (S.[code])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
GO
