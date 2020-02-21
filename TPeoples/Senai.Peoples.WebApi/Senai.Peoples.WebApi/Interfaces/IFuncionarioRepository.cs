using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionariosDomain> Listar();

        FuncionariosDomain BuscarPorId(int id);

        void Deletar(int id);

        void AtualizarIdUrl(int id, FuncionariosDomain funcionario);

        void AtualizarIdCorpo(FuncionariosDomain funcionario);

        void Cadastrar(FuncionariosDomain funcionario);

    }
}
