using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source=DEV8\\SQLEXPRESS; initial catalog=Filmes_tarde; user Id=sa; pwd=sa@132";

        public List<FuncionariosDomain> Listar()
        {
            // Cria uma lista generos onde serão armazenados os dados
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelecionarTodos = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario from Funcionarios";

                // Abre a conexão com o banco de dados
                Conexao.Open();

                // Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader Leitor;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand Comando = new SqlCommand(querySelecionarTodos, Conexao))
                {
                    // Executa a query [{.}{.}]
                    Leitor = Comando.ExecuteReader();

                    // Enquanto houver registros para ler, o laço se repete
                    while (Leitor.Read())
                    {
                        // Cria um objeto genero do tipo GeneroDomain
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            // Atribui à propriedade IdGenero o valor da primeira coluna da tabela do banco
                            IdFuncionario = Convert.ToInt32(Leitor[0]), //0 = Primeira coluna de uma tabela//

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            NomeFuncionario = Leitor["NomeFuncionario"].ToString(),

                            SobrenomeFuncionario = Leitor["SobrenomeFuncionario"].ToString()
                        };

                        // Adiciona o genero criado à tabela generos
                        funcionarios.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de generos
            return funcionarios;
        }

        public FuncionariosDomain BuscarPorId(int id)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelecionarPorId = "SELECT IdFuncionario, NomeFuncionarios, SobrenomeFuncionarios FROM Funcionarios WHERE IdFuncionario = @ID";

                // Abre a conexão com o banco de dados
                Conexao.Open();

                // Declara o SqlDataReader fazer a leitura no banco de dados
                SqlDataReader Leitor;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query
                    rdr = cmd.ExecuteReader();

                    // Caso a o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Cria um objeto genero
                        GeneroDomain genero = new GeneroDomain
                        {
                            // Atribui à propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco
                            ,
                            Nome = rdr["Nome"].ToString()
                        };

                        // Retorna o genero com os dados obtidos
                        return genero;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }


    }
}
