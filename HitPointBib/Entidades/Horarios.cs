using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPointBib.Entidades
{
    internal class Horarios
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string AcessType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private static List<Horarios> _Records = new List<Horarios>();
        public static List<Horarios> QuerryAll()
        {
            return _Records;
        }
        public static void Create(Horarios horarios)
        {
            _Records.Add(horarios);
        }

        public static void PreencherCadastro()
        {
            Console.Write("Informe o nome do seu Horário: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o horário de entrada da manhã: ");
            Console.Write("Exemplo: 08:00 ");
            string horarioManha01 = Console.ReadLine();

            Console.Write("Informe o horário de saída da manhã: ");
            Console.Write("Exemplo: 08:00 ");
            string horarioManha02 = Console.ReadLine();

            Console.Write("Informe o horário de entrada da tarde: ");
            Console.Write("Exemplo: 08:00 ");
            string horarioTarde01 = Console.ReadLine();

            Console.Write("Informe o horário de saída da tarde: ");
            Console.Write("Exemplo: 08:00 ");
            string horarioTarde02 = Console.ReadLine();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO Horarios (ID, Nome, DataManha01, DataManha02, DataTarde01, DataTarde02)" +
                $" VALUES (NEXT VALUE FOR HORARIOS_SEQ, '{nome}', '{horarioManha01}', '{horarioManha02}', '{horarioTarde01}', '{horarioTarde02}')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void ListarHorarios()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT * FROM HORARIOS", conn);
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
    }
}
