using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        List<Jogos> Listar();

        /// <summary>
        /// Busca um estúdio através do ID
        /// </summary>
        Jogos BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        void Cadastrar(Jogos novoJogo);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        void Atualizar(int id, Jogos JogoAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        void Deletar(int id);

        /// <summary>
        /// Lista todos estudios e seus jogos
        /// </summary>
        List<Jogos> ListarJogosPorEstudio();
    }
}
