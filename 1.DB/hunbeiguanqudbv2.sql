set quoted_identifier on 
GO

/****** ����: �û� dbo    �ű�����: 2011-9-9 11:36:37 ******/
/****** ����: �û� guest    �ű�����: 2011-9-9 11:36:37 ******/
if not exists (select * from dbo.sysusers where name = N'guest' and hasdbaccess = 1)
	EXEC sp_grantdbaccess N'guest'
GO

/****** ����: ������ dbo.InsertMeasureSluiceData    �ű�����: 2011-9-9 11:36:37 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertMeasureSluiceData]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[InsertMeasureSluiceData]
GO

/****** ����: ��ͼ dbo.vMeasureSluiceDataLast    �ű�����: 2011-9-9 11:36:37 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vMeasureSluiceDataLast]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vMeasureSluiceDataLast]
GO

/****** ����: ��ͼ dbo.vMeasureSluiceData    �ű�����: 2011-9-9 11:36:37 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vMeasureSluiceData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vMeasureSluiceData]
GO

/****** ����: �� [dbo].[tblMeasureSluiceDataLast]    �ű�����: 2011-9-9 11:36:37 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMeasureSluiceDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMeasureSluiceDataLast]
GO

/****** ����: �� [dbo].[tblMeasureSluiceData]    �ű�����: 2011-9-9 11:36:37 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMeasureSluiceData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMeasureSluiceData]
GO

/****** ����: �� [dbo].[tblDevice]    �ű�����: 2011-9-9 11:36:37 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDevice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDevice]
GO

/****** ����: �� [dbo].[tblStation]    �ű�����: 2011-9-9 11:36:37 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblStation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblStation]
GO

/****** ����: �� [dbo].[tblGroup]    �ű�����: 2011-9-9 11:36:37 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblGroup]
GO

/****** ����: �� [dbo].[tblGroup]    �ű�����: 2011-9-9 11:36:37 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblGroup] (
	[GroupID] [int] IDENTITY (1, 1) NOT NULL ,
	[GroupName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[GroupLeader] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[ContactWay] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Remark] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[Deleted] [bit] NULL CONSTRAINT [DF_tblGroup_Deleted] DEFAULT (0),
	CONSTRAINT [PK_tblGroup] PRIMARY KEY  CLUSTERED 
	(
		[GroupID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblStation]    �ű�����: 2011-9-9 11:36:37 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblStation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblStation] (
	[GroupID] [int] NULL ,
	[StationID] [int] IDENTITY (1, 1) NOT NULL ,
	[Deleted] [bit] NULL CONSTRAINT [DF_tblStation_Deleted] DEFAULT (0),
	[Name] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[CommuniType] [int] NULL ,
	[CommuniTypeContent] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [PK_tblStation] PRIMARY KEY  CLUSTERED 
	(
		[StationID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblStation_tblGroup] FOREIGN KEY 
	(
		[GroupID]
	) REFERENCES [dbo].[tblGroup] (
		[GroupID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblDevice]    �ű�����: 2011-9-9 11:36:37 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDevice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblDevice] (
	[DeviceID] [int] IDENTITY (1, 1) NOT NULL ,
	[StationID] [int] NULL ,
	[Name] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Address] [int] NULL ,
	[DeviceKind] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[DeviceType] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Deleted] [bit] NULL CONSTRAINT [DF_tblDevice_Deleted] DEFAULT (0),
	[Remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [PK_tblDevice] PRIMARY KEY  CLUSTERED 
	(
		[DeviceID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblDevice_tblStation] FOREIGN KEY 
	(
		[StationID]
	) REFERENCES [dbo].[tblStation] (
		[StationID]
	)
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblMeasureSluiceData]    �ű�����: 2011-9-9 11:36:37 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMeasureSluiceData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblMeasureSluiceData] (
	[MeasureSluiceDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NULL ,
	[DT] [datetime] NULL ,
	[BeforeWL] [real] NULL ,
	[BehindWL] [real] NULL ,
	[InstantFlux] [real] NULL ,
	[Height] [real] NULL ,
	[RemainedAmount] [real] NULL ,
	[UsedAmount] [real] NULL ,
	CONSTRAINT [PK_tblMeasureSluiceData] PRIMARY KEY  CLUSTERED 
	(
		[MeasureSluiceDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblMeasureSluiceData_tblDevice] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** ����: �� [dbo].[tblMeasureSluiceDataLast]    �ű�����: 2011-9-9 11:36:37 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMeasureSluiceDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblMeasureSluiceDataLast] (
	[MeasureSluiceDataLastID] [int] IDENTITY (1, 1) NOT NULL ,
	[MeasureSluiceDataID] [int] NULL ,
	[DeviceID] [int] NULL ,
	CONSTRAINT [PK_tblMeasureSluiceDataLast] PRIMARY KEY  CLUSTERED 
	(
		[MeasureSluiceDataLastID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblMeasureSluiceDataLast_tblMeasureSluiceData] FOREIGN KEY 
	(
		[MeasureSluiceDataID]
	) REFERENCES [dbo].[tblMeasureSluiceData] (
		[MeasureSluiceDataID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** ����: ��ͼ dbo.vMeasureSluiceData    �ű�����: 2011-9-9 11:36:37 ******/

CREATE  VIEW dbo.vMeasureSluiceData
AS
SELECT dbo.tblGroup.GroupID, dbo.tblStation.StationID, dbo.tblDevice.DeviceID, 
      dbo.tblGroup.GroupName, dbo.tblStation.Name AS StationName, 
      dbo.tblMeasureSluiceData.MeasureSluiceDataID, dbo.tblMeasureSluiceData.DT, 
      dbo.tblMeasureSluiceData.BeforeWL, dbo.tblMeasureSluiceData.BehindWL, 
      dbo.tblMeasureSluiceData.InstantFlux, dbo.tblMeasureSluiceData.Height, 
      dbo.tblMeasureSluiceData.RemainedAmount, 
      dbo.tblMeasureSluiceData.UsedAmount
FROM dbo.tblDevice INNER JOIN
      dbo.tblStation ON dbo.tblDevice.StationID = dbo.tblStation.StationID INNER JOIN
      dbo.tblGroup ON dbo.tblStation.GroupID = dbo.tblGroup.GroupID INNER JOIN
      dbo.tblMeasureSluiceData ON 
      dbo.tblDevice.DeviceID = dbo.tblMeasureSluiceData.DeviceID


GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** ����: ��ͼ dbo.vMeasureSluiceDataLast    �ű�����: 2011-9-9 11:36:37 ******/

CREATE  VIEW dbo.vMeasureSluiceDataLast
AS
SELECT dbo.tblGroup.GroupID, dbo.tblStation.StationID, dbo.tblDevice.DeviceID, 
      dbo.tblGroup.GroupName, dbo.tblStation.Name AS StationName, 
      dbo.tblMeasureSluiceData.MeasureSluiceDataID, dbo.tblMeasureSluiceData.DT, 
      dbo.tblMeasureSluiceData.BeforeWL, dbo.tblMeasureSluiceData.BehindWL, 
      dbo.tblMeasureSluiceData.InstantFlux, dbo.tblMeasureSluiceData.Height, 
      dbo.tblMeasureSluiceData.RemainedAmount, 
      dbo.tblMeasureSluiceData.UsedAmount
FROM dbo.tblDevice INNER JOIN
      dbo.tblStation ON dbo.tblDevice.StationID = dbo.tblStation.StationID INNER JOIN
      dbo.tblGroup ON dbo.tblStation.GroupID = dbo.tblGroup.GroupID INNER JOIN
      dbo.tblMeasureSluiceData ON 
      dbo.tblDevice.DeviceID = dbo.tblMeasureSluiceData.DeviceID INNER JOIN
      dbo.tblMeasureSluiceDataLast ON 
      dbo.tblMeasureSluiceData.MeasureSluiceDataID = dbo.tblMeasureSluiceDataLast.MeasureSluiceDataID


GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** ����: ������ dbo.InsertMeasureSluiceData    �ű�����: 2011-9-9 11:36:37 ******/

CREATE TRIGGER InsertMeasureSluiceData ON [dbo].[tblMeasureSluiceData] 
FOR INSERT
AS



declare @m_DataID 	int,
        @m_DeviceID int
	  

select  top 1 	@m_DataID = MeasureSluiceDataID, 
		@m_DeviceID = DeviceID 
		from inserted


-- ɾ�����豸���е�����
DELETE From tblMeasureSluiceDataLast WHERE DeviceID = @m_DeviceID
--DeviceID = @m_DeviceID

-- ���� �豸ID �� ��������ID
INSERT INTO tblMeasureSluiceDataLast( MeasureSluiceDataID , DeviceID) VALUES ( @m_DataID, @m_deviceID)

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

