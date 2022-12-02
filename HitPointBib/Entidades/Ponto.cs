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
        public int Funcionario { get; set; } 

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
    }

}