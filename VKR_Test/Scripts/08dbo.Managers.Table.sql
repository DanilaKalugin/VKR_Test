CREATE TABLE [dbo].[Managers](
	[ManagerID] [int] NOT NULL,
	[ManagerFirstName] [nvarchar](30) NOT NULL,
	[ManagerSecondName] [nvarchar](30) NOT NULL,
	[ManagerPlaceOfBirth] [int] NOT NULL,
	[ManagerDateOfBirth] [date] NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (1, N'Joe', N'Maddon', 1, CAST(N'1954-02-08' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (2, N'Dusty', N'Baker', 2, CAST(N'1949-06-15' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (3, N'Bob', N'Melvin', 3, CAST(N'1961-10-28' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (4, N'Charlie', N'Montoyo', 4, CAST(N'1965-10-17' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (5, N'Brian', N'Snitker', 5, CAST(N'1955-10-17' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (6, N'Craig', N'Counsell', 6, CAST(N'1970-08-21' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (7, N'Mike', N'Shildt', 7, CAST(N'1968-08-09' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (8, N'David', N'Ross', 8, CAST(N'1977-03-19' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (9, N'Torey', N'Lovullo', 9, CAST(N'1965-07-25' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (10, N'Dave', N'Roberts', 10, CAST(N'1972-05-31' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (11, N'Gabe', N'Kapler', 11, CAST(N'1975-07-31' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (12, N'Terry', N'Francona', 12, CAST(N'1959-04-22' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (13, N'Scott', N'Servais', 13, CAST(N'1967-06-04' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (14, N'Don', N'Mattingly', 14, CAST(N'1961-04-20' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (15, N'Luis', N'Rojas', 15, CAST(N'1981-09-01' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (16, N'Dave', N'Martinez', 16, CAST(N'1964-09-26' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (17, N'Brandon', N'Hyde', 17, CAST(N'1973-10-03' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (18, N'Jayce', N'Tingler', 18, CAST(N'1980-11-28' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (19, N'Joe', N'Girardi', 19, CAST(N'1964-10-14' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (20, N'Derek', N'Shelton', 20, CAST(N'1970-07-30' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (21, N'Chris', N'Woodward', 21, CAST(N'1976-06-27' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (22, N'Kevin', N'Cash', 22, CAST(N'1977-12-06' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (23, N'Alex', N'Cora', 23, CAST(N'1975-10-18' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (24, N'David', N'Bell', 24, CAST(N'1972-09-14' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (25, N'Bud', N'Black', 25, CAST(N'1957-06-30' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (26, N'Mike', N'Matheny', 26, CAST(N'1970-09-22' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (27, N'A. J.', N'Hinch', 27, CAST(N'1974-05-15' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (28, N'Rocco', N'Baldelli', 28, CAST(N'1981-09-25' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (29, N'Tony', N'La Russa', 22, CAST(N'1944-10-04' AS Date))
INSERT [dbo].[Managers] ([ManagerID], [ManagerFirstName], [ManagerSecondName], [ManagerPlaceOfBirth], [ManagerDateOfBirth]) VALUES (30, N'Aaron', N'Boone', 29, CAST(N'1973-03-09' AS Date))

ALTER TABLE [dbo].[Managers]  WITH CHECK ADD  CONSTRAINT [FK_Managers_Cities] FOREIGN KEY([ManagerPlaceOfBirth])
REFERENCES [dbo].[Cities] ([CityID])

ALTER TABLE [dbo].[Managers] CHECK CONSTRAINT [FK_Managers_Cities]

