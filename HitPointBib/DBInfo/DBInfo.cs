//using System.Data.SqlClient;

//namespace TechStudents.Utils.DataBase
//{
//    internal class DBInfo
//    {
//       
//        public const string DBConnection = @"Data Source=BUE0102D18\SQLEXPRESS;Initial catalog=TechStudents_DB;User=sa;Password=Senac@2021;Trusted_Connection=True;";
//       

//        public static void TestarBanco()
//        {
//            using (var conn = new SqlConnection(DBConnection))
//            {
//                var cmd = new SqlCommand("SELECT * FROM ALUNOS", conn);
//                conn.Open();

//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        Console.WriteLine($"{reader[1]}");
//                    }
//                }
//            }

//            Console.ReadLine();
//        }
//    }
//}