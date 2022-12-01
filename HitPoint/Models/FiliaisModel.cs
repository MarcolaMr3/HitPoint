using HitPoint.Utils.Entidades;
namespace HitPoint.Models
{
    public class FiliaisModel
    {
        public List<Filial> GetAll()
        {
            return Filial.QuerryAll();
        }
    }
}
