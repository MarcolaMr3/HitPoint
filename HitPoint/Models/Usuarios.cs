namespace HitPoint.Models
{
    public class Usuarios
    {
        public List<Usuario> GetAll()
        {
            return Usuario.QuerryAll();
        }
    }
}
