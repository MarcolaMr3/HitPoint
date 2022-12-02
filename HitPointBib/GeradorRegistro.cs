using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPoint.Utils
{
    internal class GeradorRegistro
    {
        static void Pontotxt()
        {
            {
                // 1: Escreve um linha para o novo arquivo
                using (StreamWriter writer = new StreamWriter("C:\\dados\\macoratti.txt", true))
                {
                    writer.WriteLine("Macoratti .net");
                }
                // 2: Anexa uma linha ao arquivo
                using (StreamWriter writer = new StreamWriter(@"C:\dados\macoratti.txt", true))
                {
                    writer.WriteLine("Quase tudo para Visual Basic");
                }
            }
        }

    }



}
