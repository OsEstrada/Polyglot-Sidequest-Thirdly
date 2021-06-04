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

        public MainForm()
        {
            InitializeComponent();

        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            int x_c = picCanvas.Width / 2;
            int y_c = picCanvas.Height / 2;

            c = new Cuadro(new Point(x_c, y_c), new Point(x_c + 50, y_c), new Point(x_c + 50, y_c + 50), new Point(x_c, y_c + 50), picCanvas);
            c.Draw();
        }

        private void nmEscalado_ValueChanged(object sender, EventArgs e)
        {
            int x_c = picCanvas.Width / 2;
            int y_c = picCanvas.Height / 2;

            c = new Cuadro(new Point(x_c, y_c), new Point(x_c + 50, y_c), new Point(x_c + 50, y_c - 50), new Point(x_c, y_c - 50), picCanvas);
            c.Draw();
        }
    }
}
