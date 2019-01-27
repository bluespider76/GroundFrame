/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\app.TAPPLICATION.sql
** Name:	app.TAPPLICATION
** Desc:	Stores the applications accessing the system
** Auth:	Tim Caceres
** Date:	2018-04-13
**************************
** Change History
**************************
** Ver	Date		Author		Description 
** ---  --------	-------		------------------------------------
** 1    2018-07-19  TC			Initial Script creation
**
*******************************/

CREATE TABLE [app].[TAPPLICATION]
(
	[itemno]						TINYINT NOT NULL,
	[name]							NVARCHAR(64) NOT NULL,
	[description]					NVARCHAR(1024) NULL,
	[token]							NVARCHAR(64) NOT NULL,
	[statecode]						TINYINT CONSTRAINT DF_APP_TPPLCATION_STATECODE DEFAULT 0,
	[app_type_itemno]				TINYINT NOT NULL
);

ALTER TABLE [app].[TAPPLICATION]
ADD CONSTRAINT PK_APP_TAPPLICATION PRIMARY KEY ([itemno] ASC);
GO
