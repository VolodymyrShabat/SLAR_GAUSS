using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SLAR
    {
        public Matrix A;
        public Vector b;
        public int[] x;
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

        public double GaussMethod()
        {
            double[] result = new double[A.n];
            for (int i = 0; i < A.n; i++)
            {
                double[] tempResult = A.FindMaxIndex(i);
                //Console.WriteLine(tempResult[0]);
                A.Swap((int)tempResult[0], i);
                A[i] = (new Vector(A[i])/tempResult[1]).vector;

                for (int j = i+1; j < A.n; j++)
                {

                    A[j] = ((new Vector(A[i]) * A[j][i]) - new Vector(A[j])).vector;
                }
                //Console.WriteLine();
                Console.WriteLine(A.ToString());
            }
            result[A.n-1] =A[A.n-1][A.m - 1];
            //Console.WriteLine(result[A.n - 1] + "gdfgdfgdf" );



            //Обратный цикл
            for (int i =1; i <A.n; i++)
            {
                double[] temp = new double[i];
                for (int j = 0; j <i; j++)
                {
                    temp[j]=result[A.n-j-1] * A.matrix[A.m - i - 2, A.m - j-2];
                    //Console.WriteLine(result[A.n - j-1] + "*" + A.matrix[A.m - i-2 , A.m - j-2]);
                }
                result[A.n - 1-i] = A.matrix[A.n-1-i, A.m - 1];
                //foreach (var item in temp)
                //{
                //    Console.Write(item+ " ");
                //}
                ////Console.WriteLine();
                for (int k = 0; k < temp.Length; k++)
                {
                    result[A.n - 1 - i] -= temp[k];
                }
                //Console.WriteLine(result[A.n - 1 - i] + " res");
                //Console.WriteLine();
            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

                return 0;
        }
    }
}
