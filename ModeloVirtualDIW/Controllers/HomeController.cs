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

            Acceso acceso = new Acceso("Usu", "Usuarios de la biblioteca");
            Usuario usuario = new Usuario("432423D", "Fran", "Gallego", "4343242", "noemail@no", "dadwad2", false, null, null, null, 1);
            
            Editorial editorial = new Editorial("Bilbo");
            Genero genero = new Genero("Terror", "Libros de terror");
            Coleccion coleccion = new Coleccion("Coleccion prueba");
            Libro libro = new Libro("321321", "Harry Potter", "Ralv", 3, 1, 1, 1);

            Autor autor = new Autor("Federico", "Fedez");

            EstadoPrestamo estadoPrestamo = new EstadoPrestamo("Devuelto", "El prestamo ha sido devuelto");
            Prestamo prestamo = new Prestamo(null, null, null, 1, 1);

            RelAutorLibro relAutorLibro = new RelAutorLibro(1, 1);
            RelPrestamoLibro relPrestamoLibro = new RelPrestamoLibro(1, 1);

            // Insert
            insert.insertAcceso(acceso, _contexto);
            insert.insertUsuario(usuario, _contexto);
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
            select.selectUsuarioAll(_contexto);
            select.selectUsuarioPorDni(_contexto, usuario);

            return View();
        }
    }
}