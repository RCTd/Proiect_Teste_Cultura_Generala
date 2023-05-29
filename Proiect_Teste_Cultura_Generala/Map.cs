/**************************************************************************
 *                                                                        *
 *  File:        Map.cs                                                 *
 *  Copyright:   (c) 2023, Tudusciuc Cristian-Rafael                      *
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
        public static bool[] isClicked = { false, false, false, false, false, false, false, false, false, };
        int[] _answersArray ={ 0,0,0,0,0,0,0,0,0};
        public Map()
        {
            InitializeComponent();
        }
        public Map(int[] v)
        {
            _answersArray = v;
            InitializeComponent();
        }

        private void Map_Load(object sender, EventArgs e)
        {
            SvgButton[] svgButtons = { svgButton1, svgButton2, svgButton3, svgButton4, svgButton5, svgButton6, svgButton7, svgButton8, svgButton9 };
            for (int i = 0; i < 9; i++)
            {
                if (isClicked[i] == true)
                    if (_answersArray[i] <2)
                    {
                        svgButtons[i].BackColor = Color.Red;
                    }
                    else
                    {
                        if (_answersArray[i] <=4)
                        {
                            svgButtons[i].BackColor = Color.Yellow;
                        }
                        else
                        {
                            svgButtons[i].BackColor = Color.Green;
                        }
                    }

            }
        }
        private void Buttons_Click(int i)
        {
            GridQuestions grid = new GridQuestions(_answersArray,i);
            if (isClicked[i] == false)
            {
                grid.Owner = this;
                grid.Show();
                this.Hide();
                isClicked[i] = true;
            }
            if (GridQuestions.isAux[i] == true)
            {
                MessageBox.Show("Ai rezolvat deja acest chestionar!");
            }
        }

        private void svgButton1_Click(object sender, EventArgs e)
        {
            Buttons_Click(0);
        }
        private void svgButton2_Click(object sender, EventArgs e)
        {
            Buttons_Click(1);
        }
        private void svgButton3_Click(object sender, EventArgs e)
        {
            Buttons_Click(2);
        }
        private void svgButton4_Click(object sender, EventArgs e)
        {
            Buttons_Click(3);
        }
        private void svgButton5_Click(object sender, EventArgs e)
        {
            Buttons_Click(4);
        }
        private void svgButton6_Click(object sender, EventArgs e)
        {
            Buttons_Click(5);
        }
        private void svgButton7_Click(object sender, EventArgs e)
        {
            Buttons_Click(6);
        }
        private void svgButton8_Click(object sender, EventArgs e)
        {
            Buttons_Click(7);
        }
        private void svgButton9_Click(object sender, EventArgs e)
        {
            Buttons_Click(8);
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
