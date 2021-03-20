CREATE TABLE Snapshots
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TimeStamp DATETIME NOT NULL DEFAULT GETUTCDATE()
);

CREATE TABLE Configurations
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ImageBasePath NVARCHAR(100) NOT NULL,
	BackdropPathOriginal NVARCHAR(50) NOT NULL,
	BackdropPathW1280 NVARCHAR(50) NOT NULL,
	BackdropPathW780 NVARCHAR(50) NOT NULL,
	BackdropPathW300 NVARCHAR(50) NOT NULL,
	PosterPathOriginal NVARCHAR(50) NOT NULL,
	PosterPathW780 NVARCHAR(50) NOT NULL,
	PosterPathW500 NVARCHAR(50) NOT NULL,
	PosterPathW342 NVARCHAR(50) NOT NULL,
	PosterPathW185 NVARCHAR(50) NOT NULL,
	PosterPathW154 NVARCHAR(50) NOT NULL,
	PosterPathW92 NVARCHAR(50) NOT NULL,
	ProfilePathOriginal NVARCHAR(50) NOT NULL,
	ProfilePathH632 NVARCHAR(50) NOT NULL,
	ProfilePathW185 NVARCHAR(50) NOT NULL,
	ProfilePathW45 NVARCHAR(50) NOT NULL,
	LogoPathOriginal NVARCHAR(50) NOT NULL,
	LogoPathW500 NVARCHAR(50) NOT NULL,
	LogoPathW300 NVARCHAR(50) NOT NULL,
	LogoPathW185 NVARCHAR(50) NOT NULL,
	LogoPathW154 NVARCHAR(50) NOT NULL,
	LogoPathW92 NVARCHAR(50) NOT NULL,
	LogoPathW45 NVARCHAR(50) NOT NULL,
	StillPathOriginal NVARCHAR(50) NOT NULL,
	StillPathW300 NVARCHAR(50) NOT NULL,
	StillPathW185 NVARCHAR(50) NOT NULL,
	StillPathW92 NVARCHAR(50) NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_Configurations_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE ShowGenres
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	GenreId INT NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_ShowGenres_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE MovieGenres
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	GenreId INT NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_MovieGenres_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE ListItems
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ItemType INT NOT NULL, /* Show = 0, Movie = 1 */
	ItemId INT NOT NULL,
	Title NVARCHAR(150) NOT NULL,
	Overview NTEXT NOT NULL,
	BackdropPathOriginal NVARCHAR(300) NOT NULL,
	BackdropPathW1280 NVARCHAR(300) NOT NULL,
	BackdropPathW780 NVARCHAR(300) NOT NULL,
	BackdropPathW300 NVARCHAR(300) NOT NULL,
	PosterPathOriginal NVARCHAR(300) NOT NULL,
	PosterPathW780 NVARCHAR(300) NOT NULL,
	PosterPathW500 NVARCHAR(300) NOT NULL,
	PosterPathW342 NVARCHAR(300) NOT NULL,
	PosterPathW185 NVARCHAR(300) NOT NULL,
	PosterPathW154 NVARCHAR(300) NOT NULL,
	PosterPathW92 NVARCHAR(300) NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_ListItems_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE TrendingShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_TrendingShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_TrendingShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE ComedyShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_ComedyShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_ComedyShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE DramaShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_DramaShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_DramaShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE ActionAdventureShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_ActionAdventureShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_ActionAdventureShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE AnimationShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_AnimationShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_AnimationShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE ScifiShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_ScifiShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_ScifiShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE CrimeShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_CrimeShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_CrimeShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE MysteryShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_MysteryShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_MysteryShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE ThrillerShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_ThrillerShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_ThrillerShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE HorrorShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_HorrorShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_HorrorShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE FamilyShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_FamilyShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_FamilyShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE KidsShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_KidsShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_KidsShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE WesternShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_WesternShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_WesternShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE FantasyMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_FantasyMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_FantasyMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE HistoryShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_HistoryShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_HistoryShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE RomanceShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_RomanceShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_RomanceShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE WarShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_WarShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_WarShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE DocumentaryShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_DocumentaryShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_DocumentaryShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE SitcomShows
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_SitcomShows_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_SitcomShows_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE AnthologyShows
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_AnthologyShows_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_AnthologyShows_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE AnimeShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_AnimeShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_AnimeShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE TeenDramaShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_TeenDramaShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_TeenDramaShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE HistoricalDramaShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_HistoricalDramaShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_HistoricalDramaShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE WorkplaceComedyShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_WorkplaceComedyShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_WorkplaceComedyShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);

CREATE TABLE MedicalDramaShowsAndMovies
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ListItemId INT NOT NULL,
	SnapshotId INT NOT NULL,
	CONSTRAINT FK_MedicalDramaShowsAndMovies_ListItems_ListItemId FOREIGN KEY (ListItemId) REFERENCES [dbo].[ListItems] (Id),
	CONSTRAINT FK_MedicalDramaShowsAndMovies_Snapshots_SnapshotId FOREIGN KEY (SnapShotId) REFERENCES [dbo].[Snapshots] (Id)
);
