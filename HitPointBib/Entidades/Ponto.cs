using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitPoint.Utils.Database;

namespace HitPoint.Utils.Entidades
{
    public class Ponto
    {
        public int ID { get; set; }
        public int Funcionario { get; set; } 
        public DateTime Marcacao { get; set; }

        public void MarcarPonto()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO HORARIOS (FUNCIONARIO)" +
                $" VALUES ({Funcionario})", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Ponto> QuerryAll()
        {
            var lista = new List<Ponto>();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, FUNCIONARIO, MARCACAO FROM HORARIOS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        lista.Add(new Ponto()
                        {
                            ID = reader.GetInt32(0),
                            Funcionario = reader.GetInt32(1),
                            Marcacao = reader.GetDateTime(2),
                        });
                    }
                }
            }

            return lista;
        }
        public string PegarNomeFuncionario()
        {
            var result = string.Empty;
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var querry = $"SELECT NOME FROM FUNCIONARIOS WHERE ID = {Funcionario}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = reader.GetString(0);
                    }
                }
            }
            return result;
        }

    }

}