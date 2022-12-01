using HitPoint.Utils.Entidades;
namespace HitPoint.Models
{
    public class ColaboradoresModel
    {
        public List<Colaborador> GetAll()
        {
            return Colaborador.QuerryAll();
        }
    }
}
