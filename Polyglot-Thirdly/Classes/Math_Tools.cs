namespace Polyglot_Thirdly.Classes
{
    //Funciones con operaciones para matrices
    public static class Math_Tools
    {
        public static void Zeroes(decimal[,] M, int n)
        {
            for(int i = 0; i < n; i++)
                for(int j = 0; j<n; j++)
                {
                    M[i, j] = 0;
                }
        }

        public static void Zeroes(decimal[] V, int n)
        {
            for (int i = 0; i < n; i++)
                V[i] = 0;
        }

        public static decimal calculateMember(int i, int j, int r, decimal[,] A, decimal[,] B)
        {
            decimal member = 0;
            for (int k = 0; k < r; k++)
                member += A[i, k] * B[k, j];
            return member;
        }

        public static decimal[,] productMatrixMatrix(decimal[,] A, decimal[,] B, int n, int r, int m)
        {
            decimal[,] R = new decimal[3,3];

            Zeroes(R, n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    R[i, j] = calculateMember(i, j, r, A, B);

            return R;
        }

        public static void productMatrixVector(decimal[,] A, decimal[] v, decimal[] R, int n)
        {
            for (int i = 0; i < n; i++)
            {
                decimal cell = 0;
                for (int c = 0; c < n; c++)
                {
                    cell += A[i, c] * v[c];
                }
                R[i] += cell;
            }
        }
    }
}
