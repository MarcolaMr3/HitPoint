using HitPoint.Utils.Entidades;
namespace HitPoint.Models
{
    public class EmpresasModel
    {
        public List<Empresa> GetAll()
        {
            return Empresa.QuerryAll();
        }
    }
}
