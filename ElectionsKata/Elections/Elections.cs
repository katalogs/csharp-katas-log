using System.Globalization;

namespace Elections
{
    public class Elections
    {
        private readonly List<string> _allCandidates = new List<string>();
        private readonly Dictionary<string, List<string>> _electorsListByDistrict;
        private readonly List<string> _officialCandidates = new List<string>();
        private readonly Dictionary<string, List<int>> _numberOfVotesForCandidatesByDistricts;
        private readonly List<int> _totalNumberOfVotesForCandidates = new List<int>();
        private readonly bool _isVoteByDistrict;

        public Elections(Dictionary<string, List<string>> electorsListByDistrict, bool isVoteByDistrict)
        {
            _electorsListByDistrict = electorsListByDistrict;
            _isVoteByDistrict = isVoteByDistrict;

            _numberOfVotesForCandidatesByDistricts = new Dictionary<string, List<int>>
            {
                {"District 1", new List<int>()},
                {"District 2", new List<int>()},
                {"District 3", new List<int>()}
            };
        }

        public void AddCandidate(string candidate)
        {
            _officialCandidates.Add(candidate);
            _allCandidates.Add(candidate);
            _totalNumberOfVotesForCandidates.Add(0);
            _numberOfVotesForCandidatesByDistricts["District 1"].Add(0);
            _numberOfVotesForCandidatesByDistricts["District 2"].Add(0);
            _numberOfVotesForCandidatesByDistricts["District 3"].Add(0);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            //add a "a voté" to un allow a candidate to emit more than 1 vote
            if (!_isVoteByDistrict)
            {
                VoteForACandidate(candidate);
            }
            else
            {
                VoteForACandidateByDistrict(candidate, electorDistrict);
            }
        }

        private void VoteForACandidateByDistrict(string candidate, string voteDistrict)
        {
            // vérifier que l'électeur appartien bien au district
            if (_numberOfVotesForCandidatesByDistricts.ContainsKey(voteDistrict))
            {
                var numberOfVotesForCandidatesForGivenDistrict = _numberOfVotesForCandidatesByDistricts[voteDistrict];
                if (!HasCandidateAlreadyBeenAdded(candidate))
                {
                    AddUnofficialCandidate(candidate);
                }
                AddVoteForCandidateByDistrict(candidate, numberOfVotesForCandidatesForGivenDistrict);
            }
        }

        private void AddUnofficialCandidate(string candidate)
        {
            _allCandidates.Add(candidate);
            foreach (var votes in _numberOfVotesForCandidatesByDistricts.Values) votes.Add(0);
        }

        private bool HasCandidateAlreadyBeenAdded(string candidate)
        {
            return _allCandidates.Contains(candidate);
        }

        private void AddVoteForCandidateByDistrict(string candidate, List<int> numberOfVotesForCandidatesForGivenDistrict)
        {
            var index = _allCandidates.IndexOf(candidate);
            numberOfVotesForCandidatesForGivenDistrict[index] = numberOfVotesForCandidatesForGivenDistrict[index] + 1;
        }

        private void VoteForACandidate(string candidate)
        {
            if (HasCandidateAlreadyBeenAdded(candidate))
            {
                AddVoteForACandidate(candidate);
            }
            else
            {
                AddUnofficialCandidate(candidate);
                _totalNumberOfVotesForCandidates.Add(1);
            }
        }

        private void AddVoteForACandidate(string candidate)
        {
            var index = _allCandidates.IndexOf(candidate);
            _totalNumberOfVotesForCandidates[index] = _totalNumberOfVotesForCandidates[index] + 1;
        }

        public Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            if (!_isVoteByDistrict)
            {
                nbVotes = _totalNumberOfVotesForCandidates.Select(i => i).Sum();
                for (var i = 0; i < _officialCandidates.Count; i++)
                {
                    var index = _allCandidates.IndexOf(_officialCandidates[i]);
                    nbValidVotes += _totalNumberOfVotesForCandidates[index];
                }

                for (var i = 0; i < _totalNumberOfVotesForCandidates.Count; i++)
                {
                    var candidateResult = (float)_totalNumberOfVotesForCandidates[i] * 100 / nbValidVotes;
                    var candidate = _allCandidates[i];

                    if (_officialCandidates.Contains(candidate))
                    {
                        results[candidate] = string.Format(cultureInfo, "{0:0.00}%", candidateResult);
                    }
                    else
                    {
                        if (_allCandidates[i] == string.Empty)
                            blankVotes += _totalNumberOfVotesForCandidates[i];
                        else
                            nullVotes += _totalNumberOfVotesForCandidates[i];
                    }
                }
            }
            else
            {
                foreach (var entry in _numberOfVotesForCandidatesByDistricts)
                {
                    var districtVotes = entry.Value;
                    nbVotes += districtVotes.Select(i => i).Sum();
                }

                for (var i = 0; i < _officialCandidates.Count; i++)
                {
                    var index = _allCandidates.IndexOf(_officialCandidates[i]);
                    foreach (var entry in _numberOfVotesForCandidatesByDistricts)
                    {
                        var districtVotes = entry.Value;
                        nbValidVotes += districtVotes[index];
                    }
                }

                var officialCandidatesResult = new Dictionary<string, int>();
                for (var i = 0; i < _officialCandidates.Count; i++) officialCandidatesResult[_allCandidates[i]] = 0;
                foreach (var entry in _numberOfVotesForCandidatesByDistricts)
                {
                    var districtResult = new List<float>();
                    var districtVotes = entry.Value;
                    for (var i = 0; i < districtVotes.Count; i++)
                    {
                        float candidateResult = 0;
                        if (nbValidVotes != 0)
                            candidateResult = (float)districtVotes[i] * 100 / nbValidVotes;
                        var candidate = _allCandidates[i];
                        if (_officialCandidates.Contains(candidate))
                        {
                            districtResult.Add(candidateResult);
                        }
                        else
                        {
                            if (_allCandidates[i] == string.Empty)
                                blankVotes += districtVotes[i];
                            else
                                nullVotes += districtVotes[i];
                        }
                    }

                    var districtWinnerIndex = 0;
                    for (var i = 1; i < districtResult.Count; i++)
                        if (districtResult[districtWinnerIndex] < districtResult[i])
                            districtWinnerIndex = i;
                    officialCandidatesResult[_allCandidates[districtWinnerIndex]] =
                        officialCandidatesResult[_allCandidates[districtWinnerIndex]] + 1;
                }

                for (var i = 0; i < officialCandidatesResult.Count; i++)
                {
                    var ratioCandidate = (float)officialCandidatesResult[_allCandidates[i]] /
                        officialCandidatesResult.Count * 100;
                    results[_allCandidates[i]] = string.Format(cultureInfo, "{0:0.00}%", ratioCandidate);
                }
            }

            var blankResult = (float)blankVotes * 100 / nbVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / nbVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _electorsListByDistrict.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }
    }
}
