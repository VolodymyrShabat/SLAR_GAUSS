using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SLAR
    {
        public Matrix A;
        public Vector b;
        public Matrix A_1;
        public int[] x;
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


        public void Inversion()
        {
            Console.WriteLine(A_1);
            Matrix A1 = new Matrix(A_1.n, A_1.n);
           
            for (int i = 0; i < A_1.n; i++)
            {
                for (int j = 0; j < A_1.n; j++)
                {
                    if(i==j)
                    {
                        A1[i, j] = 1;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < A.n; i++)
            {
                Console.WriteLine(new Vector(A1[i]).ToString());
            }
            Console.WriteLine();
            Console.WriteLine();
            Matrix mInv = new Matrix(A.n, A.n);
            for (int i = 0; i < A_1.n; i++)
            {
                for (int k = 0; k < A_1.n; k++)
                {
                    A_1[k] = new Vector(Copy[k]).vector;
                }
                for (int j = 0; j < A_1.n; j++)
                {
                    A_1[j, A_1.m - 1] = A1[i,j];
                }
                Console.WriteLine(A_1.ToString());
                mInv[i]=GaussMethod(A_1);
            }
            Console.WriteLine(mInv.ToString());
            Console.WriteLine(Copy*mInv);
        }

        public double[] GaussMethod(Matrix matrix)
        {
            double[] result = new double[matrix.n];
            
            for (int i = 0; i < matrix.n; i++)
            {
                double[] tempResult = matrix.FindMaxIndex(i);
                //Console.WriteLine(tempResult[0]);
                matrix.Swap((int)tempResult[0], i);
                matrix[i] = (new Vector(matrix[i])/tempResult[1]).vector;

                for (int j = i+1; j < matrix.n; j++)
                {

                    matrix[j] = ((new Vector(matrix[i]) * matrix[j][i]) - new Vector(matrix[j])).vector;
                }
                //Console.WriteLine();
                Console.WriteLine(A.ToString());
            }
            result[matrix.n-1] = matrix[matrix.n-1][matrix.m - 1];
            //Console.WriteLine(result[A.n - 1] + "gdfgdfgdf" );



            //Обернений цикл
            for (int i =1; i < matrix.n; i++)
            {
                double[] temp = new double[i];
                for (int j = 0; j <i; j++)
                {
                    temp[j]=result[matrix.n-j-1] * matrix.matrix[matrix.m - i - 2, matrix.m - j-2];
                    //Console.WriteLine(result[A.n - j-1] + "*" + A.matrix[A.m - i-2 , A.m - j-2]);
                }
                result[matrix.n - 1-i] = matrix.matrix[matrix.n-1-i, matrix.m - 1];
                //foreach (var item in temp)
                //{
                //    Console.Write(item+ " ");
                //}
                ////Console.WriteLine();
                for (int k = 0; k < temp.Length; k++)
                {
                    result[matrix.n - 1 - i] -= temp[k];
                }
                //Console.WriteLine(result[A.n - 1 - i] + " res");
                //Console.WriteLine();
            }
            for (int i = 0; i < result.Length; i++)
            {
                Math.Round(result[i]);
            }
            return result;
        }
    }
}
