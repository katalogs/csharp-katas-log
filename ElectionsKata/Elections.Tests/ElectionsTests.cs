using System.Collections.Generic;
using VerifyXunit;
using Xunit;

namespace Elections.Tests;

[UsesVerify]
public class ElectionsTests
{

    [Fact]
    public Task Should_run_without_districts()
        {
            var list = new Dictionary<string, List<string>>
            {
                ["District 1"] = new List<string> {"Bob", "Anna", "Jess", "July"},
                ["District 2"] = new List<string> {"Jerry", "Simon"},
                ["District 3"] = new List<string> {"Johnny", "Matt", "Carole"}
            };

            var elections = new Elections(list, false);
            elections.AddCandidate("Michel");
            elections.AddCandidate("Jerry");
            elections.AddCandidate("Johnny");

            elections.VoteFor("Bob", "Jerry", "District 1");
            elections.VoteFor("Jerry", "Jerry", "District 2");
            elections.VoteFor("Anna", "Johnny", "District 1");
            elections.VoteFor("Johnny", "Johnny", "District 3");
            elections.VoteFor("Matt", "Donald", "District 3");
            elections.VoteFor("Jess", "Joe", "District 1");
            elections.VoteFor("Simon", "", "District 2");
            elections.VoteFor("Carole", "", "District 3");

            var results = elections.Results();


            // Add approval tests here
            return Verify(results);
            

        }

        [Fact]
        public Task Should_run_with_districts()
        {
            var list = new Dictionary<string, List<string>>
            {
                ["District 1"] = new List<string> {"Bob", "Anna", "Jess", "July"},
                ["District 2"] = new List<string> {"Jerry", "Simon"},
                ["District 3"] = new List<string> {"Johnny", "Matt", "Carole"}
            };
            var elections = new Elections(list, true);
            elections.AddCandidate("Michel");
            elections.AddCandidate("Jerry");
            elections.AddCandidate("Johnny");

            elections.VoteFor("Bob", "Jerry", "District 1");
            elections.VoteFor("Jerry", "Jerry", "District 2");
            elections.VoteFor("Anna", "Johnny", "District 1");
            elections.VoteFor("Johnny", "Johnny", "District 3");
            elections.VoteFor("Matt", "Donald", "District 3");
            elections.VoteFor("Jess", "Joe", "District 1");
            elections.VoteFor("July", "Jerry", "District 1");
            elections.VoteFor("Simon", "", "District 2");
            elections.VoteFor("Carole", "", "District 3");

            var results = elections.Results();

            // Add approval tests here
            return Verify(results);

    }

    [Fact]
    public void Compare_with_districts_and_without()
    {
        var list = new Dictionary<string, List<string>>
        {
            ["District 1"] = new List<string> { "Bob", "Anna", "Jess", "July" },
            ["District 2"] = new List<string> { "Jerry", "Simon" },
            ["District 3"] = new List<string> { "Johnny", "Matt", "Carole" }
        };
        var electionsWithDistrict = new Elections(list, true);
        electionsWithDistrict.AddCandidate("Michel");
        electionsWithDistrict.AddCandidate("Jerry");
        electionsWithDistrict.AddCandidate("Johnny");

        electionsWithDistrict.VoteFor("Bob", "Jerry", "District 1");
        electionsWithDistrict.VoteFor("Jerry", "Jerry", "District 2");
        electionsWithDistrict.VoteFor("Anna", "Johnny", "District 1");
        electionsWithDistrict.VoteFor("Johnny", "Johnny", "District 3");
        electionsWithDistrict.VoteFor("Matt", "Donald", "District 3");
        electionsWithDistrict.VoteFor("Jess", "Joe", "District 1");
        electionsWithDistrict.VoteFor("July", "Jerry", "District 1");
        electionsWithDistrict.VoteFor("Simon", "", "District 2");
        electionsWithDistrict.VoteFor("Carole", "", "District 3");

        var resultsWithDistrict = electionsWithDistrict.Results();

        var electionsWithoutDistrict = new Elections(list, false);
        electionsWithoutDistrict.AddCandidate("Michel");
        electionsWithoutDistrict.AddCandidate("Jerry");
        electionsWithoutDistrict.AddCandidate("Johnny");

        electionsWithoutDistrict.VoteFor("Bob", "Jerry", "District 1");
        electionsWithoutDistrict.VoteFor("Jerry", "Jerry", "District 2");
        electionsWithoutDistrict.VoteFor("Anna", "Johnny", "District 1");
        electionsWithoutDistrict.VoteFor("Johnny", "Johnny", "District 3");
        electionsWithoutDistrict.VoteFor("Matt", "Donald", "District 3");
        electionsWithoutDistrict.VoteFor("Jess", "Joe", "District 1");
        electionsWithoutDistrict.VoteFor("July", "Jerry", "District 1");
        electionsWithoutDistrict.VoteFor("Simon", "", "District 2");
        electionsWithoutDistrict.VoteFor("Carole", "", "District 3");

        var resultsWithoutDistrict = electionsWithoutDistrict.Results();

        // Add approval tests here
        Assert.Equal(resultsWithDistrict, resultsWithoutDistrict);

    }
}
