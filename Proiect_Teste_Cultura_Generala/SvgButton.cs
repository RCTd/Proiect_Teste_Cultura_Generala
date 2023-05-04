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
           /* int width =176;
            int height = 152;*/

            ReadOnlySpan<char> pathData = new ReadOnlySpan<char>("M900 1440 c0 -47 -4 -80 -10 -80 -5 0 -10 5 -10 10 0 6 -35 10 -86 10 -84 0 -87 -1 -117 -32 -19 -21 -32 -28 -34 -20 -3 6 -18 12 -34 12 -16 0 -29 5 -29 10 0 6 -40 10 -100 10 -60 0 -100 -4 -100 -10 0 -5 -16 -10 -35 -10 -25 0 -44 -8 -60 -25 -17 -16 -25 -35 -25 -60 l0 -35 -65 0 -65 0 -65 -65 -65 -65 0 -135 c0 -83 4 -135 10 -135 6 0 10 -8 10 -18 0 -10 9 -24 20 -32 11 -8 20 -21 20 -30 0 -9 9 -22 20 -30 11 -8 20 -21 20 -28 0 -8 14 -27 30 -42 17 -15 30 -34 30 -42 0 -7 9 -20 20 -28 11 -8 20 -20 20 -28 0 -17 25 -42 42 -42 8 0 20 -9 28 -20 8 -11 21 -20 30 -20 9 0 22 -9 30 -20 8 -11 21 -20 30 -20 9 0 22 -9 30 -20 8 -11 21 -20 30 -20 9 0 22 -9 30 -20 13 -18 26 -20 118 -20 96 0 105 -2 127 -25 14 -13 25 -30 25 -37 0 -8 9 -20 20 -28 11 -8 20 -20 20 -28 0 -20 26 -42 50 -42 22 0 70 -41 70 -60 0 -24 30 -40 74 -40 25 0 46 5 46 10 0 18 31 10 55 -15 14 -13 25 -36 25 -50 0 -24 2 -25 70 -25 40 0 70 4 70 10 0 6 16 10 35 10 29 0 44 9 80 45 25 24 45 49 45 55 0 6 16 26 35 45 29 30 41 35 80 35 25 0 45 5 45 10 0 6 12 10 26 10 17 0 39 -14 64 -40 31 -32 46 -40 74 -40 29 0 36 4 36 20 0 11 5 20 10 20 6 0 10 25 10 56 0 49 -4 59 -30 84 -17 15 -30 33 -30 40 0 7 -13 25 -30 40 -16 15 -30 33 -30 40 0 7 -14 25 -31 41 l-30 28 90 90 c78 78 91 95 91 123 0 22 -7 39 -20 48 -12 8 -20 26 -20 42 0 15 -4 28 -10 28 -6 0 -10 43 -10 110 0 67 -4 110 -10 110 -6 0 -10 33 -10 80 0 47 -4 80 -10 80 -6 0 -10 30 -10 70 0 40 4 70 10 70 6 0 10 23 10 50 l0 50 -140 0 c-87 0 -140 -4 -140 -10 0 -18 -35 -11 -50 10 -12 16 -26 20 -72 20 -32 0 -58 4 -58 10 0 6 -30 10 -70 10 -40 0 -70 4 -70 10 0 6 -37 10 -90 10 l-90 0 0 -80z".ToCharArray());
            var path = new GraphicsPath();
            var segList = SvgPathBuilder.Parse(pathData);
            PointF pnt=new Point(0,0);
            foreach (var segment in segList)
            {
                pnt=segment.AddToPath(path,pnt,segList);
            }

            // Scale the GraphicsPath to fit the desired size
            float scaleX = 0.1f;
            float scaleY = -0.1f;
            Matrix scaleMatrix = new Matrix();
            scaleMatrix.Translate(0, 152);
            scaleMatrix.Scale(scaleX, scaleY);

            path.Transform(scaleMatrix);

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);


            Rectangle rectSurface = this.ClientRectangle;

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface))
            using (Pen penSurface = new Pen(this.Parent.BackColor))
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //Button surface
                this.Region = new Region(pathSurface);
                //Draw surface border for HD result
                pevent.Graphics.DrawPath(penSurface, pathSurface);

            }
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