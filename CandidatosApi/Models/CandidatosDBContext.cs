using Microsoft.EntityFrameworkCore;

namespace CandidatosApi.Models
{
    public class CandidatosDBContext: DbContext
    {
        public CandidatosDBContext(DbContextOptions<CandidatosDBContext> options) : base(options)
        {

        }

        public DbSet<RegistroCandidato> RegistroCandidatos { get; set; }
    }
}
