
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CandidatosApi.Models;
using CandidatosApi.Dto;

namespace CandidatosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroCandidatosController : ControllerBase
    {
        private readonly CandidatosDBContext _context;

        public RegistroCandidatosController(CandidatosDBContext context)
        {
            _context = context;
        }

        // GET: api/RegistroCandidatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroCandidato>>> GetRegistroCandidatos()
        {
            return await _context.RegistroCandidatos.ToListAsync();
        }

        // GET: api/RegistroCandidatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroCandidato>> GetRegistroCandidato(Guid id)
        {
            var registroCandidato = await _context.RegistroCandidatos.FindAsync(id);

            if (registroCandidato == null)
            {
                return NotFound();
            }

            return registroCandidato;
        }

        // PUT: api/RegistroCandidatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroCandidato(Guid id, CreateRegistroCandidatosDto request)
        {
            var UpdateRegistro = new RegistroCandidato
            {

                Id = id,
                NomeCompleto = request.Nome_Candidato,
                NomeVice = request.Nome_Vice,
                DataRegistro = request.Data_Registro,
                Legenda = request.Legenda
            };
          

            _context.Entry(UpdateRegistro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroCandidatoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RegistroCandidatos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroCandidato>> PostRegistroCandidato(CreateRegistroCandidatosDto request)
        {

            var newRegistro = new RegistroCandidato
            {
                Id = request.Id_Candidato,
                NomeCompleto = request.Nome_Candidato,
                NomeVice = request.Nome_Vice,
                DataRegistro = request.Data_Registro,
                Legenda = request.Legenda

            };
            _context.RegistroCandidatos.Add(newRegistro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroCandidato", new { id = request.Id_Candidato }, request);
        }

        // DELETE: api/RegistroCandidatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroCandidato(Guid id)
        {
            var registroCandidato = await _context.RegistroCandidatos.FindAsync(id);
            if (registroCandidato == null)
            {
                return NotFound();
            }

            _context.RegistroCandidatos.Remove(registroCandidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroCandidatoExists(Guid id)
        {
            return _context.RegistroCandidatos.Any(e => e.Id == id);
        }
    }
}
