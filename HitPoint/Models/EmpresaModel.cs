
using HitPoint.Utils.Entidades;

namespace HitPoint.Models
{
    public class EmpresaModel
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal CNPJ { get; set; }


        public EmpresaModel() { }
        public EmpresaModel(Empresa empresa)
        {
            ID = empresa.ID;
            Nome = empresa.Nome;
            CNPJ = empresa.CNPJ;
        }

        public Empresa GerarEmpresa()
        {
            var result = new Empresa()
            {
                ID = ID,
                Nome = Nome,
                CNPJ = CNPJ,
            };
            return result;
        }

    }
}

