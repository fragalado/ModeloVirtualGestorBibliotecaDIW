using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Usuario
    {
        // Atributos

        [Key] // Indica que es el PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Hace que sea autoincrementable
        public long id_usuario { get; set; }
        public string dni_usuario { get; set; }
        public string? nombre_usuario { get; set; } // Se pone ? para indicar que puede ser NULL
        public string? apellidos_usuario { get; set; }
        public string? tlf_usuario { get; set; }
        public string? email_usuario { get; set; }
        public string clave_usuario { get; set; }
        public bool? estaBloqueado_usuario { get; set; }
        [Column(TypeName = "timestamp without time zone")] // Para hacer que sea timestamp without time zone
        public DateTime? fch_fin_bloqueo_usuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fch_alta_usuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fch_baja_usuario { get; set; }

        // FK

        [ForeignKey(name: "id_acceso")] // Para indicar a quien va a apuntar (PK de acceso)
        [Column(name: "id_acceso")] // Para indicar el nombre que se va a poner en la bd
        public long AccesoId { get; set; }
        public Acceso Acceso { get; set; }

        // Collection
        public ICollection<Prestamo> Prestamos { get; set; }
    }


    public class Acceso
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_acceso { get; set; }
        public string? codigo_acceso { get; set; }
        public string? descripcion_acceso { get; set; }

        // Collection
        public ICollection<Usuario> Usuarios { get; set; }
    }


    [Table(name: "libro")]
    public class Libro
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_libro { get; set; }
        public string? isbn_libro { get; set; }
        public string? titulo_libro { get; set; }
        public string? edicion_libro { get; set; }

        // FK

        [Column(name: "id_editorial")]
        public long EditorialId { get; set; }
        public Editorial Editorial { get; set; }
        [Column(name: "id_genero")]
        public long GeneroId { get; set; }
        public Genero Genero { get; set; }
        [Column(name: "id_coleccion")]
        public long ColeccionId { get; set; }
        public Coleccion Coleccion { get; set; }

        // Collection

        public ICollection<RelAutorLibro> RelAutorLibros { get; set; }
        public ICollection<RelPrestamoLibro> RelPrestamoLibros { get; set; }
    }

    [Table(name: "editorial")] // Otra forma de ponerle el nombre que queramos a la tabla en la bd
    public class Editorial
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_editorial { get; set; }
        public string? nombre_editorial { get; set; }

        // Collection
        public ICollection<Libro> Libros { get; set; }
    }


    [Table(name: "genero")]
    public class Genero
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_genero { get; set; }
        public string? nombre_genero { get; set; }
        public string? descripcion_genero { get; set; }

        // Collection
        public ICollection<Libro> Libros { get; set; }
    }


    [Table(name: "coleccion")]
    public class Coleccion
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_coleccion { get; set; }
        public string? nombre_coleccion { get; set; }

        // Collection
        public ICollection<Libro> Libros { get; set; }
    }


    [Table(name:"autor")]
    public class Autor
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_autor {  get; set; }
        public string? nombre_autor { get; set; }
        public string? apellidos_autor { get; set; }

        // Collection

        public ICollection<RelAutorLibro> RelAutorLibros { get; set; }
    }


    [Table(name:"estadoPrestamo")]
    public class EstadoPrestamo
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_estado_prestamo { get; set; }
        public string? codigo_estado_prestamo { get; set; }
        public string? descripcion_estado_prestamo { get; set; }

        // Collection

        public ICollection<Prestamo> Prestamos { get; set; }
    }

    [Table(name:"prestamo")]
    public class Prestamo
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_prestamo { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fch_inicio_prestamo { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fch_fin_prestamo { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fch_entrega_prestamo { get; set; }

        // FK

        [Column(name:"id_estado_prestamo")]
        public long EstadoPrestamoId { get; set; }
        public EstadoPrestamo EstadoPrestamo {  get; set; }

        [Column(name: "id_usuario")]
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Collection

        public ICollection<RelPrestamoLibro> RelPrestamoLibros {  get; set; }
    }

    [Table(name:"rel_autor_libro")]
    public class RelAutorLibro
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_rel_autores_libros { get; set; }

        // FK 

        [Column(name:"id_autor")]
        public long AutorId { get; set; }
        public Autor Autor { get; set; }

        [Column(name: "id_libro")]
        public long LibroId { get; set; }
        public Libro Libro { get; set; }
    }

    [Table(name:"rel_prestamo_libro")]
    public class RelPrestamoLibro
    {
        // Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_rel_prestamos_libros { get; set; }

        // FK

        [Column(name: "id_prestamo")]
        public long PrestamoId { get; set; }
        public Prestamo Prestamo{ get; set; }

        [Column(name: "id_libro")]
        public long LibroId { get; set; }
        public Libro Libro { get; set; }
    }


}
