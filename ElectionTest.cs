using System;
using System.Collections.Generic;
using System.Linq;
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
            var jose = new Candidate("José","001.002.003-04");
            var candidates = new List<Candidate>{jose};

            // Quando / Ação
            var created = election.CreateCandidates(candidates, "incorrect");

            // Deve / Asserções
            Assert.Empty(election.Candidates);
            Assert.False(created);
        }

        [Fact]
        public void should_create_candidates_when_password_is_correct()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            var jose = new Candidate("José","180.625.639-87");
            var candidates = new List<Candidate>{jose};
            // Quando / Ação

            // Estamos acessando o MÉTODO CreateCandidates do OBJETO election
            var created = election.CreateCandidates(candidates, "Pa$$w0rd");

            // Deve / Asserções
            Assert.True(created);
            
            // Estamos acessando a PROPRIEDADE Candidates, que faz parte do ESTADO do OBJETO election
            Assert.True(election.Candidates.Count==1);
            Assert.True(election.Candidates.First().Name == candidates.First().Name);
        }

        [Fact]
        public void should_not_generate_same_id_for_both_candidates()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            var jose = new Candidate("José","180.625.639-87");
            var ana = new Candidate("Ana","111.222.333-44");
            var candidates = new List<Candidate>{jose,ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            var candidatejose = election.GetCandidateIdByName(jose.Name);
            var candidateana = election.GetCandidateIdByName(ana.Name);

            // Deve / Asserções
            Assert.NotEqual(candidateana, candidatejose);
        }

        [Fact]
        public void should_return_a_list_of_ids()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            var jose1 = new Candidate("José","180.625.639-87");
            var joao = new Candidate("João","123.456.789.12");
            var jose2 = new Candidate("José","987.654.321-98");
            var ana = new Candidate("Ana","111.222.333-44");
            var jose3 = new Candidate("José","999.999.999-99");
            var candidates = new List<Candidate>{jose1,joao,jose2,ana,jose3};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            var candidatesJoseId = election.GetCandidatesIdByName("José");
            //var expectedIds = new List<Guid>{};
            // Deve / Asserções
            Assert.Equal(3,candidatesJoseId.Count);
            Assert.NotEqual(candidatesJoseId[0],candidatesJoseId[1]);
            Assert.NotEqual(candidatesJoseId[1],candidatesJoseId[2]);
            Assert.NotEqual(candidatesJoseId[2],candidatesJoseId[0]);
        }

        [Fact]
        public void should_return_a_list_of_candidates()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            var jose1 = new Candidate("José","180.625.639-87");
            var joao = new Candidate("João","123.456.789.12");
            var jose2 = new Candidate("José","987.654.321-98");
            var ana = new Candidate("Ana","111.222.333-44");
            var jose3 = new Candidate("José","999.999.999-99");
            var candidates = new List<Candidate>{jose1,joao,jose2,ana,jose3};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            var candidatesList = election.GetCandidatesByName("José");
            //var expectedIds = new List<Guid>{};
            // Deve / Asserções
            Assert.Equal("180.625.639-87",candidatesList[0].Cpf);
            Assert.Equal("987.654.321-98",candidatesList[1].Cpf);
            Assert.Equal("999.999.999-99",candidatesList[2].Cpf);
        }

        [Fact]
        public void should_return_a_list_of_cpfs()
        {
            // Dado / Setup

            // OBJETO election
            var election = new Election();
            var jose1 = new Candidate("José","180.625.639-87");
            var joao = new Candidate("João","123.456.789.12");
            var jose2 = new Candidate("José","987.654.321-98");
            var ana = new Candidate("Ana","111.222.333-44");
            var jose3 = new Candidate("José","999.999.999-99");
            var candidates = new List<Candidate>{jose1,joao,jose2,ana,jose3};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            
            // Quando / Ação
            var candidatesJoseCpf = election.GetCandidatesCpfByName("José");
            var expectedCpfs = new List<string>{"180.625.639-87","987.654.321-98","999.999.999-99"};
            // Deve / Asserções
            Assert.Equal(3,candidatesJoseCpf.Count);
            Assert.NotEqual(candidatesJoseCpf[0],candidatesJoseCpf[1]);
            Assert.NotEqual(candidatesJoseCpf[1],candidatesJoseCpf[2]);
            Assert.NotEqual(candidatesJoseCpf[2],candidatesJoseCpf[0]);
            Assert.Equal(expectedCpfs,candidatesJoseCpf);
        }

        [Fact]
        public void should_vote_twice_in_candidate_Fernando()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            var ana = new Candidate("Ana","111.222.333-44");
            var fernando = new Candidate ("Fernando","444.333.222-11");
            var candidates = new List<Candidate>{fernando, ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            //var fernandoId = election.GetCandidateIdByName(fernando.name);
            //var anaId = election.GetCandidateIdByName(ana.name);
            var fernandoId = election.GetCandidateIdByCpf(fernando.Cpf);
            var anaId = election.GetCandidateIdByCpf(ana.Cpf);

            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            Candidate.Vote(fernandoId);
            election.Vote(fernandoId);

            // Deve / Asserções
            var candidateFernando = election.Candidates.First(x => x.Id == fernandoId);
            var candidateana = election.Candidates.First(x => x.Id == anaId);
            Assert.Equal(2, candidateFernando.Votes);
            Assert.Equal(0, candidateana.Votes);
        }

        [Fact]
        public void should_return_ana_as_winner_when_only_ana_receives_votes()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            var ana = new Candidate("Ana","111.222.333-44");
            var fernando = new Candidate ("Fernando","444.333.222-11");
            var candidates = new List<Candidate>{fernando, ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            var anaId = election.GetCandidateIdByName(ana.Name);
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            election.Vote(anaId);
            election.Vote(anaId);
            var winners = election.GetWinners();

            // Deve / Asserções
            Assert.True(winners.Count == 1);
            Assert.Equal(anaId, winners[0].Id);
            Assert.Equal(2, winners[0].Votes);
        }

        [Fact]
        public void should_return_both_candidates_when_occurs_draw()
        {
            // Dado / Setup
            // OBJETO election
            var election = new Election();
            var ana = new Candidate("Ana","111.222.333-44");
            var fernando = new Candidate ("Fernando","444.333.222-11");
            var candidates = new List<Candidate>{fernando, ana};
            election.CreateCandidates(candidates, "Pa$$w0rd");
            var fernandoId = election.GetCandidateIdByName(fernando.Name);
            var anaId = election.GetCandidateIdByName(ana.Name);
            
            // Quando / Ação
            // Estamos acessando o MÉTODO ShowMenu do OBJETO election
            election.Vote(anaId);
            election.Vote(fernandoId);
            var winners = election.GetWinners();

            // Deve / Asserções
            var candidateFernando = winners.Find(x => x.Id == fernandoId);
            var candidateana = winners.Find(x => x.Id == anaId);
            Assert.Equal(1, candidateFernando.Votes);
            Assert.Equal(1, candidateana.Votes);
        }
    }
}
