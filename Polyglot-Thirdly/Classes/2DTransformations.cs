using System;

namespace Polyglot_Thirdly.Classes
{
    //Definiendo matrices
    public static class _2DTransformations
    {
        //Matriz T, para calcular traslacion
        public static decimal[,] T(decimal a, decimal b)
        {
            return new decimal[3,3] { {1,0,a},{0,1,b},{0,0,1} };
        }

        //Matriz S, para calcular escalado
        public static decimal[,] S(decimal n)
        {
            return new decimal[3, 3] { { n, 0, 0 }, { 0, n, 0 }, { 0, 0, 1 } };
        }

        //Matriz R, Para calcular rotacion en sentido antihorario
        public static decimal[,] R_Counter(double z)
        {
            return new decimal[3, 3] { { Convert.ToDecimal(Math.Round(Math.Cos(z))), Convert.ToDecimal(Math.Round(Math.Sin(z))), 0 }, 
                                    { -1*Convert.ToDecimal(Math.Round(Math.Sin(z))), Convert.ToDecimal(Math.Round(Math.Cos(z))) , 0 },
                                    { 0, 0, 1} };
        }
        public static decimal[,] R_ClockWise(double z)
        {
            return new decimal[3, 3] { { Convert.ToDecimal(Math.Round(Math.Cos(z))), -1*Convert.ToDecimal(Math.Round(Math.Sin(z))), 0 },
                                    { Convert.ToDecimal(Math.Round(Math.Sin(z))), Convert.ToDecimal(Math.Round(Math.Cos(z))) , 0 },
                                    { 0, 0, 1} };
        }
    }
}
