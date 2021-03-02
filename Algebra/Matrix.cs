using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra
{
    class Matrix
    {
        public int n;
        public int m;

        public int[,] matrix;
        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            this.matrix = new int[n, m];
        }
        public void GenerateMatrix(int left, int right)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = r.Next(left, right);
                }
            }
        }
        public void ReadFromArray(string[] arr)
        {
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] temp = arr[i].Split(",");
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(temp[j]);
                }
            }
            this.matrix = matrix;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result += matrix[i, j] + " " ;
                }
                result += "\n";
            }
            return result;
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.n != m2.n && m1.m != m2.m)
            {
                return null;
            }
            else
            {
                Matrix result = new Matrix(m1.n, m1.m);
                for (int i = 0; i < m1.n; i++)
                {
                    for (int j = 0; j < m1.m; j++)
                    {
                        result.matrix[i, j] = m1.matrix[i, j] + m2.matrix[i, j];
                    }
                }
                return result;
            }

        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.n != m2.n && m1.m != m2.m)
            {
                return null;
            }
            else
            {
                Matrix result = new Matrix(m1.n, m1.m);
                for (int i = 0; i < m1.n; i++)
                {
                    for (int j = 0; j < m1.m; j++)
                    {
                        result.matrix[i, j] = m1.matrix[i, j] - m2.matrix[i, j];
                    }
                }
                return result;
            }

        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.m != m2.n)
            {
                return null;
            }
            else
            {
                Matrix result = new Matrix(m1.n, m2.m);
                for (int i = 0; i <= m1.n; i++)
                {
                    for (int j = 0; j < m2.m; j++)
                    {
                        for (int k = 0; k < m1.n; k++)
                        {
                            result.matrix[i, j] += m1.matrix[i, k] * m2.matrix[k, j];
                        }
                    }
                }
                return result;
            }

        }
    }
}

