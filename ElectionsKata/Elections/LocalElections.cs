using System.Globalization;

namespace Elections
{
    public class LocalElections : Elections
    {
        private readonly Dictionary<string, List<int>> _votesWithDistricts;

        public LocalElections(Dictionary<string, List<string>> electoralList): base(electoralList)
        {
            _votesWithDistricts = new Dictionary<string, List<int>>
            {
                {"District 1", new List<int>()},
                {"District 2", new List<int>()},
                {"District 3", new List<int>()}
            };
        }

        public override void AddCandidate(string candidate)
        {
            _votesWithDistricts["District 1"].Add(0);
            _votesWithDistricts["District 2"].Add(0);
            _votesWithDistricts["District 3"].Add(0);
            base.AddCandidate(candidate);
        }

        public override void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (_votesWithDistricts.ContainsKey(electorDistrict))
            {
                var districtVotes = _votesWithDistricts[electorDistrict];
                if (CandidatesAndOthers.Contains(candidate))
                {
                    var index = CandidatesAndOthers.IndexOf(candidate);
                    districtVotes[index] = districtVotes[index] + 1;
                }
                else
                {
                    CandidatesAndOthers.Add(candidate);
                    foreach (var (_, votes) in _votesWithDistricts) votes.Add(0);
                    districtVotes[CandidatesAndOthers.Count - 1] = districtVotes[CandidatesAndOthers.Count - 1] + 1;
                }
            }
        }

        public override Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;

            foreach (var entry in _votesWithDistricts)
            {
                var districtVotes = entry.Value;
                nbVotes += districtVotes.Select(i => i).Sum();
            }

            for (var i = 0; i < OfficialCandidates.Count; i++)
            {
                var index = CandidatesAndOthers.IndexOf(OfficialCandidates[i]);
                foreach (var entry in _votesWithDistricts)
                {
                    var districtVotes = entry.Value;
                    nbValidVotes += districtVotes[index];
                }
            }

            var officialCandidatesResult = new Dictionary<string, int>();
            for (var i = 0; i < OfficialCandidates.Count; i++) officialCandidatesResult[CandidatesAndOthers[i]] = 0;
            foreach (var entry in _votesWithDistricts)
            {
                var districtResult = new List<float>();
                var districtVotes = entry.Value;
                for (var i = 0; i < districtVotes.Count; i++)
                {
                    float candidateResult = 0;
                    if (nbValidVotes != 0) candidateResult = CalculatePercentage(districtVotes[i], nbValidVotes);
                    var candidate = CandidatesAndOthers[i];
                    if (OfficialCandidates.Contains(candidate))
                    {
                        districtResult.Add(candidateResult);
                    }
                    else
                    {
                        if (CandidatesAndOthers[i] == string.Empty)
                            blankVotes += districtVotes[i];
                        else
                            nullVotes += districtVotes[i];
                    }
                }

                var districtWinnerIndex = 0;
                for (var i = 1; i < districtResult.Count; i++)
                    if (districtResult[districtWinnerIndex] < districtResult[i])
                        districtWinnerIndex = i;
                officialCandidatesResult[CandidatesAndOthers[districtWinnerIndex]] =
                    officialCandidatesResult[CandidatesAndOthers[districtWinnerIndex]] + 1;
            }

            for (var i = 0; i < officialCandidatesResult.Count; i++)
            {
                var ratioCandidate = CalculatePercentage(officialCandidatesResult[CandidatesAndOthers[i]],
                    officialCandidatesResult.Count);

                results[CandidatesAndOthers[i]] = FormatResult(ratioCandidate);
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
