using Polyglot_Thirdly.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyglot_Thirdly
{
    public partial class MainForm : Form
    {
        //Cuadro
        private Cuadro c;
        //Coordenadas centro
        private int x_c;
        private int y_c;

        //Puntos iniciales
        private Point[] pointList;

        public MainForm()
        {
            InitializeComponent();
            pointList = new Point[4];
        }

        private void setCenterCoordinates()
        {
            x_c = picCanvas.Width / 2;
            y_c = picCanvas.Height / 2;
        }
        private void setPoints()
        {
            c = new Cuadro(pointList[0], pointList[1], pointList[2], pointList[3], picCanvas);

            c.Size = 20;
            c.SetRelativePoints();

            pointList[0] = new Point(x_c,y_c);
            pointList[1] = new Point(x_c+c.Size,y_c);
            pointList[2] = new Point(x_c+c.Size,y_c-c.Size);
            pointList[3] = new Point(x_c,y_c-c.Size);
        }

        public void drawInCenter()
        {
            setCenterCoordinates();
            setPoints();
            c.Draw();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            setCenterCoordinates();
            setPoints();
            drawInCenter();
        }

        private void nmEscalado_ValueChanged(object sender, EventArgs e)
        {
            //Antes de hacer cualquier operacion se ubicara de nuevo el centro, para controlar que el cuadrado no se salga de los limites
            setCenterCoordinates();

            for(int i = 0; i< 4; i++)
            {
                int[] point = new int[3] {c.GetRelativePoint(i).X, c.GetRelativePoint(i).Y, 1 };
                int[] res = new int[3] {0, 0, 0};
                Math_Tools.productMatrixVector(_2DTransformations.S(Convert.ToInt32(nmEscalado.Value)), point, res, 3);
                c.SetPoint(i, x_c, y_c, res);
            }
            c.Draw();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (!nmRotacion.Enabled)
            {
                nmEscalado.Enabled = true;
                nmTraslacion.Enabled = true;
                nmRotacion.Enabled = true;
                drawInCenter();
            }
        }
    }
}
