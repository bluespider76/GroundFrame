SET IDENTITY_INSERT [network].[TSYSTEMLOCATION] ON;

MERGE [network].[TSYSTEMLOCATION] AS T
USING
(
	SELECT
		[system_itemno],
		[system_name]
	FROM
	(
		VALUES 
			(1, N'Salisbury'),
			(2, N'Salisbury Signal SY240'),
			(3, N'Wilton Junction'),
			(4, N'Wilton Junction Signal SY7'),
			(5, N'Wilton South'),
			(6, N'Dinton'),
			(7, N'Dinton MOD'),
			(8, N'Tisbury'),
			(9, N'Tisbury Loop'),
			(10, N'Gillingham'),
			(11, N'Salisbury West Approach'),
			(12, N'Salisbury Traction & Rolling Stock Maintenance Depot') 	
	) AS A ([system_itemno], [system_name])
) AS S ([system_itemno], [system_name])
ON T.[system_itemno] = S.[system_itemno]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([system_itemno], [system_name])
VALUES (S.[system_itemno], S.[system_name])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
GO

SET IDENTITY_INSERT [network].[TSYSTEMLOCATION] OFF;
GO
