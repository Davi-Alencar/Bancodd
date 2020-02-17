CREATE DATABASE Optus_Tarde;

USE Optus_Tarde

CREATE TABLE Artistas (
	IdArtista		INT PRIMARY KEY IDENTITY,
	NomeArtista		VARCHAR(200) NOT NULL
	DtNasc			DATE,
	Nacionalidade	VARCHAR(200),
	QtdMinTotais	BIGINT

);

CREATE TABLE Albuns (
	IdAlbum			INT PRIMARY KEY IDENTITY,
	NomeAlbum		VARCHAR(200) NOT NULL UNIQUE,
	DtLancamento	DATE,
	Localizacao		VARCHAR(200),
	QtdViews		BIGINT
	IdArtista		INT FOREIGN KEY REFERENCES Artistas (IdArtista)

);

CREATE TABLE Usuarios (
	IdUsuario		INT PRIMARY KEY IDENTITY,
	NomeUsuario		VARCHAR(200),
	DtNasc			VARCHAR(200),
	Nacionalidade	VARCHAR(200),
	IdTipoUsuario	INT FOREIGN KEY REFERENCES TipoUsuarios (IdTipoUsuario)

);

CREATE TABLE TipoUsuarios (
	IdTipoUsuario		INT PRIMARY KEY IDENTITY,
	NomeTipoUsuario		VARCHAR(200),
	DtNasc				VARCHAR(200),
	Nacionalidade		VARCHAR(200),

);

SELECT * FROM Artistas;
SELECT * FROM Albuns;
SELECT * FROM Usuarios;
SELECT * FROM TipoUsuarios;

INSERT INTO	Artistas ('NomeArtista', 'DtNasc', 'Nacionalidade', 'QtdMinTotais')
VALUES ('Fulano', '21/12/2012', 'UK', '200')

INSERT INTO	Artistas ('NomeArtista', 'DtNasc', 'Nacionalidade', 'QtdMinTotais')
VALUES ('Ciclano', '02/10/2001', 'BR', '45')

INSERT INTO Albuns ('NomeAlbum', 'DtLancamento', 'Localizacao', 'QtdViews', 'IdArtista')
VALUES ('A volta dos que não foram', '30/12/2018', 'UK', '3.050,315', '1')

INSERT INTO Albuns ('NomeAlbum', 'DtLancamento', 'Localizacao', 'QtdViews', 'IdArtista')
VALUES ('Poeira em alto mara', '31/01/2009', 'BR', '1.010,115', '2')