using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitPoint.Utils.Database;

namespace HitPoint.Utils.Entidades
{
    internal class Filial
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int EmpresaID { get; set; }
        public decimal CNPJ { get; set; }

        public Filial() { }

        public Filial(int id)
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, EMPRESAID ,CNPJ FROM FILIAIS WHERE ID = {id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                        Nome = reader.GetString(1);
                        EmpresaID = reader.GetInt32(2);
                        CNPJ = reader.GetDecimal(3);
                    }
                }
            }
        }

        public static List<Filial> QuerryAll()
        {
            var lista = new List<Filial>();

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NOME, EMPRESAID, CNPJ FROM FILIAIS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        lista.Add(new Filial()
                        {
                            ID = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            EmpresaID = reader.GetInt32(2),
                            CNPJ = reader.GetDecimal(3),
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
                var cmd = new SqlCommand($"INSERT INTO FILIAIS (ID, NOME, EMPRESAID, CNPJ)" +
                $" VALUES (NEXT VALUE FOR FILIAIS_SEQ, '{Nome}', {EmpresaID}, {CNPJ})", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM FILIAIS WHERE ID = {ID}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var querry = $"UPDATE FILIAIS SET NOME = '{Nome}',EMPRESAID = {EmpresaID} , CNPJ = {CNPJ} WHERE ID = {ID}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
