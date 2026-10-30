USE [DB_BizzareTimes]
GO
/****** Объект:  Table [dbo].[Articles]    Дата создания скрипта: 29.10.2026 3:01:09 ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[ViewsCount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Объект:  Table [dbo].[Categories]    Дата создания скрипта: 29.10.2026 3:01:09 ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Объект:  Table [dbo].[Comments]    Дата создания скрипта: 29.10.2026 3:01:09 ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Объект:  Table [dbo].[Favorites]    Дата создания скрипта: 29.10.2026 3:01:09 ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ArticleID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Объект:  Table [dbo].[History]    Дата создания скрипта: 29.10.2026 3:01:09 ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ArticleID] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Объект:  Table [dbo].[Likes]    Дата создания скрипта: 29.10.2026 3:01:09 ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ArticleID] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Объект:  Table [dbo].[Subscriptions]    Дата создания скрипта: 29.10.2026 3:01:09 ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriptions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubscriberID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Объект:  Table [dbo].[Users]    Дата создания скрипта: 29.10.2026 3:01:09 ******/ 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([ID], [Title], [Content], [CategoryID], [AuthorID], [CreatedAt], [ImageUrl], [ViewsCount]) VALUES (1, N'Стенд будущего', N'Сегодня был представлен новый стенд, который переворачивает представление о технологиях.', 4, 2, CAST(N'2026-10-27T13:30:12.190' AS DateTime), NULL, 150)
INSERT [dbo].[Articles] ([ID], [Title], [Content], [CategoryID], [AuthorID], [CreatedAt], [ImageUrl], [ViewsCount]) VALUES (2, N'Новый Стенд будущего', N'Продолжение истории про стенды. На этот раз без проводов.', 4, 2, CAST(N'2026-10-27T13:30:12.190' AS DateTime), NULL, 320)
INSERT [dbo].[Articles] ([ID], [Title], [Content], [CategoryID], [AuthorID], [CreatedAt], [ImageUrl], [ViewsCount]) VALUES (3, N'Стенд будущего: Часть 2', N'Разбираем детали и характеристики недавнего анонса.', 4, 2, CAST(N'2026-10-27T13:30:12.190' AS DateTime), NULL, 80)
INSERT [dbo].[Articles] ([ID], [Title], [Content], [CategoryID], [AuthorID], [CreatedAt], [ImageUrl], [ViewsCount]) VALUES (4, N'Новости Стрел', N'Вышло обновление для стрел. Теперь они летают быстрее.', 2, 2, CAST(N'2026-10-27T13:30:12.190' AS DateTime), NULL, 200)
INSERT [dbo].[Articles] ([ID], [Title], [Content], [CategoryID], [AuthorID], [CreatedAt], [ImageUrl], [ViewsCount]) VALUES (5, N'Новости Стрел: Интервью', N'Эксклюзивное интервью с создателем стрел.', 2, 2, CAST(N'2026-10-27T13:30:12.190' AS DateTime), NULL, 95)
INSERT [dbo].[Articles] ([ID], [Title], [Content], [CategoryID], [AuthorID], [CreatedAt], [ImageUrl], [ViewsCount]) VALUES (6, N'Тайны Наследия', N'Что скрывает древнее наследие? Расследование.', 3, 2, CAST(N'2026-10-27T13:30:12.190' AS DateTime), NULL, 400)
INSERT [dbo].[Articles] ([ID], [Title], [Content], [CategoryID], [AuthorID], [CreatedAt], [ImageUrl], [ViewsCount]) VALUES (7, N'Приключения в Бизарре', N'Странные вещи происходят в нашем городе. Читайте репортаж.', 5, 2, CAST(N'2026-10-27T13:30:12.190' AS DateTime), NULL, 110)
INSERT [dbo].[Articles] ([ID], [Title], [Content], [CategoryID], [AuthorID], [CreatedAt], [ImageUrl], [ViewsCount]) VALUES (8, N'Технологии Приключений', N'Как технологии меняют подход к приключениям.', 1, 2, CAST(N'2026-10-27T13:30:12.190' AS DateTime), NULL, 60)
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (1, N'Приключения', N'Приключенческие новости')
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (2, N'Стрелы', N'Стрелы и технологии')
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (3, N'Наследие', N'Наследие и культура')
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (4, N'Стенды', N'Стенды и гаджеты')
INSERT [dbo].[Categories] ([ID], [Name], [Description]) VALUES (5, N'Бизарр', N'Странные новости')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Email], [Password], [Name], [Role]) VALUES (1, N'admin@mail.ru', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', N'Админ', N'ADMIN')
INSERT [dbo].[Users] ([ID], [Email], [Password], [Name], [Role]) VALUES (2, N'volkova@mail.ru', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', N'Владимир', N'WRITER')
INSERT [dbo].[Users] ([ID], [Email], [Password], [Name], [Role]) VALUES (3, N'reader@mail.ru', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', N'Читатель', N'READER')
INSERT [dbo].[Users] ([ID], [Email], [Password], [Name], [Role]) VALUES (4, N'sodleena2006@gmail.com', N'B1B3773A05C0ED0176787A4F1574FF0075F7521E', N'leenoleumm', N'READER')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Объект:  Index [UQ__Categori__737584F6FD4202F9]    Дата создания скрипта: 29.10.2026 3:01:10 ******/ 
ALTER TABLE [dbo].[Categories] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Объект:  Index [UQ__Users__A9D1053424FB583C]    Дата создания скрипта: 29.10.2026 3:01:10 ******/ 
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [ViewsCount]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[History] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Likes] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Subscriptions] ADD  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('READER') FOR [Role]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Categories]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_Articles_Users] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_Articles_Users]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Articles]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Articles]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Users]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Articles]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Users]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Articles] FOREIGN KEY([ArticleID])
REFERENCES [dbo].[Articles] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Articles]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Users]
GO
ALTER TABLE [dbo].[Subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_Subs_Author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Subscriptions] CHECK CONSTRAINT [FK_Subs_Author]
GO
ALTER TABLE [dbo].[Subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_Subs_Subscriber] FOREIGN KEY([SubscriberID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Subscriptions] CHECK CONSTRAINT [FK_Subs_Subscriber]
GO
