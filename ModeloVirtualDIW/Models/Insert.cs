using DAL;

namespace ModeloVirtualDIW.Models
{
    public class Insert
    {
        public void InsertBD(Usuario usu, Contexto context)
        {
            context.Add<Usuario>(usu);
            context.SaveChanges();
        }
    }
}
