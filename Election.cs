using System.Collections.Generic;

namespace entra21_tests
{
    class Election
    {
        //propriedade abaixo:
        //sempre em PascalCase
        //public int Candidates
        public bool CreateCandidates(List<(int id, string name)> candidates, string password)
        {
            if(password == "Pa$$w0rd")
            {
                var myCandidates = candidates;
                return true;
            }
            else
            {
                return false;
            }
        }

        // public bool GetCandidates()
        // {
        //     return 
        // }
    }
}