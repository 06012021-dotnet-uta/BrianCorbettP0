--CREATE SCHEMA RpsGame;

CREATE DATABASE RpsGameDb;

CREATE TABLE Choices(
	ChoiceId INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	ChoiceName NVARCHAR(12) NOT NULL
);

INSERT INTO Choices(ChoiceName)
VALUES ('Rock'), ('Paper'), ('Scissors');

SELECT * FROM Choices;
--DROP TABLE Choices;

--------------------------

CREATE TABLE Players(
	PlayerId INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	PlayerFname NVARCHAR(20) NOT NULL,
	PlayerAge INT NULL,
	Wins INT DEFAULT 0 NOT NULL,
	CONSTRAINT AgeUnder125 CHECK(PlayerAge < 125 AND PlayerAge > 0)
);

INSERT INTO Players (PlayerFname, PlayerAge)
VALUES ('Brian', 23), ('Jason', 29), ('Lisa', 26);

SELECT * FROM Players;
--DROP TABLE Players;

--------------------------

CREATE TABLE Game(
	GameId INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	Player1Id INT NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
	Player2Id INT NOT NULL FOREIGN KEY REFERENCES Players(PlayerId),
	Winner INT NULL
	-- GameDate
);

INSERT INTO Game(Player1Id, Player2Id)
VALUES (1, 3), (2, 3), (1, 2);

SELECT * FROM Game;
--DROP TABLE Game;

--------------------------

CREATE TABLE GameRound(
	RoundId INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	GameId INT NOT NULL FOREIGN KEY REFERENCES Game(GameId),
	Player1Choice INT NOT NULL FOREIGN KEY REFERENCES Choices(ChoiceId),
	Player2Choice INT NOT NULL FOREIGN KEY REFERENCES Choices(ChoiceId)
);

SELECT * FROM GameRound;
--DROP TABLE GameRound;

---------------------------
