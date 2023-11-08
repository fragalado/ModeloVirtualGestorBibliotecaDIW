using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModeloVirtualDIW.Models;
using System.Diagnostics;

namespace ModeloVirtualDIW.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexto _contexto;

        public HomeController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            Insert insert = new Insert();
            Select select = new Select();
            Update update = new Update();
            Delete delete = new Delete();

            Acceso acceso = new Acceso(1,"Usu", "Usuarios de la biblioteca");
            Usuario usuario = new Usuario(1, "432423D", "Fran", "Gallego", "4343242", "noemail@no", "dadwad2", false, null, null, null, acceso.id_acceso);
            
            Editorial editorial = new Editorial(1, "Bilbo");
            Genero genero = new Genero(1, "Terror", "Libros de terror");
            Coleccion coleccion = new Coleccion(1, "Coleccion prueba");
            Libro libro = new Libro(1, "321321", "Harry Potter", "Ralv", 3, editorial.id_editorial, genero.id_genero, coleccion.id_coleccion);

            Autor autor = new Autor(1, "Federico", "Fedez");

            EstadoPrestamo estadoPrestamo = new EstadoPrestamo(1, "Devuelto", "El prestamo ha sido devuelto");
            Prestamo prestamo = new Prestamo(1, null, null, null, estadoPrestamo.id_estado_prestamo, usuario.id_usuario);

            RelAutorLibro relAutorLibro = new RelAutorLibro(autor.id_autor, libro.id_libro);
            RelPrestamoLibro relPrestamoLibro = new RelPrestamoLibro(prestamo.id_prestamo, libro.id_libro);

            // Insert
            //insert.insertAcceso(acceso, _contexto);
            //insert.insertUsuario(usuario, _contexto);
            //insert.insertGenero(genero, _contexto);
            //insert.insertEditorial(editorial, _contexto);
            //insert.insertColeccion(coleccion, _contexto);
            //insert.insertLibro(libro, _contexto);
            //insert.insertAutor(autor, _contexto);
            //insert.insertEstadoPrestamo(estadoPrestamo, _contexto);
            //insert.insertPrestamo(prestamo, _contexto);
            //insert.insertRelAutorLibro(relAutorLibro, _contexto);
            //insert.insertRelPrestamoLibro(relPrestamoLibro, _contexto);

            // Select
            //select.selectUsuarioAll(_contexto);
            //select.selectUsuarioPorDni(_contexto, usuario);
            //select.selectAccesoAll(_contexto);
            //select.selectPrestamoAll(_contexto);
            //select.selectEstadoPrestamoAll(_contexto);
            //select.selectLibrosAll(_contexto);
            //select.selectGenerosAll(_contexto);
            //select.selectColeccionesAll(_contexto);
            //select.selectEditorialesAll(_contexto);
            //select.selectAutoresAll(_contexto);

            // Update
            //usuario.nombre_usuario = "Daniel";
            //update.updateUsuario(usuario, _contexto);

            // Delete
            //delete.deleteUsuario(usuario, _contexto);

            return View();
        }
    }
}