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
        }

        public string GaussMethod()
        {
            double[] result = new double[A.n];
            //Формування східчастої матриці
            for (int i = 0; i < A.n; i++)
            {
                double[] tempResult = A.FindMaxIndex(i);

                A.Swap((int)tempResult[0], i);
                A[i] = (new Vector(A[i]) / tempResult[1]).vector;

                for (int j = i + 1; j < A.n; j++)
                {

                    A[j] = ((new Vector(A[i]) * A[j][i]) - new Vector(A[j])).vector;
                }
                Steps.Append(A.ToString());
                Steps.Append("\n");
    }
            result[A.n - 1] = A[A.n - 1][A.m - 1];



            //Обернений цикл
            for (int i = 1; i < A.n; i++)
            {
                double[] temp = new double[i];
                for (int j = 0; j < i; j++)
                {
                    temp[j] = result[A.n - j - 1] * A.matrix[A.m - i - 2, A.m - j - 2];
                }
                result[A.n - 1 - i] = A.matrix[A.n - 1 - i, A.m - 1];
                for (int k = 0; k < temp.Length; k++)
                {
                    result[A.n - 1 - i] -= temp[k];
                }
            }



            //Формування відповіді
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                s.Append("x_" + (i+1) + "= " + result[i] + "\n");
            }
           
            
            return s.ToString();
        }
    }
}
