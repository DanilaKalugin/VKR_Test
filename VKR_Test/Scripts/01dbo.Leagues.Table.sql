CREATE TABLE [dbo].[Leagues](
	[LeagueID] [nvarchar](2) NOT NULL,
	[LeagueTitle] [nvarchar](20) NOT NULL,
	[LeagueDHRule] [bit] NOT NULL,
	[LeagueYearOfFoundation] [int] NOT NULL,
 CONSTRAINT [PK_Leagues] PRIMARY KEY CLUSTERED 
(
	[LeagueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT [dbo].[Leagues] ([LeagueID], [LeagueTitle], [LeagueDHRule], [LeagueYearOfFoundation]) VALUES (N'AL', N'American', 1, 1901)
INSERT [dbo].[Leagues] ([LeagueID], [LeagueTitle], [LeagueDHRule], [LeagueYearOfFoundation]) VALUES (N'NL', N'National', 0, 1876)

