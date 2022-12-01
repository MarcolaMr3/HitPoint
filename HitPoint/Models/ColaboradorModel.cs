namespace HitPoint.Models
{
    public class ColaboradorModel
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int EmpresaID { get; set; }
        public int FilialID { get; set; }
        public decimal PIS { get; set; }

        public ColaboradorModel() { }
        public ColaboradorModel(ColaboradorModel colaborador)
        {
            ID = colaborador.ID;
            Nome = colaborador.Nome;
            EmpresaID = colaborador.EmpresaID;
            FilialID = colaborador.FilialID;
            PIS = colaborador.PIS;
        }

        public ColaboradorModel GerarColaborador()
        {
            var result = new ColaboradorModel()
            {
                ID = ID,
                Nome = Nome,
                EmpresaID = EmpresaID,
                FilialID = FilialID,
                PIS = PIS,
            };
            return result;
        }
        internal static List<ColaboradorModel> QuerryAll()
        {
            throw new NotImplementedException();
        }
    }
}