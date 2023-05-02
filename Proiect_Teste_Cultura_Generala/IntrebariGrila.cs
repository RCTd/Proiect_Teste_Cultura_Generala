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
    public partial class IntrebariGrila : Form
    {
        private delegate void SafeCallDelegate();
        private Intrebare q;
        public IntrebariGrila()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAnswer(answer1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckAnswer(answer2);
        }

        private void IntrebariGrila_Load(object sender, EventArgs e)
        {
            NewQuestion();
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
            if (answer.Text == q.GetGoodAnswer())
            {
                answer.BackColor = Color.Green;
            }
            else
            {
                answer.BackColor = Color.Red;
            }
            Task.Delay(1000).ContinueWith(t => NewQuestion());
        }

        private void NewQuestion()
        {
            q = new Intrebare();
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
