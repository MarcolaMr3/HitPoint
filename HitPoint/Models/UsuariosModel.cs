namespace HitPoint.Models
{
    public class UsuariosModel
    {
        public List<UsuarioModel> GetAll()
        {
            return UsuarioModel.QuerryAll();
        }
    }
}
