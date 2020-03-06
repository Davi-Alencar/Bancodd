using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    [Authorize]
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista os tipos de usuarios
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo usuario
        /// </summary>
        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipoUsuario)
        {
            _tiposUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um tipo usuario
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario TipoUsuarioAtualizado)
        {
            TiposUsuario tipoUsuarioBuscado = _tiposUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                try
                {
                    _tiposUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);

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
                        mensagem = "Tipo usuario não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um tipo usuario
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TiposUsuario tipoUsuarioBuscado = _tiposUsuarioRepository.BuscarPorId(id);

            if (tipoUsuarioBuscado != null)
            {
                _tiposUsuarioRepository.Deletar(id);

                return Ok($"O tipo usuario {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum tipo usuario encontrado para o identificador informado");
        }
    }
}