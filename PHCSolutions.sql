USE [master]
GO
/****** Object:  Database [PHCSolutions]    Script Date: 09/16/2016 17:39:38 ******/
CREATE DATABASE [PHCSolutions] ON  PRIMARY 
( NAME = N'PHCSolutions', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PHCSolutions.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PHCSolutions_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\PHCSolutions_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PHCSolutions] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PHCSolutions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PHCSolutions] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [PHCSolutions] SET ANSI_NULLS OFF
GO
ALTER DATABASE [PHCSolutions] SET ANSI_PADDING OFF
GO
ALTER DATABASE [PHCSolutions] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [PHCSolutions] SET ARITHABORT OFF
GO
ALTER DATABASE [PHCSolutions] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [PHCSolutions] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [PHCSolutions] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [PHCSolutions] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [PHCSolutions] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [PHCSolutions] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [PHCSolutions] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [PHCSolutions] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [PHCSolutions] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [PHCSolutions] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [PHCSolutions] SET  DISABLE_BROKER
GO
ALTER DATABASE [PHCSolutions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [PHCSolutions] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [PHCSolutions] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [PHCSolutions] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [PHCSolutions] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [PHCSolutions] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [PHCSolutions] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [PHCSolutions] SET  READ_WRITE
GO
ALTER DATABASE [PHCSolutions] SET RECOVERY FULL
GO
ALTER DATABASE [PHCSolutions] SET  MULTI_USER
GO
ALTER DATABASE [PHCSolutions] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [PHCSolutions] SET DB_CHAINING OFF
GO
USE [PHCSolutions]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [nvarchar](50) NOT NULL,
	[LoginID] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MState]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MState](
	[StateID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_MState] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MDrugs]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MDrugs](
	[DrugID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Quantity] [int] NOT NULL,
	[BatchNo] [nvarchar](200) NULL,
	[manufactureDate] [datetime] NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
	[State] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DrugID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MDistrict]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MDistrict](
	[DistrictID] [nvarchar](50) NOT NULL,
	[StateID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_MDistrict] PRIMARY KEY CLUSTERED 
(
	[DistrictID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MDisease]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MDisease](
	[DiseaseID] [nvarchar](50) NOT NULL,
	[StateID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_MDisease] PRIMARY KEY CLUSTERED 
(
	[DiseaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserDetailID] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NULL,
	[MobileNo] [nvarchar](13) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MLabTest]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MLabTest](
	[LabTestID] [nvarchar](50) NOT NULL,
	[StateID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_MLabTest] PRIMARY KEY CLUSTERED 
(
	[LabTestID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MTaluk]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MTaluk](
	[TalukID] [nvarchar](50) NOT NULL,
	[DistrictID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_MTaluk] PRIMARY KEY CLUSTERED 
(
	[TalukID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MPHC]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MPHC](
	[PHCID] [nvarchar](50) NOT NULL,
	[TalukID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_MPHC] PRIMARY KEY CLUSTERED 
(
	[PHCID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MVillage]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MVillage](
	[VillageID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_MVillage] PRIMARY KEY CLUSTERED 
(
	[VillageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientDetails]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientDetails](
	[PatientID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[age] [smallint] NOT NULL,
	[DOB] [datetime] NULL,
	[Sex] [char](1) NOT NULL,
	[BloodGroup] [nvarchar](3) NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_PatientDetails] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserMap]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMap](
	[UserMapID] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](50) NOT NULL,
	[StateID] [nvarchar](50) NOT NULL,
	[DistrictID] [nvarchar](50) NOT NULL,
	[TalukID] [nvarchar](50) NULL,
	[PHCID] [nvarchar](50) NULL,
	[VillageID] [nvarchar](50) NULL,
	[DisplayName] [nvarchar](100) NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_UserMap] PRIMARY KEY CLUSTERED 
(
	[UserMapID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientAddress]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientAddress](
	[PatientAddressID] [nvarchar](50) NOT NULL,
	[PatientID] [nvarchar](50) NOT NULL,
	[Village] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[PhoneNo] [nvarchar](13) NULL,
	[ContactNo] [nvarchar](13) NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_PatientAddress] PRIMARY KEY CLUSTERED 
(
	[PatientAddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientEC]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientEC](
	[PatientECID] [nvarchar](50) NOT NULL,
	[ECNumber] [nvarchar](50) NOT NULL,
	[PatientID] [nvarchar](50) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_PatientEC] PRIMARY KEY CLUSTERED 
(
	[PatientECID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientPrescription]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientPrescription](
	[PrescriptionID] [nvarchar](50) NOT NULL,
	[PatientID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[DiseaseID] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_PatientPrescription] PRIMARY KEY CLUSTERED 
(
	[PrescriptionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientMC]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientMC](
	[PatientMC] [nvarchar](50) NOT NULL,
	[PatientID] [nvarchar](50) NOT NULL,
	[PatientECID] [nvarchar](50) NOT NULL,
	[MCNumber] [nvarchar](50) NOT NULL,
	[MCIssued] [char](1) NOT NULL,
	[LMP] [datetime] NOT NULL,
	[EDD] [datetime] NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_PatientMC] PRIMARY KEY CLUSTERED 
(
	[PatientMC] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LabTestDetails]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LabTestDetails](
	[LabTestDetailID] [nvarchar](50) NOT NULL,
	[PatientPrescriptionID] [nvarchar](50) NOT NULL,
	[LabTestID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[Result] [nvarchar](50) NULL,
	[Remarks] [nvarchar](200) NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
 CONSTRAINT [PK_LabTestDetails] PRIMARY KEY CLUSTERED 
(
	[LabTestDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DrugsIssued]    Script Date: 09/16/2016 17:39:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DrugsIssued](
	[DrugsID] [nvarchar](50) NOT NULL,
	[PHCID] [nvarchar](50) NOT NULL,
	[DrugID] [nvarchar](50) NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[Dosage] [nvarchar](20) NOT NULL,
	[LastModifiedBy] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[ObsInd] [char](1) NOT NULL,
	[PrescriptionID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DrugsIssued] PRIMARY KEY CLUSTERED 
(
	[DrugsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_MDistrict_MState]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[MDistrict]  WITH CHECK ADD  CONSTRAINT [FK_MDistrict_MState] FOREIGN KEY([StateID])
REFERENCES [dbo].[MState] ([StateID])
GO
ALTER TABLE [dbo].[MDistrict] CHECK CONSTRAINT [FK_MDistrict_MState]
GO
/****** Object:  ForeignKey [FK_MDisease_MState]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[MDisease]  WITH CHECK ADD  CONSTRAINT [FK_MDisease_MState] FOREIGN KEY([StateID])
REFERENCES [dbo].[MState] ([StateID])
GO
ALTER TABLE [dbo].[MDisease] CHECK CONSTRAINT [FK_MDisease_MState]
GO
/****** Object:  ForeignKey [FK_UserDetails_UserDetails]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_UserDetails_UserDetails] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_UserDetails]
GO
/****** Object:  ForeignKey [FK_MLabTest_MState]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[MLabTest]  WITH CHECK ADD  CONSTRAINT [FK_MLabTest_MState] FOREIGN KEY([StateID])
REFERENCES [dbo].[MState] ([StateID])
GO
ALTER TABLE [dbo].[MLabTest] CHECK CONSTRAINT [FK_MLabTest_MState]
GO
/****** Object:  ForeignKey [FK_MTaluk_MDistrict]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[MTaluk]  WITH CHECK ADD  CONSTRAINT [FK_MTaluk_MDistrict] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[MDistrict] ([DistrictID])
GO
ALTER TABLE [dbo].[MTaluk] CHECK CONSTRAINT [FK_MTaluk_MDistrict]
GO
/****** Object:  ForeignKey [FK_MPHC_MTaluk]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[MPHC]  WITH CHECK ADD  CONSTRAINT [FK_MPHC_MTaluk] FOREIGN KEY([TalukID])
REFERENCES [dbo].[MTaluk] ([TalukID])
GO
ALTER TABLE [dbo].[MPHC] CHECK CONSTRAINT [FK_MPHC_MTaluk]
GO
/****** Object:  ForeignKey [FK_MVillage_MPHC]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[MVillage]  WITH CHECK ADD  CONSTRAINT [FK_MVillage_MPHC] FOREIGN KEY([PHCID])
REFERENCES [dbo].[MPHC] ([PHCID])
GO
ALTER TABLE [dbo].[MVillage] CHECK CONSTRAINT [FK_MVillage_MPHC]
GO
/****** Object:  ForeignKey [FK_PatientDetails_MPHC]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[PatientDetails]  WITH CHECK ADD  CONSTRAINT [FK_PatientDetails_MPHC] FOREIGN KEY([PHCID])
REFERENCES [dbo].[MPHC] ([PHCID])
GO
ALTER TABLE [dbo].[PatientDetails] CHECK CONSTRAINT [FK_PatientDetails_MPHC]
GO
/****** Object:  ForeignKey [FK_UserMap_MDistrict]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[UserMap]  WITH CHECK ADD  CONSTRAINT [FK_UserMap_MDistrict] FOREIGN KEY([DistrictID])
REFERENCES [dbo].[MDistrict] ([DistrictID])
GO
ALTER TABLE [dbo].[UserMap] CHECK CONSTRAINT [FK_UserMap_MDistrict]
GO
/****** Object:  ForeignKey [FK_UserMap_MPHC]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[UserMap]  WITH CHECK ADD  CONSTRAINT [FK_UserMap_MPHC] FOREIGN KEY([PHCID])
REFERENCES [dbo].[MPHC] ([PHCID])
GO
ALTER TABLE [dbo].[UserMap] CHECK CONSTRAINT [FK_UserMap_MPHC]
GO
/****** Object:  ForeignKey [FK_UserMap_MState]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[UserMap]  WITH CHECK ADD  CONSTRAINT [FK_UserMap_MState] FOREIGN KEY([StateID])
REFERENCES [dbo].[MState] ([StateID])
GO
ALTER TABLE [dbo].[UserMap] CHECK CONSTRAINT [FK_UserMap_MState]
GO
/****** Object:  ForeignKey [FK_UserMap_MTaluk]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[UserMap]  WITH CHECK ADD  CONSTRAINT [FK_UserMap_MTaluk] FOREIGN KEY([TalukID])
REFERENCES [dbo].[MTaluk] ([TalukID])
GO
ALTER TABLE [dbo].[UserMap] CHECK CONSTRAINT [FK_UserMap_MTaluk]
GO
/****** Object:  ForeignKey [FK_UserMap_MVillage]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[UserMap]  WITH CHECK ADD  CONSTRAINT [FK_UserMap_MVillage] FOREIGN KEY([VillageID])
REFERENCES [dbo].[MVillage] ([VillageID])
GO
ALTER TABLE [dbo].[UserMap] CHECK CONSTRAINT [FK_UserMap_MVillage]
GO
/****** Object:  ForeignKey [FK_UserMap_Users]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[UserMap]  WITH CHECK ADD  CONSTRAINT [FK_UserMap_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserMap] CHECK CONSTRAINT [FK_UserMap_Users]
GO
/****** Object:  ForeignKey [FK_PatientAddress_PatientDetails]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[PatientAddress]  WITH CHECK ADD  CONSTRAINT [FK_PatientAddress_PatientDetails] FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientDetails] ([PatientID])
GO
ALTER TABLE [dbo].[PatientAddress] CHECK CONSTRAINT [FK_PatientAddress_PatientDetails]
GO
/****** Object:  ForeignKey [FK_PatientEC_PatientDetails]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[PatientEC]  WITH CHECK ADD  CONSTRAINT [FK_PatientEC_PatientDetails] FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientDetails] ([PatientID])
GO
ALTER TABLE [dbo].[PatientEC] CHECK CONSTRAINT [FK_PatientEC_PatientDetails]
GO
/****** Object:  ForeignKey [FK__PatientPr__Disea__4316F928]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[PatientPrescription]  WITH CHECK ADD FOREIGN KEY([DiseaseID])
REFERENCES [dbo].[MDisease] ([DiseaseID])
GO
/****** Object:  ForeignKey [FK_PatientPrescription_MPHC]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[PatientPrescription]  WITH CHECK ADD  CONSTRAINT [FK_PatientPrescription_MPHC] FOREIGN KEY([PHCID])
REFERENCES [dbo].[MPHC] ([PHCID])
GO
ALTER TABLE [dbo].[PatientPrescription] CHECK CONSTRAINT [FK_PatientPrescription_MPHC]
GO
/****** Object:  ForeignKey [FK_PatientPrescription_PatientDetails]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[PatientPrescription]  WITH CHECK ADD  CONSTRAINT [FK_PatientPrescription_PatientDetails] FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientDetails] ([PatientID])
GO
ALTER TABLE [dbo].[PatientPrescription] CHECK CONSTRAINT [FK_PatientPrescription_PatientDetails]
GO
/****** Object:  ForeignKey [FK_PatientMC_PatientDetails]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[PatientMC]  WITH CHECK ADD  CONSTRAINT [FK_PatientMC_PatientDetails] FOREIGN KEY([PatientID])
REFERENCES [dbo].[PatientDetails] ([PatientID])
GO
ALTER TABLE [dbo].[PatientMC] CHECK CONSTRAINT [FK_PatientMC_PatientDetails]
GO
/****** Object:  ForeignKey [FK_PatientMC_PatientEC]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[PatientMC]  WITH CHECK ADD  CONSTRAINT [FK_PatientMC_PatientEC] FOREIGN KEY([PatientECID])
REFERENCES [dbo].[PatientEC] ([PatientECID])
GO
ALTER TABLE [dbo].[PatientMC] CHECK CONSTRAINT [FK_PatientMC_PatientEC]
GO
/****** Object:  ForeignKey [FK_LabTestDetails_MLabTest]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[LabTestDetails]  WITH CHECK ADD  CONSTRAINT [FK_LabTestDetails_MLabTest] FOREIGN KEY([LabTestID])
REFERENCES [dbo].[MLabTest] ([LabTestID])
GO
ALTER TABLE [dbo].[LabTestDetails] CHECK CONSTRAINT [FK_LabTestDetails_MLabTest]
GO
/****** Object:  ForeignKey [FK_LabTestDetails_MPHC]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[LabTestDetails]  WITH CHECK ADD  CONSTRAINT [FK_LabTestDetails_MPHC] FOREIGN KEY([PHCID])
REFERENCES [dbo].[MPHC] ([PHCID])
GO
ALTER TABLE [dbo].[LabTestDetails] CHECK CONSTRAINT [FK_LabTestDetails_MPHC]
GO
/****** Object:  ForeignKey [FK_LabTestDetails_PatientPrescription]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[LabTestDetails]  WITH CHECK ADD  CONSTRAINT [FK_LabTestDetails_PatientPrescription] FOREIGN KEY([PatientPrescriptionID])
REFERENCES [dbo].[PatientPrescription] ([PrescriptionID])
GO
ALTER TABLE [dbo].[LabTestDetails] CHECK CONSTRAINT [FK_LabTestDetails_PatientPrescription]
GO
/****** Object:  ForeignKey [FK__DrugsIssu__DrugI__38996AB5]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[DrugsIssued]  WITH CHECK ADD FOREIGN KEY([DrugID])
REFERENCES [dbo].[MDrugs] ([DrugID])
GO
/****** Object:  ForeignKey [FK__DrugsIssu__Presc__3D5E1FD2]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[DrugsIssued]  WITH CHECK ADD FOREIGN KEY([PrescriptionID])
REFERENCES [dbo].[PatientPrescription] ([PrescriptionID])
GO
/****** Object:  ForeignKey [FK_DrugsIssued_MPHC]    Script Date: 09/16/2016 17:39:39 ******/
ALTER TABLE [dbo].[DrugsIssued]  WITH CHECK ADD  CONSTRAINT [FK_DrugsIssued_MPHC] FOREIGN KEY([PHCID])
REFERENCES [dbo].[MPHC] ([PHCID])
GO
ALTER TABLE [dbo].[DrugsIssued] CHECK CONSTRAINT [FK_DrugsIssued_MPHC]
GO
