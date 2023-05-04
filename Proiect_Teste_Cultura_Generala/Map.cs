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
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }

        private void svgButton1_Click(object sender, EventArgs e)
        {
            var grid = new GridQuestions();
            grid.Show();
        }
    }
}
