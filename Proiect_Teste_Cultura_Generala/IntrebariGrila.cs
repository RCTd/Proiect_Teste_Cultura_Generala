using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_Teste_Cultura_Generala
{
    public partial class IntrebariGrila : Form
    {
        public IntrebariGrila()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void IntrebariGrila_Load(object sender, EventArgs e)
        {

            Intrebare q = new Intrebare();
            QuestTextBox.Text = q.GetQuestion();
            List<string> answers = q.GetAnswers();
            answer1.Text = answers[0];
            answer2.Text = answers[1];
            answer3.Text = answers[2];
            answer4.Text = answers[3];
        }
    }
}
