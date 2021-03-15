using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra
{
    class Vector : ICloneable
    {
        public double[] vector;
        public Vector(double[] vector)
        {
            this.vector = vector;
        }
        public Vector(int Lenght)
        {
            this.vector = new double[Lenght];
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void GenerateVector(int left, int right)
        {
            Random r = new Random();
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = r.Next(left, right);
            }
        }

        public static Vector operator *(Vector v1, double number)
        {
            Vector temp = (Vector)v1.Clone();
            for (int i = 0; i < v1.vector.Length; i++)
            {
                temp.vector[i] = v1.vector[i] * number;
            }
            return temp;
        }
        public static Vector operator /(Vector v1, double number)
        {
            Vector temp = (Vector)v1.Clone();
            for (int i = 0; i < v1.vector.Length; i++)
            {
                temp.vector[i] = v1.vector[i] / number;
            }
            return temp;
        }


        public static Vector operator -(Vector v1, Vector v2)
        {
            if (v1.vector.Length != v2.vector.Length)
            {
                throw new NotImplementedException();
            }
            Vector resultVector = new Vector(v1.vector.Length);
            for (int i = 0; i < v1.vector.Length; i++)
            {
                resultVector.vector[i] = v1.vector[i] - v2.vector[i];
            }
            return resultVector;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < vector.Length; i++)
            {
                s += vector[i] + " ";
            }
            return s;
        }
    }
}
