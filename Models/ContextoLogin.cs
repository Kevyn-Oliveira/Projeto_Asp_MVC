using Microsoft.EntityFrameworkCore;

namespace ProjetoAspMvc.Models
{
    public class ContextoLogin : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
