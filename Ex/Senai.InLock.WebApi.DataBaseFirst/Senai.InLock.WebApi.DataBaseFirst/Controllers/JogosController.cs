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
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista um jogo
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.Listar());
        }

        /// <summary>
        /// Busca um jogo por id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogosRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            _jogosRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um jogo
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogos jogoAtualizado)
        {
            Jogos jogoBuscado = _jogosRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogosRepository.Atualizar(id, jogoAtualizado);

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
                        mensagem = "Jogo não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Jogos jogoBuscado = _jogosRepository.BuscarPorId(id);

            if (jogoBuscado != null)
            {
                _jogosRepository.Deletar(id);

                return Ok($"O jogo {id} foi deletado com sucesso!");
            }

            return NotFound("Nenhum jogo encontrado para o identificador informado");
        }

    }
}