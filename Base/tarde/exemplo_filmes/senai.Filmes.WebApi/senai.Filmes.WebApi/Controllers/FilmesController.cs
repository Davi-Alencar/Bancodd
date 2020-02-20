using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            FilmeDomain filmeBuscado  = _filmeRepository.BuscarPorId(id);

            if(filmeBuscado == null)
            {
                return NotFound("Nenhum filme encontrado!");
            }

            return Ok(filmeBuscado);
        }
    }
}
