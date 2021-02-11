USE [master]
GO
/****** Object:  Database [project]    Script Date: 11-02-2021 20:42:25 ******/
CREATE DATABASE [project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [project] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [project] SET ARITHABORT OFF 
GO
ALTER DATABASE [project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [project] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [project] SET  MULTI_USER 
GO
ALTER DATABASE [project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [project] SET QUERY_STORE = OFF
GO
USE [project]
GO
/****** Object:  Table [dbo].[1]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[1](
	[Id] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varbinary](30) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](20) NOT NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buyer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[ReqDate] [datetime] NOT NULL,
	[ApprovedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Buyer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](100) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[AdminId] [int] NOT NULL,
	[Date] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[EmailId] [varchar](50) NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[Comment] [varchar](max) NOT NULL,
 CONSTRAINT [PK_comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](50) NULL,
	[Description] [varchar](300) NULL,
	[AdminId] [int] NOT NULL,
	[Date] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManageAdmin]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageAdmin](
	[SupportPhone] [varchar](20) NOT NULL,
	[SupportEmail] [varchar](50) NOT NULL,
	[EmailId] [varbinary](50) NULL,
	[DisplayPic] [varchar](350) NULL,
	[ProfilePicture] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MembersData]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MembersData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfilePicture] [varchar](350) NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmailId] [varchar](100) NOT NULL,
	[Password] [varchar](24) NOT NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](10) NULL,
	[PhoneNo] [varchar](20) NOT NULL,
	[AddLine1] [varchar](100) NOT NULL,
	[Addline2] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[ZipCode] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[University] [varchar](50) NULL,
	[Collage] [varchar](50) NULL,
	[Date] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[IsDetailsSubmitted] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_MembersData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NoteDetails]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NoteDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerId] [int] NOT NULL,
	[NoteTitle] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[DisplayPic] [varchar](350) NULL,
	[Preview] [varchar](350) NOT NULL,
	[Type] [varchar](50) NULL,
	[NoOfPages] [varchar](10) NULL,
	[Description] [varchar](max) NULL,
	[University] [varchar](200) NULL,
	[Country] [varchar](50) NULL,
	[CourseCode] [varchar](100) NULL,
	[Course] [varchar](100) NULL,
	[Professor] [varchar](100) NULL,
	[SellFor] [bit] NOT NULL,
	[SellPrice] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[ReqDate] [datetime] NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_NoteDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rate] [int] NULL,
	[Description] [varchar](300) NOT NULL,
	[Date] [datetime] NOT NULL,
	[InaAppropriate] [varchar](50) NULL,
	[NoteId] [int] NOT NULL,
	[BuyerId] [int] NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seller]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seller](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[ReqDate] [datetime] NOT NULL,
	[ApprovedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Seller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 11-02-2021 20:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](100) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[AdminId] [int] NOT NULL,
	[Date] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Table_1_EmailId]    Script Date: 11-02-2021 20:42:26 ******/
ALTER TABLE [dbo].[MembersData] ADD  CONSTRAINT [UQ_Table_1_EmailId] UNIQUE NONCLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[admin] ADD  CONSTRAINT [DF_admin_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Buyer] ADD  CONSTRAINT [DF_Buyer_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [DF_Country_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ManageAdmin] ADD  CONSTRAINT [DF_ManageAdmin_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MembersData] ADD  CONSTRAINT [DF_MembersData_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[MembersData] ADD  CONSTRAINT [DF_MembersData_IsEmailVerified]  DEFAULT ((1)) FOR [IsEmailVerified]
GO
ALTER TABLE [dbo].[MembersData] ADD  CONSTRAINT [DF_MembersData_IsDetailsSubmitted]  DEFAULT ((0)) FOR [IsDetailsSubmitted]
GO
ALTER TABLE [dbo].[NoteDetails] ADD  CONSTRAINT [DF_NoteDetails_SellFor]  DEFAULT ((0)) FOR [SellFor]
GO
ALTER TABLE [dbo].[NoteDetails] ADD  CONSTRAINT [DF_NoteDetails_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Seller] ADD  CONSTRAINT [DF_Seller_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Type] ADD  CONSTRAINT [DF_Type_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Buyer]  WITH CHECK ADD  CONSTRAINT [FK_Buyer_MembersData] FOREIGN KEY([MemberId])
REFERENCES [dbo].[MembersData] ([Id])
GO
ALTER TABLE [dbo].[Buyer] CHECK CONSTRAINT [FK_Buyer_MembersData]
GO
ALTER TABLE [dbo].[Buyer]  WITH CHECK ADD  CONSTRAINT [FK_Buyer_NoteDetails] FOREIGN KEY([BookId])
REFERENCES [dbo].[NoteDetails] ([Id])
GO
ALTER TABLE [dbo].[Buyer] CHECK CONSTRAINT [FK_Buyer_NoteDetails]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_admin] FOREIGN KEY([AdminId])
REFERENCES [dbo].[admin] ([Id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_admin]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_admin] FOREIGN KEY([AdminId])
REFERENCES [dbo].[admin] ([Id])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_admin]
GO
ALTER TABLE [dbo].[NoteDetails]  WITH CHECK ADD  CONSTRAINT [FK_NoteDetails_MembersData] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[MembersData] ([Id])
GO
ALTER TABLE [dbo].[NoteDetails] CHECK CONSTRAINT [FK_NoteDetails_MembersData]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_NoteDetails] FOREIGN KEY([NoteId])
REFERENCES [dbo].[NoteDetails] ([Id])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_NoteDetails]
GO
ALTER TABLE [dbo].[Seller]  WITH CHECK ADD  CONSTRAINT [FK_Seller_MembersData] FOREIGN KEY([MemberId])
REFERENCES [dbo].[MembersData] ([Id])
GO
ALTER TABLE [dbo].[Seller] CHECK CONSTRAINT [FK_Seller_MembersData]
GO
ALTER TABLE [dbo].[Seller]  WITH CHECK ADD  CONSTRAINT [FK_Seller_NoteDetails] FOREIGN KEY([BookId])
REFERENCES [dbo].[NoteDetails] ([Id])
GO
ALTER TABLE [dbo].[Seller] CHECK CONSTRAINT [FK_Seller_NoteDetails]
GO
USE [master]
GO
ALTER DATABASE [project] SET  READ_WRITE 
GO
