/****** Object:  Database [MWB_TEST_TC]    Script Date: 09/17/2018 16:53:38 ******/
CREATE DATABASE [MWB_TEST_TC] ON  PRIMARY 
( NAME = N'MWB_TEST_TC', FILENAME = N'S:\MWB_TEST_TC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MWB_TEST_TC_log', FILENAME = N'L:\MWB_TEST_TC_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MWB_TEST_TC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MWB_TEST_TC] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET ARITHABORT OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MWB_TEST_TC] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MWB_TEST_TC] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MWB_TEST_TC] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET  DISABLE_BROKER
GO
ALTER DATABASE [MWB_TEST_TC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MWB_TEST_TC] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MWB_TEST_TC] SET  READ_WRITE
GO
ALTER DATABASE [MWB_TEST_TC] SET RECOVERY SIMPLE
GO
ALTER DATABASE [MWB_TEST_TC] SET  MULTI_USER
GO
ALTER DATABASE [MWB_TEST_TC] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MWB_TEST_TC] SET DB_CHAINING OFF
GO
/****** Object:  Schema [wtt]    Script Date: 09/17/2018 16:53:38 ******/
CREATE SCHEMA [wtt] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [users]    Script Date: 09/17/2018 16:53:38 ******/
CREATE SCHEMA [users] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [rollingstock]    Script Date: 09/17/2018 16:53:38 ******/
CREATE SCHEMA [rollingstock] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [network]    Script Date: 09/17/2018 16:53:38 ******/
CREATE SCHEMA [network] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [logical]    Script Date: 09/17/2018 16:53:38 ******/
CREATE SCHEMA [logical] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [common]    Script Date: 09/17/2018 16:53:38 ******/
CREATE SCHEMA [common] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [app]    Script Date: 09/17/2018 16:53:38 ******/
CREATE SCHEMA [app] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [admin]    Script Date: 09/17/2018 16:53:38 ******/
CREATE SCHEMA [admin] AUTHORIZATION [dbo]
GO
/****** Object:  Table [app].[TENCRYPTIONTOKEN]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [app].[TENCRYPTIONTOKEN](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[token] [uniqueidentifier] NOT NULL,
	[db_createdon] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_APP_TENCRYPTIONTOKEN] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [network].[TDEPOT]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [network].[TDEPOT](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[location_itemno] [int] NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[code] [nvarchar](16) NOT NULL,
	[ease_of_access] [decimal](16, 6) NOT NULL,
	[percentage_visible_from_train] [decimal](16, 6) NOT NULL,
	[capabilities] [int] NOT NULL,
 CONSTRAINT [PK_NETWORK_DEPOT] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [network].[TDEPOT] 
(
	[location_itemno] ASC,
	[start_ymdv] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [users].[TCREDENTIALPROVIDER]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [users].[TCREDENTIALPROVIDER](
	[itemno] [tinyint] NOT NULL,
	[provider_name] [nvarchar](128) NOT NULL,
	[provider_description] [nvarchar](1024) NOT NULL,
 CONSTRAINT [PK_USERS_TCREDENTIALPROVIDER] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_USERS_TCREDENTIALPROVIDER_NAME] UNIQUE NONCLUSTERED 
(
	[provider_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wtt].[TCALLINGPOINT]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wtt].[TCALLINGPOINT](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[train_itemno] [int] NOT NULL,
	[location_itemno] [int] NOT NULL,
	[arr] [bigint] NOT NULL,
	[dep] [bigint] NOT NULL,
	[setdownonly] [bit] NOT NULL,
	[pickuponly] [bit] NOT NULL,
	[mindwelltime] [bigint] NOT NULL,
	[order] [smallint] NOT NULL,
 CONSTRAINT [PK_WTT_TCALLINGPOINT] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [common].[TCALENDAR]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [common].[TCALENDAR](
	[ymdv] [int] NOT NULL,
	[ymdv_date] [date] NULL,
	[ymv] [int] NULL,
	[year_month] [nvarchar](16) NULL,
	[year] [int] NULL,
 CONSTRAINT [PK_COMMON_TCALENDAR] PRIMARY KEY CLUSTERED 
(
	[ymdv] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [app].[TAUDITTYPE]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [app].[TAUDITTYPE](
	[itemno] [tinyint] NOT NULL,
	[name] [nvarchar](16) NULL,
 CONSTRAINT [PK_APP_TAUDITTYPE] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [app].[TAUDIT]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [app].[TAUDIT](
	[itemno] [bigint] IDENTITY(1,1) NOT NULL,
	[application_itemno] [tinyint] NOT NULL,
	[login_instance_itemno] [bigint] NOT NULL,
	[date] [datetime2](7) NULL,
	[audit_type_itemno] [tinyint] NOT NULL,
	[message] [nvarchar](2048) NOT NULL,
	[error_number] [int] NOT NULL,
	[error_object_xml] [xml] NULL,
	[rv] [timestamp] NOT NULL,
 CONSTRAINT [PK_APP_TAUDIT] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [app].[TAPPLICATION]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [app].[TAPPLICATION](
	[itemno] [tinyint] NOT NULL,
	[name] [nvarchar](64) NOT NULL,
	[description] [nvarchar](1024) NULL,
	[token] [nvarchar](64) NOT NULL,
	[statecode] [tinyint] NULL,
	[app_type_itemno] [tinyint] NOT NULL,
 CONSTRAINT [PK_APP_TAPPLICATION] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [users].[TUSERUNIQUEID]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [users].[TUSERUNIQUEID](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[user_itemno] [int] NOT NULL,
	[unique_id] [uniqueidentifier] NOT NULL,
	[db_rowversion] [timestamp] NOT NULL,
	[db_createdon] [datetime2](7) NOT NULL,
	[db_modifiedon] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_USERS_TUSERUNIQUEID] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [users].[TUSER]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [users].[TUSER](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[unique_id] [uniqueidentifier] NOT NULL,
	[last_name] [nvarchar](256) NOT NULL,
	[first_name] [nvarchar](128) NOT NULL,
	[display_name] [nvarchar](256) NOT NULL,
	[contact_email] [nvarchar](512) NOT NULL,
	[contact_preferences] [int] NOT NULL,
 CONSTRAINT [PK_USERS_TUSER] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_USERS_DISPLAYNAME] UNIQUE NONCLUSTERED 
(
	[display_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_USERS_EMAIL] UNIQUE NONCLUSTERED 
(
	[contact_email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [wtt].[TTRAINTRACTIONALLOCATION]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wtt].[TTRAINTRACTIONALLOCATION](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[train_itemno] [int] NOT NULL,
	[traction_class_itemno] [int] NOT NULL,
	[sector_itemno] [int] NULL,
	[depot_location_itemno] [int] NULL,
	[region_itemno] [int] NULL,
	[perc] [numeric](16, 6) NULL,
	[booked_traction] [bit] NOT NULL,
 CONSTRAINT [PK_WTT_TTRAINTRACTIONALLOCATION] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [wtt].[TTRAINTRACTIONALLOCATION] 
(
	[train_itemno] ASC,
	[traction_class_itemno] ASC,
	[depot_location_itemno] ASC,
	[sector_itemno] ASC
)
INCLUDE ( [perc]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [wtt].[TTRAINRAKEALLOCATION]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wtt].[TTRAINRAKEALLOCATION](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[train_itemno] [int] NOT NULL,
	[rake_itemno] [int] NOT NULL,
	[perc] [decimal](16, 6) NOT NULL,
	[booked_rake] [bit] NOT NULL,
 CONSTRAINT [PK_WTT_TTRAINRAKEALLOCATION] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [wtt].[TTRAINRAKEALLOCATION] 
(
	[train_itemno] ASC,
	[rake_itemno] ASC
)
INCLUDE ( [perc]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [wtt].[TTRAIN]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [wtt].[TTRAIN](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[headcode] [nvarchar](8) NOT NULL,
	[description] [nvarchar](2048) NULL,
	[start_location_itemno] [int] NOT NULL,
	[end_location_itemno] [int] NOT NULL,
	[mp_next_train_itemno] [int] NULL,
	[mp_next_train_perc] [decimal](16, 6) NULL,
	[mp_next_train_min_turnaround] [tinyint] NULL,
	[stock_next_train_itemno] [int] NULL,
	[stock_next_train_perc] [decimal](16, 6) NULL,
	[stock_next_train_min_turnaround] [tinyint] NULL,
	[parent_train_itemno] [int] NULL,
	[mins_allocation_on_tops] [tinyint] NULL,
	[start_time] [bigint] NOT NULL,
	[days] [tinyint] NOT NULL,
	[brake_types] [tinyint] NOT NULL,
	[heat_types] [tinyint] NOT NULL,
	[configuration] [bigint] NOT NULL,
	[max_speed] [smallint] NOT NULL,
	[max_speed_if_late] [smallint] NULL,
	[run_as_required] [bit] NOT NULL,
	[run_as_required_perc] [tinyint] NOT NULL,
	[runs_once] [bit] NOT NULL,
 CONSTRAINT [PK_WTT_TTRAIN] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [wtt].[TTRAIN] 
(
	[headcode] ASC,
	[start_location_itemno] ASC,
	[start_time] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TTRACTIONPROFILE]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TTRACTIONPROFILE](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[traction_class_itemno] [int] NOT NULL,
	[max_speed] [smallint] NOT NULL,
	[max_speed_light_loco] [smallint] NOT NULL,
	[power_itemno] [int] NOT NULL,
	[tractive_effort] [int] NOT NULL,
	[horse_power] [int] NOT NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TRACTIONPROFILE] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TTRACTIONCLASS]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TTRACTIONCLASS](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[name] [nvarchar](128) NOT NULL,
	[description] [nvarchar](2048) NOT NULL,
	[parent_itemno] [int] NULL,
	[traction_type_itemno] [tinyint] NOT NULL,
	[length] [decimal](16, 6) NULL,
	[route_availability] [tinyint] NOT NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TTRACTIONCLASS] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [network].[TTOKEN]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [network].[TTOKEN](
	[itemno] [int] NOT NULL,
	[token_name] [nvarchar](128) NOT NULL,
	[token_description] [nvarchar](1024) NOT NULL,
	[system_token] [bit] NOT NULL,
 CONSTRAINT [PK_NETWORK_TOKEN] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [network].[TTOKEN] 
(
	[token_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TSYSTEMTRACTION]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TSYSTEMTRACTION](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[traction_class_itemno] [int] NOT NULL,
	[parent_system_traction_itemno] [int] NULL,
	[unique_number] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TSYSTEMTRACTION] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [logical].[TSYSTEMSECTOR]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [logical].[TSYSTEMSECTOR](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](4) NOT NULL,
 CONSTRAINT [PK_LOGICAL_TSYSTEMSECTOR] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [logical].[TSYSTEMSECTOR] 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [network].[TSYSTEMPATH]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [network].[TSYSTEMPATH](
	[system_itemno] [int] NOT NULL,
	[system_name] [nvarchar](128) NOT NULL,
	[system_description] [nvarchar](2048) NULL,
 CONSTRAINT [PK_NETWORK_SYSTEMPATH] PRIMARY KEY CLUSTERED 
(
	[system_itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [network].[TSYSTEMLOCATION]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [network].[TSYSTEMLOCATION](
	[system_itemno] [int] NOT NULL,
	[system_name] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_NETWORK_SYSTEMLOCATION] PRIMARY KEY CLUSTERED 
(
	[system_itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TSTOCK]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TSTOCK](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[type_itemno] [tinyint] NOT NULL,
	[name] [nvarchar](128) NOT NULL,
	[description] [nvarchar](2048) NULL,
	[coupling_types] [smallint] NOT NULL,
	[brake_types] [smallint] NOT NULL,
	[heating_types] [smallint] NOT NULL,
	[max_speed] [smallint] NOT NULL,
	[length] [smallint] NOT NULL,
	[options] [int] NOT NULL,
	[eth_index] [smallint] NOT NULL,
	[weight] [smallint] NOT NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TSTOCK] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [rollingstock].[TSTOCK] 
(
	[type_itemno] ASC,
	[name] ASC,
	[start_ymdv] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [logical].[TSECTOR]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [logical].[TSECTOR](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[code_itemno] [int] NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[description] [nvarchar](2048) NOT NULL,
 CONSTRAINT [PK_LOGICAL_TSECTOR] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [logical].[TSECTOR] 
(
	[code_itemno] ASC,
	[start_ymdv] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [logical].[TREGION]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [logical].[TREGION](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[name] [nvarchar](128) NOT NULL,
	[description] [nvarchar](2056) NULL,
 CONSTRAINT [PK_LOGICAL_TREGION] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TRAKESECTOR]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TRAKESECTOR](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[rake_itemno] [int] NOT NULL,
	[sector_itemno] [int] NOT NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TRAKESECTOR] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [rollingstock].[TRAKESECTOR] 
(
	[rake_itemno] ASC
)
INCLUDE ( [sector_itemno]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TRAKEREGION]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TRAKEREGION](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[rake_itemno] [int] NOT NULL,
	[region_itemno] [int] NOT NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TRAKEREGION] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [rollingstock].[TRAKEREGION] 
(
	[rake_itemno] ASC
)
INCLUDE ( [region_itemno]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TRAKEELEMENT]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TRAKEELEMENT](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[rake_itemno] [int] NOT NULL,
	[stock_itemno] [int] NOT NULL,
	[number] [tinyint] NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TRAKEELEMENT] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [rollingstock].[TRAKEELEMENT] 
(
	[rake_itemno] ASC
)
INCLUDE ( [stock_itemno]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TRAKEDEPOT]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TRAKEDEPOT](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[rake_itemno] [int] NOT NULL,
	[depot_location_itemno] [int] NOT NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TDEPOT] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [rollingstock].[TRAKEDEPOT] 
(
	[depot_location_itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [rollingstock].[TRAKE]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rollingstock].[TRAKE](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[name] [nvarchar](128) NOT NULL,
	[description] [nvarchar](2048) NULL,
 CONSTRAINT [PK_ROLLINGSTOCK_TRAKE] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [rollingstock].[TRAKE] 
(
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [network].[TPATH]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [network].[TPATH](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[path_itemno] [int] NOT NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[start_location_itemno] [int] NOT NULL,
	[end_location_itemno] [int] NOT NULL,
	[distance] [int] NOT NULL,
	[direction] [tinyint] NOT NULL,
	[token_itemno] [int] NULL,
	[type_itemno] [smallint] NOT NULL,
	[route_availability] [smallint] NOT NULL,
	[berths] [smallint] NOT NULL,
	[permissible_power] [smallint] NOT NULL,
	[crossing_count] [smallint] NOT NULL,
	[score] [smallint] NOT NULL,
	[freight_only] [bit] NOT NULL,
	[max_speed] [smallint] NOT NULL,
	[rating] [decimal](16, 6) NOT NULL,
	[signal_type_itemno] [smallint] NOT NULL,
	[options] [bigint] NOT NULL,
 CONSTRAINT [PK_NETWORK_PATH] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [network].[TLOCATIONTYPE]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [network].[TLOCATIONTYPE](
	[itemno] [smallint] NOT NULL,
	[name] [nvarchar](128) NULL,
 CONSTRAINT [PK_NETWORK_LOCATIONTYPE] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [network].[TLOCATION]    Script Date: 09/17/2018 16:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [network].[TLOCATION](
	[itemno] [int] IDENTITY(1,1) NOT NULL,
	[location_itemno] [int] NULL,
	[start_ymdv] [int] NOT NULL,
	[end_ymdv] [int] NULL,
	[name] [nvarchar](128) NOT NULL,
	[tiploc] [nvarchar](16) NULL,
	[stanox] [int] NOT NULL,
	[stanme] [nvarchar](32) NULL,
	[nlc] [int] NOT NULL,
	[location_type_itemno] [smallint] NOT NULL,
	[latitude] [decimal](16, 6) NULL,
	[longitude] [decimal](16, 6) NULL,
	[parent_itemno] [int] NULL,
	[length] [decimal](16, 6) NOT NULL,
	[disembark_passengers] [bit] NOT NULL,
	[embark_passengers] [bit] NOT NULL,
	[freight_only] [bit] NOT NULL,
	[single_train_working] [bit] NOT NULL,
	[token_itemno] [int] NULL,
	[berths] [smallint] NOT NULL,
	[direction] [tinyint] NOT NULL,
	[score] [smallint] NULL,
	[use_as_timing_point] [bit] NOT NULL,
	[options] [bigint] NULL,
	[permissible_power] [bigint] NOT NULL,
	[tops_office] [bit] NOT NULL,
 CONSTRAINT [PK_NETWORK_LOCATION] PRIMARY KEY CLUSTERED 
(
	[itemno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_NONCLUSTERED_1] ON [network].[TLOCATION] 
(
	[name] ASC
)
WHERE ([end_ymdv] IS NULL)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [common].[Fn_YMDV_ADD]    Script Date: 09/17/2018 16:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [common].[Fn_YMDV_ADD]
(
	@ymdv	INT,
	@days	INT
)
RETURNS INT
AS
BEGIN
	DECLARE @date DATE = DATEADD(DAY,@days, (SELECT [ymdv_date] FROM [common].[TCALENDAR] WHERE [ymdv] = @ymdv));
	DECLARE @return_ymdv INT

	IF @days < 1
	BEGIN
		SELECT
			@return_ymdv = MAX([ymdv])
		FROM [common].[TCALENDAR]
		WHERE
			[ymdv_date] <= @date;
	END
	ELSE
	BEGIN
		SELECT
			@return_ymdv = MIN([ymdv])
		FROM [common].[TCALENDAR]
		WHERE
			[ymdv_date] > @date;	
	END
	
	RETURN @return_ymdv;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_GET_TTRAINTRACTIONALLOCATION_BY_ID]    Script Date: 09/17/2018 16:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_GET_TTRAINTRACTIONALLOCATION_BY_ID]
(
	@itemno	INT
)
AS
BEGIN
	SELECT
		[itemno],
		[start_ymdv],
		[end_ymdv],
		[train_itemno],
		[traction_class_itemno],
		[sector_itemno],
		[depot_location_itemno],
		[region_itemno], 
		[perc],
		[booked_traction]
	FROM [wtt].[TTRAINTRACTIONALLOCATION]
	WHERE
		[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_GET_TTRAINRAKEALLOCATION_BY_ID]    Script Date: 09/17/2018 16:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_GET_TTRAINRAKEALLOCATION_BY_ID]
(
	@itemno	INT
)
AS
BEGIN
	SELECT
		[itemno],
		[start_ymdv],
		[end_ymdv],
		[train_itemno],
		[rake_itemno], 
		[perc],
		[booked_rake]
	FROM [wtt].[TTRAINRAKEALLOCATION]
	WHERE
		[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_TTRACTIONPROFILES]    Script Date: 09/17/2018 16:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_TTRACTIONPROFILES]
(
	@traction_class_itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno]
	FROM [rollingstock].TTRACTIONPROFILE
	WHERE
		[traction_class_itemno] = @traction_class_itemno
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_TTRACTIONPROFILE_BY_ID]    Script Date: 09/17/2018 16:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_TTRACTIONPROFILE_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[traction_class_itemno], 
		[max_speed], 
		[max_speed_light_loco], 
		[power_itemno], 
		[tractive_effort], 
		[horse_power]
	FROM [rollingstock].TTRACTIONPROFILE
	WHERE
		[itemno] = @itemno;
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_TTRACTIONCLASSES]    Script Date: 09/17/2018 16:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_TTRACTIONCLASSES]
(
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno]
	FROM [rollingstock].TTRACTIONCLASS
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_TTRACTIONCLASS_BY_ID]    Script Date: 09/17/2018 16:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_TTRACTIONCLASS_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno], 
		[start_ymdv], 
		[end_ymdv], 
		[name], 
		[description], 
		[parent_itemno], 
		[traction_type_itemno],
		[length],
		[route_availability]
	FROM [rollingstock].TTRACTIONCLASS
	WHERE
		[itemno] = @itemno;
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_TSYSTEMPATHS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_TSYSTEMPATHS]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[system_itemno],
		[system_name],
		[system_description]
	FROM [network].[TSYSTEMPATH];
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_TSYSTEMLOCATIONS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_TSYSTEMLOCATIONS]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[system_itemno],
		[system_name]
	FROM [network].[TSYSTEMLOCATION];
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_GET_TRAINTRACTIONALLOCATIONS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_GET_TRAINTRACTIONALLOCATIONS]
(
	@ymdv	INT,
	@train_itemno INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [wtt].[TTRAINTRACTIONALLOCATION]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv)
		and [train_itemno] = @train_itemno;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_GET_TRAINS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_GET_TRAINS]
(
	@ymdv INT,
	@wtt_day INT
)
AS
BEGIN
	SELECT
		[itemno],
		[description],
		[start_location_itemno],
		[end_location_itemno],
		[mp_next_train_itemno],
		[mp_next_train_perc],
		[mp_next_train_min_turnaround],
		[stock_next_train_itemno], 
		[stock_next_train_perc], 
		[stock_next_train_min_turnaround], 
		[parent_train_itemno],
		[mins_allocation_on_tops],
		[start_time], 
		[days], 
		[brake_types], 
		[heat_types],
		[configuration], 
		[max_speed],
		[max_speed_if_late]
	FROM [wtt].[TTRAIN]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv)
		AND [days] & @wtt_day > 0;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_GET_TRAINRAKEALLOCATIONS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_GET_TRAINRAKEALLOCATIONS]
(
	@ymdv	INT,
	@train_itemno INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [wtt].[TTRAINRAKEALLOCATION]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv)
		and [train_itemno] = @train_itemno;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_GET_TRAIN_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_GET_TRAIN_BY_ID]
(
	@itemno	INT
)
AS
BEGIN
	SELECT
		[headcode],
		[description],
		[start_location_itemno],
		[end_location_itemno],
		[mp_next_train_itemno],
		[mp_next_train_perc],
		[mp_next_train_min_turnaround],
		[stock_next_train_itemno], 
		[stock_next_train_perc], 
		[stock_next_train_min_turnaround], 
		[parent_train_itemno],
		[mins_allocation_on_tops],
		[start_time], 
		[days], 
		[brake_types], 
		[heat_types],
		[configuration], 
		[max_speed],
		[max_speed_if_late],
		[run_as_required],
		[run_as_required_perc],
		[runs_once]
	FROM [wtt].[TTRAIN]
	WHERE
		[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_TOKENS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_TOKENS]

AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[token_name],
		[token_description],
		[system_token]
	FROM [network].[TTOKEN]
		
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_TOKEN_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_TOKEN_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[token_name],
		[token_description],
		[system_token]
	FROM [network].[TTOKEN]
	WHERE
		[itemno] = @itemno;
		
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_STOCKS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_STOCKS]
(
	@ymdv INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [rollingstock].[TSTOCK]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_STOCK_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_STOCK_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SELECT
		[itemno],
		[start_ymdv],
		[end_ymdv],
		[type_itemno],
		[name],
		[description],
		[coupling_types],
		[brake_types],
		[heating_types],
		[max_speed],
		[length], 
		[options],
		[eth_index],
		[weight]
	FROM [rollingstock].[TSTOCK]
	WHERE
		[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [logical].[Usp_GET_SECTORS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [logical].[Usp_GET_SECTORS]
(
	@ymdv INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [logical].[TSECTOR]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv)
END
GO
/****** Object:  StoredProcedure [logical].[Usp_GET_SECTOR_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [logical].[Usp_GET_SECTOR_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SELECT
		[itemno],
		[code],
		[start_ymdv],
		[end_ymdv],
		[description]
	FROM [logical].[TSECTOR]
	WHERE
		[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [logical].[Usp_GET_REGIONS_BY_YMDV]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [logical].[Usp_GET_REGIONS_BY_YMDV]
(
	@ymdv	INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [logical].[TREGION]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
END
GO
/****** Object:  StoredProcedure [logical].[Usp_GET_REGIONS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [logical].[Usp_GET_REGIONS]
AS
BEGIN
	SELECT
		[itemno]
	FROM [logical].[TREGION]
END
GO
/****** Object:  StoredProcedure [logical].[Usp_GET_REGION_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [logical].[Usp_GET_REGION_BY_ID]
(
	@itemno	INT
)
AS
BEGIN
	SELECT
		[itemno],
		[start_ymdv],
		[end_ymdv],
		[name],
		[description]
	FROM [logical].[TREGION]
	WHERE
		[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_RAKES]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_RAKES]
(
	@ymdv INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [rollingstock].[TRAKE]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv)
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_RAKE_REGIONS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_RAKE_REGIONS]
(
	@rake_itemno INT
)
AS
BEGIN
	SELECT
		region_itemno
	FROM [rollingstock].[TRAKEREGION] AS RD
	WHERE
		RD.[rake_itemno] = @rake_itemno;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_RAKE_ELEMENTS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_RAKE_ELEMENTS]
(
	@rake_itemno INT
)
AS
BEGIN
	SELECT
		itemno
	FROM [rollingstock].[TRAKEELEMENT] AS RD
	WHERE
		RD.[rake_itemno] = @rake_itemno;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_RAKE_ELEMENT_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_RAKE_ELEMENT_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SELECT DISTINCT
		itemno,
		rake_itemno,
		stock_itemno,
		number
	FROM [rollingstock].[TRAKEELEMENT] AS RD
	WHERE
		RD.[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_RAKE_DEPOTS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_RAKE_DEPOTS]
(
	@rake_itemno INT,
	@ymdv INT
)
AS
BEGIN
	SELECT DISTINCT
		D.location_itemno
	FROM [rollingstock].[TRAKEDEPOT] AS RD
	INNER JOIN [network].[TDEPOT] AS D ON RD.depot_location_itemno = D.location_itemno
	WHERE
		RD.rake_itemno = @rake_itemno
		AND @ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv);
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_GET_RAKE_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_GET_RAKE_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SELECT DISTINCT
		[itemno],
		[start_ymdv],
		[end_ymdv],
		[type_itemno],
		[name],
		[description]
	FROM [rollingstock].[TRAKE]
	WHERE
		[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_PATHS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_PATHS]
(
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno]
	FROM [network].[TPATH]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_PATH_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_PATH_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[path_itemno],
		[start_ymdv],
		[end_ymdv],
		[start_location_itemno],
		[end_location_itemno],
		[distance],
		[direction],
		[token_itemno],
		[type_itemno],
		[route_availability],
		[berths],
		[permissible_power],
		[crossing_count],
		[score],
		[freight_only],
		[max_speed],
		[rating],
		[signal_type_itemno],
		[options]
	FROM [network].[TPATH]
	WHERE
		[itemno] = @itemno;
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_GET_CALLINGPOINTS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_GET_CALLINGPOINTS]
(
	@train_itemno INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [wtt].[TCALLINGPOINT]
	WHERE
		[train_itemno] = @train_itemno
	ORDER BY
		[order] ASC;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_GET_CALLINGPOINT_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_GET_CALLINGPOINT_BY_ID]
(
	@itemno	INT
)
AS
BEGIN
	SELECT
		[itemno],
		[train_itemno],
		[location_itemno],
		[arr],
		[dep],
		[setdownonly],
		[pickuponly],
		[mindwelltime],
		[order]
	FROM [wtt].[TCALLINGPOINT]
	WHERE
		[itemno] = @itemno;
END
GO
/****** Object:  StoredProcedure [logical].[Usp_GET_ALL_SYSTEMSECTORS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [logical].[Usp_GET_ALL_SYSTEMSECTORS]
AS
BEGIN
	SELECT
		[itemno],
		[code]
	FROM [logical].TSYSTEMSECTOR
END
GO
/****** Object:  StoredProcedure [app].[Usp_GENERATE_ENCRYPTION_TOKEN]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [app].[Usp_GENERATE_ENCRYPTION_TOKEN]
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(1024);
	
	BEGIN TRY		
		INSERT INTO [app].[TENCRYPTIONTOKEN]
		(
			[token]
		)
		SELECT
			NEWID();
	END TRY
	BEGIN CATCH
		SET @message = 'Error trying to issue a new encryption token:- ' + ERROR_MESSAGE();
		RAISERROR (@message, 16, 1);
		
		/*To Do*/
		
		/*Application needs to be disabled*/
		
		RETURN;
	END CATCH
			
	DECLARE @itemno INT = CONVERT(INT, ISNULL((SELECT SCOPE_IDENTITY()),0));
	
	IF (@itemno = 0)
	BEGIN
		RAISERROR ('Cannot issue a new encrytion token', 16, 1);
		RETURN;
	END
	
	--Delete old tokents but only if a new token was create in the last 60 minutes.
	
	DECLARE @hour_ago DATETIME2 = DATEADD(MINUTE,-60, GETUTCDATE());
	
	IF EXISTS (SELECT 1 FROM [app].[TENCRYPTIONTOKEN] WHERE [db_createdon] > @hour_ago AND [itemno] != @itemno)
	BEGIN		
		DELETE FROM [app].[TENCRYPTIONTOKEN]
		WHERE
			[db_createdon] <= @hour_ago;
	END
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_DEPOTS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_DEPOTS]
(
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[location_itemno]
	FROM [network].[TDEPOT]
	WHERE
		(@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv));
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_DEPOT_BY_SYSTEMLOCATIONANDYMDV]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_DEPOT_BY_SYSTEMLOCATIONANDYMDV]
(
	@location_itemno INT,
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[location_itemno],
		[start_ymdv],
		[end_ymdv],
		[code],
		[ease_of_access],
		[percentage_visible_from_train],
		[capabilities]
	FROM [network].[TDEPOT]
	WHERE
		[location_itemno] = @location_itemno
		AND (@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv));
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_LOCATION_BY_SYSTEMPATHANDYMDV]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_LOCATION_BY_SYSTEMPATHANDYMDV]
(
	@path_itemno INT,
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[path_itemno],
		[start_ymdv],
		[end_ymdv],
		[start_location_itemno],
		[end_location_itemno],
		[distance],
		[direction],
		[token_itemno],
		[type_itemno],
		[route_availability],
		[berths],
		[permissible_power],
		[crossing_count],
		[score],
		[freight_only],
		[max_speed],
		[rating],
		[signal_type_itemno],
		[options],
		[permissible_power]
	FROM [network].[TPATH]
	WHERE
		[path_itemno] = @path_itemno
		AND @ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_SAVE_TTRACTIONPROFILE]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_SAVE_TTRACTIONPROFILE]
(
	@traction_class_itemno NVARCHAR(128),
	@max_speed INT,
	@max_speed_light_loco INT,
	@power_itemno INT,
	@tractive_effort INT,
	@horse_power INT

)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@traction_class_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [rollingstock].[Usp_SAVE_TTRACTIONPROFILE]:- You must provide a traction type. @traction_class_itemno IS NULL';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [rollingstock].[TTRACTIONPROFILE] WHERE [traction_class_itemno] = @traction_class_itemno AND [power_itemno] = @power_itemno),0);
	
	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [rollingstock].[TTRACTIONPROFILE]
		SET
			[max_speed] = @max_speed,
			[tractive_effort] = @tractive_effort,
			[horse_power] = @horse_power
		WHERE
			[itemno] = @existing_record_itemno
			
		SELECT
			itemno = @existing_record_itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		INSERT INTO [rollingstock].[TTRACTIONPROFILE]
		(
			[traction_class_itemno],
			[power_itemno],
			[max_speed],
			[max_speed_light_loco],
			[tractive_effort],
			[horse_power]
		)
		VALUES
		(
			@traction_class_itemno,
			@power_itemno,
			@max_speed,
			@max_speed_light_loco,
			@tractive_effort,
			@horse_power
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [logical].[Usp_SAVE_REGION]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [logical].[Usp_SAVE_REGION]
(
	@itemno INT,
	@name NVARCHAR(128),
	@description NVARCHAR(2056),
	@start_ymdv	INT,
	@end_ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(1028);

	IF EXISTS (SELECT 1 FROM [logical].[TREGION] WHERE [name] = @name AND [itemno] != ISNULL(@itemno,0))
	BEGIN
		SET @message = 'Region with name ' + @name + ' already exists. Save aborted';
		RAISERROR(@message, 16, 1);
		RETURN;
	END
	
	IF @itemno = 0
	BEGIN
		INSERT INTO [logical].[TREGION]
		(
			[name],
			[description],
			[start_ymdv],
			[end_ymdv]
		)
		VALUES
		(
			@name,
			@description,
			@start_ymdv,
			@end_ymdv
		)
		
		SELECT
			[itemno] = CONVERT(INT, SCOPE_IDENTITY());
	END
	ELSE
	BEGIN
		UPDATE R
		SET
			[name] = NULLIF(@name,''),
			[description] = NULLIF(@description,''),
			[start_ymdv] = @start_ymdv,
			[end_ymdv] = @end_ymdv
		FROM [logical].[TREGION] AS R
		WHERE
			[itemno] = @itemno;
			
		SELECT
			[itemno] = @itemno;
	END
	
	SET NOCOUNT OFF;		
END
GO
/****** Object:  StoredProcedure [app].[Usp_WRITE_AUDITLOG]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [app].[Usp_WRITE_AUDITLOG]
(
	@application_itemno TINYINT,
	@token NVARCHAR(256) = NULL,
	@audit_type_itemno TINYINT,
	@message NVARCHAR(2048),
	@error_number INT,
	@error_object_xml XML = NULL
)
AS
BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO app.TAUDIT
	(
		[application_itemno],
		[audit_type_itemno],
		[message],
		[error_number],
		[error_object_xml]
	)
	VALUES
	(
		@application_itemno,
		@audit_type_itemno,
		@message,
		@error_number,
		@error_object_xml
	)	
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_SAVE_TTRAIN]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_SAVE_TTRAIN]
(
	@itemno								INT = 0,
	@ymdv								INT,
	@headcode							NVARCHAR(8),
	@description						NVARCHAR(2048),
	@start_location_itemno				INT,
	@end_location_itemno				INT,
	@mp_next_train_itemno				INT,
	@mp_next_train_perc					DECIMAL,
	@mp_next_train_min_turnaround		TINYINT,
	@stock_next_train_itemno			INT,
	@stock_next_train_perc				DECIMAL,
	@stock_next_train_min_turnaround	TINYINT,
	@parent_train_itemno				INT,
	@mins_allocation_on_tops			TINYINT,
	@start_time							BIGINT, --Stored as Ticks
	@days								TINYINT,
	@brake_types						TINYINT,
	@heat_types							TINYINT,
	@configuration						BIGINT,
	@max_speed							SMALLINT,
	@max_speed_if_late					SMALLINT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@headcode,'') IS NULL
	BEGIN
		SET @message = N'Error executing [wtt].[Usp_SAVE_TTRAIN]:- You must provide a headcode (@headcode IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	
	IF @itemno = 0
	BEGIN	
		 SET @itemno = ISNULL((SELECT [itemno] FROM [wtt].[TTRAIN] WHERE [start_ymdv] = @ymdv AND [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0)),0);
	END
	
	IF @itemno != 0
	BEGIN
		UPDATE [wtt].[TTRAIN]
		SET
			[headcode] = NULLIF(@headcode, ''), 
			[description] = NULLIF(@description, ''), 
			[start_location_itemno] = NULLIF(@start_location_itemno,0), 
			[end_location_itemno] = NULLIF(@end_location_itemno,0),  
			[mp_next_train_itemno] = NULLIF(@mp_next_train_itemno,0),
			[mp_next_train_perc] = NULLIF(@mp_next_train_perc,0),
			[mp_next_train_min_turnaround] = NULLIF(@mp_next_train_min_turnaround,0),
			[stock_next_train_itemno] = NULLIF(@stock_next_train_itemno,0),
			[stock_next_train_perc] = NULLIF(@stock_next_train_perc,0), 
			[stock_next_train_min_turnaround] = NULLIF(@stock_next_train_min_turnaround,0), 
			[parent_train_itemno] = NULLIF(@parent_train_itemno,0), 
			[mins_allocation_on_tops] = NULLIF(@mins_allocation_on_tops,0), 
			[start_time] = NULLIF(@start_time,0), 
			[days] = NULLIF(@days,0),  
			[brake_types] = NULLIF(@brake_types,0), 
			[heat_types] = NULLIF(@heat_types,0), 
			[configuration] = NULLIF(@configuration,0), 
			[max_speed] = NULLIF(@max_speed,0), 
			[max_speed_if_late] = NULLIF(@max_speed_if_late,0)
		WHERE
			[itemno] = @itemno
			
		RETURN;
	END;

	DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [wtt].[TTRAIN] WHERE [end_ymdv] IS NULL AND [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0)),0);
	DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [wtt].[TTRAIN] WHERE [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0) AND [start_ymdv] = @prev_start_ymdv),0);
	DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
	IF @prev_record_itemno != 0
	BEGIN
		UPDATE [wtt].[TTRAIN]
		SET
			[end_ymdv] = @new_end_ymdv
		WHERE
			[itemno] = @prev_record_itemno;
	END
	
	INSERT INTO [wtt].[TTRAIN]
	(
		[headcode], 
		[description], 
		[start_location_itemno], 
		[end_location_itemno],  
		[mp_next_train_itemno],
		[mp_next_train_perc],
		[mp_next_train_min_turnaround],
		[stock_next_train_itemno],
		[stock_next_train_perc], 
		[stock_next_train_min_turnaround], 
		[parent_train_itemno], 
		[mins_allocation_on_tops], 
		[start_time], 
		[days],  
		[brake_types], 
		[heat_types], 
		[configuration], 
		[max_speed], 
		[max_speed_if_late]
	)
	VALUES
	(
		NULLIF(@headcode, ''), 
		NULLIF(@description, ''), 
		NULLIF(@start_location_itemno,0), 
		NULLIF(@end_location_itemno,0),  
		NULLIF(@mp_next_train_itemno,0),
		NULLIF(@mp_next_train_perc,0),
		NULLIF(@mp_next_train_min_turnaround,0),
		NULLIF(@stock_next_train_itemno,0),
		NULLIF(@stock_next_train_perc,0), 
		NULLIF(@stock_next_train_min_turnaround,0), 
		NULLIF(@parent_train_itemno,0), 
		NULLIF(@mins_allocation_on_tops,0), 
		NULLIF(@start_time,0), 
		NULLIF(@days,0),  
		NULLIF(@brake_types,0), 
		NULLIF(@heat_types,0), 
		NULLIF(@configuration,0), 
		NULLIF(@max_speed,0), 
		NULLIF(@max_speed_if_late,0)
	);
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_HAS_LOCATION_GOT_CHILDREN]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_HAS_LOCATION_GOT_CHILDREN]
(
	@itemno INT
)
AS
BEGIN
	IF EXISTS (SELECT 1 FROM [network].[TLOCATION] WHERE [parent_itemno] = @itemno)
	BEGIN
		SELECT
			[has_children] = CONVERT(BIT, 1);
	END
	ELSE
	BEGIN
		SELECT
			[has_children] = CONVERT(BIT, 0);
	END
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_SAVE_TTRACTIONCLASS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_SAVE_TTRACTIONCLASS]
(
	@ymdv INT,
	@name NVARCHAR(128),
	@description NVARCHAR(2048),
	@parent_itemno INT,
	@traction_type_itemno TINYINT,
	@length DECIMAL(16,6)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@name,'') IS NULL
	BEGIN
		SET @message = N'Error executing [rollingstock].[Usp_SAVE_TTRACTIONCLASS]:- You must provide a name for the traction class';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [rollingstock].[TTRACTIONCLASS] WHERE [start_ymdv] = @ymdv AND [name] = @name),0);
	
	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [rollingstock].[TTRACTIONCLASS]
		SET
			[description] = @description,
			[parent_itemno] = NULLIF(@parent_itemno,0),
			[traction_type_itemno] = ISNULL(@traction_type_itemno,0),
			[length] = ISNULL(@length,0)
		WHERE
			[itemno] = @existing_record_itemno
			
		SELECT
			itemno = @existing_record_itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [rollingstock].[TTRACTIONCLASS] WHERE [name] = @name AND [end_ymdv] IS NULL),18500101);
		DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [rollingstock].[TTRACTIONCLASS] WHERE [name] = @name AND [start_ymdv] = @prev_start_ymdv),0);
		DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
		IF @prev_record_itemno != 0
		BEGIN
			UPDATE [rollingstock].[TTRACTIONCLASS]
			SET
				[end_ymdv] = @new_end_ymdv
			WHERE
				[itemno] = @prev_record_itemno;
		END
		
		INSERT INTO [rollingstock].[TTRACTIONCLASS]
		(
			[name],
			[description],
			[start_ymdv],
			[parent_itemno],
			[traction_type_itemno],
			[length]
		)
		VALUES
		(
			@name,
			@description,
			@ymdv,
			NULLIF(@parent_itemno,0),
			ISNULL(@traction_type_itemno,0),
			ISNULL(@length,0)
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [rollingstock].[Usp_SAVE_TSTOCK]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [rollingstock].[Usp_SAVE_TSTOCK]
(
	@ymdv INT,
	@type_itemno TINYINT,
	@name NVARCHAR(128),
	@description NVARCHAR(2048),
	@coupling_types SMALLINT,
	@brake_types SMALLINT,
	@heating_types SMALLINT,
	@max_speed SMALLINT,
	@length SMALLINT,
	@options INT,
	@eth_index SMALLINT,
	@weight SMALLINT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF ISNULL(@name,'') IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TSTOCK]:- You must provide a valid name in @name.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [rollingstock].[TSTOCK] WHERE [start_ymdv] = @ymdv AND [name] = @name AND [type_itemno] = @type_itemno),0); 
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [rollingstock].[TSTOCK]
		SET
			[description] = NULLIF(@description,''),
			[coupling_types] = NULLIF(@coupling_types, 0),
			[brake_types] = NULLIF(@brake_types, 0),	
			[heating_types] = NULLIF(@heating_types, 0),	
			[max_speed]	= NULLIF(@max_speed, 0),		
			[length] = NULLIF(@length, 0),			
			[options] = NULLIF(@options, 0),			
			[eth_index]	 = NULLIF(@eth_index, 0),
			[weight] = NULLIF(@weight,0)			
		WHERE
			[itemno] = @existing_record_itemno;
			
		SELECT
			itemno = @existing_record_itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [rollingstock].[TSTOCK] WHERE [name] = @name AND [type_itemno] = @type_itemno AND [end_ymdv] IS NULL),18500101);
		DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [rollingstock].[TSTOCK] WHERE [name] = @name AND [type_itemno] = @type_itemno AND [start_ymdv] = @prev_start_ymdv),0);
		DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
		IF @prev_record_itemno != 0
		BEGIN
			UPDATE [rollingstock].[TSTOCK]
			SET
				[end_ymdv] = @new_end_ymdv
			WHERE
				[itemno] = @prev_record_itemno;
		END
		
		INSERT INTO [rollingstock].[TSTOCK]
		(
			[start_ymdv],
			[type_itemno],
			[name],
			[description],
			[coupling_types],
			[brake_types],
			[heating_types],
			[max_speed],
			[length],
			[options],
			[eth_index],
			[weight]
		)
		VALUES
		(
			@ymdv,
			@type_itemno,
			NULLIF(@name,''),
			NULLIF(@description,''),
			NULLIF(@coupling_types, 0),
			NULLIF(@brake_types, 0),
			NULLIF(@heating_types, 0),
			NULLIF(@max_speed, 0),
			NULLIF(@length, 0),		
			NULLIF(@options, 0),
			NULLIF(@eth_index, 0),
			NULLIF(@weight,0)
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [wtt].[Usp_SAVE_TSECTOR]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [wtt].[Usp_SAVE_TSECTOR]
(
	@itemno								INT = 0,
	@ymdv								INT,
	@headcode							NVARCHAR(8),
	@description						NVARCHAR(2048),
	@start_location_itemno				INT,
	@end_location_itemno				INT,
	@mp_next_train_itemno				INT,
	@mp_next_train_perc					DECIMAL,
	@mp_next_train_min_turnaround		TINYINT,
	@stock_next_train_itemno			INT,
	@stock_next_train_perc				DECIMAL,
	@stock_next_train_min_turnaround	TINYINT,
	@parent_train_itemno				INT,
	@mins_allocation_on_tops			TINYINT,
	@start_time							BIGINT, --Stored as Ticks
	@days								TINYINT,
	@brake_types						TINYINT,
	@heat_types							TINYINT,
	@configuration						BIGINT,
	@max_speed							SMALLINT,
	@max_speed_if_late					SMALLINT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@headcode,'') IS NULL
	BEGIN
		SET @message = N'Error executing [wtt].[Usp_SAVE_TTRAIN]:- You must provide a headcode (@headcode IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	
	IF @itemno = 0
	BEGIN	
		 SET @itemno = ISNULL((SELECT [itemno] FROM [wtt].[TTRAIN] WHERE [start_ymdv] = @ymdv AND [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0)),0);
	END
	
	IF @itemno != 0
	BEGIN
		UPDATE [wtt].[TTRAIN]
		SET
			[headcode] = NULLIF(@headcode, ''), 
			[description] = NULLIF(@description, ''), 
			[start_location_itemno] = NULLIF(@start_location_itemno,0), 
			[end_location_itemno] = NULLIF(@end_location_itemno,0),  
			[mp_next_train_itemno] = NULLIF(@mp_next_train_itemno,0),
			[mp_next_train_perc] = NULLIF(@mp_next_train_perc,0),
			[mp_next_train_min_turnaround] = NULLIF(@mp_next_train_min_turnaround,0),
			[stock_next_train_itemno] = NULLIF(@stock_next_train_itemno,0),
			[stock_next_train_perc] = NULLIF(stock_next_train_perc,0), 
			[stock_next_train_min_turnaround] = NULLIF(stock_next_train_min_turnaround,0), 
			[parent_train_itemno] = NULLIF(@parent_train_itemno,0), 
			[mins_allocation_on_tops] = NULLIF(@mins_allocation_on_tops,0), 
			[start_time] = NULLIF(@start_time,0), 
			[days] = NULLIF(@days,0),  
			[brake_types] = NULLIF(@brake_types,0), 
			[heat_types] = NULLIF(@heat_types,0), 
			[configuration] = NULLIF(@configuration,0), 
			[max_speed] = NULLIF(@max_speed,0), 
			[max_speed_if_late] = NULLIF(@max_speed_if_late,0)
		WHERE
			[itemno] = @itemno
			
		RETURN;
	END;

	DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [wtt].[TTRAIN] WHERE [end_ymdv] IS NULL AND [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0)),0);
	DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [wtt].[TTRAIN] WHERE [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0) AND [start_ymdv] = @prev_start_ymdv),0);
	DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
	IF @prev_record_itemno != 0
	BEGIN
		UPDATE [wtt].[TTRAIN]
		SET
			[end_ymdv] = @new_end_ymdv
		WHERE
			[itemno] = @prev_record_itemno;
	END
	
	INSERT INTO [wtt].[TTRAIN]
	(
		[headcode], 
		[description], 
		[start_location_itemno], 
		[end_location_itemno],  
		[mp_next_train_itemno],
		[mp_next_train_perc],
		[mp_next_train_min_turnaround],
		[stock_next_train_itemno],
		[stock_next_train_perc], 
		[stock_next_train_min_turnaround], 
		[parent_train_itemno], 
		[mins_allocation_on_tops], 
		[start_time], 
		[days],  
		[brake_types], 
		[heat_types], 
		[configuration], 
		[max_speed], 
		[max_speed_if_late]
	)
	VALUES
	(
		NULLIF(@headcode, ''), 
		NULLIF(@description, ''), 
		NULLIF(@start_location_itemno,0), 
		NULLIF(@end_location_itemno,0),  
		NULLIF(@mp_next_train_itemno,0),
		NULLIF(@mp_next_train_perc,0),
		NULLIF(@mp_next_train_min_turnaround,0),
		NULLIF(@stock_next_train_itemno,0),
		NULLIF(@stock_next_train_perc,0), 
		NULLIF(@stock_next_train_min_turnaround,0), 
		NULLIF(@parent_train_itemno,0), 
		NULLIF(@mins_allocation_on_tops,0), 
		NULLIF(@start_time,0), 
		NULLIF(@days,0),  
		NULLIF(@brake_types,0), 
		NULLIF(@heat_types,0), 
		NULLIF(@configuration,0), 
		NULLIF(@max_speed,0), 
		NULLIF(@max_speed_if_late,0)
	);
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [logical].[Usp_SAVE_TSECTOR]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [logical].[Usp_SAVE_TSECTOR]
(
	@code_itemno INT,
	@ymdv INT,
	@description NVARCHAR(2048)
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@code_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TSECTOR]:- You must provide a @code_itemno (@code_itemno IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [logical].[TSECTOR] WHERE [start_ymdv] = @ymdv AND [code_itemno] = @code_itemno),0);

	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [logical].[TSECTOR]
		SET
			[description] = @description
		WHERE
			[itemno] = @existing_record_itemno;

		SELECT
			[itemno] = @existing_record_itemno;
			
		RETURN;
	END;

	DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [logical].[TSECTOR] WHERE [code_itemno] = @code_itemno AND [end_ymdv] IS NULL),18500101);
	DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [logical].[TSECTOR] WHERE [code_itemno] = @code_itemno AND [start_ymdv] = @prev_start_ymdv),0);
	DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
	IF @prev_record_itemno != 0
	BEGIN
		UPDATE [logical].[TSECTOR]
		SET
			[end_ymdv] = @new_end_ymdv
		WHERE
			[itemno] = @prev_record_itemno;
	END

	INSERT INTO [logical].[TSECTOR]
	(
		[description],
		[start_ymdv],
		[code_itemno]
	)
	VALUES
	(
		@description,
		@ymdv,
		@code_itemno
	);

	SELECT
		[itemno] = SCOPE_IDENTITY();

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_SAVE_TPATH]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_SAVE_TPATH]
(
	@ymdv INT,
	@path_itemno INT,
	@start_location_itemno INT,
	@end_location_itemno INT,
	@distance INT, -- Meters
	@direction TINYINT,
	@token_itemno INT,
	@type_itemno SMALLINT,
	@route_availability SMALLINT,
	@berths SMALLINT,
	@permissible_power SMALLINT,
	@cross_count SMALLINT,
	@score SMALLINT,
	@freight_only BIT,
	@max_speed SMALLINT,
	@rating DECIMAL(16,6),
	@signal_type_itemno SMALLINT,
	@options BIGINT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@path_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TPATH]:- You must provide a SystemPath (@path_itemno IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NOT EXISTS (SELECT 1 FROM [network].[TLOCATION] AS L WHERE L.[itemno] = @start_location_itemno AND @ymdv BETWEEN L.[start_ymdv] AND ISNULL(L.[end_ymdv], @ymdv))
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TPATH]:- No location exists with a @start_location_itemno of ' + CONVERT(NVARCHAR(8), @start_location_itemno) + ' which was active at YMDV ' + CONVERT(NVARCHAR(8), @ymdv) + '.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NOT EXISTS (SELECT 1 FROM [network].[TLOCATION] AS L WHERE L.[itemno] = @end_location_itemno AND @ymdv BETWEEN L.[start_ymdv] AND ISNULL(L.[end_ymdv], @ymdv))
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TPATH]:- No location exists with a @end_location_itemno of ' + CONVERT(NVARCHAR(8), @end_location_itemno) + ' which was active at YMDV ' + CONVERT(NVARCHAR(8), @ymdv) + '.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TPATH] WHERE [start_ymdv] = @ymdv AND [path_itemno] = @path_itemno AND [start_location_itemno] = @start_location_itemno AND [end_location_itemno] = @end_location_itemno),0);
	
	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [network].[TPATH]
		SET
			[start_location_itemno] = @start_location_itemno,
			[end_location_itemno] = @end_location_itemno,
			[distance] = @distance,
			[direction] = @direction,
			[token_itemno] = NULLIF(@token_itemno,0),
			[type_itemno] = @type_itemno,
			[route_availability] = @route_availability,
			[berths] = @berths,
			[permissible_power] = @permissible_power,
			[crossing_count] = @cross_count,
			[score] = @score,
			[freight_only] = @freight_only,
			[max_speed] = @max_speed,
			[rating] = @rating,
			[signal_type_itemno] = @signal_type_itemno,
			[options] = @options 
		WHERE
			[itemno] = @existing_record_itemno
			
		SELECT
			itemno = @existing_record_itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [network].[TPATH] WHERE [path_itemno] = @path_itemno AND [end_ymdv] IS NULL AND [start_location_itemno] = @start_location_itemno AND [end_location_itemno] = @end_location_itemno),18500101);
		DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TPATH] WHERE [path_itemno] = @path_itemno AND [start_ymdv] = @prev_start_ymdv AND [end_location_itemno] = @end_location_itemno),0);
		DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
		IF @prev_record_itemno != 0
		BEGIN
			UPDATE [network].[TPATH]
			SET
				[end_ymdv] = @new_end_ymdv
			WHERE
				[itemno] = @prev_record_itemno;
		END
		
		INSERT INTO [network].[TPATH]
		(
			[path_itemno], 
			[start_ymdv],
			[start_location_itemno],
			[end_location_itemno],
			[distance],
			[direction],
			[token_itemno],
			[type_itemno],
			[route_availability],
			[berths],
			[permissible_power],
			[crossing_count],
			[score],
			[freight_only],
			[max_speed],
			[rating],
			[signal_type_itemno],
			[options]
		)
		VALUES
		(
			@path_itemno,
			@ymdv,
			ISNULL(@start_location_itemno,0),
			ISNULL(@end_location_itemno,0),
			@distance,
			@direction,
			NULLIF(@token_itemno,0),
			@type_itemno,
			@route_availability,
			@berths,
			@permissible_power,
			@cross_count,
			@score,
			@freight_only,
			@max_speed,
			@rating,
			@signal_type_itemno,
			@options
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_SAVE_TLOCATION]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_SAVE_TLOCATION]
(
	@ymdv INT,
	@location_itemno INT,
	@name NVARCHAR(128),
	@tiploc NVARCHAR(16),
	@stanox INT = 0,
	@stanme NVARCHAR(32),
	@nlc INT,
	@location_typeitemno INT,
	@latitude DECIMAL(16,6),
	@longitude DECIMAL(16,6),
	@parent_location_itemno INT = NULL,
	@length DECIMAL(16,6),
	@disembark_passengers BIT,
	@embark_passengers BIT,
	@freight_only BIT,
	@single_train_working BIT,
	@token_itemno INT,
	@berths SMALLINT,
	@direction TINYINT,
	@score SMALLINT,
	@use_as_timing_point BIT,
	@options BIGINT,
	@permissible_power BIGINT,
	@tops_office BIT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF ISNULL(@name,'') IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TLOCATION]:- You must provide a valid name in @name.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NULLIF(@location_itemno,0) IS NULL AND NULLIF(@parent_location_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TLOCATION]:- System Location and Parent Location cannot both be NULL. Please supply either @location_itemno or @parent_location_itemno.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NULLIF(@location_itemno,0) IS NOT NULL AND NULLIF(@latitude,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TLOCATION]:- You are updating a parent location. Please supply @latitude.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NULLIF(@location_itemno,0) IS NOT NULL AND NULLIF(@longitude,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TLOCATION]:- You are updating a parent location. Please supply @longitude.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NULLIF(@location_itemno,0) IS NULL
	BEGIN
		SET @latitude = NULL;
		SET @longitude = NULL;
	END			
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	DECLARE @existing_record_itemno INT 
	
	IF NULLIF(@location_itemno,0) IS NOT NULL
	BEGIN
		SET @existing_record_itemno = ISNULL((SELECT [itemno] FROM [network].[TLOCATION] WHERE [start_ymdv] = @ymdv AND [location_itemno] = ISNULL(@location_itemno,0) AND ISNULL([parent_itemno],0) = 0),0);
	END
	ELSE
	BEGIN
		SET @existing_record_itemno = ISNULL((SELECT [itemno] FROM [network].[TLOCATION] WHERE [start_ymdv] = @ymdv AND [parent_itemno] = @parent_location_itemno AND [name] = @name),0);
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [network].[TLOCATION]
		SET
			[name] = CASE WHEN ISNULL(@location_itemno,0) = 0 THEN [name] ELSE @name END, --Child Records cannot have their name changed
			[tiploc] = NULLIF(@tiploc,''),
			[stanox] = ISNULL(@stanox,0),
			[stanme] = NULLIF(@stanme,''),
			[nlc] = ISNULL(@stanox,0),
			[location_type_itemno] = @location_typeitemno,
			[latitude] = @latitude,
			[longitude] = @longitude,
			[parent_itemno] = NULLIF(@parent_location_itemno,0),
			[length] = @length,
			[disembark_passengers] = @disembark_passengers,
			[embark_passengers] = @embark_passengers,
			[freight_only] = @freight_only,
			[single_train_working] = @single_train_working,
			[token_itemno] = NULLIF(@token_itemno,0),
			[berths] = @berths,
			[direction] = @direction,
			[score] = @score,
			[use_as_timing_point] = @use_as_timing_point,
			[options] = ISNULL(@options,0),
			[permissible_power] = ISNULL(@permissible_power,0),
			[tops_office] = ISNULL(@tops_office,0)
		WHERE
			[itemno] = @existing_record_itemno;
			
		SELECT
			itemno = @existing_record_itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [network].[TLOCATION] WHERE [location_itemno] = @location_itemno AND [end_ymdv] IS NULL),18500101);
		DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TLOCATION] WHERE [location_itemno] = @location_itemno AND [start_ymdv] = @prev_start_ymdv),0);
		DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
		IF @prev_record_itemno != 0
		BEGIN
			UPDATE [network].[TLOCATION]
			SET
				[end_ymdv] = @new_end_ymdv
			WHERE
				[itemno] = @prev_record_itemno;
		END
		
		INSERT INTO [network].[TLOCATION]
		(
			[location_itemno], 
			[start_ymdv], 
			[name], 
			[tiploc], 
			[stanox], 
			[stanme], 
			[nlc], 
			[location_type_itemno],
			[latitude],
			[longitude],
			[parent_itemno],
			[length], 
			[disembark_passengers],
			[embark_passengers],
			[freight_only],
			[single_train_working],
			[token_itemno],
			[berths],
			[direction],
			[score],
			[use_as_timing_point],
			[options],
			[permissible_power],
			[tops_office]
		)
		VALUES
		(
			@location_itemno,
			@ymdv,
			@name,
			@tiploc,
			ISNULL(@stanox,0),
			@stanme,
			@nlc,
			@location_typeitemno,
			@latitude,
			@longitude,
			NULLIF(@parent_location_itemno,0),
			@length,
			@disembark_passengers,
			@embark_passengers,
			@freight_only,
			@single_train_working,
			NULLIF(@token_itemno,0),
			@berths,
			@direction,
			@score,
			@use_as_timing_point,
			ISNULL(@options,0),
			ISNULL(@permissible_power,0),
			ISNULL(@tops_office,0)
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_SAVE_TDEPOT]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_SAVE_TDEPOT]
(
	@location_itemno INT,
	@ymdv INT,
	@code NVARCHAR(16),
	@ease_of_access DECIMAL(16,6),
	@percentage_visible_from_train DECIMAL(16,6),
	@capabilities DECIMAL(16,6)
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@location_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TDEPOT]:- You must provide a SystemLocation (@location_itemno IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TDEPOT] WHERE [start_ymdv] = @ymdv AND [location_itemno] = @location_itemno),0);

	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [network].[TDEPOT]
		SET
			[code] = @code,
			[ease_of_access] = @ease_of_access,
			[percentage_visible_from_train] = @percentage_visible_from_train,
			[capabilities] = @capabilities
		WHERE
			[itemno] = @existing_record_itemno;

		SELECT
			[itemno] = @existing_record_itemno;
			
		RETURN;
	END;

	DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [network].[TDEPOT] WHERE [location_itemno] = @location_itemno AND [end_ymdv] IS NULL),18500101);
	DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TDEPOT] WHERE [location_itemno] = @location_itemno AND [start_ymdv] = @prev_start_ymdv),0);
	DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
	IF @prev_record_itemno != 0
	BEGIN
		UPDATE [network].[TDEPOT]
		SET
			[end_ymdv] = @new_end_ymdv
		WHERE
			[itemno] = @prev_record_itemno;
	END

	INSERT INTO [network].[TDEPOT]
	(
		[location_itemno],
		[start_ymdv],
		[code],
		[ease_of_access],
		[percentage_visible_from_train],
		[capabilities]
	)
	VALUES
	(
		@location_itemno,
		@ymdv,
		@code,
		@ease_of_access,
		@percentage_visible_from_train,
		@capabilities
	);

	SELECT
		[itemno] = SCOPE_IDENTITY();

	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV]
(
	@location_itemno INT,
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[location_itemno],
		[start_ymdv],
		[end_ymdv],
		[name],
		[tiploc],
		[stanox],
		[stanme],
		[nlc],
		[location_type_itemno],
		[latitude],
		[longitude],
		[parent_itemno],
		[length], 
		[disembark_passengers],
		[embark_passengers],
		[freight_only],
		[single_train_working],
		[token_itemno],
		[berths],
		[direction],
		[score],
		[use_as_timing_point],
		[options],
		[permissible_power],
		[tops_office]
	FROM [network].[TLOCATION]
	WHERE
		[location_itemno] = @location_itemno
		AND (@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv));
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_LOCATION_BY_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_LOCATION_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[location_itemno],
		[start_ymdv],
		[end_ymdv],
		[name],
		[tiploc],
		[stanox],
		[stanme],
		[nlc],
		[location_type_itemno],
		[latitude],
		[longitude],
		[parent_itemno],
		[length], 
		[disembark_passengers],
		[embark_passengers],
		[freight_only],
		[single_train_working],
		[token_itemno],
		[berths],
		[direction],
		[score],
		[use_as_timing_point],
		[options],
		[permissible_power],
		[tops_office]
	FROM [network].[TLOCATION]
	WHERE
		[itemno] = @itemno;
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_CHILD_LOCATIONS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_CHILD_LOCATIONS]
(
	@parent_itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno]
	FROM [network].[TLOCATION]
	WHERE
		[parent_itemno] = @parent_itemno;
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  StoredProcedure [network].[Usp_GET_LOCATIONS]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [network].[Usp_GET_LOCATIONS]
(
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno]
	FROM [network].[TLOCATION]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
	
	SET NOCOUNT OFF;
END
GO
/****** Object:  UserDefinedFunction [network].[Fn_GET_LOCATION_ID]    Script Date: 09/17/2018 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [network].[Fn_GET_LOCATION_ID]
(
	@name NVARCHAR(128),
	@ymdv INT
)
RETURNS INT
AS
BEGIN
	RETURN (ISNULL((SELECT [itemno] FROM [network].TLOCATION WHERE [name] = @name AND @ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv)),0))
END
GO
/****** Object:  Default [DF_TTENCRYPTIONTOKEN_TOKEN]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [app].[TENCRYPTIONTOKEN] ADD  CONSTRAINT [DF_TTENCRYPTIONTOKEN_TOKEN]  DEFAULT (newid()) FOR [token]
GO
/****** Object:  Default [DF_TUSERCREDENTIALS_CREATEDON]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [app].[TENCRYPTIONTOKEN] ADD  CONSTRAINT [DF_TUSERCREDENTIALS_CREATEDON]  DEFAULT (getutcdate()) FOR [db_createdon]
GO
/****** Object:  Default [DF_WTT_TCALLINGPOINT_ARR]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TCALLINGPOINT] ADD  CONSTRAINT [DF_WTT_TCALLINGPOINT_ARR]  DEFAULT ((0)) FOR [arr]
GO
/****** Object:  Default [DF_WTT_TCALLINGPOINT_DEP]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TCALLINGPOINT] ADD  CONSTRAINT [DF_WTT_TCALLINGPOINT_DEP]  DEFAULT ((0)) FOR [dep]
GO
/****** Object:  Default [DF_WTT_TCALLINGPOINT_SETDOWNONLY]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TCALLINGPOINT] ADD  CONSTRAINT [DF_WTT_TCALLINGPOINT_SETDOWNONLY]  DEFAULT ((0)) FOR [setdownonly]
GO
/****** Object:  Default [DF_WTT_TCALLINGPOINT_PICKUPONLY]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TCALLINGPOINT] ADD  CONSTRAINT [DF_WTT_TCALLINGPOINT_PICKUPONLY]  DEFAULT ((0)) FOR [pickuponly]
GO
/****** Object:  Default [DF_WTT_TCALLINGPOINT_MINDWELLTIME]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TCALLINGPOINT] ADD  CONSTRAINT [DF_WTT_TCALLINGPOINT_MINDWELLTIME]  DEFAULT ((0)) FOR [mindwelltime]
GO
/****** Object:  Default [DF_APP_TAPPLICATION_LOGIN_INSTANCE_ITEMNO]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [app].[TAUDIT] ADD  CONSTRAINT [DF_APP_TAPPLICATION_LOGIN_INSTANCE_ITEMNO]  DEFAULT ((0)) FOR [login_instance_itemno]
GO
/****** Object:  Default [DF_APP_TAPPLICATION_DATE]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [app].[TAUDIT] ADD  CONSTRAINT [DF_APP_TAPPLICATION_DATE]  DEFAULT (getutcdate()) FOR [date]
GO
/****** Object:  Default [DF_APP_TAPPLICATION_ERROR_NO]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [app].[TAUDIT] ADD  CONSTRAINT [DF_APP_TAPPLICATION_ERROR_NO]  DEFAULT ((0)) FOR [error_number]
GO
/****** Object:  Default [DF_APP_TPPLCATION_STATECODE]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [app].[TAPPLICATION] ADD  CONSTRAINT [DF_APP_TPPLCATION_STATECODE]  DEFAULT ((0)) FOR [statecode]
GO
/****** Object:  Default [DF_TUSERUNIQUEID_UNIQUEID]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [users].[TUSERUNIQUEID] ADD  CONSTRAINT [DF_TUSERUNIQUEID_UNIQUEID]  DEFAULT (newid()) FOR [unique_id]
GO
/****** Object:  Default [DF_TUSERCREDENTIALS_CREATEDON]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [users].[TUSERUNIQUEID] ADD  CONSTRAINT [DF_TUSERCREDENTIALS_CREATEDON]  DEFAULT (getutcdate()) FOR [db_createdon]
GO
/****** Object:  Default [DF_TUSERCREDENTIALS_MODIFIEDON]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [users].[TUSERUNIQUEID] ADD  CONSTRAINT [DF_TUSERCREDENTIALS_MODIFIEDON]  DEFAULT (getutcdate()) FOR [db_modifiedon]
GO
/****** Object:  Default [DF_TUSER_UNIQUEID]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [users].[TUSER] ADD  CONSTRAINT [DF_TUSER_UNIQUEID]  DEFAULT (newid()) FOR [unique_id]
GO
/****** Object:  Default [DF_TUSER_CONTACT_PREFERENCES]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [users].[TUSER] ADD  CONSTRAINT [DF_TUSER_CONTACT_PREFERENCES]  DEFAULT ((0)) FOR [contact_preferences]
GO
/****** Object:  Default [DF_WTT_TTRAINTRACTIONALLOCATION_BOOKEDTRACTION]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TTRAINTRACTIONALLOCATION] ADD  CONSTRAINT [DF_WTT_TTRAINTRACTIONALLOCATION_BOOKEDTRACTION]  DEFAULT ((0)) FOR [booked_traction]
GO
/****** Object:  Default [DF_WTT_TTRAINRAKEALLOCATION_BOOKEDRAKE]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TTRAINRAKEALLOCATION] ADD  CONSTRAINT [DF_WTT_TTRAINRAKEALLOCATION_BOOKEDRAKE]  DEFAULT ((0)) FOR [booked_rake]
GO
/****** Object:  Default [DF_WTT_TRAIN_CONFIGURATION]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TTRAIN] ADD  CONSTRAINT [DF_WTT_TRAIN_CONFIGURATION]  DEFAULT ((0)) FOR [configuration]
GO
/****** Object:  Default [DF_WTT_TRAIN_RUNASREQUIRED]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TTRAIN] ADD  CONSTRAINT [DF_WTT_TRAIN_RUNASREQUIRED]  DEFAULT ((0)) FOR [run_as_required]
GO
/****** Object:  Default [DF_WTT_TRAIN_RUNASREQUIREDPERC]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TTRAIN] ADD  CONSTRAINT [DF_WTT_TRAIN_RUNASREQUIREDPERC]  DEFAULT ((0)) FOR [run_as_required_perc]
GO
/****** Object:  Default [DF_WTT_TRAIN_RUNSONCE]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [wtt].[TTRAIN] ADD  CONSTRAINT [DF_WTT_TRAIN_RUNSONCE]  DEFAULT ((0)) FOR [runs_once]
GO
/****** Object:  Default [DF_NETWORK_TOKEN_SYSTEM_TOKEN]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TTOKEN] ADD  CONSTRAINT [DF_NETWORK_TOKEN_SYSTEM_TOKEN]  DEFAULT ((0)) FOR [system_token]
GO
/****** Object:  Default [DF_ROLLINGSTOCK_TSTOCK_OPTIONS]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [rollingstock].[TSTOCK] ADD  CONSTRAINT [DF_ROLLINGSTOCK_TSTOCK_OPTIONS]  DEFAULT ((0)) FOR [options]
GO
/****** Object:  Default [DF_NETWORK_PATH_BERTHS]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TPATH] ADD  CONSTRAINT [DF_NETWORK_PATH_BERTHS]  DEFAULT ((0)) FOR [berths]
GO
/****** Object:  Default [DF_NETWORK_PATH_FREIGHT_ONLY]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TPATH] ADD  CONSTRAINT [DF_NETWORK_PATH_FREIGHT_ONLY]  DEFAULT ((0)) FOR [freight_only]
GO
/****** Object:  Default [DF_NETWORK_PATH_RATING]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TPATH] ADD  CONSTRAINT [DF_NETWORK_PATH_RATING]  DEFAULT ((0)) FOR [rating]
GO
/****** Object:  Default [DF_NETWORK_PATH_SIGNAL_TYPE]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TPATH] ADD  CONSTRAINT [DF_NETWORK_PATH_SIGNAL_TYPE]  DEFAULT ((1)) FOR [signal_type_itemno]
GO
/****** Object:  Default [DF_NETWORK_PATH_OPTIONS]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TPATH] ADD  CONSTRAINT [DF_NETWORK_PATH_OPTIONS]  DEFAULT ((0)) FOR [options]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_STARTYMV]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_STARTYMV]  DEFAULT ((18500101)) FOR [start_ymdv]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_STANOX]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_STANOX]  DEFAULT ((0)) FOR [stanox]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_NLC]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_NLC]  DEFAULT ((0)) FOR [nlc]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_DISEMBARK_PASSENGERS]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_DISEMBARK_PASSENGERS]  DEFAULT ((1)) FOR [disembark_passengers]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_EMBARK_PASSENGERS]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_EMBARK_PASSENGERS]  DEFAULT ((1)) FOR [embark_passengers]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_FREIGHT_ONLY_PASSENGERS]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_FREIGHT_ONLY_PASSENGERS]  DEFAULT ((0)) FOR [freight_only]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_SINGLE_TRAIN_WORKING]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_SINGLE_TRAIN_WORKING]  DEFAULT ((0)) FOR [single_train_working]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_SCORE]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_SCORE]  DEFAULT ((10)) FOR [score]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_USE_AS_TIMING_POINT]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_USE_AS_TIMING_POINT]  DEFAULT ((1)) FOR [use_as_timing_point]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_OPTIONS]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_OPTIONS]  DEFAULT ((0)) FOR [options]
GO
/****** Object:  Default [DF_NETWORK_TLOCATION_TOPSOFFICE]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION] ADD  CONSTRAINT [DF_NETWORK_TLOCATION_TOPSOFFICE]  DEFAULT ((0)) FOR [tops_office]
GO
/****** Object:  ForeignKey [FK_NETWORK_LOCATION_NETWORK_LOCATIONTYPE]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION]  WITH CHECK ADD  CONSTRAINT [FK_NETWORK_LOCATION_NETWORK_LOCATIONTYPE] FOREIGN KEY([location_type_itemno])
REFERENCES [network].[TLOCATIONTYPE] ([itemno])
GO
ALTER TABLE [network].[TLOCATION] CHECK CONSTRAINT [FK_NETWORK_LOCATION_NETWORK_LOCATIONTYPE]
GO
/****** Object:  ForeignKey [FK_NETWORK_LOCATION_NETWORK_SYSTEMLOCATION]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION]  WITH CHECK ADD  CONSTRAINT [FK_NETWORK_LOCATION_NETWORK_SYSTEMLOCATION] FOREIGN KEY([location_itemno])
REFERENCES [network].[TSYSTEMLOCATION] ([system_itemno])
GO
ALTER TABLE [network].[TLOCATION] CHECK CONSTRAINT [FK_NETWORK_LOCATION_NETWORK_SYSTEMLOCATION]
GO
/****** Object:  ForeignKey [FK_NETWORK_LOCATION_NETWORK_TOKEN]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION]  WITH CHECK ADD  CONSTRAINT [FK_NETWORK_LOCATION_NETWORK_TOKEN] FOREIGN KEY([token_itemno])
REFERENCES [network].[TTOKEN] ([itemno])
GO
ALTER TABLE [network].[TLOCATION] CHECK CONSTRAINT [FK_NETWORK_LOCATION_NETWORK_TOKEN]
GO
/****** Object:  ForeignKey [FK_NETWORK_LOCATION_PARENT_NETWORK_LOCATION]    Script Date: 09/17/2018 16:53:39 ******/
ALTER TABLE [network].[TLOCATION]  WITH CHECK ADD  CONSTRAINT [FK_NETWORK_LOCATION_PARENT_NETWORK_LOCATION] FOREIGN KEY([parent_itemno])
REFERENCES [network].[TLOCATION] ([itemno])
GO
ALTER TABLE [network].[TLOCATION] CHECK CONSTRAINT [FK_NETWORK_LOCATION_PARENT_NETWORK_LOCATION]
GO
