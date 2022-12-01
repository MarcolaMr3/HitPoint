namespace HitPoint.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }

        public bool Blocked { get; set; }

        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }

        public string AcessType { get; set; }
        public string Status { get; set; }
        public int LoginCount { get; set; }

        public UsuarioModel() { }
        public UsuarioModel(UsuarioModel user)
        {
            ID = user.ID;
            Name = user.Name;
            NickName = user.NickName;

            AcessType = user.AcessType;
            LoginCount = user.LoginCount;
            Blocked = user.Blocked;
        }

        public UsuarioModel GenerateUser()
        {
            var result = new UsuarioModel()
            {
                ID = ID,
                Name = Name,
                NickName = NickName,
                Password = Password,
                AcessType = AcessType,
                LoginCount = LoginCount,
                Blocked = Blocked,
            };

            return result;
        }

        internal static List<UsuarioModel> QuerryAll()
        {
            throw new NotImplementedException();
        }
    }
}

