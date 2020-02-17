CREATE DATABASE LivroEx5;

USE LivroEx5

CREATE TABLE Generos(
	IdGenero		INT PRIMARY KEY IDENTITY,
	NomeGenero		VARCHAR(200) NOT NULL
	QtdLeitores 	BIGINT,
	QtdAutores		BIGINT,
	QtdLivros		BIGINT

);

CREATE TABLE Autores (
	IdAutor			INT PRIMARY KEY IDENTITY,
	NomeAutor		VARCHAR(200) NOT NULL UNIQUE,
	DtNascimento	DATE,
	Nacionalidade	VARCHAR(200),
	QtdViews		BIGINT
	

);

CREATE TABLE Livros (
	IdLivro 		INT PRIMARY KEY IDENTITY,
	NomeLivro		VARCHAR(200),
	DtLancamento	DATE,
	Localizacao 	VARCHAR(200),
	IdAutor			INT FOREIGN KEY REFERENCES Autores (IdAutor),
	IdGenero		INT FOREIGN KEY REFERENCES Generos (IdGenero)

);


SELECT * FROM Autores;
SELECT * FROM Generos;
SELECT * FROM Livros;

INSERT INTO	Artistas ('NomeArtista', 'DtNasc', 'Nacionalidade', 'QtdMinTotais')
VALUES ('Fulano', '21/12/2012', 'UK', '200')

INSERT INTO	Artistas ('NomeArtista', 'DtNasc', 'Nacionalidade', 'QtdMinTotais')
VALUES ('Ciclano', '02/10/2001', 'BR', '45')

INSERT INTO Albuns ('NomeAlbum', 'DtLancamento', 'Localizacao', 'QtdViews', 'IdArtista')
VALUES ('A volta dos que não foram', '30/12/2018', 'UK', '3.050,315', '1')

INSERT INTO Albuns ('NomeAlbum', 'DtLancamento', 'Localizacao', 'QtdViews', 'IdArtista')
VALUES ('Poeira em alto mara', '31/01/2009', 'BR', '1.010,115', '2')