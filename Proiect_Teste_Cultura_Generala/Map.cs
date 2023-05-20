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
        public static bool clicked1 = false;
        public static bool clicked2 = false;
        public static bool clicked3 = false;
        public static bool clicked4 = false;
        public static bool clicked5 = false;
        public static bool clicked6 = false;
        public static bool clicked7 = false;
        public static bool clicked8 = false;
        public static bool clicked9 = false;
        public Map()
        {
            InitializeComponent();
        }

        private void Map_Load(object sender, EventArgs e)
        {

            if (clicked1 == true)
            {
                svgButton1.BackColor = Color.Green;
            }
            if (clicked2 == true)
            {
                svgButton2.BackColor = Color.Green;
            }
            if (clicked3 == true)
            {
                svgButton3.BackColor = Color.Green;
            }
            if (clicked4 == true)
            {
                svgButton4.BackColor = Color.Green;
            }
            if (clicked5 == true)
            {
                svgButton5.BackColor = Color.Green;
            }
            if (clicked6 == true)
            {
                svgButton6.BackColor = Color.Green;
            }
            if (clicked7 == true)
            {
                svgButton7.BackColor = Color.Green;
            }
            if (clicked8 == true)
            {
                svgButton8.BackColor = Color.Green;
            }
            if (clicked9 == true)
            {
                svgButton9.BackColor = Color.Green;
            }
        }


        private void svgButton1_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked1 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked1 = true;
            }
            if (GridQuestions.aux1 == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }
        private void svgButton2_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked2 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked2 = true;
            }
            if (GridQuestions.aux2 == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }
        private void svgButton3_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked3 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked3 = true;
            }
            if (GridQuestions.aux3 == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }
        private void svgButton4_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked4 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked4 = true;
            }
            if (GridQuestions.aux4 == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }
        private void svgButton5_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked5 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked5 = true;
            }
            if (GridQuestions.aux5 == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }
        private void svgButton6_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked6 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked6 = true;
            }
            if (GridQuestions.aux6 == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }
        private void svgButton7_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked7 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked7 = true;
            }
            if (GridQuestions.aux7== true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }
        private void svgButton8_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked8 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked8 = true;
            }
            if (GridQuestions.aux8 == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }
        private void svgButton9_Click(object sender, EventArgs e)
        {
            GridQuestions grid = new GridQuestions();
            if (clicked9 == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                clicked9 = true;
            }
            if (GridQuestions.aux9 == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
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
