using System.Collections.Generic;
using Xunit;

namespace entra21_tests
{
    public class ElectionTest
    {
        
        [Fact]
        public void should_not_create_with_wrong_password()
        {
            var election = new Election();
            var candidates = new List<(int id, string name)>{(1,"José")};

            var created = election.CreateCandidates(candidates,"incorrect");

            Assert.False(created);
        }
        [Fact]
        public void should_create_with_correct_password()
        {
            var election = new Election();
            var candidates = new List<(int id, string name)>{(1,"José")};

            var created = election.CreateCandidates(candidates,"Pa$$w0rd");

            Assert.True(created);
        }
    }
}
