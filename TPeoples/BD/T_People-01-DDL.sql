CREATE DATABASE T_Peoples;

USE T_Peoples;

CREATE TABLE Funcionarios(
	IdFuncionario			INT PRIMARY KEY IDENTITY,
	NomeFuncionario			VARCHAR (50) NOT NULL,
	SobrenomeFuncionario	VARCHAR (50) NOT NULL
);