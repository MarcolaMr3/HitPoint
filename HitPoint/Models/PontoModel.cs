using HitPoint.Utils.Database;
using HitPoint.Utils.Entidades;
using System.Data.SqlClient;

namespace HitPoint.Models
{
    public class PontoModel
    {
        public int Funcionario { get; set; }


        public PontoModel() { }
        public PontoModel(Ponto ponto)
        {
            Funcionario = ponto.Funcionario;
        }

        public Ponto GerarMarcacao()
        {
            var result = new Ponto()
            {
                Funcionario = Funcionario,
            };
            return result;
        }

        public List<Colaborador> PegarFuncionarios()
        {
            return Colaborador.QuerryAll();
        }

    }
}

