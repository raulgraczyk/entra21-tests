using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain
{
    public class Candidate
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public int Votes { get; private set; }

        public Candidate(string name, string cpf)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cpf = cpf;
            Votes = 0;
        }

        public void Vote()
        {
            Votes++;
        }
        
        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateCpf())
            {
                errors.Add("CPF inválido.");
            }
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }

        // public (bool,bool) Validate()
        // {
        //     (bool,bool) result;
        //     result = (candidate.Cpf.ValidateCpf(),candidate.Name.ValidateName());
             
        //     return result;
        // }

        private bool ValidateCpf()
        {
            if (string.IsNullOrEmpty(Cpf))
            {
                return false;
            }

            var cpf = Cpf.Replace(".", "").Replace("-", "");
            
            if (cpf.Length != 11)
            {
                return false;
            }

            if (!cpf.All(char.IsNumber))
            {
                return false;
            }

            var first = cpf[0];
            if (cpf.Substring(1, 10).All(x => x == first))
            {
                var teste = false;
                return teste;
            }

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temp;
            string digit;
            int sum;
            int rest;

            temp = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(temp[i].ToString()) * multiplier1[i];
            }

            rest = sum % 11;

            rest = rest < 2 ? 0 : 11 - rest;

            digit = rest.ToString();
            temp += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(temp[i].ToString()) * multiplier2[i];
            }

            rest = sum % 11;

            rest = rest < 2 ? 0 : 11 - rest;

            digit += rest.ToString();

            if (cpf.EndsWith(digit))
            {
                return true;
            }

            return false;
        }

        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            //var name = Name.Trim();
            var name = Name;

            if (Name.Length < 2)
            {
                return false;
            }

            if (Regex.IsMatch(name, "[^a-zA-ZáéíóúàâêôãõüçÁÉÍÓÚÀÂÊÔÃÕÜÇ ]", RegexOptions.Compiled))
            {
                return false;
            }

            var nameCompost = name.Split(" ");

            if (nameCompost.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < nameCompost.Length; i++)
            {
                if((nameCompost[i] == null) || (nameCompost[i] == "") || (nameCompost[i].Length < 2))
                {
                    return false;
                }
            }

            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');
            if (words.Length < 2)
            {
                return false;
            }

            foreach (var word in words)
            {
                if (word.Trim().Length < 2)
                {
                    return false;
                }
                if (word.Any(x => !char.IsLetter(x)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}