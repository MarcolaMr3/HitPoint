using System.Data.SqlClient;

namespace HitPoint.Utils.Database
{
    public class DBInfo
    {

        public const string DBConnection = @"Data Source=DESKTOP-G6C06E4\SQLEXPRESS;Initial catalog=HitPoint;User=sa;Password=sa;Trusted_Connection=True;";


        public static void TestarBanco()
        {
            using (var conn = new SqlConnection(DBConnection))
            {
                var cmd = new SqlCommand("SELECT * FROM FUNCIONARIOS", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[1]}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}