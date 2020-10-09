using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Exercises
    {
        public int[] Exercise1A()
        {
            var numbers = new int[10];

            for (int counter = 1; counter < 11; counter++)
            {
				numbers[counter - 1] = counter;
            }

            return numbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1b,
        // então a aplicação deverá retornar todos os números de 1 a 10 de forma decrescente
        public int[] Exercise1B()
        {
            int[] numbers = new int[10];
            
            for (int counter = 10; counter > 0; counter--)
            {
                numbers[numbers.Length - counter] = counter;
            }

            return numbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1c,
        // então a aplicação deverá retornar os números de 1 a 10, mas somente os pares
        public int[] Exercise1C()
        {
            var numbers = new int[5];

            for (int counter = 2; counter < 11; counter+=2)
            {
                var index = (counter / 2) - 1;
				numbers[index] = counter;
            }

            return numbers;
        }


        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 2,
        // então a aplicação deverá retornar a soma dos numeros inteiros de 1 a 100
        public int Exercise2()
        {
            var sum = 0;
            for (int counter = 1; counter < 101; counter++)
            {
                sum += counter;
            }
            return sum;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 3,
        // então a aplicação deverá retornar um array com os numeros impares menores que 200
        public int[] Exercise3()
        {
            var numbers = new int[100];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i*2+1;
            }
            return numbers;
        }

        public double Exercise4(List<int> ages)
        {
            return (double)ages.Sum() / ages.Count;
        }

        public double Exercise5(double[] yo)
        {
            var womenBetween18And35 = 0;
            for (int i = 0; i < yo.Length; i++)
            {
                if( (yo[i] >= 18) && (yo[i] <= 35) )
                {
                    womenBetween18And35++;
                }
            }
            var result = womenBetween18And35 * 100 / 5;
            return result;
        }

        public string Exercise6(int[] op, string pw, string[] cand, int[] vote)
        {
            const int registerMode = 1;
            const int votesMode = 2;
            const int resultMode = 3; 

            var candidates = new (string name, int votes)[2];
            var mode = 0;
            var result = "";
            for (int i = 0; i < op.Length; i++)
            {
                mode = op[i];
                if(mode == registerMode)
                {
                    var password = pw;
                    while (password != "Pa$$w0rd")
                    {
                        System.Console.WriteLine("Informe a senha para cadastrar candidatos: ");
                        password = pw;
                    }
                    for (int j = 0; j < candidates.Length; j++)
                    {
                        candidates[j].name = cand[j];
                    }
                }else if(mode == votesMode)
                {
                    for (int k = 0; k < vote.Length; k++)
                    {
                        candidates[vote[k] - 1].votes++;
                    }
                }else if(mode == resultMode)
                {
                    break;
                }
            }
            if (candidates[0].votes == candidates[1].votes)
            {
                System.Console.WriteLine("Segundo turno!");
            }else
            {
                var winner = candidates[0];
                for (int i = 1; i < candidates.Length; i++)
                {
                    var currentCandidates = candidates[i];
                    if(currentCandidates.votes > winner.votes)
                    {
                        winner = candidates[i]; 
                    }
                }
                result = ($"O vencedor é {winner.name}, com o total de {winner.votes} votos");
            }
            return result;
        }

        public double Exercise7(int years, int cigarByDay, double priceForCigarWallet)
        {
            var result = ((priceForCigarWallet / 20) * cigarByDay * (years * 365));
            return result;
        }

        public double Exercise8(int n1, int n2)
        {
            var result = n1 % n2;
            return result;
        }

        public bool Exercise9(double n1, double n2, double n3)
        {
            var result = false;
            if(n1 > (n2 + n3))
            {
                result = true;
            }
            return result;
        }

        public string Exercise10(double n1, double n2)
        {
            var result = "";
            if( n1 > n2)
            {
                result = ($"O número {n1} é maior que o número {n2}.");
            }else if( n1 < n2)
            {
                result = ($"O número {n1} é menor que o número {n2}.");
            }else
            {
                result = ("A = B");
            }
            return result;
        }

        public double Exercise11(int n1, int n2)
        {
            var result = 0;
            if(n2 != 0)
            {
                result = (n1/n2);
            }
            return result;
        }

        public double Exercise12(int[] n)
        {
            var result = 0;
            for(var i = 0 ; i < n.Length ; i++)
            {
                if(( n[i] % 2 ) == 0)
                {
                    result += n[i];
                }
            }
            return result;
        }

        public double Exercise13(double[] n)
        {
            var result = double.MinValue;
            for(var i = 0 ; i < n.Length ; i++)
            {
                if(n[i] > result)
                {
                    result = n[i];
                }
            }
            return result;
        }

        public double[] Exercise14(double[] num)
        {
            var result = new double[3];
            if(num[0] > num[1] && num[0] > num[2])
            {
                var temp = num[2];
                num[2] = num[0];
                num[0] = temp;
            }
            if(num[1] > num[0] && num[1] > num[2])
            {
                var temp = num[2];
                num[2] = num[1];
                num[1] = temp;
            }
            if(num[0] > num[1])
            {
                var temp = num[1];
                num[1] = num[0];
                num[0] = temp;
            }
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = num[i];
            }
            return result;
        }

        public int[] Exercise15(double[] num)
        {
            var result = new int[2];
            for (int i = 0; i < num.Length; i++)
            {
                if((num[i] % 3) == 0)
                {
                    result[0]++;
                }
                if((num[i] % 5) == 0)
                {
                    result[1]++;
                }
            }
            return result;
        }

        public int[] Exercise16(double[] num)
        {
            var result = new int[2];
            for (int i = 0; i < num.Length; i++)
            {
                if((num[i] % 3) == 0)
                {
                    result[0]++;
                }
                if((num[i] % 5) == 0)
                {
                    result[1]++;
                }
            }
            return result;
        }
    }
}