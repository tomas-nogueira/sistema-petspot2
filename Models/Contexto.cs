using Microsoft.EntityFrameworkCore;

namespace TrackIt.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Animals> Animals { get; set; }
        public DbSet<Observacoes> Observacoes { get; set; }
    }
}

