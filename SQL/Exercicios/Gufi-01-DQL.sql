USE Gufi_Tarde

--1
SELECT UsuarioJoin.NomeUsuario, UsuarioJoin.Email, TipoUsuarioJoin.TituloTipoUsuario, UsuarioJoin.DataNascimento, UsuarioJoin.Genero FROM Usuario 
AS UsuarioJoin
INNER JOIN TipoUsuario AS TipoUsuarioJoin 
ON TipoUsuarioJoin.IdTipoUsuario = UsuarioJoin.IdTipoUsuario

--2
SELECT CNPJ, NomeFantasia, Endereco 
FROM Instituicao

--3
SELECT TituloTipoEvento FROM TipoEvento 

--4
SELECT EventoJoin.NomeEvento, TipoEventoJoin.TituloTipoEvento, EventoJoin.DataEvento, CASE WHEN EventoJoin.AcessoLivre = 1 THEN 'Público' ELSE 'Privado' END AS TipoAcesso, EventoJoin.Descricao,
InstituicaoJoin.CNPJ, InstituicaoJoin.NomeFantasia, InstituicaoJoin.Endereco FROM Evento AS EventoJoin

INNER JOIN TipoEvento AS TipoEventoJoin
ON EventoJoin.IdTipoEvento = TipoEventoJoin.IdTipoEvento

INNER JOIN Instituicao AS InstituicaoJoin
ON EventoJoin.IdInstituicao = InstituicaoJoin.IdInstituicao


--5
SELECT EventoJoin.NomeEvento, TipoEventoJoin.TituloTipoEvento, EventoJoin.DataEvento, CASE WHEN EventoJoin.AcessoLivre = 1 THEN 'Público' ELSE 'Privado' END AS TipoAcesso, EventoJoin.Descricao,
InstituicaoJoin.CNPJ, InstituicaoJoin.NomeFantasia, InstituicaoJoin.Endereco FROM Evento AS EventoJoin

INNER JOIN TipoEvento AS TipoEventoJoin
ON EventoJoin.IdTipoEvento = TipoEventoJoin.IdTipoEvento

INNER JOIN Instituicao AS InstituicaoJoin
ON EventoJoin.IdInstituicao = InstituicaoJoin.IdInstituicao

WHERE AcessoLivre = 1

--6
SELECT EventoJoin.NomeEvento, TipoEventoJoin.TituloTipoEvento, EventoJoin.DataEvento, CASE WHEN EventoJoin.AcessoLivre = 1 THEN 'Público' ELSE 'Privado' END AS TipoAcesso, EventoJoin.Descricao,
InstituicaoJoin.CNPJ, InstituicaoJoin.NomeFantasia, InstituicaoJoin.Endereco, UsuarioJoin.NomeUsuario, UsuarioJoin.Email, UsuarioJoin.Genero, UsuarioJoin.DataNascimento,
CASE WHEN UsuarioJoin.IdTipoUsuario = 1 THEN 'Admin' ELSE 'Comum' END AS TipoUsuario FROM Presenca 

INNER JOIN Evento AS EventoJoin
ON Presenca.IdEvento = EventoJoin.IdEvento

INNER JOIN TipoEvento AS TipoEventoJoin
ON EventoJoin.IdTipoEvento = TipoEventoJoin.IdTipoEvento

INNER JOIN Instituicao AS InstituicaoJoin
ON EventoJoin.IdInstituicao = InstituicaoJoin.IdInstituicao

INNER JOIN Usuario AS UsuarioJoin
ON Presenca.IdUsuario = UsuarioJoin.IdUsuario

WHERE UsuarioJoin.IdUsuario = 2







