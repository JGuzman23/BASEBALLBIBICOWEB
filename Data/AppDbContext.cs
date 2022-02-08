using BASEBALLBIBICOWEB.Models;
using Microsoft.EntityFrameworkCore;

namespace BASEBALLBIBICOWEB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions options) : base(options)
        {

        }


        public DbSet<Preguntas> Preguntas { get; set; }

        public DbSet<Respuestas> Prespuesta { get; set; }
    }
}
