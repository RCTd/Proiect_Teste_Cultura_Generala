/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Proiect_Teste_Cultura_Generala
{
    public class SvgButton : Button
    {
        //Fields
        private string _svgfilename = "";
        private Color _borderColor = Color.PaleVioletRed;
        

        //Properties
        [Category("Svg Button")]
        public string Svgfilename
        {
            get { return _svgfilename; }
            set
            {
                _svgfilename = value;
                this.Invalidate();
            }
        }

        [Category("Svg Button")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Svg Button")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("Svg Button")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        //Constructor
        public SvgButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(176, 152);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
        }


        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect)
        {
            try
            {
                SvgData.SvgData SVGData = new SvgData.SvgData(_svgfilename);
                GraphicsPath path = SVGData.GetGraphicsPath();
                // Scale the GraphicsPath to fit the desired size
                float scaleX = (float)rect.Width / (SVGData.GetWidth() * 10f);
                float scaleY = -(float)rect.Height / (SVGData.GetHeight() * 10f);
                Matrix scaleMatrix = new Matrix();
                scaleMatrix.Translate(0, rect.Height);
                scaleMatrix.Scale(scaleX, scaleY);

                path.Transform(scaleMatrix);

                return path;
            }catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw (e);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);


            Rectangle rectSurface = this.ClientRectangle;

            GraphicsPath pathSurface = GetFigurePath(rectSurface);
            Pen penSurface = new Pen(this.Parent.BackColor);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //Button surface
            this.Region = new Region(pathSurface);
            //Draw surface border for HD result
            pevent.Graphics.DrawPath(penSurface, pathSurface);

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}