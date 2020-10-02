using System;
using System.Collections.Generic;
using System.Linq;

namespace entra21_tests
{
    public class Election
    {
        // Propriedade abaixo:
        // Sempre em PascalCase
        public IReadOnlyCollection<Candidate> Candidates { get; private set; }
        
        public bool CreateCandidates(List<Candidate> candidate, string password)
        {
            if (password == "Pa$$w0rd")
            {
                Candidates = candidate;

                return true;
            }
            else
            {
                return false;
            }
        }

        // ToDo: Criar método que retorne um Guid que represente o candidato pesquisado por CPF

        // ToDo: Este método deve retornar a lista de candidatos que tem o mesmo nome informado
        public Guid GetCandidateIdByName(string name)
        {
            return Candidates.First(x => x.Name == name).Id;
        }

        // public List<Guid> GetCandidatesIdByName(string name)
        // {
        //     var  foundCandidates = Candidates.Where(x => x.name == name);
        //     return foundCandidates.Select(x => x.id ).ToList();
        // }

        public List<string> GetCandidatesCpfByName(string name)
        {
            var  foundCandidates = Candidates.Where(x => x.Name == name);
            return foundCandidates.Select(x => x.Cpf).ToList();
        }

        public Guid GetCandidateIdByCpf(string cpf)
        {
            return Candidates.First(x => x.Cpf == cpf).Id;
        }

        public void Vote(Guid id)
        {
            Candidates.First(candidate => candidate.Id == id).Votes++;
                    //return candidate.Id == id
                    //? (Candidate.Vote +1)
                    //: candidate;
           // }).ToList();
        }

        public List<Guid> GetCandidatesIdByName(string name)
        {
            var foundCandidates = Candidates.Where(x => x.Name == name);
            return foundCandidates.Select(x => x.Id).ToList();
        }

        public List<Candidate> GetCandidatesByName(string name)
        {
            var foundCandidates = Candidates.Where(x => x.Name == name);
            return foundCandidates.ToList();
        }

        public List<Candidate> GetWinners()
        {
            var winners = new List<Candidate>{Candidates.First()};

            foreach (var item in Candidates)
            {
                if (item.Votes > winners[0].Votes)
                {
                    winners.Clear();
                    winners.Add(item);
                }
                else if (item.Votes == winners[0].Votes)
                {
                    winners.Add(item);
                }
            }
            return winners;
        }
    }
}