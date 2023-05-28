/**************************************************************************
 *                                                                        *
 *  File:        Form1.cs                                                 *
 *  Copyright:   (c) 2023, Tudusciuc Cristian-Rafael                       *
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

using Svg;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;

namespace SvgData
{
    public class SvgData
    {
        private char[] _svgCommands;
        private GraphicsPath _Path;
        private int _width, _height;

        public SvgData()
        {
            _width = 0;
            _height = 0;
            _svgCommands = "".ToCharArray();
        }

        public SvgData(in string filename)
        {
            try
            {
                Parse(filename);
            }
            catch
            {
                throw new Exception("Eroare la incarcarea resurselor svg");
            }
        }

        /// <summary>
        /// functie de convertire a unui SvgPath la GraphicsPath
        /// </summary>
        /// <returns></returns>
        public void Parse(in string filename)
        {
            // Replace "example.svg" with the path to your SVG file
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
            nsMgr.AddNamespace("svg", "http://www.w3.org/2000/svg");

            // Get the root SVG element
            XmlElement svg = doc.SelectSingleNode("//svg:svg", nsMgr) as XmlElement;

            // Extract the width and height attributes
            string width3 = svg.GetAttribute("width");
            string height3 = svg.GetAttribute("height");

            _width = Int32.Parse(svg.GetAttribute("width").Split('.')[0]);
            _height = Int32.Parse(svg.GetAttribute("height").Split('.')[0]);


            // Extract the path element
            XmlElement path = doc.SelectSingleNode("//svg:path", nsMgr) as XmlElement;
            string pathData = path.GetAttribute("d");
            _svgCommands = pathData.ToCharArray();
            _Path = new GraphicsPath();
            var svgBuilder = new SvgPathBuilder();
            var segList = SvgPathBuilder.Parse(new ReadOnlySpan<char>(_svgCommands));
            PointF pnt = new Point(0, 0);
            foreach (var segment in segList)
            {
                pnt = segment.AddToPath(_Path, pnt, segList);
            }
        }

        /// <summary>
        /// functie de preluare a comenzilor de desenare svg
        /// </summary>
        /// <returns></returns>
        public char[] GetCommands()
        {
            return _svgCommands;
        }

        /// <summary>
        /// functie de preluare a latimii unui judet
        /// </summary>
        /// <returns></returns>
        public int GetWidth()
        {
            return _width;
        }

        /// <summary>
        /// functie de preluare a inaltimii unui judet
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
            return _height;
        }

        /// <summary>
        /// functie de preluare a conturului unui judet sub 
        /// </summary>
        /// <returns></returns>
        public GraphicsPath GetGraphicsPath()
        {
            return _Path;
        }
    }
}
