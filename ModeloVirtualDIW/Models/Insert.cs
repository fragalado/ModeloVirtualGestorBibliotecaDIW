using DAL;

namespace ModeloVirtualDIW.Models
{
    public class Insert
    {
        public void insertUsuario(Usuario usuario, Contexto context)
        {
            context.Add<Usuario>(usuario);
            //context.Usuarios.Add(usuario); Lo mismo
            context.SaveChanges();
        }

        public void insertAcceso(Acceso acceso, Contexto context)
        {
            context.Add<Acceso>(acceso);
            context.SaveChanges();
        }

        public void insertEditorial(Editorial editorial, Contexto context)
        {
            context.Add<Editorial>(editorial);
            context.SaveChanges();
        }

        public void insertGenero(Genero genero, Contexto context)
        {
            context.Add<Genero>(genero);
            context.SaveChanges();
        }

        public void insertColeccion(Coleccion coleccion, Contexto context)
        {
            context.Add<Coleccion>(coleccion);
            context.SaveChanges();
        }

        public void insertLibro(Libro libro, Contexto context)
        {
            context.Add<Libro>(libro);
            context.SaveChanges();
        }

        public void insertEstadoPrestamo(EstadoPrestamo estadoPrestamo, Contexto context)
        {
            context.Add<EstadoPrestamo>(estadoPrestamo);
            context.SaveChanges();
        }

        public void insertPrestamo(Prestamo prestamo, Contexto context)
        {
            context.Add<Prestamo>(prestamo);
            context.SaveChanges();
        }

        public void insertAutor(Autor autor, Contexto context)
        {
            context.Add<Autor>(autor);
            context.SaveChanges();
        }

        public void insertRelAutorLibro(RelAutorLibro relAutorLibro, Contexto context)
        {
            context.Add<RelAutorLibro>(relAutorLibro);
            context.SaveChanges();
        }

        public void insertRelPrestamoLibro(RelPrestamoLibro relPrestamoLibro, Contexto context)
        {
            context.Add<RelPrestamoLibro>(relPrestamoLibro);
            context.SaveChanges();
        }
    }
}
