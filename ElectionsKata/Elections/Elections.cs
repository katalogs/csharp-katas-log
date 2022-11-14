using System.Globalization;

namespace Elections
{
    public class Elections
    {
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly List<string> _candidatesAndOthers = new List<string>();

        private readonly Dictionary<string, List<string>> _electoralList;

        private readonly Dictionary<string, List<int>> _votesWithDistricts;
        private readonly List<int> _votesWithoutDistricts = new List<int>();

        private readonly bool _withDistrict;

        public Elections(Dictionary<string, List<string>> electoralList, bool withDistrict)
        {
            _electoralList = electoralList;
            _withDistrict = withDistrict;

            _votesWithDistricts = new Dictionary<string, List<int>>
            {
                {"District 1", new List<int>()},
                {"District 2", new List<int>()},
                {"District 3", new List<int>()}
            };
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _candidatesAndOthers.Add(candidate);
            _votesWithoutDistricts.Add(0);
            _votesWithDistricts["District 1"].Add(0);
            _votesWithDistricts["District 2"].Add(0);
            _votesWithDistricts["District 3"].Add(0);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (!_withDistrict)
            {
                if (!_candidatesAndOthers.Contains(candidate))
                {
                    _votesWithoutDistricts.Add(0);
                    _candidatesAndOthers.Add(candidate);
                }
                
                var index = _candidatesAndOthers.IndexOf(candidate);
                _votesWithoutDistricts[index] = _votesWithoutDistricts[index] + 1;
                
            }
            else
            {
                if (_votesWithDistricts.ContainsKey(electorDistrict))
                {
                    var districtVotes = _votesWithDistricts[electorDistrict];
                    if (_candidatesAndOthers.Contains(candidate))
                    {
                        var index = _candidatesAndOthers.IndexOf(candidate);
                        districtVotes[index] = districtVotes[index] + 1;
                    }
                    else
                    {
                        _candidatesAndOthers.Add(candidate);
                        foreach (var (_, votes) in _votesWithDistricts) votes.Add(0);
                        districtVotes[_candidatesAndOthers.Count - 1] = districtVotes[_candidatesAndOthers.Count - 1] + 1;
                    }
                }
            }
        }

        public Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;

            if (!_withDistrict)
            {
                nbVotes = _votesWithoutDistricts.Select(i => i).Sum();
                for (var i = 0; i < _officialCandidates.Count; i++)
                {
                    var index = _candidatesAndOthers.IndexOf(_officialCandidates[i]);
                    nbValidVotes += _votesWithoutDistricts[index];
                }

                for (var i = 0; i < _votesWithoutDistricts.Count; i++)
                {
                    var candidateResult = (float) _votesWithoutDistricts[i] * 100 / nbValidVotes;
                    var candidate = _candidatesAndOthers[i];

                    if (_officialCandidates.Contains(candidate))
                    {
                        results[candidate] = FormatResult(candidateResult);
                    }
                    else
                    {
                        if (_candidatesAndOthers[i] == string.Empty)
                            blankVotes += _votesWithoutDistricts[i];
                        else
                            nullVotes += _votesWithoutDistricts[i];
                    }
                }
            }
            else
            {
                foreach (var entry in _votesWithDistricts)
                {
                    var districtVotes = entry.Value;
                    nbVotes += districtVotes.Select(i => i).Sum();
                }

                for (var i = 0; i < _officialCandidates.Count; i++)
                {
                    var index = _candidatesAndOthers.IndexOf(_officialCandidates[i]);
                    foreach (var entry in _votesWithDistricts)
                    {
                        var districtVotes = entry.Value;
                        nbValidVotes += districtVotes[index];
                    }
                }

                var officialCandidatesResult = new Dictionary<string, int>();
                for (var i = 0; i < _officialCandidates.Count; i++) officialCandidatesResult[_candidatesAndOthers[i]] = 0;
                foreach (var entry in _votesWithDistricts)
                {
                    var districtResult = new List<float>();
                    var districtVotes = entry.Value;
                    for (var i = 0; i < districtVotes.Count; i++)
                    {
                        float candidateResult = 0;
                        if (nbValidVotes != 0)
                            candidateResult = (float) districtVotes[i] * 100 / nbValidVotes;
                        var candidate = _candidatesAndOthers[i];
                        if (_officialCandidates.Contains(candidate))
                        {
                            districtResult.Add(candidateResult);
                        }
                        else
                        {
                            if (_candidatesAndOthers[i] == string.Empty)
                                blankVotes += districtVotes[i];
                            else
                                nullVotes += districtVotes[i];
                        }
                    }

                    var districtWinnerIndex = 0;
                    for (var i = 1; i < districtResult.Count; i++)
                        if (districtResult[districtWinnerIndex] < districtResult[i])
                            districtWinnerIndex = i;
                    officialCandidatesResult[_candidatesAndOthers[districtWinnerIndex]] =
                        officialCandidatesResult[_candidatesAndOthers[districtWinnerIndex]] + 1;
                }

                for (var i = 0; i < officialCandidatesResult.Count; i++)
                {
                    var ratioCandidate = (float) officialCandidatesResult[_candidatesAndOthers[i]] /
                        officialCandidatesResult.Count * 100;
                    results[_candidatesAndOthers[i]] = FormatResult(ratioCandidate);
                }
            }

            var blankResult = (float) blankVotes * 100 / nbVotes;
            results["Blank"] = FormatResult(blankResult);

            var nullResult = (float) nullVotes * 100 / nbVotes;
            results["Null"] = FormatResult(nullResult);

            var nbElectors = _electoralList.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float) nbVotes * 100 / nbElectors;
            results["Abstention"] = FormatResult(abstentionResult);

            return results;
        }

        private static string FormatResult(float blankResult)
        {
            return string.Format(new CultureInfo("fr-fr"), "{0:0.00}%", blankResult);
        }
    }
}
