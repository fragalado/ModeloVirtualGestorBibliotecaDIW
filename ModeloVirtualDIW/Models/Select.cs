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
        public List<Usuario> selectUsuarioPorDni(Contexto _context, Usuario usuario)
        {
            List<Usuario> listaAuxiliar = new List<Usuario>();
            listaAuxiliar.Add(_context.Usuarios.FirstOrDefault(u => u.dni_usuario == usuario.dni_usuario));
            foreach (Usuario aux in listaAuxiliar)
            {
                aux.ToString();
            }
            return listaAuxiliar;
        }

        // Acceso
        public List<Acceso> selectAccesoAll(Contexto _context)
        {
            List<Acceso> listaAuxiliar = _context.Accesos.ToList();
            foreach (Acceso aux in listaAuxiliar)
            {
                aux.ToString();
            }
            return listaAuxiliar;
        }
        public List<Acceso> selectAccesoPorCodigo(Contexto _context, Acceso acceso)
        {
            List<Acceso> listaAuxiliar = new List<Acceso>();
            listaAuxiliar.Add(_context.Accesos.FirstOrDefault(u => u.codigo_acceso == acceso.codigo_acceso));
            foreach (Acceso aux in listaAuxiliar)
            {
                aux.ToString();
            }
            return listaAuxiliar;
        }

        // Prestamo
        public List<Prestamo> selectPrestamoAll(Contexto _context)
        {
            List<Prestamo> listaAuxiliar = _context.Prestamos.ToList();
            foreach (Prestamo aux in listaAuxiliar)
            {
                aux.ToString();
            }
            return listaAuxiliar;
        }
        public List<Prestamo> selectPrestamoPorId(Contexto _context, Prestamo prestamo)
        {
            List<Prestamo> listaAuxiliar = new List<Prestamo>();
            listaAuxiliar.Add(_context.Prestamos.FirstOrDefault(u => u.id_prestamo == prestamo.id_prestamo));
            foreach (Prestamo aux in listaAuxiliar)
            {
                aux.ToString();
            }
            return listaAuxiliar;
        }

    }
}
