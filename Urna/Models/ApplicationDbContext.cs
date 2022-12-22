using Microsoft.EntityFrameworkCore;

namespace Urna.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
                
        }

        public DbSet<RegistroCandidatos> RegistroCandidatos { get; set; }
    }
}
