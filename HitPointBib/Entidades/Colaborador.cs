using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPointBib.Utils.Entidades
{
    public class Colaborador
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string AcessType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private static List<Colaborador> _Records = new List<Colaborador>();
        public static List<Colaborador> QuerryAll()
        {
            return _Records;
        }
        public static void Create(Colaborador colaborador)
        {
            _Records.Add(colaborador);
        }

        public static void ListarFuncionario()
        {
            Console.WriteLine("Insira o nome do Funcionário");
            int nome = int.Parse(Console.ReadLine());

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT * FROM FUNCIONARIOS WHERE ID = {nome}", conn);
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
        public static void ListarFuncionarios()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT * FROM FUNCIONARIOS", conn);
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
            Console.Write("Informe seu nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Informe sua empresa");
            int empresaID = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe sua filial");
            int filialID = int.Parse(Console.ReadLine());

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO FUNCIONARIOS (ID, NOME, EMPRESAID, FILIALID)" +
                $" VALUES (NEXT VALUE FOR FUNCIONARIOS_SEQ, '{nome}', {empresaID}, {filialID})", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}