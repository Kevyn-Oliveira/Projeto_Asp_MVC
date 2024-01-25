using Microsoft.EntityFrameworkCore;

namespace ProjetoAspMvc.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        
        public DbSet<Noticia> Noticia { get; set; }
    }
}
