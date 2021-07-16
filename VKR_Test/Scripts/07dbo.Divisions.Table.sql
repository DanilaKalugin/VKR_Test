CREATE TABLE [dbo].[Divisions](
	[DivisionNumber] [int] NOT NULL,
	[DivisionTitle] [nvarchar](10) NOT NULL,
	[League] [nvarchar](2) NOT NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[DivisionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT [dbo].[Divisions] ([DivisionNumber], [DivisionTitle], [League]) VALUES (1, N'AL East', N'AL')
INSERT [dbo].[Divisions] ([DivisionNumber], [DivisionTitle], [League]) VALUES (2, N'AL Central', N'AL')
INSERT [dbo].[Divisions] ([DivisionNumber], [DivisionTitle], [League]) VALUES (3, N'AL West', N'AL')
INSERT [dbo].[Divisions] ([DivisionNumber], [DivisionTitle], [League]) VALUES (4, N'NL East', N'NL')
INSERT [dbo].[Divisions] ([DivisionNumber], [DivisionTitle], [League]) VALUES (5, N'NL Central', N'NL')
INSERT [dbo].[Divisions] ([DivisionNumber], [DivisionTitle], [League]) VALUES (6, N'NL West', N'NL')

ALTER TABLE [dbo].[Divisions]  WITH CHECK ADD  CONSTRAINT [FK_Divisions_Leagues] FOREIGN KEY([League])
REFERENCES [dbo].[Leagues] ([LeagueID])

ALTER TABLE [dbo].[Divisions] CHECK CONSTRAINT [FK_Divisions_Leagues]

