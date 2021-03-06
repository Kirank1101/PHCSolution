USE [master]
GO
/****** Object:  Database [PHC]    Script Date: 08/25/2016 21:36:05 ******/
CREATE DATABASE [PHC] ON  PRIMARY 
( NAME = N'PHC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PHC.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PHC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PHC_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PHC] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PHC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PHC] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [PHC] SET ANSI_NULLS OFF
GO
ALTER DATABASE [PHC] SET ANSI_PADDING OFF
GO
ALTER DATABASE [PHC] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [PHC] SET ARITHABORT OFF
GO
ALTER DATABASE [PHC] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [PHC] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [PHC] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [PHC] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [PHC] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [PHC] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [PHC] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [PHC] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [PHC] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [PHC] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [PHC] SET  DISABLE_BROKER
GO
ALTER DATABASE [PHC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [PHC] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [PHC] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [PHC] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [PHC] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [PHC] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [PHC] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [PHC] SET  READ_WRITE
GO
ALTER DATABASE [PHC] SET RECOVERY FULL
GO
ALTER DATABASE [PHC] SET  MULTI_USER
GO
ALTER DATABASE [PHC] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [PHC] SET DB_CHAINING OFF
GO
USE [PHC]
GO
/****** Object:  Table [dbo].[PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHCInfo](
	[PHCID] [nvarchar](50) NOT NULL,
	[PHCName] [nvarchar](100) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Taluk] [nvarchar](100) NOT NULL,
	[District] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[PinCode] [int] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PHCInfo] PRIMARY KEY CLUSTERED 
(
	[PHCID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PHCInfo] ([PHCID], [PHCName], [Address1], [Taluk], [District], [State], [PinCode], [ObsInd], [LastModifiedBy], [LastModifiedDate]) VALUES (N'PHC1', N'MATTIKOTE', N'MATTIKOTE', N'SHIKARIPUR', N'SHIMOGA', N'KARNATAKA', 577427, N'N', N'SYSTEM', CAST(0x0000A66A00000000 AS DateTime))
/****** Object:  Table [dbo].[PatientInfo]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientInfo](
	[PatientID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Age] [smallint] NOT NULL,
	[Sex] [char](1) NOT NULL,
	[ContactNo] [nvarchar](15) NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[DOB] [date] NULL,
	[BloodGroup] [varchar](6) NULL,
	[PhotoPath] [nvarchar](100) NULL,
 CONSTRAINT [PK_PatientInfo] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[PatientInfo] ([PatientID], [PHCID], [Name], [Age], [Sex], [ContactNo], [ObsInd], [LastModifiedBy], [LastModifiedDate], [DOB], [BloodGroup], [PhotoPath]) VALUES (N'p1', N'PHC1', N'Nagavardhan', 36, N'M', N'9900990300', N'N', N'system', CAST(0x0000A66A00000000 AS DateTime), CAST(0x98070B00 AS Date), N'O+', NULL)
INSERT [dbo].[PatientInfo] ([PatientID], [PHCID], [Name], [Age], [Sex], [ContactNo], [ObsInd], [LastModifiedBy], [LastModifiedDate], [DOB], [BloodGroup], [PhotoPath]) VALUES (N'p2', N'PHC1', N'Harshavardhan', 32, N'M', N'9611285554', N'N', N'system', CAST(0x0000A66A00000000 AS DateTime), CAST(0x8F0B0B00 AS Date), N'O-', N'')
INSERT [dbo].[PatientInfo] ([PatientID], [PHCID], [Name], [Age], [Sex], [ContactNo], [ObsInd], [LastModifiedBy], [LastModifiedDate], [DOB], [BloodGroup], [PhotoPath]) VALUES (N'p3', N'PHC1', N'Deepa', 30, N'F', N'8495919999', N'N', N'system', CAST(0x0000A66900000000 AS DateTime), CAST(0x3B0D0B00 AS Date), N'O+', NULL)
INSERT [dbo].[PatientInfo] ([PatientID], [PHCID], [Name], [Age], [Sex], [ContactNo], [ObsInd], [LastModifiedBy], [LastModifiedDate], [DOB], [BloodGroup], [PhotoPath]) VALUES (N'PT2016082327cb1990ba4dfc', N'PHC1', N'tt', 2, N'm', N'1234', N'N', N'system', CAST(0x0000A66B016478DF AS DateTime), CAST(0xC63B0B00 AS Date), N'', NULL)
INSERT [dbo].[PatientInfo] ([PatientID], [PHCID], [Name], [Age], [Sex], [ContactNo], [ObsInd], [LastModifiedBy], [LastModifiedDate], [DOB], [BloodGroup], [PhotoPath]) VALUES (N'PT20160824b249adf8447646', N'PHC1', N'Rudresh kulkarni', 34, N' ', N'9900990300', N'N', N'system', CAST(0x0000A66C0110F020 AS DateTime), CAST(0xC73B0B00 AS Date), N'', NULL)
/****** Object:  Table [dbo].[MLabTest]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MLabTest](
	[LabTestID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[TestType] [nvarchar](100) NOT NULL,
	[MinValue] [nvarchar](10) NULL,
	[MaxValue] [nvarchar](10) NULL,
	[CountValue] [nvarchar](10) NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_MLabTest] PRIMARY KEY CLUSTERED 
(
	[LabTestID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MDrugs]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MDrugs](
	[DrugID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[DrugName] [nvarchar](200) NOT NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_MDrugs] PRIMARY KEY CLUSTERED 
(
	[DrugID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[EmailID] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ContactNo] [varchar](20) NULL,
	[LoginID] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Users] ([UserID], [PHCID], [Name], [EmailID], [Password], [ObsInd], [LastModifiedBy], [LastModifiedDate], [ContactNo], [LoginID]) VALUES (N'UI20160824237ea5c5a6d974', N'PHC1', N'Nagavardhan', N'nagavardhan.kj@gmail.com', N'deepakj', N'N', N'system', CAST(0x0000A66C0101C4E4 AS DateTime), N'9900990300', N'nagu')
INSERT [dbo].[Users] ([UserID], [PHCID], [Name], [EmailID], [Password], [ObsInd], [LastModifiedBy], [LastModifiedDate], [ContactNo], [LoginID]) VALUES (N'UI201608242e4f86df37908d', N'PHC1', N'Harshavardhan', N'nagavardhan.kj@gmail.com', N'Deepakj', N'N', N'system', CAST(0x0000A66C00D85840 AS DateTime), N'9900990300', N'Harsha')
/****** Object:  Table [dbo].[DrugInfo]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DrugInfo](
	[DrugInfoID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[DrugID] [nvarchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[MFDT] [date] NOT NULL,
	[EXPDT] [date] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DrugInfo] PRIMARY KEY CLUSTERED 
(
	[DrugInfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prescription]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Prescription](
	[prescriptionID] [nvarchar](50) NOT NULL,
	[PatientID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[Diseases] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED 
(
	[prescriptionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LabReport]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LabReport](
	[LabReportID] [nvarchar](50) NOT NULL,
	[prescriptionID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[LabTestID] [nvarchar](50) NOT NULL,
	[Result] [nvarchar](100) NOT NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LabReport] PRIMARY KEY CLUSTERED 
(
	[LabReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MedicationDetails]    Script Date: 08/25/2016 21:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MedicationDetails](
	[MedicationID] [nvarchar](50) NOT NULL,
	[prescriptionID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[DrugID] [nvarchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
	[Dosage] [nvarchar](3) NOT NULL,
	[ObsInd] [char](1) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_MedicationDetails] PRIMARY KEY CLUSTERED 
(
	[MedicationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_PatientInfo_PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[PatientInfo]  WITH CHECK ADD  CONSTRAINT [FK_PatientInfo_PHCInfo] FOREIGN KEY([PHCID])
REFERENCES [dbo].[PHCInfo] ([PHCID])
GO
ALTER TABLE [dbo].[PatientInfo] CHECK CONSTRAINT [FK_PatientInfo_PHCInfo]
GO
/****** Object:  ForeignKey [FK_MLabTest_PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[MLabTest]  WITH CHECK ADD  CONSTRAINT [FK_MLabTest_PHCInfo] FOREIGN KEY([PHCID])
REFERENCES [dbo].[PHCInfo] ([PHCID])
GO
ALTER TABLE [dbo].[MLabTest] CHECK CONSTRAINT [FK_MLabTest_PHCInfo]
GO
/****** Object:  ForeignKey [FK_MDrugs_PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[MDrugs]  WITH CHECK ADD  CONSTRAINT [FK_MDrugs_PHCInfo] FOREIGN KEY([PHCID])
REFERENCES [dbo].[PHCInfo] ([PHCID])
GO
ALTER TABLE [dbo].[MDrugs] CHECK CONSTRAINT [FK_MDrugs_PHCInfo]
GO
/****** Object:  ForeignKey [FK_Users_PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PHCInfo] FOREIGN KEY([PHCID])
REFERENCES [dbo].[PHCInfo] ([PHCID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PHCInfo]
GO
/****** Object:  ForeignKey [FK_DrugInfo_MDrugs]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[DrugInfo]  WITH CHECK ADD  CONSTRAINT [FK_DrugInfo_MDrugs] FOREIGN KEY([DrugID])
REFERENCES [dbo].[MDrugs] ([DrugID])
GO
ALTER TABLE [dbo].[DrugInfo] CHECK CONSTRAINT [FK_DrugInfo_MDrugs]
GO
/****** Object:  ForeignKey [FK_DrugInfo_PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[DrugInfo]  WITH CHECK ADD  CONSTRAINT [FK_DrugInfo_PHCInfo] FOREIGN KEY([PHCID])
REFERENCES [dbo].[PHCInfo] ([PHCID])
GO
ALTER TABLE [dbo].[DrugInfo] CHECK CONSTRAINT [FK_DrugInfo_PHCInfo]
GO
/****** Object:  ForeignKey [FK_Prescription_PatientInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_PatientInfo] FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientInfo] ([PatientID])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_Prescription_PatientInfo]
GO
/****** Object:  ForeignKey [FK_Prescription_PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[Prescription]  WITH CHECK ADD  CONSTRAINT [FK_Prescription_PHCInfo] FOREIGN KEY([PHCID])
REFERENCES [dbo].[PHCInfo] ([PHCID])
GO
ALTER TABLE [dbo].[Prescription] CHECK CONSTRAINT [FK_Prescription_PHCInfo]
GO
/****** Object:  ForeignKey [FK_LabReport_MLabTest]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_MLabTest] FOREIGN KEY([LabTestID])
REFERENCES [dbo].[MLabTest] ([LabTestID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_MLabTest]
GO
/****** Object:  ForeignKey [FK_LabReport_PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_PHCInfo] FOREIGN KEY([PHCID])
REFERENCES [dbo].[PHCInfo] ([PHCID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_PHCInfo]
GO
/****** Object:  ForeignKey [FK_LabReport_Prescription]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_Prescription] FOREIGN KEY([prescriptionID])
REFERENCES [dbo].[Prescription] ([prescriptionID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_Prescription]
GO
/****** Object:  ForeignKey [FK_MedicationDetails_MDrugs]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[MedicationDetails]  WITH CHECK ADD  CONSTRAINT [FK_MedicationDetails_MDrugs] FOREIGN KEY([DrugID])
REFERENCES [dbo].[MDrugs] ([DrugID])
GO
ALTER TABLE [dbo].[MedicationDetails] CHECK CONSTRAINT [FK_MedicationDetails_MDrugs]
GO
/****** Object:  ForeignKey [FK_MedicationDetails_PHCInfo]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[MedicationDetails]  WITH CHECK ADD  CONSTRAINT [FK_MedicationDetails_PHCInfo] FOREIGN KEY([PHCID])
REFERENCES [dbo].[PHCInfo] ([PHCID])
GO
ALTER TABLE [dbo].[MedicationDetails] CHECK CONSTRAINT [FK_MedicationDetails_PHCInfo]
GO
/****** Object:  ForeignKey [FK_MedicationDetails_Prescription]    Script Date: 08/25/2016 21:36:06 ******/
ALTER TABLE [dbo].[MedicationDetails]  WITH CHECK ADD  CONSTRAINT [FK_MedicationDetails_Prescription] FOREIGN KEY([prescriptionID])
REFERENCES [dbo].[Prescription] ([prescriptionID])
GO
ALTER TABLE [dbo].[MedicationDetails] CHECK CONSTRAINT [FK_MedicationDetails_Prescription]
GO
