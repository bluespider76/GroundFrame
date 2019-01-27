TRUNCATE TABLE [network].[TPATH]

--Salisbury 4 > SY240

EXEC [network].[Usp_SAVE_TPATH]
	@ymdv = 18500101,
	@path_itemno = 1, 
	@start_location_itemno = 2,
	@end_location_itemno = 3,
	@distance = 300,
	@direction = 2,
	@token_itemno = NULL,
	@type_itemno = 1,
	@route_availability = 7,
	@berths = 0,
	@permissible_power = 3,
	@cross_count = 0,
	@score = 10,
	@freight_only = 0,
	@max_speed = 75,
	@rating = 0,
	@signal_type_itemno = 1,
	@options = 0

--SY240 > Salisbury 4
	
EXEC [network].[Usp_SAVE_TPATH]
	@ymdv = 18500101,
	@path_itemno = 1, 
	@start_location_itemno = 3,
	@end_location_itemno = 2,
	@distance = 300,
	@direction = 1,
	@token_itemno = 3,
	@type_itemno = 1,
	@route_availability = 7,
	@berths = 0,
	@permissible_power = 3,
	@cross_count = 0,
	@score = 10,
	@freight_only = 0,
	@max_speed = 30,
	@rating = 0,
	@signal_type_itemno = 2,
	@options = 0;
	
--SY240 > Wilton Junction
	
EXEC [network].[Usp_SAVE_TPATH]
	@ymdv = 18500101,
	@path_itemno = 2, 
	@start_location_itemno = 3,
	@end_location_itemno = 4,
	@distance = 2500,
	@direction = 2,
	@token_itemno = 4,
	@type_itemno = 1,
	@route_availability = 7,
	@berths = 0,
	@permissible_power = 3,
	@cross_count = 1,
	@score = 10,
	@freight_only = 0,
	@max_speed = 75,
	@rating = 0,
	@signal_type_itemno = 1,
	@options = 0;
	
--Wilton Junction > Wilton South
	
EXEC [network].[Usp_SAVE_TPATH]
	@ymdv = 18500101,
	@path_itemno = 4, 
	@start_location_itemno = 4,
	@end_location_itemno = 6,
	@distance = 1000,
	@direction = 2,
	@token_itemno = NULL,
	@type_itemno = 1,
	@route_availability = 7,
	@berths = 0,
	@permissible_power = 3,
	@cross_count = 1,
	@score = 10,
	@freight_only = 0,
	@max_speed = 75,
	@rating = 0,
	@signal_type_itemno = 1,
	@options = 0;
	
--Wilton Junction > Salisbury West Approach
	
EXEC [network].[Usp_SAVE_TPATH]
	@ymdv = 18500101,
	@path_itemno = 2, 
	@start_location_itemno = 4,
	@end_location_itemno = 7,
	@distance = 3036,
	@direction = 1,
	@token_itemno = NULL,
	@type_itemno = 1,
	@route_availability = 7,
	@berths = 2,
	@permissible_power = 3,
	@cross_count = 1,
	@score = 10,
	@freight_only = 0,
	@max_speed = 75,
	@rating = 0,
	@signal_type_itemno = 1,
	@options = 0;
	
--Salisbury West Approach > Salisbury Platform 4
	
EXEC [network].[Usp_SAVE_TPATH]
	@ymdv = 18500101,
	@path_itemno = 2, 
	@start_location_itemno = 7,
	@end_location_itemno = 2,
	@distance = 300,
	@direction = 1,
	@token_itemno = 3,
	@type_itemno = 1,
	@route_availability = 7,
	@berths = 0,
	@permissible_power = 3,
	@cross_count = 1,
	@score = 0,
	@freight_only = 0,
	@max_speed = 30,
	@rating = 0,
	@signal_type_itemno = 1,
	@options = 0;
GO
