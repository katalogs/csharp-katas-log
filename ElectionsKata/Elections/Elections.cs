using System.Globalization;

namespace Elections
{
    public class Elections
    {
        private readonly List<Candidate> _allCandidates = new List<Candidate>();
        private readonly Dictionary<string, List<string>> _electorsListByDistrict;
        private readonly List<Candidate> _officialCandidates = new List<Candidate>();
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

        public void AddCandidate(string candidateName)
        {
            Candidate candidate = new Candidate(candidateName);
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

        private void AddUnofficialCandidate(string candidateName)
        {
            Candidate candidate = new Candidate(candidateName);
            _allCandidates.Add(candidate);
            foreach (var votes in _numberOfVotesForCandidatesByDistricts.Values) votes.Add(0);
            _totalNumberOfVotesForCandidates.Add(0);
        }

        private bool HasCandidateAlreadyBeenAdded(string candidateName)
        {
            return _allCandidates.Exists(candidate=>candidate.Name == candidateName);
        }

        private void AddVoteForCandidateByDistrict(string candidate, List<int> numberOfVotesForCandidatesForGivenDistrict)
        {
            var index = _allCandidates.IndexOf(candidate);
            numberOfVotesForCandidatesForGivenDistrict[index] = numberOfVotesForCandidatesForGivenDistrict[index] + 1;
        }

        private void VoteForACandidate(string candidate)
        {
            if (!HasCandidateAlreadyBeenAdded(candidate))
            {
                AddUnofficialCandidate(candidate);
            }
            AddVoteForACandidate(candidate);
        }

        private void VoteForACandidateByDistrict(string candidate, string voteDistrict)
        {
            // vérifier que l'électeur appartient bien au district
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

        private void AddVoteForACandidate(string candidate)
        {
            var index = _allCandidates.IndexOf(candidate);
            _totalNumberOfVotesForCandidates[index] = _totalNumberOfVotesForCandidates[index] + 1;

        }

        private bool IsCandidateOfficial(string candidate)
        {
            return _officialCandidates.Contains(candidate);
        }

        public Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var totalVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var totalVotesForOfficialCandidates = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            if (!_isVoteByDistrict)
            {
                totalVotes = _totalNumberOfVotesForCandidates.Sum();
                totalVotesForOfficialCandidates = CalculateTotalVotesForOfficialCandidates();

                for (var i = 0; i < _totalNumberOfVotesForCandidates.Count; i++)
                {
                    var candidate = _allCandidates[i];

                    if (IsCandidateOfficial(candidate))
                    {
                        var candidateResult = GetCandidateResultPercentage(totalVotesForOfficialCandidates, i);
                        results[candidate] = string.Format(cultureInfo, "{0:0.00}%", candidateResult);
                        continue;
                    }

                    if (IsVoteBlank(i))
                        blankVotes += _totalNumberOfVotesForCandidates[i];
                    else
                        nullVotes += _totalNumberOfVotesForCandidates[i];
                }
            }
            else
            {
                totalVotes = CalculateTotalVotes();

                foreach(var officialCandidate in _officialCandidates)
                {
                    var indexOfOfficialCandidate = _allCandidates.IndexOf(officialCandidate);
                    foreach (var numberOfVotesForACandidateByDistricts in _numberOfVotesForCandidatesByDistricts)
                    {
                        var districtVotes = numberOfVotesForACandidateByDistricts.Value;
                        totalVotesForOfficialCandidates += districtVotes[indexOfOfficialCandidate];
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
                        if (totalVotesForOfficialCandidates != 0)
                            candidateResult = (float)districtVotes[i] * 100 / totalVotesForOfficialCandidates;
                        var candidate = _allCandidates[i];
                        if (IsCandidateOfficial(candidate))
                        {
                            districtResult.Add(candidateResult);
                        }
                        else
                        {
                            if (IsVoteBlank(i))
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

            var blankResult = (float)blankVotes * 100 / totalVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / totalVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _electorsListByDistrict.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)totalVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }

        private int CalculateTotalVotes()
        {
            int totalVotes = 0;
            foreach (var voteForACandidateByDistrict in _numberOfVotesForCandidatesByDistricts)
            {
                var districtVotes = voteForACandidateByDistrict.Value;
                totalVotes += districtVotes.Sum();
            }

            return totalVotes;
        }

        private bool IsVoteBlank(int i)
        {
            return _allCandidates[i] == string.Empty;
        }

        private float GetCandidateResultPercentage(int totalVotesForOfficialCandidates, int i)
        {
            return (float)_totalNumberOfVotesForCandidates[i] * 100 / totalVotesForOfficialCandidates;
        }

        private int CalculateTotalVotesForOfficialCandidates()
        {
            int totalVotesForOfficialCandidates = 0;
            for (var i = 0; i < _officialCandidates.Count; i++)
            {
                var index = _allCandidates.IndexOf(_officialCandidates[i]);
                totalVotesForOfficialCandidates += _totalNumberOfVotesForCandidates[index];
            }

            return totalVotesForOfficialCandidates;
        }
    }
}
