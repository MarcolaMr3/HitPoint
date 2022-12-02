using HitPoint.Utils.Entidades;
namespace HitPoint.Models
{
    public class GeradorModel
    {
        public List<Colaborador> GetAll()
        {
            return Colaborador.QuerryAll();
        }
    }
}
