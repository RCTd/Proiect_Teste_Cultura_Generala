using Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_Teste_Cultura_Generala
{
    public partial class GridQuestions : Form
    {
        private delegate void SafeCallDelegate();
        private Question q;
        private OrderIterator i;
        private int region=0;
        private int numQuestionsAnswered = 0;
        public int numCorrectAnswers = 0;
        public bool waitflag = false;
        public static bool[] aux = { false, false, false, false, false, false, false, false, false};

        public GridQuestions()
        {
            InitializeComponent();
        }

        public GridQuestions(int selectedButton)
        {
            region = selectedButton;
            InitializeComponent();
        }

        private void GridQuestionWindow_Load(object sender, EventArgs e)
        {
            i = new OrderIterator(new QuestionList(region));
            NewQuestion();
        }

        private void QuestTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void answear1_Click(object sender, EventArgs e)
        {
            CheckAnswer(answer1);
        }

        private void answear2_Click(object sender, EventArgs e)
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
            if (!waitflag)
            {
                if (numQuestionsAnswered == 5)
                {
                    if (q.CheckGoodAnswer(answer.Text) == Color.Green)
                    {
                        numCorrectAnswers++;
                    }
                    numQuestionsAnswered = 0;
                    MessageBox.Show("Ai finalizat chestionarul despre aceasta regiune.\n" +
                        "vei fi reidrectionat catre harta\n" +
                        "Puncte adunate pana acum: " + numCorrectAnswers, "Atenție");
                    for(int i =0;i<9;i++)
                    {
                        if (Map.clicked[i] == true)
                        {
                            aux[i] = true;
                        }
                    }
                    Form mod = new Map();
                    mod.Owner = this;
                    mod.Show();
                    this.Hide();
                }
                numQuestionsAnswered++;
                if (q.CheckGoodAnswer(answer.Text) == Color.Green)
                {
                    numCorrectAnswers++;
                }
                timer1.Start();
                waitflag = true;
            }
        }

        private void NewQuestion()
        {
            i.MoveNext();
            q = (Question)i.Current();
            QuestTextBox.Text = q.GetQuestion();
           
            List<string> answers = q.GetAnswers();
            Button[] answersBtn = { answer1, answer2, answer3, answer4 };
            for (int i = 0; i < q.GetNumberOfAnswers(); i++)
            {
                answersBtn[i].Text = answers[i];
                answersBtn[i].BackColor = Color.White;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            NewQuestion();
            timer1.Stop();
            waitflag = false;
        }
    }
}
