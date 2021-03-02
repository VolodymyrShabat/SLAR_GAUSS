using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra
{
    class Vector
    {
        public int[] vector;
        public Vector(int[] vector)
        {
            this.vector = vector;
        }
        public Vector(int Lenght)
        {
            this.vector = new int[Lenght];
        }
        public void GenerateVector(int left, int right)
        {
            Random r = new Random();
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = r.Next(left, right);
            }
        }
    }
}
