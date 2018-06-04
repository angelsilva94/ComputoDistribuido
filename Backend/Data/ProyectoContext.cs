using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext(DbContextOptions<ProyectoContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=35.231.105.59;port=3306;database=UAADb;user=root;password=angel.silva");
            // optionsBuilder.UseMySQL("server=localhost;database=UAADb;user=root;password=angel.silva");
            
        }

        public DbSet<Directorio> Directorio { get; set; }
        public DbSet<Aviso> Avisos { get; set; }

    }
}