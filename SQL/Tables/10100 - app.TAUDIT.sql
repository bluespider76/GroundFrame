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
** ---  --------	-------		-------------------	-----------------
** 1    2018-07-19  TC			Initial Script creation
**
*******************************/

CREATE TABLE [app].[TAUDIT]
(
	[itemno]						BIGINT NOT NULL IDENTITY(1,1),
	[application_itemno]			TINYINT NOT NULL,
	[login_instance_itemno]			BIGINT NOT NULL CONSTRAINT DF_APP_TAPPLICATION_LOGIN_INSTANCE_ITEMNO DEFAULT 0,
	[date]							DATETIME2 CONSTRAINT DF_APP_TAPPLICATION_DATE DEFAULT GETUTCDATE(),
	[audit_type_itemno]				TINYINT NOT NULL,
	[message]						NVARCHAR(2048) NOT NULL,
	[error_number]					INT NOT NULL CONSTRAINT DF_APP_TAPPLICATION_ERROR_NO DEFAULT 0,
	[error_object_xml]				XML,
	[rv]							ROWVERSION
);

ALTER TABLE [app].[TAUDIT]
ADD CONSTRAINT PK_APP_TAUDIT PRIMARY KEY ([itemno] ASC);
GO
