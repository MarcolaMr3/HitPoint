using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static List<Usuario> _Records = new List<Usuario>();
        public static List<Usuario> QuerryAll()
        {
            return _Records;
        }
        
    }
}
