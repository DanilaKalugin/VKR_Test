CREATE TABLE [dbo].[Stadiums](
	[StadiumID] [int] NOT NULL,
	[StadiumTitle] [nvarchar](75) NOT NULL,
	[StadiumCapacity] [int] NOT NULL,
	[StadiumLocation] [int] NULL,
	[StadiumDistanceToCenterField] [int] NOT NULL,
 CONSTRAINT [PK_Stadiums] PRIMARY KEY CLUSTERED 
(
	[StadiumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (1, N'American Family Field', 41900, 30, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (2, N'Angel Stadium', 45517, 31, 396)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (3, N'Busch Stadium', 45494, 32, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (4, N'Chase Field', 48686, 33, 407)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (5, N'Citi Field', 41922, 16, 408)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (6, N'Citizens Bank Park', 42792, 34, 401)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (7, N'Comerica Park', 41083, 35, 420)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (8, N'Coors Field', 50445, 36, 415)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (9, N'Dodger Stadium', 56000, 37, 395)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (10, N'Fenway Park', 37755, 38, 390)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (11, N'Globe Life Field', 40300, 39, 407)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (12, N'Great American Ball Park', 42319, 24, 404)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (13, N'Guaranteed Rate Field', 40615, 40, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (14, N'Kauffman Stadium', 37903, 41, 410)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (15, N'LoanDepot Park', 36742, 42, 407)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (16, N'Minute Maid Park', 41168, 43, 409)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (17, N'Nationals Park', 41339, 44, 402)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (18, N'RingCentral Coliseum', 46847, 45, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (19, N'Oracle Park', 41265, 46, 391)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (20, N'Oriole Park at Camden Yards', 45971, 47, 410)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (21, N'Petco Park', 40209, 48, 396)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (22, N'PNC Park', 38747, 49, 399)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (23, N'Progressive Field', 35041, 50, 410)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (24, N'Rogers Centre', 49282, 51, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (25, N'T-Mobile Park', 47929, 52, 401)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (26, N'Target Field', 38544, 53, 404)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (27, N'Tropicana Field', 25000, 54, 404)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (28, N'Truist Park', 41084, 55, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (29, N'Wrigley Field', 41649, 40, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (30, N'Yankee Stadium', 47309, 16, 408)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (31, N'Sahlen Field', 16600, 56, 404)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (32, N'Coca-Cola Park', 10100, 57, 409)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (33, N'Frontier Field', 10840, 58, 402)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (34, N'PNC Field', 10000, 59, 408)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (35, N'NBT Bank Stadium', 11731, 60, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (36, N'Polar Park', 9508, 61, 402)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (37, N'Truist Field', 10200, 7, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (38, N'Durham Bulls Athletic Park', 10000, 62, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (39, N'Coolray Field', 10427, 63, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (40, N'Harbor Park', 11856, 64, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (41, N'Huntington Park', 10100, 26, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (42, N'Victory Field', 14230, 65, 418)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (43, N'Louisville Slugger Field', 13131, 66, 405)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (44, N'Fifth Third Field', 10300, 67, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (45, N'Principal Park', 11500, 68, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (46, N'AutoZone Park', 10000, 69, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (47, N'First Horizon Park', 10000, 70, 403)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (48, N'Werner Park', 9023, 71, 402)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (49, N'Chickasaw Bricktown Ballpark', 9000, 72, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (50, N'Dell Diamond', 11631, 73, 400)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (51, N'Greater Nevada Field', 9013, 74, 424)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (52, N'Sutter Health Park', 14014, 75, 403)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (53, N'Cheney Stadium', 6500, 76, 425)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (54, N'Rio Grande Credit Union Field at Isotopes Park', 13500, 77, 428)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (55, N'Southwest University Park', 9500, 78, 406)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (56, N'Las Vegas Ballpark', 10000, 79, 415)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (57, N'Smith''s Ballpark', 14511, 80, 420)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (58, N'Constellation Field', 7500, 81, 405)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (59, N'121 Financial Park', 11000, 82, 420)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (60, N'CHS Field', 7210, 83, 405)
INSERT [dbo].[Stadiums] ([StadiumID], [StadiumTitle], [StadiumCapacity], [StadiumLocation], [StadiumDistanceToCenterField]) VALUES (61, N'TD Ballpark', 8500, 480, 400)

ALTER TABLE [dbo].[Stadiums]  WITH CHECK ADD  CONSTRAINT [FK_Stadiums_Cities] FOREIGN KEY([StadiumLocation])
REFERENCES [dbo].[Cities] ([CityID])

ALTER TABLE [dbo].[Stadiums] CHECK CONSTRAINT [FK_Stadiums_Cities]
