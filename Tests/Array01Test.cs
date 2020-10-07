using System.Collections.Generic;
using System.Linq;
using Domain;
using Xunit;

namespace Tests
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
            var array01 = new Array01();

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
            var array01 = new Array01();

            // Quando / Ação
            var result = array01.AExercise2(a);

            // Deve / Asserções

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }

        [Theory]
        [InlineData(new double[10]{1,2,3,4,5,6,7,8,9,10}, 2, "O número existe no array")]
        [InlineData(new double[10]{2,4,8,16,32,64,128,256,512,1024}, 16, "O número existe no array")]
        [InlineData(new double[10]{4,8,12,16,20,24,28,32,36,40}, 50, "Número inexistente")]
        public void test_exercise3_of_array01(double[] a, double num, string expected)
        {
            // Dado / Setup
            var array01 = new Array01();

            // Quando / Ação
            var result = array01.AExercise3(a, num);

            // Deve / Asserções

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new double[10]{1,2,3,4,5,6,7,8,9,10}, new double[10]{1,2,3,4,5,6,7,8,9,10}, "As listas são iguais")]
        [InlineData(new double[10]{2,4,8,16,32,64,128,256,512,1024}, new double[10]{1,3,3,4,5,6,7,8,9,10}, "As listas são diferentes")]
        [InlineData(new double[10]{4,8,12,16,20,24,28,32,36,40}, new double[10]{4,8,12,16,20,24,28,32,36,40}, "As listas são iguais")]
        public void test_exercise4_of_array01(double[] a, double[] b, string expected)
        {
            // Dado / Setup
            var array01 = new Array01();

            // Quando / Ação
            string result = array01.AExercise4(a, b);

            // Deve / Asserções

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new double[15]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15}, new int[3]{7,1,7})]
        [InlineData(new double[15]{2,4,8,16,32,64,128,256,512,1024,2048,4096,8192,16384,32768}, new int[3]{12,0,3})]
        [InlineData(new double[15]{4,8,12,16,20,24,28,32,36,40,44,48,52,56,60}, new int[3]{7,1,7})]
        public void test_exercise5_of_array01(double[] a, int[] expected)
        {
            // Dado / Setup
            var array01 = new Array01();

            // Quando / Ação
            var result = array01.AExercise5(a);

            // Deve / Asserções

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData
        (new double[12]{12,5,8,9,2,6,3,4,7,11,10,1}, new double[12]{54,56,32,17,69,51,24,35,85,6,41,25}, new double[12]{18,28,34,34,40,42,47,56,58,59,71,86})]
        public void test_exercise6_of_array01(double[] a, double[] b, double[] expected)
        {
            // Dado / Setup
            var array01 = new Array01();

            // Quando / Ação
            var result = array01.AExercise6(a, b);

            // Deve / Asserções
            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
            Assert.Equal(expected, result);
        }
    }
}
