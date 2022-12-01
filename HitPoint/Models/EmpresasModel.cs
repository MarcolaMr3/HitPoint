namespace HitPoint.Models
{
    public class EmpresasModel
    {
        public List<EmpresaModel> GetAll()
        {
            return EmpresaModel.QuerryAll();
        }
    }
}
