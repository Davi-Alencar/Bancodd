using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {

            return _funcionarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            FuncionariosDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Nenhum funcionário encontrado");
            }
            return Ok(funcionarioBuscado);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _funcionarioRepository.Deletar(id);

            return Ok("Funcionário deletado");
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionariosDomain funcionarioAtualizado)
        {
            FuncionariosDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionário não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut]
        public IActionResult PutIdCorpo(FuncionariosDomain funcionarioAtualizado)
        {
            FuncionariosDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.IdFuncionario);

            if (funcionarioBuscado != null)
            {
                try
                {
                    _funcionarioRepository.AtualizarIdCorpo(funcionarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

            }

            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionário não encontrado",
                        erro = true
                    }
                );
        }

        [HttpPost]
        public IActionResult Post(FuncionariosDomain novoFuncionario)
        {
            _funcionarioRepository.Cadastrar(novoFuncionario);

            return StatusCode(201);
        }
    }
}