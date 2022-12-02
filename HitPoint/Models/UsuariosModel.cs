
using HitPointBib.Entidades;

namespace HitPoint.Models
{
    public class UsuariosModel
    {
        public List<Usuario> GetAll()
        {
            return Usuario.QuerryAll();
        }
    }
}
