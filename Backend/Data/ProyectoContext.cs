using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext (DbContextOptions<ProyectoContext> options) : base (options)
        {

        }

        public DbSet<Directorio> Directorio { get; set; }
        public DbSet<Aviso> Avisos { get; set; }

    }
}