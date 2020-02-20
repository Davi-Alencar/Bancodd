using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source=DEV8\\SQLEXPRESS; initial catalog=Filmes_tarde; user Id=sa; pwd=sa@132";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string querySelecionarTudo = "SELECT * FROM Filmes";

                Conexao.Open();

                SqlDataReader Leitor;

                using (SqlCommand Comando = new SqlCommand(querySelecionarTudo, Conexao))
                {
                    Leitor = Comando.ExecuteReader();

                    while(Leitor.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(Leitor["IdFilme"]),

                            Titulo = Leitor["Titulo"].ToString()
                        };

                        filmes.Add(filme);
                    }

                }
            }

        }
    



        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string querySelecionarPorId = "SELECT IdFilme, Titulo FROM Filmes WHERE IdFilme = @ID";

                Conexao.Open();

                SqlDataReader Leitor;

                using (SqlCommand Comando = new SqlCommand(querySelecionarPorId, Conexao))
                {
                    Comando.Parameters.AddWithValue("@ID", id);

                    Leitor = Comando.ExecuteReader();

                    if(Leitor.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(Leitor["IdFilme"]),

                            Titulo = Leitor["Titulo"].ToString(),
                            
                            IdGenero = Convert.ToInt32(Leitor["IdGenero"])
                        };
                        return filme;
                    }
                    return null;

                }   
            }
        }

        public void Cadastrar (FilmeDomain filme)
        {
            using (SqlConnection Conexao = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Fimes(Titulo) VALUES(@Titulo)";

                SqlCommand Comando = new SqlCommand(queryInsert, Conexao);

                Comando.Parameters.AddWithValue("@Titulo", filme.Titulo);

                Conexao.Open();

                Comando.ExecuteNonQuery();


            }
        }
    }
}
