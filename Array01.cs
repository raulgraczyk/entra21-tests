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
                result[a.Length-(i+1)] = a[i];
            }
            return result;
        }

        public string AExercise3(double[] a, double num)
        {
            //Leia 10 elementos e armazene em um array A. 
            //Em seguida, solicite pelo teclado um número 
            //qualquer e pesquise no array se o número existe. 
            //Caso, seja verdade imprima a mensagem: 
            //“O número existe no array” , 
            //caso contrário “Número inexistente”.
            var result = "Número inexistente";
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] == num)
                {
                    result = ("O número existe no array");
                    return result;
                }
            }
            return result;
        }

        public string AExercise4(double[] a, double[] b)
        {
            //Leia 10 elementos e armazene em um array A. 
            //Em seguida, solicite pelo teclado um número 
            //qualquer e pesquise no array se o número existe. 
            //Caso, seja verdade imprima a mensagem: 
            //“O número existe no array” , 
            //caso contrário “Número inexistente”.
            var result = "As listas são iguais";
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] != b[i])
                {
                    result = ("As listas são diferentes");
                    return result;
                }
            }
            return result;
        }

        public int[] AExercise5(double[] a)
        {
            //Leia um array A com 15 elementos, e calcule a média aritmética dos mesmos, 
            //em seguida, diga quantos dos elementos lidos estão abaixo, acima e na média.
            var result = new int[3];
            var media = 0.0;
            var sum = 0.0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            media = sum/a.Length;
            foreach (var item in a)
            {
                if(item < media)
                {
                    result[0]++;
                }else if(item == media)
                {
                    result[1]++;
                }else
                {
                    result[2]++;
                }
            }
            return result;
        }
    }
}