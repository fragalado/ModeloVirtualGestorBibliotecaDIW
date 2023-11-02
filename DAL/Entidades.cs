using Microsoft.EntityFrameworkCore;
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

        // Constructor

        public Usuario(string dni_usuario, string? nombre_usuario, string? apellidos_usuario, string? tlf_usuario, string? email_usuario, string clave_usuario, bool? estaBloqueado_usuario, DateTime? fch_fin_bloqueo_usuario, DateTime? fch_alta_usuario, DateTime? fch_baja_usuario, long accesoId)
        {
            this.dni_usuario = dni_usuario;
            this.nombre_usuario = nombre_usuario;
            this.apellidos_usuario = apellidos_usuario;
            this.tlf_usuario = tlf_usuario;
            this.email_usuario = email_usuario;
            this.clave_usuario = clave_usuario;
            this.estaBloqueado_usuario = estaBloqueado_usuario;
            this.fch_fin_bloqueo_usuario = fch_fin_bloqueo_usuario;
            this.fch_alta_usuario = fch_alta_usuario;
            this.fch_baja_usuario = fch_baja_usuario;
            AccesoId = accesoId;
        }

        // toString

        
        public void ToString()
        {
            Console.WriteLine("Usuario [Dni:{0}, Nombre:{1}, Apellidos:{2}, Telefono:{3}, Email:{4}, Clave:{5}, EstaBloqueado:{6}, Fecha Fin Bloqueo:{7}, Fecha Alta Usuario: {8}, Fecha Baja Usuario: {9}]", dni_usuario
                                                                                                                                                                                                            , nombre_usuario
                                                                                                                                                                                                            , apellidos_usuario
                                                                                                                                                                                                            , tlf_usuario
                                                                                                                                                                                                            , email_usuario
                                                                                                                                                                                                            , clave_usuario
                                                                                                                                                                                                            , estaBloqueado_usuario
                                                                                                                                                                                                            , fch_fin_bloqueo_usuario
                                                                                                                                                                                                            , fch_alta_usuario
                                                                                                                                                                                                            , fch_baja_usuario);
        }
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

        // Constructor

        public Acceso(string codigo_acceso, string? descripcion_acceso)
        {
            this.codigo_acceso = codigo_acceso;
            this.descripcion_acceso = descripcion_acceso;
        }
    }


    [Table(name: "libros")]
    public class Libro
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_libro { get; set; }
        public string? isbn_libro { get; set; }
        public string? titulo_libro { get; set; }
        public string? edicion_libro { get; set; }
        public int? cantidad_libro { get; set; }

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

        // Constructor

        public Libro(string? isbn_libro, string? titulo_libro, string? edicion_libro, int? cantidad_libro, long editorialId, long generoId, long coleccionId)
        {
            this.isbn_libro = isbn_libro;
            this.titulo_libro = titulo_libro;
            this.edicion_libro = edicion_libro;
            this.cantidad_libro = cantidad_libro;
            EditorialId = editorialId;
            GeneroId = generoId;
            ColeccionId = coleccionId;
        }
    }

    [Table(name: "editoriales")] // Otra forma de ponerle el nombre que queramos a la tabla en la bd
    public class Editorial
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_editorial { get; set; }
        public string? nombre_editorial { get; set; }

        // Collection
        public ICollection<Libro> Libros { get; set; }

        // Constructor

        public Editorial(string? nombre_editorial)
        {
            this.nombre_editorial = nombre_editorial;
        }
    }


    [Table(name: "generos")]
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

        // Constructor

        public Genero(string? nombre_genero, string? descripcion_genero)
        {
            this.nombre_genero = nombre_genero;
            this.descripcion_genero = descripcion_genero;
        }
    }


    [Table(name: "colecciones")]
    public class Coleccion
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_coleccion { get; set; }
        public string? nombre_coleccion { get; set; }

        // Collection
        public ICollection<Libro> Libros { get; set; }

        // Constructor

        public Coleccion(string? nombre_coleccion)
        {
            this.nombre_coleccion = nombre_coleccion;
        }
    }


    [Table(name:"autores")]
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

        // Constructor

        public Autor(string? nombre_autor, string? apellidos_autor)
        {
            this.nombre_autor = nombre_autor;
            this.apellidos_autor = apellidos_autor;
        }
    }


    [Table(name:"estados_prestamos")]
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

        // Constructor

        public EstadoPrestamo(string? codigo_estado_prestamo, string? descripcion_estado_prestamo)
        {
            this.codigo_estado_prestamo = codigo_estado_prestamo;
            this.descripcion_estado_prestamo = descripcion_estado_prestamo;
        }
    }

    [Table(name:"prestamos")]
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

        // Constructor

        public Prestamo(DateTime? fch_inicio_prestamo, DateTime? fch_fin_prestamo, DateTime? fch_entrega_prestamo, long estadoPrestamoId, long usuarioId)
        {
            this.fch_inicio_prestamo = fch_inicio_prestamo;
            this.fch_fin_prestamo = fch_fin_prestamo;
            this.fch_entrega_prestamo = fch_entrega_prestamo;
            EstadoPrestamoId = estadoPrestamoId;
            UsuarioId = usuarioId;
        }
    }

    [Table(name:"rel_autores_libros")]
    public class RelAutorLibro
    {
        // FK 

        [Column(name:"id_autor")]
        public long AutorId { get; set; }
        public Autor Autor { get; set; }
        [Column(name: "id_libro")]
        public long LibroId { get; set; }
        public Libro Libro { get; set; }

        // Constructor

        public RelAutorLibro(long autorId, long libroId)
        {
            AutorId = autorId;
            LibroId = libroId;
        }
    }

    [Table(name:"rel_prestamos_libros")]
    //[PrimaryKey(nameof(PrestamoId), nameof(LibroId))]
    public class RelPrestamoLibro
    {
        // FK

        [Column(name: "id_prestamo")]
        public long PrestamoId { get; set; }
        public Prestamo Prestamo{ get; set; }
        [Column(name: "id_libro")]
        public long LibroId { get; set; }
        public Libro Libro { get; set; }

        // Constructor

        public RelPrestamoLibro(long prestamoId, long libroId)
        {
            PrestamoId = prestamoId;
            LibroId = libroId;
        }
    }


}
