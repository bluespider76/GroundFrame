TRUNCATE TABLE [rollingstock].[TTRACTIONCLASS];
GO

EXEC [rollingstock].[Usp_SAVE_TTRACTIONCLASS]
	@itemno = 0,
	@name = N'Class 159',
	@description = N'Class 159',
	@parent_itemno = NULL,
	@start_ymdv = 19930106,
	@end_ymdv = NULL,
	@traction_type_itemno = 2,
	@length = 69.63,
	@route_availability = 3;

EXEC [rollingstock].[Usp_SAVE_TTRACTIONCLASS]
	@itemno = 0,
	@name = N'Class 159/0',
	@description = N'Class 159/0',
	@parent_itemno = 1,
	@start_ymdv = 19930106,
	@end_ymdv = NULL,
	@traction_type_itemno = 2,
	@length = 69.63,
	@route_availability = 3;

EXEC [rollingstock].[Usp_SAVE_TTRACTIONCLASS]
	@itemno = 0,
	@name = N'Class 159/1',
	@description = N'Class 159/1',
	@parent_itemno = 1,
	@start_ymdv = 20070501,
	@end_ymdv = NULL,
	@traction_type_itemno = 2,
	@length = 69.63,
	@route_availability = 3;
GO
