using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Busca um estúdio através do ID
        /// </summary>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        void Cadastrar(TiposUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        void Atualizar(int id, TiposUsuario TipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um usuário existente
        /// </summary>
        void Deletar(int id);
    }
}
