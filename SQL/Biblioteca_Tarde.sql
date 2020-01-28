 --COMENTARIO
 --CRIAR BANCO DE DADOS
CREATE DATABASE Biblioteca_Tarde;

 -- Apontar para o banco que ira usar
USE Biblioteca_Tarde

 --CRIAR TABELAS(Entidade)
CREATE TABLE Autores (
	IdAutor		INT PRIMARY KEY IDENTITY,
	NomeAutor	VARCHAR(200) NOT NULL
);

CREATE TABLE Generos (
	IdGenero	INT PRIMARY KEY IDENTITY,
	NomeGenero	VARCHAR(200) NOT NULL
);

CREATE TABLE Livros (
	IdLivro		INT PRIMARY KEY IDENTITY,
	Titulo		VARCHAR(255) NOT NULL,
	IdAutor		INT FOREIGN KEY REFERENCES Autores (IdAutor),
	IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

SELECT * FROM Generos;
SELECT * FROM Autores;
SELECT * FROM Livros;

-- ALTERAR ADICIONAR UMA NOVA COLUNA
ALTER TABLE Generos
ADD Descricao VARCHAR (255);

-- ALTERAR TIPO DE DADO
-- Comandos na mesma linha funfa
ALTER TABLE Generos ALTER COLUMN Descricao CHAR (100);

-- ALTERAR EXCLUIR COLUNA
ALTER TABLE Generos
DROP COLUMN Descricao;

-- Excluir
	DROP TABLE Generos;
	DROP TABLE Autores;
	DROP TABLE Livros;

-- Excluir banco de dados
DROP DATABASE Biblioteca_Tarde;


