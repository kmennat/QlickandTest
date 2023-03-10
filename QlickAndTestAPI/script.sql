USE [AshanteSystemDb]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 9/25/2022 5:18:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyLogo]    Script Date: 9/25/2022 5:18:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyLogo](
	[CompanyLogoID] [int] IDENTITY(1,1) NOT NULL,
	[FileBytes] [varbinary](max) NOT NULL,
	[IsActive] [bit] NULL,
	[CompanyID] [int] NOT NULL,
	[Extension] [nvarchar](250) NULL,
 CONSTRAINT [PK_CompanyLogo] PRIMARY KEY CLUSTERED 
(
	[CompanyLogoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Identity]    Script Date: 9/25/2022 5:18:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Identity](
	[IdentityID] [int] NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NULL,
	[CompanyID] [int] NULL,
	[Position] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[IdentityTypeID] [int] NOT NULL,
	[CustomizableOne] [nvarchar](max) NULL,
	[CustomizableTwo] [nvarchar](max) NULL,
	[LastUpdated] [datetime2](7) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[CardID] [nvarchar](max) NULL,
 CONSTRAINT [PK_Identity] PRIMARY KEY CLUSTERED 
(
	[IdentityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityPhoto]    Script Date: 9/25/2022 5:18:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityPhoto](
	[IdentityPhotoID] [int] IDENTITY(1,1) NOT NULL,
	[FileBytes] [varbinary](max) NOT NULL,
	[IdentityID] [int] NOT NULL,
	[Extension] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_IdentityPhoto] PRIMARY KEY CLUSTERED 
(
	[IdentityPhotoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[CompanyLogo]  WITH CHECK ADD  CONSTRAINT [FK_CompanyLogo_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([CompanyID])
GO
ALTER TABLE [dbo].[CompanyLogo] CHECK CONSTRAINT [FK_CompanyLogo_Company]
GO
