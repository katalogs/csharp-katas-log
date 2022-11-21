using System.Collections.Generic;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;
using static VerifyXunit.Verifier;


namespace Elections.Tests;

[UsesVerify]
public class ElectionsTests
{
    [Fact]
    public Task Should_run_without_districts()
    {
        var list = new Dictionary<string, List<string>>
        {
            ["District 1"] = new() {"Bob", "Anna", "Jess", "July"},
            ["District 2"] = new() {"Jerry", "Simon"},
            ["District 3"] = new() {"Johnny", "Matt", "Carole"}
        };

        var elections = new NationalElections(list);
        elections.AddCandidate("Michel");
        elections.AddCandidate("Jerry");
        elections.AddCandidate("Johnny");

        elections.VoteFor("Bob", "Jerry", "District 1");
        elections.VoteFor("Jerry", "Jerry", "District 2");
        elections.VoteFor("Anna", "Johnny", "District 1");
        elections.VoteFor("Johnny", "Johnny", "District 3");
        elections.VoteFor("Matt", "Donald", "District 3");
        elections.VoteFor("Jess", "Jerry", "District 1");
        elections.VoteFor("Simon", "", "District 2");
        elections.VoteFor("Carole", "", "District 3");

        var results = elections.Results();

        return Verify(results);
    }

        [Fact]
        public Task Should_run_with_districts()
        {
            var list = new Dictionary<string, List<string>>
            {
                ["District 1"] = new() {"Bob", "Anna", "Jess", "July"},
                ["District 2"] = new() {"Jerry", "Simon"},
                ["District 3"] = new() {"Johnny", "Matt", "Carole"}
            };
            var elections = new LocalElections(list);
            elections.AddCandidate("Michel");
            elections.AddCandidate("Jerry");
            elections.AddCandidate("Johnny");

            elections.VoteFor("Bob", "Jerry", "District 1");
            elections.VoteFor("Jerry", "Jerry", "District 2");
            elections.VoteFor("Anna", "Johnny", "District 1");
            elections.VoteFor("Johnny", "Johnny", "District 3");
            elections.VoteFor("Matt", "NULL", "District 3");
            elections.VoteFor("Jess", "NULL2", "District 1");
            elections.VoteFor("July", "Jerry", "District 1");
            elections.VoteFor("Simon", "", "District 2");
            elections.VoteFor("Carole", "NULL3", "District 3");

            var results = elections.Results();

            return Verify(results);
        }
}
