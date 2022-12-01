
namespace HitPoint.Models
{
    public class EmpresaModel
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal CNPJ { get; set; }


        public EmpresaModel() { }
        public EmpresaModel(EmpresaModel empresa)
        {
            ID = empresa.ID;
            Nome = empresa.Nome;
            CNPJ = empresa.CNPJ;
        }

        public EmpresaModel GerarEmpresa()
        {
            var result = new EmpresaModel()
            {
                ID = ID,
                Nome = Nome,
                CNPJ = CNPJ,
            };
            return result;
        }
    }
}

