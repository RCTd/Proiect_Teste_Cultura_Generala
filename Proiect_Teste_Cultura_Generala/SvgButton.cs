using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Svg;

namespace Proiect_Teste_Cultura_Generala
{
    public class SvgButton : Button
    {
        //Fields
        private int borderSize = 0;
        private string svgfilename = "../../Resources/Buttons/BWSVG/Atlantida.svg";
        private Color borderColor = Color.PaleVioletRed;
        

        //Properties
        [Category("Svg Button")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        [Category("Svg Button")]
        public string Svgfilename
        {
            get { return svgfilename; }
            set
            {
                svgfilename = value;
                this.Invalidate();
            }
        }

        [Category("Svg Button")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
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
            //this.Resize += new EventHandler(Button_Resize);
        }


        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect)
        {
            SvgData SVGData = new SvgData(svgfilename);
            GraphicsPath path = SVGData.GetGraphicsPath();
            // Scale the GraphicsPath to fit the desired size
            float scaleX = (float)rect.Width / (SVGData.GetWidth() * 10f);
            float scaleY = -(float)rect.Height / (SVGData.GetHeight() * 10f);
            Matrix scaleMatrix = new Matrix();
            scaleMatrix.Translate(0, rect.Height);
            scaleMatrix.Scale(scaleX, scaleY);

            path.Transform(scaleMatrix);

            return path;
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