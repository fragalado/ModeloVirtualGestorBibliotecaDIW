using DAL;

namespace ModeloVirtualDIW.Models
{
    public class Select
    {
        // Usuario
        public List<Usuario> selectUsuarioAll(Contexto _context)
        {
            List<Usuario> listaAuxiliar = _context.Usuarios.ToList();
            foreach (Usuario aux in listaAuxiliar)
            {
                aux.ToString();
            }
            return listaAuxiliar;
        }
        public Usuario selectUsuarioPorDni(Contexto _context, Usuario usuario)
        {
            Usuario usu = _context.Usuarios.FirstOrDefault(u => u.dni_usuario == usuario.dni_usuario);
            usu.ToString();
            return usu;
        }

        // Acceso
        public List<Acceso> selectAccesoAll(Contexto _context)
        {
            List<Acceso> listaAuxiliar = _context.Accesos.ToList();
            foreach (Acceso aux in listaAuxiliar)
            {
                Console.WriteLine(aux.codigo_acceso + " " + aux.descripcion_acceso);
            }
            return listaAuxiliar;
        }

        // Prestamo
        public List<Prestamo> selectPrestamoAll(Contexto _context)
        {
            List<Prestamo> listaAuxiliar = _context.Prestamos.ToList();
            foreach (Prestamo aux in listaAuxiliar)
            {
                Console.WriteLine(aux.id_prestamo);
            }
            return listaAuxiliar;
        }

        // EstadoPrestamo
        public List<EstadoPrestamo> selectEstadoPrestamoAll(Contexto _context)
        {
            List<EstadoPrestamo> listaAuxiliar = _context.EstadoPrestamos.ToList();
            foreach (EstadoPrestamo aux in listaAuxiliar)
            {
                Console.WriteLine(aux.codigo_estado_prestamo + " " + aux.descripcion_estado_prestamo);
            }
            return listaAuxiliar;
        }

        // Autores
        public List<Autor> selectAutoresAll(Contexto _context)
        {
            List<Autor> listaAuxiliar = _context.Autores.ToList();
            foreach (Autor aux in listaAuxiliar)
            {
                Console.WriteLine(aux.nombre_autor + " " + aux.apellidos_autor);
            }
            return listaAuxiliar;
        }

        // Colecciones
        public List<Coleccion> selectColeccionesAll(Contexto _context)
        {
            List<Coleccion> listaAuxiliar = _context.Colecciones.ToList();
            foreach (Coleccion aux in listaAuxiliar)
            {
                Console.WriteLine(aux.nombre_coleccion);
            }
            return listaAuxiliar;
        }

        // Editoriales
        public List<Editorial> selectEditorialesAll(Contexto _context)
        {
            List<Editorial> listaAuxiliar = _context.Editoriales.ToList();
            foreach (Editorial aux in listaAuxiliar)
            {
                Console.WriteLine(aux.nombre_editorial);
            }
            return listaAuxiliar;
        }

        // Generos
        public List<Genero> selectGenerosAll(Contexto _context)
        {
            List<Genero> listaAuxiliar = _context.Generos.ToList();
            foreach (Genero aux in listaAuxiliar)
            {
                Console.WriteLine(aux.nombre_genero);
            }
            return listaAuxiliar;
        }

        // Libros
        public List<Libro> selectLibrosAll(Contexto _context)
        {
            List<Libro> listaAuxiliar = _context.Libros.ToList();
            foreach (Libro aux in listaAuxiliar)
            {
                Console.WriteLine(aux.titulo_libro + " " + aux.isbn_libro);
            }
            return listaAuxiliar;
        }

    }
}
