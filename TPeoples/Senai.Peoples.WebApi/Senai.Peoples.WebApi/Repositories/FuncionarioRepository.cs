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
        private string stringConexao = "Data Source=DEV8\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string querySelecionarTodos = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios";

                Conexao.Open();

                SqlDataReader Leitor;

                using (SqlCommand Comando = new SqlCommand(querySelecionarTodos, Conexao))
                {
                    Leitor = Comando.ExecuteReader();

                    while (Leitor.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain()
                        {
                            IdFuncionario = Convert.ToInt32(Leitor[0]),
            
                            NomeFuncionario = Leitor["NomeFuncionario"].ToString(),

                            SobrenomeFuncionario = Leitor["SobrenomeFuncionario"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

        public FuncionariosDomain BuscarPorId(int id)
        {
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string querySelecionarPorId = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario FROM Funcionarios WHERE IdFuncionario = @ID";

                Conexao.Open();

                SqlDataReader Leitor;

                using (SqlCommand Comando = new SqlCommand(querySelecionarPorId, Conexao))
                {
                    Comando.Parameters.AddWithValue("@ID", id);

                    Leitor = Comando.ExecuteReader();

                    if (Leitor.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain()
                        {       
                            IdFuncionario = Convert.ToInt32(Leitor[0]),

                            NomeFuncionario = Leitor["NomeFuncionario"].ToString(),

                            SobrenomeFuncionario = Leitor["SobrenomeFuncionario"].ToString()
                        };

                        return funcionario;
                    }

                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";

                using (SqlCommand Comando = new SqlCommand(queryDeletar, Conexao))
                {
                    Comando.Parameters.AddWithValue("@ID", id);

                    Conexao.Open();

                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FuncionariosDomain funcionario)
        {
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string queryAtualizar = "UPDATE Funcionarios SET NomeFuncionario = @NomeFuncionario, SobrenomeFuncionario = @SobrenomeFuncionario WHERE IdFuncionario = @ID";

                using (SqlCommand Comando = new SqlCommand(queryAtualizar, Conexao))
                {
                    Comando.Parameters.AddWithValue("@ID", id);
                    Comando.Parameters.AddWithValue("@NomeFuncionario", funcionario.NomeFuncionario);
                    Comando.Parameters.AddWithValue("@SobrenomeFuncionario", funcionario.SobrenomeFuncionario);

                    Conexao.Open();

                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdCorpo(FuncionariosDomain funcionario)
        {
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string queryAtualizar = "UPDATE Funcionarios SET NomeFuncionario = @NomeFuncionario, SobrenomeFuncionario = @SobrenomeFuncionario WHERE IdFuncionario = @ID";

                using (SqlCommand Comando = new SqlCommand(queryAtualizar, Conexao))
                {
                    Comando.Parameters.AddWithValue("@ID", funcionario.IdFuncionario);
                    Comando.Parameters.AddWithValue("@NomeFuncionario", funcionario.NomeFuncionario);
                    Comando.Parameters.AddWithValue("@SobrenomeFuncionario", funcionario.SobrenomeFuncionario);

                    Conexao.Open();

                    Comando.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(FuncionariosDomain funcionario)
        {
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string queryInserir = "INSERT INTO Funcionarios(NomeFuncionario, SobrenomeFuncionario) VALUES (@NomeFuncionario, @SobrenomeFuncionario)";
                
                SqlCommand Comando = new SqlCommand(queryInserir, Conexao);

                Comando.Parameters.AddWithValue("@NomeFuncionario", funcionario.NomeFuncionario);
                Comando.Parameters.AddWithValue("@SobrenomeFuncionario", funcionario.SobrenomeFuncionario);

                Conexao.Open();

                Comando.ExecuteNonQuery();
            }
        }

    }
}
