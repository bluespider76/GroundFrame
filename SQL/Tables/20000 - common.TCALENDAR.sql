/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\common.TCALENDAR.sql
** Name:	common.TCALENDAR
** Desc:	Table for ymdv lookup
** Auth:	Tim Caceres
** Date:	2018-04-13
**************************
** Change History
**************************
** Ver	Date		Author		Description 
** ---  --------	-------		------------------------------------
** 1    2018-04-13  TC			Initial Script creation
**
*******************************/

IF OBJECT_ID('common.TCALENDAR') IS NULL
BEGIN
	CREATE TABLE common.TCALENDAR
	(
		ymdv				INT NOT NULL,
		[ymdv_date]			DATE,
		ymv					INT,
		[year_month]		NVARCHAR(16),
		[year]				INT,
		CONSTRAINT PK_COMMON_TCALENDAR PRIMARY KEY (ymdv ASC)
	)
END
GO

SET NOCOUNT ON;
GO

DECLARE @start_date DATE = '1850-01-01';
DECLARE @end_date DATE = '2022-12-31';

WITH
	L0 AS(SELECT 1 AS C UNION ALL SELECT 1 AS C), -- 2 rows
	L1 AS(SELECT 1 AS C FROM L0 AS A CROSS JOIN L0 AS B), -- 4 rows
	L2 AS(SELECT 1 AS C FROM L1 AS A CROSS JOIN L1 AS B), -- 16 rows
	L3 AS(SELECT 1 AS C FROM L2 AS A CROSS JOIN L2 AS B), -- 256 rows
	L4 AS(SELECT 1 AS C FROM L3 AS A CROSS JOIN L3 AS B), -- 65,536 rows
	L5 AS(SELECT 1 AS C FROM L0 AS A CROSS JOIN L4 AS B), -- 65,536 rows
	Nums AS(SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS N FROM L5),
    CTE_DATES AS
    (
		SELECT
			[ymdv_date] = DATEADD(DAY, N - 1, @start_date)
		FROM Nums
	)

	INSERT INTO common.TCALENDAR
	(
		ymdv,
		[ymdv_date],
		ymv,
		[year_month],
		[year]	
	)
	SELECT
		((YEAR([ymdv_date]) * 100 + MONTH([ymdv_date])) * 100) + DAY([ymdv_date]),
		[ymdv_date],
		YEAR([ymdv_date]) * 100 + MONTH([ymdv_date]),
		CONVERT(CHAR(4), [ymdv_date], 100) + CONVERT(CHAR(4), [ymdv_date], 120),
		YEAR([ymdv_date])
	FROM CTE_DATES
	WHERE
		[ymdv_date] <= @end_date
		AND NOT EXISTS (SELECT 1 FROM common.TCALENDAR AS C WHERE C.ymdv_date = CTE_DATES.ymdv_date)
GO

SET NOCOUNT OFF;
GO
