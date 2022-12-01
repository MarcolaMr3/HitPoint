using HitPoint.Utils.Entidades;
namespace HitPoint.Models;

public class ColaboradorModel
{
    public int ID { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int EmpresaID { get; set; }
    public int FilialID { get; set; }
    public decimal PIS { get; set; }

    public ColaboradorModel() { }
    public ColaboradorModel(Colaborador colaborador)
    {
        ID = colaborador.ID;
        Nome = colaborador.Nome;
        EmpresaID = colaborador.EmpresaID;
        FilialID = colaborador.FilialID;
        PIS = colaborador.PIS;
    }

    public Colaborador GerarColaborador()
    {
        var result = new Colaborador()
        {
            ID = ID,
            Nome = Nome,
            EmpresaID = EmpresaID,
            FilialID = FilialID,
            PIS = PIS,
        };
        return result;
    }
}