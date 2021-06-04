using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyglot_Thirdly.Classes
{
    public static class Math_Tools
    {
        public static void Zeroes(int[,] M, int n)
        {
            for(int i = 0; i < n; i++)
                for(int j = 0; j<n; j++)
                {
                    M[i, j] = 0;
                }
        }

        public static void Zeroes(int[] V, int n)
        {
            for (int i = 0; i < n; i++)
                V[i] = 0;
        }

        public static int calculateMember(int i, int j, int r, int[,] A, int[,] B)
        {
            int member = 0;
            for (int k = 0; k < r; k++)
                member += A[i, k] * B[k, j];
            return member;
        }

        public static int[,] productMatrixMatrix(int[,] A, int[,] B, int n, int r, int m)
        {
            int[,] R = new int[3,3];

            Zeroes(R, n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    R[i, j] = calculateMember(i, j, r, A, B);

            return R;
        }

        public static void productMatrixVector(int[,] A, int[] v, int[] R, int n)
        {
            for (int i = 0; i < n; i++)
            {
                int cell = 0;
                for (int c = 0; c < n; c++)
                {
                    cell += A[i, c] * v[c];
                }
                R[i] += cell;
            }
        }
    }
}
