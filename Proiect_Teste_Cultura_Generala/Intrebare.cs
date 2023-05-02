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
        public const int nrA = 4;
        private string _question,_goodA;
        private List<string> _badA=new List<string>();
        private Random rnd = new Random();
        private string[] lines = File.ReadAllLines("../../Resources/Intrebari_grila.txt");

        public Intrebare()
        {
            int numberOfQuestions = Int32.Parse(lines[0].Substring(0,lines[0].IndexOf(' ')));
            int nrQ = rnd.Next(1, numberOfQuestions);
            _question = lines[4 * nrQ].Substring(0,lines[4*nrQ].IndexOf("?")) + '?';
            _goodA = lines[4 * nrQ].Substring(lines[4*nrQ].IndexOf("?")+1);
            for(int i=0;i<nrA-1;i++)
            {
                _badA.Add(_goodA.Split('/')[i + 1]);
            }
            _goodA = _goodA.Substring(0,_goodA.IndexOf("/"));

        }

        public Intrebare(int nrQ)
        {
            int numberOfQuestions = Int32.Parse(lines[0].Substring(0, lines[0].IndexOf(' ')));
            if (nrQ > numberOfQuestions)
            {
                nrQ = new Random().Next(1, numberOfQuestions);
            }
            _question = lines[4 * nrQ].Substring(0, lines[4 * nrQ].IndexOf("?")) + '?';
            _goodA = lines[4 * nrQ].Substring(lines[4 * nrQ].IndexOf("?") + 1);
            for (int i = 0; i < nrA - 1; i++)
            {
                _badA.Add(_goodA.Split('/')[i + 1]);
            }
            _goodA = _goodA.Substring(0, _goodA.IndexOf("/"));
        }
        public string GetQuestion()
        {
            return _question;
        }

        public List<string> GetAnswers()
        {
            List<string> answers = new List<string>(_badA);
            answers.Add(_goodA);
            Shuffle(answers);
            return answers;
        }

        public int GetNumberOfAnswers()
        {
            return nrA;
        }


        void Shuffle(List<string> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
