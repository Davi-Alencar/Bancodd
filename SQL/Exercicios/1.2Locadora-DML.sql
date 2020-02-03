USE ex01

INSERT INTO Empresa (NomeEmpresa) VALUES ('Tal')

INSERT INTO Marcas (NomeMarca) VALUES ('GM'), ('Ford'), ('Fiat')

INSERT INTO Modelos (NomeModelo, IdMarca) VALUES ('Onix', 1), ('Fiesta', 2), ('Argo', 3)

INSERT INTO Veiculos (Placa, IdEmpresa, IdModelo) VALUES ('GM-100', 1, 1), ('FR-200', 1, 2), ('FT-300', 1, 3)

INSERT INTO Clientes (NomeCliente, Cpf) VALUES ('Agostinho','3455980284'), ('Fulano', '3214562642'), ('Ciclano', '4562249982')

INSERT INTO Alugueis (DataInicio, DataFim, IdVeiculo, IdCliente) VALUES ('17/01/2002','17/01/2004', 1, 1), ('20/08/2018', '19/10/2020', 2, 2), ('20/08/2018', '19/10/2020', 3, 3)

