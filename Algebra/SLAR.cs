using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra
{
    class SLAR
    {
        public Matrix A;
        public Vector b;
        public int[] x;
        public StringBuilder Steps = new StringBuilder();
        public Matrix A_1;
        public Matrix Copy;


        public SLAR(Matrix m)
        {
            double[] vector_b = new double[m.n];
            for (int i = 0; i < m.n; i++)
            {
                vector_b[i] = m[i, m.m - 1];
            }
            this.A = m;
            this.b = new Vector(vector_b);
            this.x = new int[A.n];
            A_1 = new Matrix(A.n, A.m);
            Copy = new Matrix(A.n, A.m);
            for (int i = 0; i < A_1.n; i++)
            {
                A_1[i] = new Vector(A[i]).vector;
                Copy[i] = new Vector(A[i]).vector;
            }
        }

        public Matrix Inversion()
        {
            Matrix A1 = new Matrix(A_1.n, A_1.n);

            for (int i = 0; i < A_1.n; i++)
            {
                for (int j = 0; j < A_1.n; j++)
                {
                    if (i == j)
                    {
                        A1[i, j] = 1;
                    }
                }
            }
            Matrix mInv = new Matrix(A.n, A.n);
            for (int i = 0; i < A_1.n; i++)
            {
                for (int k = 0; k < A_1.n; k++)
                {
                    A_1[k] = new Vector(Copy[k]).vector;
                }
                for (int j = 0; j < A_1.n; j++)
                {
                    A_1[j, A_1.m - 1] = A1[i, j];
                }
                mInv[i] = GaussMethod(A_1);
            }
            return mInv;
        }


        public double[] GaussMethod(Matrix matrix)
        {
            double[] result = new double[matrix.n];
            //Формування східчастої матриці
            for (int i = 0; i < matrix.n; i++)
            {
                double[] tempResult = matrix.FindMaxIndex(i);

                matrix.Swap((int)tempResult[0], i);
                matrix[i] = (new Vector(matrix[i]) / tempResult[1]).vector;

                for (int j = i + 1; j < matrix.n; j++)
                {

                    matrix[j] = ((new Vector(matrix[i]) * matrix[j][i]) - new Vector(matrix[j])).vector;
                }
                Steps.Append(matrix.ToString());
                Steps.Append("\n");
            }
            result[matrix.n - 1] = matrix[matrix.n - 1][matrix.m - 1];



            //Обернений цикл
            for (int i = 1; i < matrix.n; i++)
            {
                double[] temp = new double[i];
                for (int j = 0; j < i; j++)
                {
                    temp[j] = result[matrix.n - j - 1] * matrix.matrix[matrix.m - i - 2, A.m - j - 2];
                }
                result[matrix.n - 1 - i] = matrix.matrix[matrix.n - 1 - i, matrix.m - 1];
                for (int k = 0; k < temp.Length; k++)
                {
                    result[matrix.n - 1 - i] -= temp[k];
                }
            }



            for (int i = 0; i < result.Length; i++)
            {
                result[i]=Math.Round(result[i]);
            }


            return result;
        }
    }
}
