using System;
using System.Drawing;
using System.Windows.Forms;

namespace Polyglot_Thirdly.Classes
{
    public class Cuadro
    {

        //Puntos reales que se graficaran en pantalla
        private Point[] Points;
        //Puntos en un sistema relativo centrado en 0, con y positiva hacia arriba.
        private Point[] RelativePoints;
        private Graphics vector;
        private Pen pen;
        private PictureBox pictureBox;
        //Tamaño original de una linea
        public int OriginalSize { get; set; }
        //Lineas
        public Tuple<Point, Point> L1 { get; set; }
        public Tuple<Point, Point> L2 { get; set; }
        public Tuple<Point, Point> L3 { get; set; }
        public Tuple<Point, Point> L4 { get; set; }
        public Point[] GetPoints { get => Points; }
        public Point[] GetRelativePoints { get => Points; }


        public Cuadro() { }
        public Cuadro(Point _p1, Point _p2, Point _p3, Point _p4, PictureBox pic)
        {
            Points = new Point[4];
            RelativePoints = new Point[4];

            Points[0] = _p1;
            Points[1] = _p2;
            Points[2] = _p3;
            Points[3] = _p4;

            //Seteando pictureBox (Lienzo)
            pictureBox = pic;

            //Creando lineas
            L1 = new Tuple<Point, Point>(Points[0], Points[1]);
            L2 = new Tuple<Point, Point>(Points[1], Points[2]);
            L3 = new Tuple<Point, Point>(Points[2], Points[3]);
            L4 = new Tuple<Point, Point>(Points[3], Points[0]);
        }

        public void SetRelativePoints()
        {
            RelativePoints[0].X = 0; RelativePoints[0].Y = 0;
            RelativePoints[1].X = 0 + OriginalSize; RelativePoints[1].Y = 0;
            RelativePoints[2].X = 0 + OriginalSize; RelativePoints[2].Y = 0 + OriginalSize;
            RelativePoints[3].X = 0; RelativePoints[3].Y = 0 + OriginalSize;
        }
        //Funcion para almacenar los puntos relativos en el indice i
        public void SetRelativePoint(int i, int x, int y, decimal[] r)
        {
            RelativePoints[i].X = Convert.ToInt32(x + r[0]);
            RelativePoints[i].Y = Convert.ToInt32(y + r[1]);
        }
        //Funcion para almacenar puntos reales en el indice i
        public void SetPoint(int i, int x, int y ,decimal[] r)
        {
            Points[i].X = Convert.ToInt32( x + r[0]);
            Points[i].Y = Convert.ToInt32( y - r[1]);
        }

        public Point GetPoint(int i)
        {
            return Points[i];
        }

        public Point GetRelativePoint(int i)
        {
            return RelativePoints[i];
        }

        public void Draw()
        {
            pen = new Pen(Color.Black);
            vector = pictureBox.CreateGraphics();
            vector.Clear(Color.White);
            vector.DrawLine(pen, Points[0], Points[1]);
            vector.DrawLine(pen, Points[1], Points[2]);
            vector.DrawLine(pen, Points[2], Points[3]);
            vector.DrawLine(pen, Points[3], Points[0]);

            //Liberando memoria
            vector.Dispose();
            pen.Dispose();
        }

    }
}
