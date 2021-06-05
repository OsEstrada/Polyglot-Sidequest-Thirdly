using Polyglot_Thirdly.Classes;
using System;
using System.Drawing;
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
        //Lista de angulos
        private double[] ANGLES = { 0, Math.PI / 4.0, Math.PI, (5.0/4.0) * Math.PI, 2.0 * Math.PI };
        //Lista de niveles (1-5)
        private int[] LEVELS = { 0, 1, 2, 3, 4 };
        //Puntos iniciales
        private Point[] pointList;
        //Valores de los numericDropDown. Necesito conocer en todo momento el valor anterior
        private decimal[] values = { 1, 1, 1}; 

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

            //tamaño inicial
            c.OriginalSize = 20;

            //Posiciones relativas iniciales.
            c.SetRelativePoints();

            pointList[0] = new Point(x_c,y_c);
            pointList[1] = new Point(x_c+c.OriginalSize,y_c);
            pointList[2] = new Point(x_c+c.OriginalSize,y_c-c.OriginalSize);
            pointList[3] = new Point(x_c,y_c-c.OriginalSize);
        }

        public void drawInCenter()
        {
            setCenterCoordinates();
            setPoints();
            c.Draw();
        }

        //En caso se maximize la pantalla, todo se resetea
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            setCenterCoordinates();
            setPoints();
            drawInCenter();
            values[0] = 1; values[1] = 1; values[2] = 1;
        }

        //Funcion que reescala el cuadrado basado en su perimetro inicial
        private void nmEscalado_ValueChanged(object sender, EventArgs e)
        {
            //Antes de hacer cualquier operacion se ubicara de nuevo el centro, para controlar que el cuadrado no se salga de los limites
            for(int i = 0; i< 4; i++)
            {
                decimal[] point = new decimal[3] {c.GetRelativePoint(i).X, c.GetRelativePoint(i).Y, 1 };
                decimal[] res = new decimal[3] {0, 0, 0};
                if(nmEscalado.Value < values[0])
                    Math_Tools.productMatrixVector(_2DTransformations.S(1/(nmEscalado.Value+1)), point, res, 3);
                else 
                    Math_Tools.productMatrixVector(_2DTransformations.S(nmEscalado.Value), point, res, 3);
                c.SetPoint(i, x_c, y_c, res);
                c.SetRelativePoint(i, 0, 0, res);
            }
            values[0] = nmEscalado.Value;
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

        //OBSERVACION: Al intentar rotar hay algunos errores, por ejemplo, debido a que c# solo admite valores enteros para representar los puntos, a la hora de hacer los
        //calculos asumo que hay un error, el cual a medida mas veces se rote aumenta. Se ve reflejado con el tamaño del cuerpo, otro error es que no logre hacer que rote
        //solo el cuerpo, sino mas bien, que este rota alrededor del punto inicial (En el plano relativo seria el punto (0,0)
        //Metodo que calcula la rotacion, desde el punto inicial
        private void nmRotacion_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                decimal[] point = new decimal[3] { c.GetRelativePoint(i).X, c.GetRelativePoint(i).Y, 1 };
                decimal[] res = new decimal[3] { 0, 0, 0 };
                Math_Tools.productMatrixVector(_2DTransformations.R_Counter(ANGLES[Convert.ToInt32(nmRotacion.Value)-1]), point, res, 3);
                c.SetPoint(i, x_c, y_c, res);
                c.SetRelativePoint(i, 0, 0, res);
            }
            c.Draw();
        }
        //Metodo que calcula la traslacion desde el punto inicial
        private void nmTraslacion_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                decimal[] point = new decimal[3] { c.GetRelativePoint(i).X, c.GetRelativePoint(i).Y, 1 };
                decimal[] res = new decimal[3] { 0, 0, 0 };
                if(nmTraslacion.Value < values[2])
                    Math_Tools.productMatrixVector(_2DTransformations.T(-(LEVELS[Convert.ToInt32(nmTraslacion.Value)-1]+1) * 30, 0), point, res, 3);
                else
                    Math_Tools.productMatrixVector(_2DTransformations.T(LEVELS[Convert.ToInt32(nmTraslacion.Value) - 1] * 30, 0), point, res, 3);
                c.SetPoint(i, x_c, y_c, res);
                c.SetRelativePoint(i, 0, 0, res);
            }
            values[2] = nmTraslacion.Value;
            c.Draw();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            setCenterCoordinates();
            setPoints();
            drawInCenter();
            values[0] = 1; values[1] = 1; values[2] = 1;
            nmRotacion.Value = nmEscalado.Value = nmTraslacion.Value = 1;

        }
    }
}
