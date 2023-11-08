using DAL;

namespace ModeloVirtualDIW.Models
{
    public class Update
    {
        // Usuario
        public void updateUsuario(Usuario usuario, Contexto context)
        {
            context.Usuarios.Update(usuario);
            context.SaveChanges();
        }

        // Acceso
        public void updateAcceso(Acceso acceso, Contexto context)
        {
            context.Accesos.Update(acceso);
            context.SaveChanges();
        }

        // Prestamo
        public void updatePrestamo(Prestamo prestamo, Contexto context)
        {
            context.Prestamos.Update(prestamo);
            context.SaveChanges();
        }

        // EstadoPrestamo
        public void updateEstadoPrestamo(EstadoPrestamo estadoPrestamo, Contexto context)
        {
            context.EstadoPrestamos.Update(estadoPrestamo);
            context.SaveChanges();
        }

        // Libro
        public void updateLibro(Libro libro, Contexto context)
        {
            context.Libros.Update(libro);
            context.SaveChanges();
        }

        // Genero
        public void updateGenero(Genero genero, Contexto context)
        {
            context.Generos.Update(genero);
            context.SaveChanges();
        }

        // Coleccion
        public void updateColeccion(Coleccion coleccion, Contexto context)
        {
            context.Colecciones.Update(coleccion);
            context.SaveChanges();
        }

        // Editorial
        public void updateEditorial(Editorial editorial, Contexto context)
        {
            context.Editoriales.Update(editorial);
            context.SaveChanges();
        }

        // Autor
        public void updateAutor(Autor autor, Contexto context)
        {
            context.Autores.Update(autor);
            context.SaveChanges();
        }
    }
}
