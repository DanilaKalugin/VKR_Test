CREATE TABLE [dbo].[TypesOfAtBatResults](
	[AtBatTypeID] [int] NOT NULL,
	[AtBatTypeTitle] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_TypesOfAtBatResults] PRIMARY KEY CLUSTERED 
(
	[AtBatTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (1, N'Strikeout')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (2, N'Walk')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (3, N'Hit-By-Pitch')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (4, N'Flyout')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (5, N'Groundout')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (6, N'Popout')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (7, N'Single')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (8, N'Double')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (9, N'Triple')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (10, N'Home run')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (11, N'Stolen base')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (12, N'Caught Stealing')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (13, N'Run')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (14, N'Sacrifice fly')
INSERT [dbo].[TypesOfAtBatResults] ([AtBatTypeID], [AtBatTypeTitle]) VALUES (15, N'Sacrifice bunt')

