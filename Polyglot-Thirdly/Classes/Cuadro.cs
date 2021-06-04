using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyglot_Thirdly.Classes
{
    public class Cuadro
    {

        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Point P4 { get; set; }
        public Tuple<Point, Point> L1 { get; set; }
        public Tuple<Point, Point> L2 { get; set; }
        public Tuple<Point, Point> L3 { get; set; }
        public Tuple<Point, Point> L4 { get; set; }

        private Graphics vector;
        private Pen pen;
        private PictureBox pictureBox;

        public Cuadro() { }
        public Cuadro(Point _p1, Point _p2, Point _p3, Point _p4, PictureBox pic)
        {
            P1 = _p1;
            P2 = _p2;
            P3 = _p3;
            P4 = _p4;

            //Seteando pictureBox (Lienzo)
            pictureBox = pic;

            //Creando lineas
            L1 = new Tuple<Point, Point>(_p1, _p2);
            L2 = new Tuple<Point, Point>(_p2, _p3);
            L3 = new Tuple<Point, Point>(_p3, _p4);
            L4 = new Tuple<Point, Point>(_p4, _p1);
        }

        public void Draw()
        {
            pen = new Pen(Color.Black);
            vector = pictureBox.CreateGraphics();
            vector.Clear(Color.White);
            vector.DrawLine(pen, P1, P2);
            vector.DrawLine(pen, P2, P3);
            vector.DrawLine(pen, P3, P4);
            vector.DrawLine(pen, P4, P1);

            //Liberando memoria
            vector.Dispose();
            pen.Dispose();
        }

    }
}
