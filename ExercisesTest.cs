using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace entra21_tests
{
    public class ExercisesTest
    {
        [Fact]
        public void should_return_an_array_from_1_to_10()
        {
            // BDD - Behavior Driven Design
            // Dado, Quando, Deve

            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1,
            // então a aplicação deverá retornar todos os número de 1 a 10

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            var result = exercises.Exercise1A();

            // Deve / Asserções
            var expectedOutput = new int[10]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], result[i]);
            }
        }

        [Fact]
        public void should_return_an_array_from_10_to_1()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1b,
            // então a aplicação deverá retornar todos os números de 1 a 10 de forma decrescente

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int[] returnedValues = exercises.Exercise1B();

            // Deve / Asserções
            var expectedOutput = new int[10]
            {
                10,9,8,7,6,5,4,3,2,1
            };

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], returnedValues[i]);
            }
        }
        
        [Fact]
        public void should_return_an_array_from_1_to_10_but_only_even()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1c,
            // então a aplicação deverá retornar os números de 1 a 10, mas somente os pares

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int[] returnedValues = exercises.Exercise1C();

            // Deve / Asserções
            var expectedOutput = new int[5]
            {
                2,4,6,8,10
            };

            Assert.Equal(5, returnedValues.Length);

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], returnedValues[i]);
            }
        }

        [Fact]
        public void should_return_sum_int_1_to_100()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 2,
            // então a aplicação deverá retornar a soma dos numeros inteiros de 1 a 100

            // Dado / Setup
            var Exercises = new Exercises();

            // Quando / Ação
            int result = Exercises.Exercise2();

            // Deve / Asserções
            Assert.Equal(5050, result);
        }

        [Fact]
        public void should_return_an_array_with_odd_of_1_to_200()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 3,
            // então a aplicação deverá retornar um array com os numeros impares menores que 200

            // Dado / Setup
            var Exercises = new Exercises();

            // Quando / Ação
            int[] result = Exercises.Exercise3();

            // Deve / Asserções
            var expectedOutput = new int[]
            {
                1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,53,55,57,59,61,63,65,67,69,71,73,75,77,79,81,83,85,87,89,91,93,95,97,99,101,103,105,107,109,111,113,115,117,119,121,123,125,127,129,131,133,135,137,139,141,143,145,147,149,151,153,155,157,159,161,163,165,167,169,171,173,175,177,179,181,183,185,187,189,191,193,195,197,199
            };

            Assert.Equal(100, result.Length);

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], result[i]);
            }
        }

        // [Fact]
        // public void should_return_yo_midia_class_until_yo_equal_0()
        // {
        //     // Dado que a aplicação está preparada, enviando as idades 31, 16, 23 e 0. Quando o usuário chamar o exercício 4,
        //     // então a aplicação deverá a media 23,33

        //     // Dado / Setup
        //     var Exercises = new Exercises();
        //     var yo = new double[4]
        //     {
        //         31,16,23,0
        //     };

        //     // Quando / Ação
        //     double result = Exercises.Exercise4(yo);

        //     // Deve / Asserções
        //     //double test = ((31+16+23)/3);
        //     Assert.Equal(23.33, result);
        // }

        [Theory]
        [InlineData(new int[4]{1,2,3,4}, 2.5)]
        [InlineData(new int[5]{1,2,3,4,5}, 3)]
        [InlineData(new int[3]{15,30,45}, 30)]
        public void should_return_theAverage_of_the_parameters(int[] ages, double expected)
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 4,
            // então a aplicação deverá retornar a méida de idade dos alunos na sala.
 
            var exercises = new Exercises();
 
            // Quando / Ação
            double returnedValue = exercises.Exercise4(ages.ToList());
            Assert.Equal(expected, returnedValue);
        }

        [Fact]
        public void should_return_percent_women_between_18_and_35()
        {
            // Dado que a aplicação está preparada, enviando as idades 31, 16, 23, 18, 36. Quando o usuário chamar o exercício 4,
            // então a aplicação deverá que 40% das mulheres tem ideda entre 18 e 35 anos
            
            // Dado / Setup
            var Exercises = new Exercises();
            var yo = new double[5]
            {
                31,16,23,18,36
            };

            // Quando / Ação
            double result = Exercises.Exercise5(yo);

            // Deve / Asserções
            Assert.Equal(60, result);
        }

        [Fact]
        public void should_return_eleicao()
        {
            // Dado que a aplicação está preparada, enviando a primeira opção para cadastro, 
            // informando os 2 candidatos e atribuindo 5 votos ao primeiro e 3 votos ao segundo. 
            // Quando o usuário chamar o exercício 6, então a aplicação deverá que o primeiro canditato é o vencedor com 5 votos

            // Criar um algoritmo que simule uma urna eletrônica. Esta urna deve possuir dois
            // candidatos e possui três modos. O primeiro é o modo de CADASTRO, onde o sistema
            // pergunta o nome de cada um dos dois candidatos. Por medidas de segurança, para poder
            // cadastrar um candidato na urna o sistema deve solicitar ao usuário a senha para poder ter
            // acesso (a senha do sistema é Pa$$w0rd). O segundo modo é o modo de votos, onde o
            // usuário informa 1 para votar no primeiro candidato e 2 para votar no segundo candidato. O
            // terceiro modo, é o modo de apuração de votos, onde o sistema verifica qual candidato tem
            // mais votos. Caso o número de votos seja igual, o sistema deve imprimir a mensagem
            // &quot;SEGUNDO TURNO&quot;, caso contrário deve imprimir o nome do candidato vencedor e o
            // número de votos que ele obteve.
            
            // Dado / Setup
            var Exercises = new Exercises();
            var op = new int[3]
            {
                1,2,3
            };
            var pw = "Pa$$w0rd";
            // var candidates = new (string name, int votes)[2]
            // {
            //     ("raul", 5),("tomaz", 3)
            // };
            var cand = new string[2] {"Raul","Tomaz"};
            var vote = new int[8] {1,2,1,1,2,1,1,2};

            // Quando / Ação
            string result = Exercises.Exercise6(op, pw, cand, vote);

            // Deve / Asserções
            Assert.Equal("O vencedor é Raul, com o total de 5 votos", result);
        }

        [Fact]
        public void should_return_765131_when_passed_5y_15_c_559r()
        {
            // Dado que a aplicação está preparada, enviando 5 anos, 15 cigarros por dia e 5,59 a carteira de cigarros 
            // Quando o usuário chamar o exercício 7, então a aplicação deverá que o valor gasto com cigarros foi de 7.651,3125
            
            // Dado / Setup
            var Exercises = new Exercises();
            var years = 5;
            var cigarByDay = 15;
            var priceForCigarWallet = 5.59;

            // Quando / Ação
            double result = Exercises.Exercise7(years, cigarByDay, priceForCigarWallet);

            // Deve / Asserções
            Assert.Equal(7651.3125, result);
        }

        [Fact]
        public void should_return_0_when_passed_12_and_3()
        {
            // Dado que a aplicação está preparada, enviando 12 e 3 
            // Quando o usuário chamar o exercício 8, então a aplicação deverá 0, confirmando que 12 é multiplo de 3
            
            // Dado / Setup
            var Exercises = new Exercises();
            var n1 = 12;
            var n2 = 3;

            // Quando / Ação
            double result = Exercises.Exercise8(n1,n2);

            // Deve / Asserções
            Assert.Equal(0, result);
        }

        [Fact]
        public void should_return_true_when_passed_10_4_and_5()
        {
            // Dado que a aplicação está preparada, enviando 10, 4 e 5 
            // Quando o usuário chamar o exercício 9, então a aplicação deverá retornar true, confirmando que 10 é maior que 4 + 5
            
            // Dado / Setup
            var Exercises = new Exercises();
            var n1 = 10;
            var n2 = 4;
            var n3 = 5;

            // Quando / Ação
            bool result = Exercises.Exercise9(n1,n2,n3);

            // Deve / Asserções
            Assert.Equal(true, result);
        }

        [Fact]
        public void should_return_that_10_is_bigger_than_5()
        {
            // Dado que a aplicação está preparada, enviando 10 e 5 
            // Quando o usuário chamar o exercício 10, então a aplicação deverá retornar que 10 é maior que 5
            
            // Dado / Setup
            var Exercises = new Exercises();
            var n1 = 10;
            var n2 = 5;

            // Quando / Ação
            string result = Exercises.Exercise10(n1,n2);

            // Deve / Asserções
            Assert.Equal("O número 10 é maior que o número 5.", result);
        }

        [Fact]
        public void should_return_that_10_is_smaller_than_15()
        {
            // Dado que a aplicação está preparada, enviando 10 e 15 
            // Quando o usuário chamar o exercício 10, então a aplicação deverá retornar que 10 é menor que 15
            
            // Dado / Setup
            var Exercises = new Exercises();
            var n1 = 10;
            var n2 = 15;

            // Quando / Ação
            string result = Exercises.Exercise10(n1,n2);

            // Deve / Asserções
            Assert.Equal("O número 10 é menor que o número 15.", result);
        }

        [Fact]
        public void should_return_that_A_equal_B()
        {
            // Dado que a aplicação está preparada, enviando 5 e 5 
            // Quando o usuário chamar o exercício 10, então a aplicação deverá retornar "A = B"
            
            // Dado / Setup
            var Exercises = new Exercises();
            var n1 = 5;
            var n2 = 5;

            // Quando / Ação
            string result = Exercises.Exercise10(n1,n2);

            // Deve / Asserções
            Assert.Equal("A = B", result);
        }

        [Fact]
        public void should_return_13_when_passed_39_and_13()
        {
            // Dado que a aplicação está preparada, enviando 39 e 3 
            // Quando o usuário chamar o exercício 11, então a aplicação deverá retornar 13
            
            // Dado / Setup
            var Exercises = new Exercises();
            var n1 = 39;
            var n2 = 3;

            // Quando / Ação
            double result = Exercises.Exercise11(n1,n2);

            // Deve / Asserções
            Assert.Equal(13, result);
        }

        [Fact]
        public void should_return_6_when_passed_1_2_3_and_4()
        {
            // Dado que a aplicação está preparada, enviando 1, 2, 3 e 4 
            // Quando o usuário chamar o exercício 12, então a aplicação deverá retornar 6
            
            // Dado / Setup
            var Exercises = new Exercises();
            var n = new int[4]{1,2,3,4};

            // Quando / Ação
            double result = Exercises.Exercise12(n);

            // Deve / Asserções
            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData(new double[10]{1,10,13,14,-76,45,76,34,22,3}, 76)]
        [InlineData(new double[10]{2,20,26,28,-76,90,152,68,44,6}, 152)]
        [InlineData(new double[10]{5,19,6,56,5,19,6,4,66,1}, 66)]
        public void test_of_exercise13(double[] n, double expected)
        {
            // Dado que a aplicação está preparada, enviando 1, 2, 3 e 4 
            // Quando o usuário chamar o exercício 12, então a aplicação deverá retornar 6
            
            // Dado / Setup
            var Exercises = new Exercises();
            
            // Quando / Ação
            double result = Exercises.Exercise13(n);

            // Deve / Asserções
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new double[3]{10,-76,45}, new double[3]{-76,10,45})]
        [InlineData(new double[3]{3,2,1}, new double[3]{1,2,3})]
        [InlineData(new double[3]{-1,-2,-3}, new double[3]{-3,-2,-1})]
        public void test_of_exercise14(double[] num, double[] expected)
        {
            // Dado / Setup
            var exercises = new Exercises();
            
            // Quando / Ação
            double[] result = exercises.Exercise14(num);

            // Deve / Asserções
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new double[10]{1,2,3,4,5,6,7,8,9,10}, new int[2]{3,2})]
        [InlineData(new double[10]{2,4,8,16,32,64,128,256,512,1024}, new int[2]{0,0})]
        [InlineData(new double[10]{3,6,9,12,15,18,21,24,27,30}, new int[2]{10,2})]
        public void test_of_exercise15(double[] num, int[] expected)
        {
            // Dado / Setup
            var Exercises = new Exercises();
            
            // Quando / Ação
            int[] result = Exercises.Exercise15(num);

            // Deve / Asserções
            Assert.Equal(expected, result);
        }
    }
}
