using HitPoint.Utils.Entidades;
namespace HitPoint.Models
{
    public class PontosModel
    {
        public List<Ponto> GetAll()
        {
            return Ponto.QuerryAll();
        }
    }
}
