using DAL;

namespace ModeloVirtualDIW.Models
{
    public class Delete
    {
        // Usuario
        public void deleteUsuario(Usuario usuario, Contexto context)
        {
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
        }

        // Acceso
        public void deleteAcceso(Acceso acceso, Contexto context)
        {
            context.Accesos.Remove(acceso);
            context.SaveChanges();
        }

        // Prestamo
        public void deletePrestamo(Prestamo prestamo, Contexto context)
        {
            context.Prestamos.Remove(prestamo);
            context.SaveChanges();
        }

        // EstadoPrestamo
        public void deleteEstadoPrestamo(EstadoPrestamo estadoPrestamo, Contexto context)
        {
            context.EstadoPrestamos.Remove(estadoPrestamo);
            context.SaveChanges();
        }

        // Libro
        public void deleteLibro(Libro libro, Contexto context)
        {
            context.Libros.Remove(libro);
            context.SaveChanges();
        }

        // Genero
        public void deleteGenero(Genero genero, Contexto context)
        {
            context.Generos.Remove(genero);
            context.SaveChanges();
        }

        // Coleccion
        public void deleteColeccion(Coleccion coleccion, Contexto context)
        {
            context.Colecciones.Remove(coleccion);
            context.SaveChanges();
        }

        // Editorial
        public void deleteEditorial(Editorial editorial, Contexto context)
        {
            context.Editoriales.Remove(editorial);
            context.SaveChanges();
        }

        // Autor
        public void deleteAutor(Autor autor, Contexto context)
        {
            context.Autores.Remove(autor);
            context.SaveChanges();
        }
    }
}
