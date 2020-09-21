using System;
using System.Collections.Generic;
using System.Linq;

namespace entra21_tests
{
    class array01
    {
        public double[] AExercise1(double[] a, double[] b)
        {
            var result = new double[10];
            for (int i = 0; i < b.Length; i++)
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }

        public double[] AExercise2(double[] a)
        {
            var result = new double[10];
            for (int i = 0; i < a.Length; i++)
            {
                result[a.Length-i] = a[i];
            }
            return result;
        }
    }
}