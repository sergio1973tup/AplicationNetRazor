using AplicationNetRazor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AplicationNetRazor.Datos
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base (options)
        {

        }
        //Modelos
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Profesor> Profesor { get; set; }

    }
}
