CREATE DATABASE T_Peoples;

USE T_Peoples;

CREATE TABLE Funcionarios(
	IdFuncionario			INT PRIMARY KEY IDENTITY,
	NomeFuncionario			VARCHAR (50) NOT NULL,
	SobrenomeFuncionario	VARCHAR (50) NOT NULL
);

CREATE TABLE Usuarios(
	IdUsuario				INT PRIMARY KEY IDENTITY,
	Email					VARCHAR (255) NOT NULL UNIQUE,
	Senha					VARCHAR (255) NOT NULL,
	TipoUsuario				INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

CREATE TABLE TipoUsuario(
	IdTipoUsuario			INT PRIMARY KEY IDENTITY,
	NomeTipoUsuario			VARCHAR (255) NOT NULL
);
