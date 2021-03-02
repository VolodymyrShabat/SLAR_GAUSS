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
        public SLAR(Matrix m, Vector v)
        {
            this.A = m;
            this.b = v;
            this.x = new int[A.n];
        }
    }
}
