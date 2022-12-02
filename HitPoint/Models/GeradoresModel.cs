using HitPoint.Utils.Entidades;
namespace HitPoint.Models
{
    public class GeradoresModel
    {
        public List<Ponto> GetAll()
        {
            return Ponto.QuerryAll();
        }
    }
}
