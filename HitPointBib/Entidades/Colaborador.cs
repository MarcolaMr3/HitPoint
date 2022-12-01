using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HitPointBib.Database;
using System.Xml.Linq;

namespace HitPointBib.Entidades
{
    public class Colaborador
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int EmpresaID { get; set; }
        public int FilialID { get; set; }
        public decimal PIS { get; set; }

        public Colaborador() { }

        public Colaborador(int id)
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, EMPRESAID, FILIALID, PIS FROM FUNCIONARIOS WHERE ID = {id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                        Nome = reader.GetString(1);
                        EmpresaID = reader.GetInt32(2);
                        FilialID = reader.GetInt32(3);
                        PIS = reader.GetDecimal(4);
                    }
                }
            }
        }

        public static List<Colaborador> QuerryAll()
        {
            var lista = new List<Colaborador>();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, EMPRESAID, FILIALID, PIS FROM FUNCIONARIOS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        lista.Add(new Colaborador()
                        {
                            ID = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            EmpresaID = reader.GetInt32(2),
                            FilialID = reader.GetInt32(3),
                            PIS = reader.GetDecimal(4),
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
                var cmd = new SqlCommand($"INSERT INTO FUNCIONARIOS (ID, NOME, EMPRESAID, FILIALID, PIS)" +
                $" VALUES (NEXT VALUE FOR FUNCIONARIOS_SEQ, '{Nome}', {EmpresaID}, {FilialID}, {PIS})", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM FUNCIONARIOS WHERE ID = {ID}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var querry = $"UPDATE FUNCIONARIOS SET NOME = '{Nome}', EMPRESAID = {EmpresaID}, FILIALID = {FilialID}, PIS = {PIS} WHERE ID = {ID}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}