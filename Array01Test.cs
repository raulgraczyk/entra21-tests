using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace entra21_tests
{
    public class Array01Test
    {
        [Theory]
        [InlineData(new double[10]{1,2,3,4,5,6,7,8,9,10}, new double[10]{1,2,3,4,5,6,7,8,9,10}, new double[10]{0,0,0,0,0,0,0,0,0,0})]
        [InlineData(new double[10]{2,4,8,16,32,64,128,256,512,1024}, new double[10]{2,3,6,13,28,59,122,249,504,1015}, new double[10]{0,1,2,3,4,5,6,7,8,9})]
        [InlineData(new double[10]{4,8,12,16,20,24,28,32,36,40}, new double[10]{2,4,6,8,10,12,14,16,18,20}, new double[10]{2,4,6,8,10,12,14,16,18,20})]
        public void test_exercise1_of_array01(double[] a, double[] b, double[] expected)
        {
            // Dado / Setup
            var array01 = new array01();

            // Quando / Ação
            var result = array01.AExercise1(a,b);

            // Deve / Asserções

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new double[10]{1,2,3,4,5,6,7,8,9,10}, new double[10]{10,9,8,7,6,5,4,3,2,1})]
        [InlineData(new double[10]{2,4,8,16,32,64,128,256,512,1024}, new double[10]{1024,512,256,128,64,32,16,8,4,2})]
        [InlineData(new double[10]{4,8,12,16,20,24,28,32,36,40}, new double[10]{40,36,32,28,24,20,16,12,8,4})]
        public void test_exercise2_of_array01(double[] a, double[] expected)
        {
            // Dado / Setup
            var array01 = new array01();

            // Quando / Ação
            var result = array01.AExercise2(a);

            // Deve / Asserções

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
    }
}
