SET IDENTITY_INSERT [network].[TSYSTEMPATH] ON;

MERGE [network].[TSYSTEMPATH] AS T
USING
(
	SELECT
		[system_itemno],
		[system_name],
		[system_description],
		[system_start_location_itemno],
		[system_end_location_itemno]
	FROM
	(
		VALUES 
			(1, N'SLSBRY > SLSB240', N'Salisbury to Salisbury Signal SY240',1, 2),
			(2, N'SLSB240 > WILTON', N'Salisbury SY240 to Wilton Junction', 2, 3),
			(3, N'WILTON > SLSBRY West Approach', N'Wilton Junction to Salisbury West Approach',3 ,12),
			(4, N'WILTON > WILTSTH', N'Wilton Junction to Wilton South',3, 5)	
	) AS A ([system_itemno], [system_name], [system_description], [system_start_location_itemno], [system_end_location_itemno])
) AS S ([system_itemno], [system_name], [system_description], [system_start_location_itemno], [system_end_location_itemno])
ON T.[system_itemno] = S.[system_itemno]
WHEN MATCHED THEN UPDATE
SET T.[system_name] = S.[system_name], T.[system_description] = S.[system_description], T.[system_start_location_itemno] = S.[system_start_location_itemno]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([system_itemno], [system_name], [system_description], [system_start_location_itemno], [system_end_location_itemno])
VALUES (S.[system_itemno], S.[system_name], S.[system_description], [system_start_location_itemno], [system_end_location_itemno])
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
GO

SET IDENTITY_INSERT [network].[TSYSTEMPATH] OFF;
GO
