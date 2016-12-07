USE [master]
GO

CREATE DATABASE [NavMusicStoreDb] 
GO

ALTER DATABASE [NavMusicStoreDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NavMusicStoreDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NavMusicStoreDb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET ARITHABORT OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [NavMusicStoreDb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [NavMusicStoreDb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [NavMusicStoreDb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET  DISABLE_BROKER
GO
ALTER DATABASE [NavMusicStoreDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [NavMusicStoreDb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [NavMusicStoreDb] SET  READ_WRITE
GO
ALTER DATABASE [NavMusicStoreDb] SET RECOVERY FULL
GO
ALTER DATABASE [NavMusicStoreDb] SET  MULTI_USER
GO
ALTER DATABASE [NavMusicStoreDb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [NavMusicStoreDb] SET DB_CHAINING OFF
GO

USE [NavMusicStoreDb]
GO
/****** Object:  FullTextCatalog [ArtistNameCatalog]    Script Date: 12/07/2016 15:07:56 ******/
CREATE FULLTEXT CATALOG [ArtistNameCatalog]WITH ACCENT_SENSITIVITY = OFF
AUTHORIZATION [dbo]
GO
/****** Object:  FullTextCatalog [ArtistNameAliasCatalog]    Script Date: 12/07/2016 15:07:56 ******/
CREATE FULLTEXT CATALOG [ArtistNameAliasCatalog]WITH ACCENT_SENSITIVITY = OFF
AUTHORIZATION [dbo]
GO
/****** Object:  Table [dbo].[artist]    Script Date: 12/07/2016 15:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[artist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[globalid] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[begindate] [datetime] NULL,
	[enddate] [datetime] NULL,
	[artisttype] [varchar](255) NULL,
	[gender] [varchar](6) NULL,
	[country] [char](2) NULL,
 CONSTRAINT [pk_artist] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE CLUSTERED INDEX [clusteredIndex_artist] ON [dbo].[artist] 
(
	[globalid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE FULLTEXT INDEX ON [dbo].[artist](
[name] LANGUAGE [English])
KEY INDEX [pk_artist]ON ([ArtistNameCatalog], FILEGROUP [PRIMARY])
WITH (CHANGE_TRACKING = AUTO, STOPLIST = SYSTEM)
GO
SET IDENTITY_INSERT [dbo].[artist] ON
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (10, N'6456a893-c1e9-4e3d-86f7-0008b0a3ac8a', N'Jack Johnson', NULL, NULL, NULL, NULL, N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (8, N'144ef525-85e9-40c3-8335-02c32d0861f3', N'John Mayer', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'personal', N'female', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (14, N'29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699', N'Transplants', CAST(0x0000A3F30155DC3A AS DateTime), NULL, NULL, N'male', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (7, N'd700b3f5-45af-4d02-95ed-57d301bda93e', N'Mogwai', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'personal', N'female', N'GB')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (2, N'650e7db6-b795-4eb5-a702-5ea2fc46c848', N'Lady Gaga', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'personal', N'female', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (9, N'18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f', N'Johnny Cash', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'personal', N'female', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (6, N'b625448e-bf4a-41c3-a421-72ad46cdb831', N'John Coltrane', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'personal', N'female', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (13, N'24f8d8a5-269b-475c-a1cb-792990b0b2ee', N'Rancid', CAST(0x0000A3F30155DC3A AS DateTime), NULL, NULL, N'male', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (12, N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822', N'Elton John', CAST(0x0000A3F30155DC3A AS DateTime), NULL, NULL, N'male', N'GB')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (1, N'65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab', N'Metallica', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'group', N'female', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (5, N'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e', N'Megadeth', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'personal', N'female', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (4, N'435f1441-0f43-479d-92db-a506449a686b', N'Mott the Hoople', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'personal', N'female', N'GB')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (15, N'931e1d1f-6b2f-4ff8-9f70-aa537210cd46', N'Operation Ivy', CAST(0x0000A3F30155DC3A AS DateTime), NULL, NULL, N'male', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (11, N'f1571db1-c672-4a54-a2cf-aaa329f26f0b', N'John Frusciante', CAST(0x0000A3F30155DC3A AS DateTime), NULL, NULL, N'male', N'US')
INSERT [dbo].[artist] ([id], [globalid], [name], [begindate], [enddate], [artisttype], [gender], [country]) VALUES (3, N'c44e9c22-ef82-4a77-9bcd-af6c958446d6', N'Mumford & Sons', CAST(0x0000A0CE0156C0D5 AS DateTime), NULL, N'personal', N'female', N'GB')
SET IDENTITY_INSERT [dbo].[artist] OFF
/****** Object:  Table [dbo].[release]    Script Date: 12/07/2016 15:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[release](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[globalid] [uniqueidentifier] NOT NULL,
	[title] [varchar](100) NOT NULL,
	[status] [varchar](255) NULL,
	[label] [varchar](255) NULL,
	[mediatype] [varchar](20) NULL,
	[releasedate] [datetime] NULL,
	[language] [varchar](20) NULL,
	[additionaldetails] [varchar](255) NOT NULL,
	[trackscount] [int] NULL,
 CONSTRAINT [pk_release] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE CLUSTERED INDEX [clusteredIndex_release] ON [dbo].[release] 
(
	[globalid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[release] ON
INSERT [dbo].[release] ([id], [globalid], [title], [status], [label], [mediatype], [releasedate], [language], [additionaldetails], [trackscount]) VALUES (1, N'726701d6-a700-4612-99f1-5e7150e9a916', N'Release  Title A', N'Official', N'Denovali Records', N'CD', CAST(0x0000A42F015E44D9 AS DateTime), N'EN', N'Auto inserted records', 11)
INSERT [dbo].[release] ([id], [globalid], [title], [status], [label], [mediatype], [releasedate], [language], [additionaldetails], [trackscount]) VALUES (6, N'4ab3456a-2bf8-4f2c-be11-8d7143f59a32', N'Title Japan NEW', N'Un Official', N'Honest Abe', N'Electronic', CAST(0x00009C19015E44D9 AS DateTime), N'English', N'Auto inserted records', 1)
INSERT [dbo].[release] ([id], [globalid], [title], [status], [label], [mediatype], [releasedate], [language], [additionaldetails], [trackscount]) VALUES (5, N'54e08bdb-b3ed-45fa-b98c-9c08bb63c504', N'Title Rap and rock', N'Official', N'Denovali Records', N'CD', CAST(0x0000A623015E44D9 AS DateTime), N'EN', N'Auto inserted records', 11)
INSERT [dbo].[release] ([id], [globalid], [title], [status], [label], [mediatype], [releasedate], [language], [additionaldetails], [trackscount]) VALUES (4, N'b919dbbe-fe38-4a30-8c48-b4091a51fe25', N'Release  Title ABC', N'Un Official', N'Honest Abe', N'Electronic', CAST(0x0000A001015E44D9 AS DateTime), NULL, N'Auto inserted records', 1)
INSERT [dbo].[release] ([id], [globalid], [title], [status], [label], [mediatype], [releasedate], [language], [additionaldetails], [trackscount]) VALUES (2, N'205d6022-cc13-4366-b4e4-badd2de8637a', N'Release  Title Japan', N'Un Official', N'Honest Abe', N'Electronic', CAST(0x0000A3E9015E44D9 AS DateTime), N'Japanese', N'Auto inserted records', 8)
INSERT [dbo].[release] ([id], [globalid], [title], [status], [label], [mediatype], [releasedate], [language], [additionaldetails], [trackscount]) VALUES (3, N'8ff78a21-c4a1-434c-92c8-d8c8c34bf9ab', N'Release  Title Canada', N'Official', N'Navalorama Records', N'CD', CAST(0x0000A50A015E44D9 AS DateTime), N'CA', N'Auto inserted records', 2)
SET IDENTITY_INSERT [dbo].[release] OFF
/****** Object:  Table [dbo].[artistrelease]    Script Date: 12/07/2016 15:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[artistrelease](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[artistid] [int] NOT NULL,
	[releaseid] [int] NOT NULL,
	[artistcount] [int] NOT NULL,
 CONSTRAINT [pk_artistrelease] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[artistrelease] ON
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (1, 1, 6, 1)
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (2, 10, 4, 5)
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (3, 4, 2, 1)
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (4, 3, 2, 1)
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (5, 11, 4, 1)
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (6, 8, 5, 6)
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (7, 7, 6, 5)
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (8, 1, 2, 3)
INSERT [dbo].[artistrelease] ([id], [artistid], [releaseid], [artistcount]) VALUES (9, 11, 6, 1)
SET IDENTITY_INSERT [dbo].[artistrelease] OFF
/****** Object:  Table [dbo].[artistalias]    Script Date: 12/07/2016 15:07:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[artistalias](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[artist] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [pk_artist_alias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE FULLTEXT INDEX ON [dbo].[artistalias](
[name] LANGUAGE [English])
KEY INDEX [pk_artist_alias]ON ([ArtistNameCatalog], FILEGROUP [PRIMARY])
WITH (CHANGE_TRACKING = AUTO, STOPLIST = SYSTEM)
GO
SET IDENTITY_INSERT [dbo].[artistalias] ON
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (22, 1, N'Metalica')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (23, 1, N'메탈리카')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (24, 2, N'Lady Ga Ga')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (25, 2, N'Stefani Joanne Angelina Germanotta')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (26, 4, N'Mott The Hoppie')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (27, 4, N'Mott The Hopple')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (28, 5, N'Megadeath')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (29, 6, N'John Coltraine')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (30, 6, N'John William Coltrane')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (31, 7, N'Mogwa')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (32, 9, N'Johhny Cash')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (33, 9, N'Jonny Cash')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (34, 10, N'Jack Hody Johnson')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (35, 11, N'John Anthony Frusciante')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (36, 12, N'E. John, Elthon John')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (37, 12, N'Elton Jphn')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (38, 12, N'John Elton')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (39, 12, N'Reginald Kenneth Dwight')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (40, 13, N'ランシド')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (41, 14, N'The Transplants')
INSERT [dbo].[artistalias] ([id], [artist], [name]) VALUES (42, 15, N'Op Ivy')
SET IDENTITY_INSERT [dbo].[artistalias] OFF
/****** Object:  Default [DF__release__additio__117F9D94]    Script Date: 12/07/2016 15:07:57 ******/
ALTER TABLE [dbo].[release] ADD  DEFAULT ('') FOR [additionaldetails]
GO
/****** Object:  ForeignKey [fk_artistrelease_artist]    Script Date: 12/07/2016 15:07:57 ******/
ALTER TABLE [dbo].[artistrelease]  WITH CHECK ADD  CONSTRAINT [fk_artistrelease_artist] FOREIGN KEY([artistid])
REFERENCES [dbo].[artist] ([id])
GO
ALTER TABLE [dbo].[artistrelease] CHECK CONSTRAINT [fk_artistrelease_artist]
GO
/****** Object:  ForeignKey [fk_artistrelease_release]    Script Date: 12/07/2016 15:07:57 ******/
ALTER TABLE [dbo].[artistrelease]  WITH CHECK ADD  CONSTRAINT [fk_artistrelease_release] FOREIGN KEY([releaseid])
REFERENCES [dbo].[release] ([id])
GO
ALTER TABLE [dbo].[artistrelease] CHECK CONSTRAINT [fk_artistrelease_release]
GO
/****** Object:  ForeignKey [FK_artistalias_artist]    Script Date: 12/07/2016 15:07:57 ******/
ALTER TABLE [dbo].[artistalias]  WITH CHECK ADD  CONSTRAINT [FK_artistalias_artist] FOREIGN KEY([artist])
REFERENCES [dbo].[artist] ([id])
GO
ALTER TABLE [dbo].[artistalias] CHECK CONSTRAINT [FK_artistalias_artist]
GO
