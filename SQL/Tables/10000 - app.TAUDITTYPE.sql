/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Tables\app.TAUDITTYPE.sql
** Name:	app.TAUDITTYPE
** Desc:	Stores the audit type
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

CREATE TABLE [app].[TAUDITTYPE]
(
	[itemno]						TINYINT NOT NULL,
	[name]							NVARCHAR(16)
);

ALTER TABLE [app].[TAUDITTYPE]
ADD CONSTRAINT PK_APP_TAUDITTYPE PRIMARY KEY ([itemno] ASC);
GO
