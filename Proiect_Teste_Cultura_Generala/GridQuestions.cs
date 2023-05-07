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
        private int numQuestionsAnswered = 0;
        private static int numCorrectAnswers = 0;

        public GridQuestions()
        {
            InitializeComponent();
        }

        private void GridQuestionWindow_Load(object sender, EventArgs e)
        {
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
            if (numQuestionsAnswered == 6)
            {
                numQuestionsAnswered = 0;
                MessageBox.Show("Ai finalizat chestionarul despre aceasta regiune.\n" +
                    "vei fi reidrectionat catre harta\n" +
                    "Scorul provizoriu: " + numCorrectAnswers, "Atenție");
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
            Task.Delay(1000).ContinueWith(t => NewQuestion());
        }

        private void NewQuestion()
        {
            q = new Question();
            if (QuestTextBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(NewQuestion);
                QuestTextBox.Invoke(d);
            }
            else
            {
                QuestTextBox.Text = q.GetQuestion();
            }
            List<string> answers = q.GetAnswers();
            Button[] answersBtn = { answer1, answer2, answer3, answer4 };
            for (int i = 0; i < q.GetNumberOfAnswers(); i++)
            {
                if (answersBtn[i].InvokeRequired)
                {
                    var d = new SafeCallDelegate(NewQuestion);
                    answersBtn[i].Invoke(d);
                }
                else
                {
                    answersBtn[i].Text = answers[i];
                    answersBtn[i].BackColor = Color.White;
                }
            }
        }
    }
}
