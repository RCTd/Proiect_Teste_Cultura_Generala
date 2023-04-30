using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proiect_Teste_Cultura_Generala
{
    class Intrebare
    {
        public const int nrA = 2;
        private string _question,_goodA;
        private string[] _badA=new string[nrA-1];

        public Intrebare()
        {
            string qfile = "./Resources/Intrebari_grila.txt";
            Random rnd = new Random();

            string[] lines = File.ReadAllLines(qfile);

            _question=lines[4*rnd.Next(1, 37)];
        }
        public string GetQuestion()
        {
            return _question;
        }

    }
}
