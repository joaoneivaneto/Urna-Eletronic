
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
    public class VotosController : ControllerBase
    {
        private readonly CandidatosDBContext _context;

        public VotosController(CandidatosDBContext context)
        {
            _context = context;
        }

        // GET: api/Votos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voto>>> Getvotos()
        {
            return await _context.votos.ToListAsync();
        }

        // GET: api/Votos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Voto>>> GetVoto(Guid id)
        {
            var voto = await _context.votos
                  .Where(x => x.IdCandidato == id)
                  .ToListAsync();

            if (voto == null)
            {
                return StatusCode(404, "esse voto não existe");
            }

            return voto;
        }

        [HttpPost]
        public async Task<ActionResult<Voto>> PostVoto(Votodto request)
        {
            var newVoto = new Voto
            {
                id = request.Id,
                IdCandidato = request.Id_Candidato,
                DataVoto = request.Data_Voto

            };
            
            if(VotoExists(request.Id_Candidato) && VotoExists2(request.Data_Voto))
            {
                return StatusCode(404, "voto ja existe");
            }

            _context.votos.Add(newVoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoto", new { id = request.Id }, request);
        }

       
        private bool VotoExists(Guid id)
        {
            return _context.votos.Any(e => e.IdCandidato == id);
        }

        private bool VotoExists2(DateTime data)
        {
            return _context.votos.Any(e => e.DataVoto == data);
        }


    }
}
