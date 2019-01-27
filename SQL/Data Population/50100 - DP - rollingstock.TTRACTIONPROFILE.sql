TRUNCATE TABLE [rollingstock].[TTRACTIONPROFILE];
GO

EXEC [rollingstock].[Usp_SAVE_TTRACTIONPROFILE]
	@traction_class_itemno = 2,
	@max_speed = 90,
	@max_speed_light_loco = 90,
	@power_itemno = 2,
	@tractive_effort = 0,
	@horse_power = 1200

EXEC [rollingstock].[Usp_SAVE_TTRACTIONPROFILE]
	@traction_class_itemno = 3,
	@max_speed = 90,
	@max_speed_light_loco = 90,
	@power_itemno = 2,
	@tractive_effort = 0,
	@horse_power = 1050;
GO
