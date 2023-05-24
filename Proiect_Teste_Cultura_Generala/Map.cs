using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIProiectIP;

namespace Proiect_Teste_Cultura_Generala
{
    public partial class Map : Form
    {
        public static bool[] clicked = { false, false, false, false, false, false, false, false, false, };
        public Map()
        {
            InitializeComponent();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            SvgButton[] svgButtons = { svgButton1, svgButton2, svgButton4, svgButton4, svgButton5, svgButton6, svgButton7, svgButton8, svgButton9 };
            for (int i = 0; i < 9; i++)
            {
                if (clicked[i] == true)
                {
                    svgButtons[i].BackColor = Color.Green;
                }
            }
        }
        private void Buttons_Click(int i)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked[i] == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked[i] = true;
            }
            if (GridQuestions.aux[i] == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }

        private void svgButton1_Click(object sender, EventArgs e)
        {
            Buttons_Click(1);
        }
        private void svgButton2_Click(object sender, EventArgs e)
        {
            Buttons_Click(2);
        }
        private void svgButton3_Click(object sender, EventArgs e)
        {
            Buttons_Click(3);
        }
        private void svgButton4_Click(object sender, EventArgs e)
        {
            Buttons_Click(4);
        }
        private void svgButton5_Click(object sender, EventArgs e)
        {
            Buttons_Click(5);
        }
        private void svgButton6_Click(object sender, EventArgs e)
        {
            Buttons_Click(6);
        }
        private void svgButton7_Click(object sender, EventArgs e)
        {
            Buttons_Click(7);
        }
        private void svgButton8_Click(object sender, EventArgs e)
        {
            Buttons_Click(8);
        }
        private void svgButton9_Click(object sender, EventArgs e)
        {
            Buttons_Click(9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formInitial = new Form1();
            formInitial.Owner = this;
            formInitial.Show();
            this.Hide();
        }
    }
}
