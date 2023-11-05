using Domain.Interfaces;
using Domain.Models;
using Heroi.Api.DTOs;
using Infrastructure.Configuracao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Heroi.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IHeroi _interfaceHeroi;
        private ContextDb _context;
        public HeroisController(IHeroi InterfaceHeroi, ContextDb ContextDb)
        {
            _interfaceHeroi = InterfaceHeroi;
            _context = ContextDb;
        }

        [HttpGet]
        public async Task<object> ListaHerois()
        {
            return await _interfaceHeroi.List();
        }

        [HttpPost]
        public async Task<IActionResult> CadastroHeroi([FromBody] CreateHeroiDto heroi)
        {
            Herois novoHeroi = new()
            {
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
            };

            try
            {
                await _interfaceHeroi.Add(novoHeroi);
                return CreatedAtAction("CadastroHeroi", new { novoHeroi.Id }, novoHeroi);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<object> GetUsuarioPorId(int id)
        {
            var heroi = await _interfaceHeroi.GetById(id);
            if (heroi == null) return NotFound();

            return Ok(heroi);
        }

        [HttpPut("{id}")]
        public async Task<object> AtualizaHeroi(int id, [FromBody] UpdateHeroiDto novoHeroi)
        {
            var heroi = await _context.Herois.FirstOrDefaultAsync(x => x.Id == id);
            if (heroi == null) return NotFound();

            try
            {
                heroi.Nome = novoHeroi.Nome;
                heroi.NomeHeroi = novoHeroi.NomeHeroi;
                heroi.DataNascimento = novoHeroi.DataNascimento;
                heroi.Altura = novoHeroi.Altura;
                heroi.Peso = novoHeroi.Peso;

                await _interfaceHeroi.Update(heroi);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<object> RemoveUsuario(int id)
        {
            var heroi = await _context.Herois.FirstOrDefaultAsync(x => x.Id == id);
            if (heroi == null) return NotFound();

            try
            {
                await _interfaceHeroi.Delete(heroi);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
