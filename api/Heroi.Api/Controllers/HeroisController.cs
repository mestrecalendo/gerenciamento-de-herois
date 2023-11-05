
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
        public async Task<ActionResult> CadastroHeroi([FromBody] CreateHeroiDto heroi)
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
                await InsertSuperpoderes(novoHeroi, heroi);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetHeroiPorId), new { novoHeroi.Id }, novoHeroi);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task InsertSuperpoderes(Herois heroi, CreateHeroiDto heroiDto)
        {

            try
            {
                foreach (var superpoder in heroiDto.Superpoderes)
                {
                    var superpoderConsultada = await _context.Superpoderes.AsNoTracking().FirstAsync(p => p.Id == superpoder.SuperpoderId);

                    var HeroisSuperpoderes = new HeroisSuperpoderes
                    {
                        HeroiId = heroi.Id,
                        SuperpoderId = superpoderConsultada.Id
                    };

                    _context.HeroisSuperpoderes.Add(HeroisSuperpoderes);
                }
            }
            catch (Exception)
            {
                await _interfaceHeroi.Delete(heroi);
                throw;
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadHeroiDto>> GetHeroiPorId(int id)
        {
            var heroi = _context.Herois
                            .Include(eOne => eOne.Superpoderes).FirstOrDefault(p => p.Id == id); 
            if (heroi is null)
            {
                return NotFound();

            }
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
        public async Task<object> RemoveHeroi(int id)
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
