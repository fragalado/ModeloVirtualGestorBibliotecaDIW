using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        // Aseguramos el uso de Ids autoincrementales.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            // Forma para cambiarle el nombre a las tablas
            modelBuilder.Entity<Usuario>()
                .ToTable("usuario");
            modelBuilder.Entity<Acceso>()
                .ToTable("acceso");
        }

        // Los DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Coleccion> Colecciones { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<EstadoPrestamo> EstadoPrestamos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<RelAutorLibro> RelAutorLibros { get; set; }
        public DbSet<RelPrestamoLibro> RelPrestamoLibros { get; set; }

    }
}