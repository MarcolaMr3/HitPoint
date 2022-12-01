using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitPoint.Utils.Database;

namespace HitPoint.Utils.Entidades
{
    public class Empresa
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal CNPJ { get; set; }

        public Empresa() { }

        public Empresa(int id)
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, CNPJ FROM EMPRESAS WHERE ID = {id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                        Nome = reader.GetString(1);
                        CNPJ = reader.GetDecimal(2);
                    }
                }
            }
        }

        public static List<Empresa> QuerryAll()
        {
            var lista = new List<Empresa>();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, CNPJ FROM EMPRESAS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        lista.Add(new Empresa()
                        {
                            ID = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            CNPJ = reader.GetDecimal(2),
                    });
                    }
                }
            }

            return lista;
        }

        public void Cadastrar()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO EMPRESAS (ID, NOME, CNPJ)" +
                $" VALUES (NEXT VALUE FOR EMPRESAS_SEQ, '{Nome}', {Nome}, {CNPJ})", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM EMPRESAS WHERE ID = {ID}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var querry = $"UPDATE EMPRESAS SET NOME = '{Nome}', CNPJ = {CNPJ} WHERE ID = {ID}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
