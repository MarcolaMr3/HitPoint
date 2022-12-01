namespace HitPoint.Models
{
    public class ColaboradoresModel
    {
        public List<ColaboradorModel> GetAll()
        {
            return ColaboradorModel.QuerryAll();
        }
    }
}
