/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
 *  Copyright:   (c) 2023, Potolea Andreea                                *
 *  Description:  Joc de cultura generala "conQUIZtador"                  *
 *                                                                        *
 *                                                                        *
 *  Acest cod este scris în scopul realizării jocului de cultură generală *
 *  din cadrul proiectului la materia Ingineria Programării, de la        *
 *  Facultatea de Automatică și Calculatoare, Univeristatea Tehnică       *
 *  "Gheorghe Asachi" Iași. Codul este opensource și gratis, se poate     *
 *  poate modifica și utiliza oricum, dar în concordanță cu prevederile   * 
 *  GNU General Public License.                                           *
 *                                                                        *
 **************************************************************************/

using Questions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Proiect_Teste_Cultura_Generala
{
    public partial class GridQuestions : Form
    {
        private delegate void SafeCallDelegate();
        private Question _q;
        private OrderIterator _i;
        private int _pos=0;
        private int _numQuestionsAnswered = 0;
        public  int numCorrectAnswers = 0;
        public bool isWaitflag = false;
        public static bool[] isAux = { false, false, false, false, false, false, false, false, false};
        public int[] _answersArray;

        public GridQuestions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construct cu parametrii 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pos"></param>
        public GridQuestions(int[] v,int pos)
        {
            _pos = pos;
            _answersArray = v;
            InitializeComponent();
        }

        private void GridQuestionWindow_Load(object sender, EventArgs e)
        {
            _i = new OrderIterator(new QuestionList(_pos));
            NewQuestion();
        }

        /// <summary>
        /// Urmatoarele functii sunt pentru verificarea fiecarui raspuns in cazul in care e apasat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void answear1_Click(object sender, EventArgs e)
        {
            CheckAnswer(answer1);
        }

        private void answer2_Click(object sender, EventArgs e)
        {
            CheckAnswer(answer2);
        }
        private void answer3_Click(object sender, EventArgs e)
        {
            CheckAnswer(answer3);
        }

        private void answer4_Click(object sender, EventArgs e)
        {
            CheckAnswer(answer4);
        }


        private void CheckAnswer(Button answer)
        {
            if (!isWaitflag)
            {
                answer.BackColor = _q.CheckGoodAnswer(answer.Text);
                if (_q.CheckGoodAnswer(answer.Text) == Color.Green)
                {
                    numCorrectAnswers++;
                }
                _numQuestionsAnswered++;
                if (_numQuestionsAnswered == 6)
                {
                    _numQuestionsAnswered = 0;
                    MessageBox.Show("Ai finalizat chestionarul despre aceasta regiune.\n" +
                        "vei fi reidrectionat catre harta\n" +
                        "Puncte adunate pana acum: " + numCorrectAnswers, "Atenție");
                    for(int i =0;i<9;i++)
                    {
                        if (Map.isClicked[i] == true)
                        {
                            isAux[i] = true;
                        }
                    }
                    _answersArray[_pos] = numCorrectAnswers;
                    Form mod = new Map(_answersArray);
                    mod.Owner = this;
                    mod.Show();
                    this.Hide();
                }
               
                
                timer1.Start();
                isWaitflag = true;
            }
        }

        private void NewQuestion()
        {
            _i.MoveNext();
            _q = (Question)_i.Current();
            QuestTextBox.Text = _q.GetQuestion();
           
            List<string> answers = _q.GetAnswers();
            Button[] answersBtn = { answer1, answer2, answer3, answer4 };
            for (int i = 0; i < _q.GetNumberOfAnswers(); i++)
            {
                answersBtn[i].Text = answers[i];
                answersBtn[i].BackColor = Color.White;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            NewQuestion();
            timer1.Stop();
            isWaitflag = false;
        }

        private void QuestTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
