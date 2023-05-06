using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Svg;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Proiect_Teste_Cultura_Generala
{
    class SvgData
    {
        private char[] svgCommands;
        private GraphicsPath Path;
        private int width, height;

        public SvgData()
        {
            width = 0;
            height = 0;
            svgCommands = "".ToCharArray();
        }

        public SvgData(in string filename)
        {
            Parse(filename);
        }

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
            string height3 =svg.GetAttribute("height");

            width = Int32.Parse(svg.GetAttribute("width").Split('.')[0]);
            height = Int32.Parse(svg.GetAttribute("height").Split('.')[0]);


            // Extract the path element
            XmlElement path = doc.SelectSingleNode("//svg:path", nsMgr) as XmlElement;
            string pathData = path.GetAttribute("d");
            svgCommands = pathData.ToCharArray();
            Path = new GraphicsPath();
            var svgBuilder = new SvgPathBuilder();
            var segList = SvgPathBuilder.Parse(new ReadOnlySpan<char>(svgCommands));
            PointF pnt = new Point(0, 0);
            foreach (var segment in segList)
            {
                pnt = segment.AddToPath(Path, pnt, segList);
            }
        }

        public char[] GetCommands()
        {
            return svgCommands;
        }

        public int GetWidth()
        {
            return width;
        }
        public int GetHeight()
        {
            return height;
        }
        public GraphicsPath GetGraphicsPath()
        {
            return Path; 
        }
    }
}