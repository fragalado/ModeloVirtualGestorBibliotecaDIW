using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aseguramos el uso de Ids autoincrementales.
            modelBuilder.UseSerialColumns();

            // Forma para cambiarle el nombre a las tablas
            modelBuilder.Entity<Usuario>()
                .ToTable("usuarios");
            modelBuilder.Entity<Acceso>()
                .ToTable("accesos");

            // Hacemos dos pk en RelAutorLibro
            modelBuilder.Entity<RelAutorLibro>()
                .HasKey(r => new {r.AutorId, r.LibroId});
            // Tambien se puede: [PrimaryKey(nameof(PrestamoId), nameof(LibroId))] poniendolo encima de la clase
            // Lo mismo para RelPrestamoLibro
            modelBuilder.Entity<RelPrestamoLibro>()
                .HasKey(r => new { r.PrestamoId, r.LibroId });
        }

        // Los DbSet
        // Un DbSet es una clase que representa una colección de entidades de un tipo específico.
        // Se utiliza para realizar operaciones de consulta y modificación en la base de datos.
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