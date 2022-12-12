using System.Globalization;

namespace Elections
{
    public class NationalElections : Elections
    {
        private readonly List<int> _votesWithoutDistricts = new();

        private readonly List<string> _ballotBox = new();

        public NationalElections(Dictionary<string, List<string>> electoralList): base(electoralList)
        {
        }

        public override void AddCandidate(string candidate)
        {
            _votesWithoutDistricts.Add(0);
            base.AddCandidate(candidate);
        }

        public override void VoteFor(string elector, string candidate, string electorDistrict)
        {
            _ballotBox.Add(candidate);
        }

        public override Dictionary<string, string> Results()
        {
            var nbVotes = _ballotBox.Count;
            var blankVotes = _ballotBox.Count(ballot => ballot == String.Empty);
            var nbValidVotes = _ballotBox.Count(ballot => OfficialCandidates.Contains(ballot));
            var nullVotes = _ballotBox.Count(ballot => !OfficialCandidates.Contains(ballot) && ballot != string.Empty);

            var results = OfficialCandidates
                .ToDictionary(officialCandidateName => officialCandidateName,
                    officialCandidateName => _ballotBox.Count(ballot => ballot == officialCandidateName))
                .ToDictionary(g => g.Key, g => CalculatePercentage(g.Value, nbValidVotes))
                .ToDictionary(g => g.Key, g => FormatResult(g.Value));

            var blankResult = CalculatePercentage(blankVotes, nbVotes);
            results["Blank"] = FormatResult(blankResult);

            var nullResult = CalculatePercentage(nullVotes, nbVotes);
            results["Null"] = FormatResult(nullResult);

            var nbElectors = ElectoralList.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - CalculatePercentage(nbVotes, nbElectors);
            results["Abstention"] = FormatResult(abstentionResult);

            return results;
        }
    }
}
