using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Matrix
    {
        public int n { get; }
        public int m { get; }

        public double[,] matrix;
        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            this.matrix = new double[n, m];
        }
        public Matrix(double[,] arr)
        {
            this.n = arr.GetLength(0);
            this.m = arr.GetLength(1);
            this.matrix = arr;
        }

        public double[] this[int index]
        {
            get
            {
                double[] returnedArray = new double[m];
                for (int i = 0; i < m; i++)
                {
                    returnedArray[i] = matrix[index, i];
                }
                return returnedArray;
            }
            set
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[index, i] = 0;
                }
                for (int i = m - value.Length; i < m; i++)
                {
                    matrix[index, i] = value[i];
                }
            }
        }

        public void Swap(int index1, int index2)
        {
            double temp;
            for (int i = 0; i < m; i++)
            {
                temp = matrix[index1, i];
                matrix[index1, i] = matrix[index2, i];
                matrix[index2, i] = temp;
            }

        }
        public double[] FindMaxIndex(int index)
        {
            double max=-1,maxIndex = -1;
            for (int i = index; i < n; i++)
            {
                
                if(Math.Abs(this.matrix[i, index])>max)
                {
                    max = this.matrix[i, index];
                    maxIndex = i;
                }
            }
            return new double[] { maxIndex,max };
        }



        public double this[int index1, int index2]
        {
            get
            {
                return matrix[index1, index2];
            }
            set
            {
                matrix[index1, index2] = value;
            }
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
            double[,] matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] temp = arr[i].Split(",");
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = double.Parse(temp[j]);
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
                    result += matrix[i, j] + " ";
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
