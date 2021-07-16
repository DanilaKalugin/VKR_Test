CREATE TABLE [dbo].[LineUpType](
	[LineupTypeID] [int] NOT NULL,
	[PitcherThrowingHand] [nvarchar](5) NULL,
	[DesignatedHitterRule] [bit] NULL,
	[Description] [nvarchar](10) NULL,
 CONSTRAINT [PK_LineUpType] PRIMARY KEY CLUSTERED 
(
	[LineupTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT [dbo].[LineUpType] ([LineupTypeID], [PitcherThrowingHand], [DesignatedHitterRule], [Description]) VALUES (1, N'Right', 1, NULL)
INSERT [dbo].[LineUpType] ([LineupTypeID], [PitcherThrowingHand], [DesignatedHitterRule], [Description]) VALUES (2, N'Right', 0, NULL)
INSERT [dbo].[LineUpType] ([LineupTypeID], [PitcherThrowingHand], [DesignatedHitterRule], [Description]) VALUES (3, N'Left', 1, NULL)
INSERT [dbo].[LineUpType] ([LineupTypeID], [PitcherThrowingHand], [DesignatedHitterRule], [Description]) VALUES (4, N'Left', 0, NULL)
INSERT [dbo].[LineUpType] ([LineupTypeID], [PitcherThrowingHand], [DesignatedHitterRule], [Description]) VALUES (5, NULL, NULL, N'Rotation')
