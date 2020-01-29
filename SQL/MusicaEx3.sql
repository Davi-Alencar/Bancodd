CREATE DATABASE MusicaEx3;

USE MusicaEx3

CREATE TABLE Estilos (
	IdEstilo		INT PRIMARY KEY IDENTITY,
	NomeEstilo		VARCHAR(250) NOT NULL
);

CREATE TABLE Artistas (
	IdArtista		INT PRIMARY KEY IDENTITY,
	NomeArtista		VARCHAR(250) NOT NULL
);

CREATE TABLE Albuns (
	IdAlbum			INT PRIMARY KEY IDENTITY,
	NomeAlbum		VARCHAR(250) NOT NULL UNIQUE,
	DtLancamento	DATE,
	Localizacao		VARCHAR(200),
	QtdMinutos		BIGINT,		
	IdArtista		INT FOREIGN KEY REFERENCES Artistas (IdArtista),
	IdEstilo		INT FOREIGN KEY REFERENCES Estilos (IdEstilo)
	
);

CREATE TABLE Usuarios (
	IdUsuario		INT PRIMARY KEY IDENTITY,
	NomeUsuario		VARCHAR(250) NOT NULL
);

SELECT * FROM Estilos;
SELECT * FROM Artistas;
SELECT * FROM Albuns;
SELECT * FROM Usuarios;

--Inserir Dados
INSERT INTO Estilos (NomeEstilo) VALUES ('Pop'), ('K-Pop'), ('Korean-Pop')

INSERT INTO Artistas(NomeArtista) VALUES ('Eu'), ('Você'), ('2 filho'), ('1 cao')

INSERT INTO Albuns (NomeAlbum, DtLancamento, Localizacao, QtdMinutos, IdArtista, IdEstilo)
VALUES ('As tranças do rei careca', '17/01/2000', 'MG', '135', '2', '2')

INSERT INTO Albuns (NomeAlbum, DtLancamento, Localizacao, QtdMinutos, IdArtista, IdEstilo)
VALUES ('A volta dos que não foram', '27/05/2030', 'PI', '314', '1', '2')

INSERT INTO Albuns (NomeAlbum, DtLancamento, Localizacao, QtdMinutos, IdArtista, IdEstilo)
VALUES ('Poeira em alto mar', '01/01/2000', 'PA', '35', '3', '3')

--Alterar Dados
UPDATE Artistas
SET NomeArtista = 'Você'
WHERE IdArtista = 2;

--Deletar Dados
DELETE FROM Artistas
WHERE IdArtista = 2;

--Limpar todos os dados da tabela
TRUNCATE TABLE Albuns
TRUNCATE TABLE Estilos
TRUNCATE TABLE Artistas
TRUNCATE TABLE Albuns
