using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HitPoint.Utils.Database;

namespace HitPoint.Utilss.Entidades
{
    internal class Horarios
    {
        public string Funcionario { get; set; } 

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