using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPointBib.Entidades
{
    internal class Empresa
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string AcessType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private static List<Empresa> _Records = new List<Empresa>();
        public static List<Empresa> QuerryAll()
        {
            return _Records;
        }
        public static void Create(Empresa empresa)
        {
            _Records.Add(empresa);
        }

        public static void ListarEmpresas()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT * FROM EMPRESAS", conn);
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
            Console.Write("Informe o nome da sua Empresa: ");
            string nome = Console.ReadLine();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO EMPRESAS (ID, NOME)" +
                $" VALUES (NEXT VALUE FOR EMPRESAS_SEQ, '{nome}')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
