using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using HitPointBib.Database;

namespace HitPointBib.Entidades
{
    internal class Usuario
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string AcessType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


        public Usuario() { }
        public Usuario(int id) 
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT ID, NAME, NOMEUSUARIO, SENHA, ACESSTYPE, LOGINCOUNT, BLOCKED, PESSOA FROM USERS WHERE ID = {id}", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                        Name = reader.GetString(1);
                        NickName = reader.GetString(2);
                        Password = reader.GetString(3);
                        AcessType = (AcessType)reader.GetInt32(4);
                        LoginCount = reader.GetInt32(5);
                        Blocked = reader.GetString(6) == "X";
                    }
                }
            }
        }
        public Usuario(string nomeUsuario)
        {
            NickName = nomeUsuario;

            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"SELECT U.ID, U.SENHA, P.PERFIL, P.NOME,  U.PESSOA, U.BLOCKED, U.LOGINCOUNT FROM USERS U INNER JOIN PESSOAS P ON P.ID = U.PESSOA WHERE NOMEUSUARIO = '{NickName}'", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ID = reader.GetInt32(0);
                        Name = reader.GetString(1);
                        NickName = reader.GetString(2);
                        Password = reader.GetString(3);
                        AcessType = (AcessType)reader.GetInt32(4);
                        LoginCount = reader.GetInt32(5);
                        Blocked = reader.GetString(6) == "X";
         
                    }
                }
            }
        }

        public LoginStatus ValidarSenha(string senha)
        {
            if (Blocked)
            {
                return LoginStatus.Blocked;
            }

            if (GenerateHash(senha).ToUpper() == Password.ToUpper())
            {
                return LoginStatus.Sucess;
            }
            else
            {
                LoginCount++;
                var isBlocked = LoginCount > MAX_LOGIN_COUNT;

                using (var conn = new SqlConnection(DBInfo.DBConnection))
                {
                    var cmd = new SqlCommand($"UPDATE USERS SET LOGINCOUNT = {LoginCount}{(isBlocked ? ", BLOCKED = 'X'" : string.Empty)} WHERE ID = {ID};", conn);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        throw new Exception("O usuário não existe na base de dados!");
                    }
                }

                return isBlocked ? LoginStatus.Blocked : LoginStatus.InvalidPassword;
            }
        }

        public void Create()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"INSERT INTO USERS (ID, NAME, NOMEUSUARIO, LOGINTYPE, SENHA, BLOCKED, LOGINCOUNT, PESSOA) VALUES (NEXT VALUE FOR USERS_SEQ, '{Name}', '{NickName}', {LoginType.GetHashCode()}, '{GenerateHash(Password)}', '{(Blocked ? "X" : ".")}', {LoginCount}, {PersonID})", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var querry = $"UPDATE USERS SET NAME = '{Name}', NOMEUSUARIO = '{NickName}', ACESSTYPE = {LoginType.GetHashCode()}, LOGINCOUNT = {LoginCount}, BLOCKED = '{(Blocked ? "X" : ".")}'{(Password != "00000000" ? ($", SENHA = '{GenerateHash(Password)}'") : string.Empty)} WHERE ID = {ID}";
                var cmd = new SqlCommand(querry, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            using (var conn = new SqlConnection(DBInfo.DBConnection))
            {
                var cmd = new SqlCommand($"DELETE FROM USERS WHERE ID = {ID}", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private static List<Usuario> _Records = new List<Usuario>();
        public static List<Usuario> QuerryAll()
        {
            return _Records;
        }
        
    }
}
