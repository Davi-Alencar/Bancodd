﻿using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    /// <summary>
    /// Repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source - Nome do Servidor
        /// initial catalog - Nome do Banco de Dados
        /// integrated security=true - Faz a autenticação com o usuário do sistema
        /// user Id=sa; pwd=sa@132 - Faz a autenticação com um usuário específico, passando o logon e a senha
        /// </summary>
        private string StringConexao = "Data Source=DEV8\\SQLEXPRESS; initial catalog=Filmes_tarde; user Id=sa; pwd=sa@132;";

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        public List<GeneroDomain> Listar()
        {
            // Cria uma lista generos onde serão armazenados os dados
            List<GeneroDomain> generos = new List<GeneroDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = "SELECT IdGenero, Nome from Generos";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (rdr.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdGenero = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            Nome = rdr["Nome"].ToString()
                        };

                        // Adiciona o genero criado à tabela generos
                        generos.Add(genero);
                    }
                }
            }

            // Retorna a lista de generos
            return generos;

        }
         
        public void Cadastrar(GeneroDomain genero)
        {

            using (SqlConnection Coneccao = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string queryInsert = $"INSERT INTO Generos (Nome) VALUES ('{genero.Nome}')"; //('" + genero.Nome + "');concatenação (comandos)//
                //string queryInsert = $"INSERT INTO Generos (Nome) VALUES (@Nome)";//

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand Comando = new SqlCommand(queryInsert, Coneccao))
                {
                    //Comando.Paremeters("@Nome",genero.Nome)//

                    // Executa a query(só mandando, sem receber)
                    Comando.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain Atualizar(GeneroDomain genero)
        {
            GeneroDomain generoDomain = new GeneroDomain();

            using (SqlConnection Coneccao = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string query = $"UPTADE TABLE Generos (Nome) VALUES ('{generoDomain.Nome}')";

                // Abre a conexão com o banco de dados
                Coneccao.Open();

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand Comando = new SqlCommand(query, Coneccao))
                {
                    // Executa a query
                    Comando.ExecuteNonQuery();
                }
            }
            return generoDomain;
        }

        void IGeneroRepository.Cadastrar(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }
    }
}
