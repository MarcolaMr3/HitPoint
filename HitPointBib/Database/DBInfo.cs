﻿using System.Data.SqlClient;

namespace HitPointBib.Database
{
    public class DBInfo
    {

        public const string DBConnection = @"Data Source=DESKTOP-NO1H2EK\SQLEXPRESS;Initial catalog=HitPoint;User=sa;Password=12345678;Trusted_Connection=True;";


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