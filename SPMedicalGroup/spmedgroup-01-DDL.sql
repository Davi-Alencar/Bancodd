CREATE DATABASE SPMedGroup

USE SPMedGroup

GO
CREATE TABLE Clinicas (
	IdClinica				INT PRIMARY KEY IDENTITY,
	NomeFantasia			VARCHAR (200) NOT NULL,
	Endereco				VARCHAR (200) NOT NULL,
	HorarioInicio			VARCHAR (200) NOT NULL,
	HorarioFim				VARCHAR (200) NOT NULL,
	CNPJ					VARCHAR (20) NOT NULL,
	RazaoSocial				VARCHAR (200) NOT NULL
);



CREATE TABLE TipoUsuarios (
	IdTipoUsuario		INT PRIMARY KEY IDENTITY,
	NomeTipoUsuario		VARCHAR (200) NOT NULL
);

CREATE TABLE Usuarios (
	IdUsuario			INT PRIMARY KEY IDENTITY,
	Email				VARCHAR (200) NOT NULL,
	Senha				VARCHAR (200) NOT NULL,
	IdTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuarios (IdTipoUsuario)
	
);

CREATE TABLE Especialidades (
	IdEspecialidade		INT PRIMARY KEY IDENTITY,
	NomeEspecialidade	VARCHAR (200) NOT NULL
);

CREATE TABLE Medicos (
	IdMedico			INT PRIMARY KEY IDENTITY,
	CRM					VARCHAR (20) NOT NULL,
	NomeMedico			VARCHAR (200) NOT NULL,
	DataNascimento		DATE NOT NULL,
	RG					VARCHAR (20) NOT NULL,
	CPF					VARCHAR (20) NOT NULL,
	IdClinica			INT FOREIGN KEY REFERENCES Clinicas (IdClinica),
	IdUsuario			INT FOREIGN KEY REFERENCES Usuarios (IdUsuario),
	IdEspecialidade		INT FOREIGN KEY REFERENCES Especialidades (IdEspecialidade)
);

CREATE TABLE Consultas (
	IdConsulta			INT PRIMARY KEY IDENTITY,
	DataConsulta		DATETIME NOT NULL,
	Situação			VARCHAR (200) NOT NULL,
	IdMedico			INT FOREIGN KEY REFERENCES Medicos (IdMedico)
);


CREATE TABLE Prontuarios (
	IdProntuario		INT PRIMARY KEY IDENTITY,
	NomePaciente		VARCHAR (200) NOT NULL,
	DataNascimento		DATE NOT NULL,
	RG					VARCHAR (20) NOT NULL,
	CPF					VARCHAR (20) NOT NULL,
	IdClinica			INT FOREIGN KEY REFERENCES Clinicas (IdClinica),
	IdUsuario			INT FOREIGN KEY REFERENCES Usuarios (IdUsuario),
	IdConsulta			INT FOREIGN KEY REFERENCES Consultas (IdConsulta)
);


CREATE TABLE Enderecos (
	IdEndereco		INT PRIMARY KEY IDENTITY,
	Estado			VARCHAR (200),
	Cidade 			VARCHAR (200),
	Municipio		VARCHAR (200),
	Bairro			VARCHAR (200),
	NomeRua			VARCHAR (200),
	Telefone		VARCHAR (200),
	IdUsuario		INT FOREIGN KEY REFERENCES Usuarios (IdUsuario),
	IdClinica		INT FOREIGN KEY REFERENCES Clinicas (IdClinica)
);