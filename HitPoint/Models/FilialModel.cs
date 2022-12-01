using HitPoint.Utils.Entidades;

namespace HitPoint.Models
{
    public class FilialModel
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int EmpresaID { get; set; }
        public decimal CNPJ { get; set; }

        public FilialModel() { }
        public FilialModel(Filial filial)
        {
            ID = filial.ID;
            Nome = filial.Nome;
            EmpresaID = filial.EmpresaID;
            CNPJ = filial.CNPJ;
        }

        public Filial GerarFilial()
        {
            var result = new Filial()
            {
                ID = ID,
                Nome = Nome,
                EmpresaID = EmpresaID,
                CNPJ = CNPJ,
            };
            return result;
        }

        public List<Empresa> PegarEmpresas()
        {
            return Empresa.QuerryAll();
        }
    }
}

