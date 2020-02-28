using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(UsuariosDomain usuario);

        List<UsuariosDomain> Listar();

        UsuariosDomain BuscarPorId(int id);

        void AtualizarIdUrl(int id, UsuariosDomain usuario);

        void AtualizarIdCorpo(UsuariosDomain usuario);

        void Deletar(int id);
    }
}
