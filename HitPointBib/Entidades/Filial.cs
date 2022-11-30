using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPointBib.Entidades
{
    internal class Filial
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string AcessType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private static List<Filial> _Records = new List<Filial>();
        public static List<Filial> QuerryAll()
        {
            return _Records;
        }
        public static void Create(Filial filial)
        {
            _Records.Add(filial);
        }
        public static void ListarFiliais()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT * FROM FILIAIS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[1]}");
                    }
                }
            }
        }
        public static void PreencherCadastro()
        {
            Console.Write("Informe o nome da sua Filial: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o nome da sua Empresa: ");
            int empresaID = int.Parse(Console.ReadLine());

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO FILIAIS (ID, NOME, EMPRESAID)" +
                $" VALUES (NEXT VALUE FOR FILIAIS_SEQ, '{nome}', {empresaID})", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
