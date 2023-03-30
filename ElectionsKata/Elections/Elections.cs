using System.Globalization;

namespace Elections
{
    public class Elections
    {
        private readonly List<Candidate> _allCandidates = new List<Candidate>();
        private readonly List<District> _districts;
        private readonly List<Candidate> _officialCandidates = new List<Candidate>();
        private readonly List<int> _totalNumberOfVotesForCandidates = new List<int>();
        private readonly bool _isVoteByDistrict;

        public Elections(Dictionary<string, List<string>> electorsListByDistrict, bool isVoteByDistrict)
        {
            _districts = new();

            foreach (var electorByDistrict in electorsListByDistrict)
            {
                _districts.Add(new District(electorByDistrict.Key, electorByDistrict.Value.Select(electorName => new Elector(electorName))));
            };

            _isVoteByDistrict = isVoteByDistrict;
        }

        public void AddCandidate(string candidateName)
        {
            Candidate candidate = new Candidate(candidateName);
            _officialCandidates.Add(candidate);
            _allCandidates.Add(candidate);
            _totalNumberOfVotesForCandidates.Add(0);

            foreach(District district in _districts)
            {
                district.AddCandidate(candidate);
            }
        }

        public void VoteFor(string elector, string candidateName, string electorDistrict)
        {
            Candidate candidate = new Candidate(candidateName);
            //add a "a voté" to allow a candidate to emit more than 1 vote
            if (!_isVoteByDistrict)
            {
                VoteForACandidate(candidate);
            }
            else
            {
                VoteForACandidateByDistrict(candidate, electorDistrict);
            }
        }

        private void AddUnofficialCandidate(Candidate candidate)
        {
            _allCandidates.Add(candidate);
            foreach (District district in _districts)
            {
                district.AddCandidate(candidate);
            }

            _totalNumberOfVotesForCandidates.Add(0);
        }

        private bool HasCandidateAlreadyBeenAdded(Candidate newCandidate)
        {
            return _allCandidates.Any(candidate => candidate == newCandidate);
        }

        private void VoteForACandidate(Candidate candidate)
        {
            if (!HasCandidateAlreadyBeenAdded(candidate))
            {
                AddUnofficialCandidate(candidate);
            }
            AddVoteForACandidate(candidate);
        }

        private void VoteForACandidateByDistrict(Candidate candidate, string districtName)
        {
            // TODO vérifier que l'électeur appartient bien au district
            District? selectedDistric = _districts.FirstOrDefault(district => district.GetName() == districtName);

            if (selectedDistric != null)
            {
                if (!HasCandidateAlreadyBeenAdded(candidate))
                {
                    AddUnofficialCandidate(candidate);
                }

                selectedDistric.VoteFor(candidate); // TODO add elector to this method to make sure he hasn't already voted
            }
        }

        private void AddVoteForACandidate(Candidate candidateWithNewVote)
        {
            var index = _allCandidates.IndexOf(candidateWithNewVote);
            _totalNumberOfVotesForCandidates[index] = _totalNumberOfVotesForCandidates[index] + 1;

        }

        private bool IsCandidateOfficial(Candidate candidate)
        {
            return _officialCandidates.Exists(officialCandidate => officialCandidate.Name == candidate.Name);
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
                        results[candidate.Name] = string.Format(cultureInfo, "{0:0.00}%", candidateResult);
                        continue;
                    }

                    if (candidate.HasEmptyName())
                        blankVotes += _totalNumberOfVotesForCandidates[i];
                    else
                        nullVotes += _totalNumberOfVotesForCandidates[i];
                }
            }
            else
            {
                totalVotes = CalculateTotalVotes();

                foreach (var officialCandidate in _officialCandidates)
                {
                    var indexOfOfficialCandidate = _allCandidates.IndexOf(officialCandidate);
                    foreach (var district in _districts) // TODO ? sum insteaf of foreach
                    {
                        totalVotesForOfficialCandidates += district.GetVoteCountForCandidate(officialCandidate);
                    }
                }

                var officialCandidatesResult = new Dictionary<string, int>();
                for (var i = 0; i < _officialCandidates.Count; i++) officialCandidatesResult[_allCandidates[i].Name] = 0;
                foreach (var district in _districts)
                {
                    var districtResult = new List<float>();
                    var districtVotes = district.GetVotes();
                    foreach(var candidate in districtVotes.Keys)
                    {
                        float candidateResult = 0;
                        if (totalVotesForOfficialCandidates != 0)
                            candidateResult = (float)districtVotes[candidate] * 100 / totalVotesForOfficialCandidates;
                        if (IsCandidateOfficial(candidate))
                        {
                            districtResult.Add(candidateResult);
                        }
                        else
                        {
                            if (candidate.HasEmptyName())
                                blankVotes += districtVotes[candidate];
                            else
                                nullVotes += districtVotes[candidate];
                        }
                    }

                    var districtWinnerIndex = 0;
                    for (var i = 1; i < districtResult.Count; i++)
                        if (districtResult[districtWinnerIndex] < districtResult[i])
                            districtWinnerIndex = i;
                    officialCandidatesResult[_allCandidates[districtWinnerIndex].Name] =
                        officialCandidatesResult[_allCandidates[districtWinnerIndex].Name] + 1;
                }

                for (var i = 0; i < officialCandidatesResult.Count; i++)
                {
                    var ratioCandidate = (float)officialCandidatesResult[_allCandidates[i].Name] /
                        officialCandidatesResult.Count * 100;
                    results[_allCandidates[i].Name] = string.Format(cultureInfo, "{0:0.00}%", ratioCandidate);
                }
            }

            var blankResult = (float)blankVotes * 100 / totalVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / totalVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _districts.Sum(district => district.GetElectorsCount());
            var abstentionResult = 100 - (float)totalVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }

        private int CalculateTotalVotes()
        {
            int totalVotes = 0;
            foreach (var district in _districts)
            {
                totalVotes += district.GetTotalNumberOfVotes();
            }

            return totalVotes;
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
