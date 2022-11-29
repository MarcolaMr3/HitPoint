using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPointBib.Entidades
{
    internal class Empresa
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string AcessType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private static List<Empresa> _Records = new List<Empresa>();
        public static List<Empresa> QuerryAll()
        {
            return _Records;
        }
        public static void Create(Empresa empresa)
        {
            _Records.Add(empresa);
        }
    }
}
