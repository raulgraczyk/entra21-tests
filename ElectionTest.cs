using System.Collections.Generic;
using Xunit;

namespace entra21_tests
{
    public class ElectionTest
    {
        [Fact]
        public void should_not_create_candidates_when_password_is_incorrect()
        {
            // Dado / Setup
            var election = new Election();
            var candidates = new List<(string, string)>{("José","180.625.639-87")};

            // Quando / Ação
            var created = election.CreateCandidates(candidates, "incorrect");

            // Deve / Asserções
            Assert.Null(election.Candidates);
            Assert.False(created);
        }

        [Fact]
        public void should_create_candidates_when_password_is_correct()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            (string name, string cpf) candidate = ("José","180.625.639-87");
            var candidates = new List<(string name, string cpf)>{candidate};

            // Quando / Ação

            // Estamos acessando o MÉTODO CreateCandidates do OBJETO election
            var created = election.CreateCandidates(candidates, "Pa$$w0rd");

            // Deve / Asserções
            Assert.True(created);
            
            // Estamos acessando a PROPRIEDADE Candidates, que faz parte do ESTADO do OBJETO election
            Assert.True(election.Candidates.Count==1);
            Assert.True(election.Candidates[0].name == candidate.name);
        }

        [Fact]
        public void should_not_generate_same_id_for_both_candidates()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            (string name, string cpf) Jose = ("José","180.625.639-87");
            (string name, string cpf) ana = ("Ana","111.222.333-44");
            var candidates = new List<(string,string)>{Jose, ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            var candidateJose = election.GetCandidateIdByName(Jose.name);
            var candidateana = election.GetCandidateIdByName(ana.name);

            // Deve / Asserções
            Assert.NotEqual(candidateana, candidateJose);
        }

        [Fact]
        public void should_vote_twice_in_candidate_Fernando()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            (string name, string cpf) ana = ("Ana","111.222.333-44");
            (string name, string cpf) fernando = ("Fernando","444.333.222-11");
            var candidates = new List<(string, string)>{fernando, ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            //var fernandoId = election.GetCandidateIdByName(fernando.name);
            //var anaId = election.GetCandidateIdByName(ana.name);
            var fernandoId = election.GetCandidateIdByCpf(fernando.cpf);
            var anaId = election.GetCandidateIdByCpf(ana.cpf);

            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            election.Vote(fernandoId);
            election.Vote(fernandoId);

            // Deve / Asserções
            var candidateFernando = election.Candidates.Find(x => x.id == fernandoId);
            var candidateana = election.Candidates.Find(x => x.id == anaId);
            Assert.Equal(2, candidateFernando.votes);
            Assert.Equal(0, candidateana.votes);
        }

        [Fact]
        public void should_return_ana_as_winner_when_only_ana_receives_votes()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            (string name, string cpf) ana = ("Ana","111.222.333-44");
            (string name, string cpf) fernando = ("Fernando","444.333.222-11");
            var candidates = new List<(string, string)>{fernando, ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            var anaId = election.GetCandidateIdByName(ana.name);
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            election.Vote(anaId);
            election.Vote(anaId);
            var winners = election.GetWinners();

            // Deve / Asserções
            Assert.True(winners.Count == 1);
            Assert.Equal(anaId, winners[0].id);
            Assert.Equal(2, winners[0].votes);
        }

        [Fact]
        public void should_return_both_candidates_when_occurs_draw()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            (string name, string cpf) ana = ("Ana","111.222.333-44");
            (string name, string cpf) fernando = ("Fernando","444.333.222-11");
            var candidates = new List<(string, string)>{fernando, ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            var fernandoId = election.GetCandidateIdByName(fernando.name);
            var anaId = election.GetCandidateIdByName(ana.name);
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            election.Vote(anaId);
            election.Vote(fernandoId);
            var winners = election.GetWinners();

            // Deve / Asserções
            var candidateFernando = winners.Find(x => x.id == fernandoId);
            var candidateana = winners.Find(x => x.id == anaId);
            Assert.Equal(1, candidateFernando.votes);
            Assert.Equal(1, candidateana.votes);
        }
    }
}
