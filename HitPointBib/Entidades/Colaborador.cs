using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPointBib.Utils.Entidades
{
    public class Colaborador
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string AcessType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        private static List<Colaborador> _Records = new List<Colaborador>();
        public static List<Colaborador> QuerryAll()
        {
            return _Records;
        }
        public static void Create(Colaborador colaborador)
        {
            _Records.Add(colaborador);
        }

    }
}