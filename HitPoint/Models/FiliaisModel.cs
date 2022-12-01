namespace HitPoint.Models
{
    public class FiliaisModel
    {
        public List<FilialModel> GetAll()
        {
            return FilialModel.QuerryAll();
        }
    }
}
