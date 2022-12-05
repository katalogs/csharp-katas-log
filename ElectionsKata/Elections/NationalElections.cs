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

        private void PreTreatment(string ballot)
        {
            if (!CandidatesAndOthers.Contains(ballot))
            {
                _votesWithoutDistricts.Add(0);
                CandidatesAndOthers.Add(ballot);
            }

            var index = CandidatesAndOthers.IndexOf(ballot);
            _votesWithoutDistricts[index] += 1;
        }

        public override Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = _ballotBox.Count;
            var nullVotes = 0;
            var blankVotes = _ballotBox.Count(ballot => ballot == String.Empty);
            var nbValidVotes = 0;

            _ballotBox.ForEach(ballot =>
            {
                if (!CandidatesAndOthers.Contains(ballot))
                {
                    _votesWithoutDistricts.Add(0);
                    CandidatesAndOthers.Add(ballot);
                }

                var index = CandidatesAndOthers.IndexOf(ballot);
                _votesWithoutDistricts[index] += 1;
            });

            for (var i = 0; i < OfficialCandidates.Count; i++)
            {
                var index = CandidatesAndOthers.IndexOf(OfficialCandidates[i]);
                nbValidVotes += _votesWithoutDistricts[index];
            }

            for (var i = 0; i < _votesWithoutDistricts.Count; i++)
            {
                var candidateResult = CalculatePercentage(_votesWithoutDistricts[i], nbValidVotes);
                var candidate = CandidatesAndOthers[i];

                if (OfficialCandidates.Contains(candidate))
                {
                    results[candidate] = FormatResult(candidateResult);
                }
                else
                {
                    if (CandidatesAndOthers[i] != string.Empty)
                        nullVotes += _votesWithoutDistricts[i];
                }
            }

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
