CREATE TABLE [dbo].[PlayerPosition](
	[PositionCode] [nvarchar](2) NOT NULL,
	[PositionFullTitle] [nvarchar](20) NOT NULL,
	[Number] [int] NULL,
 CONSTRAINT [PK_PlayerPosition] PRIMARY KEY CLUSTERED 
(
	[PositionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'1B', N'First Base', 2)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'2B', N'Second Base', 3)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'3B', N'Third Base', 4)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'C', N'Catcher', 1)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'CF', N'Center Field', 7)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'DH', N'Designated hitter', 10)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'LF', N'Left Field', 6)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'OF', N'Outfield', 9)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'P', N'Pitcher', 11)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'RF', N'Right Field', 8)
INSERT [dbo].[PlayerPosition] ([PositionCode], [PositionFullTitle], [Number]) VALUES (N'SS', N'Shortstop', 5)
