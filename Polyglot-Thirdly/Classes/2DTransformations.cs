using System;

namespace Polyglot_Thirdly.Classes
{
    //Definiendo matrices
    public static class _2DTransformations
    {
        //Matriz T, para calcular traslacion
        public static int[,] T(int a, int b)
        {
            return new int[3,3] { {1,0,a},{0,1,b},{0,0,1} };
        }

        //Matriz S, para calcular escalado
        public static int[,] S(int n)
        {
            return new int[3, 3] { { n, 0, 0 }, { 0, n, 0 }, { 0, 0, 1 } };
        }

        //Matriz R, Para calcular rotacion en sentido antihorario
        public static int[,] R_Counter(int z)
        {
            return new int[3, 3] { { Convert.ToInt32(Math.Ceiling(Math.Cos(z))), Convert.ToInt32(Math.Ceiling(Math.Sin(z))), 0 }, 
                                    { -1*Convert.ToInt32(Math.Ceiling(Math.Sin(z))), Convert.ToInt32(Math.Ceiling(Math.Cos(z))) , 1 },
                                    { 0, 0, 1} };
        }
    }
}
