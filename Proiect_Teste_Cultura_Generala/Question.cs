using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Collections;

namespace Proiect_Teste_Cultura_Generala
{

    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        // Returns the key of the current element
        public abstract int Key();

        // Returns the current element
        public abstract object Current();

        // Move forward to next element
        public abstract bool MoveNext();

        // Rewinds the Iterator to the first element
        public abstract void Reset();
    }

    abstract class IteratorAggregate : IEnumerable
    {
        // Returns an Iterator or another IteratorAggregate for the implementing
        // object.
        public abstract IEnumerator GetEnumerator();
    }

    class OrderIterator : Iterator
    {
        private QuestionList _collection;

        // Stores the current traversal position. An iterator may have a lot of
        // other fields for storing iteration state, especially when it is
        // supposed to work with a particular kind of collection.
        private int _position = -1;

        public OrderIterator(QuestionList collection)
        {
            this._collection = collection;
        }

        public override object Current()
        {
            return this._collection.getItems()[_position];
        }

        public override int Key()
        {
            return this._position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = this._position +  1;

            if (updatedPosition >= 0 && updatedPosition < this._collection.getItems().Count)
            {
                this._position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            this._position =  0;
        }
    }

    class QuestionList : IteratorAggregate
    {
        List<Question> _collection = new List<Question>();

        public QuestionList()
        {
            Random random = new Random();
            int minValue = 1;
            int maxValue = 54;
            int count = 7;

            // Create a HashSet to store unique random numbers
            HashSet<int> uniqueNumbers = new HashSet<int>();

            while (uniqueNumbers.Count < count)
            {
                int randomNumber = random.Next(minValue, maxValue + 1);
                uniqueNumbers.Add(randomNumber);
            }

            foreach (int number in uniqueNumbers)
            {
                this._collection.Add(new Question(number));
            }
        }

        public List<Question> getItems()
        {
            return _collection;
        }

        public void AddItem(Question item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new OrderIterator(this);
        }
    }

    class Question
    {
        public const int nrA = 4;
        private string _question,_goodA;
        private List<string> _badA=new List<string>();
        private Random rnd = new Random();
        private string[] lines = File.ReadAllLines("../../Resources/Grid_Questions.txt");//Properties.Resources.Grid_Questions

        public Question()
        {
            int numberOfQuestions = Int32.Parse(lines[0].Substring(0,lines[0].IndexOf(' ')));
            int nrQ = rnd.Next(1, numberOfQuestions);
            Init(nrQ);

        }

        public Question(int nrQ)
        {
            int numberOfQuestions = Int32.Parse(lines[0].Substring(0, lines[0].IndexOf(' ')));
            if (nrQ > numberOfQuestions)
            {
                nrQ = new Random().Next(1, numberOfQuestions);
            }
            Init(nrQ);
        }

        private void Init(in int nrQ)
        {
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
        public Color CheckGoodAnswer(in string answer)
        {
            if (answer == _goodA)
                return Color.Green;
            else
                return Color.Red;
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
