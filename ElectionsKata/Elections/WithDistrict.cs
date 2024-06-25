namespace Elections;

public class WithDistrict : IElections
{
    private readonly List<string> _candidates = new List<string>();
    private readonly Dictionary<string, List<string>> _list;
    private readonly List<string> _officialCandidates = new List<string>();
    private readonly Dictionary<string, List<int>> _votesWithDistricts;

    public WithDistrict(Dictionary<string, List<string>> list, Dictionary<string, List<int>> votesWithDistricts)
    {
        _list = list;
        _votesWithDistricts = votesWithDistricts;
    }

    public static string FormatResult(float percentResult)
    {
        return WithoutDistrict.FormatResult(percentResult);
    }

    public void AddCandidate(string candidate)
    {
        _officialCandidates.Add(candidate);
        _candidates.Add(candidate);
        _votesWithDistricts["District 1"].Add(0);
        _votesWithDistricts["District 2"].Add(0);
        _votesWithDistricts["District 3"].Add(0);
    }

    public void VoteFor(string elector, string candidate, string electorDistrict)
    {
        if (_votesWithDistricts.ContainsKey(electorDistrict))
        {
            var districtVotes = _votesWithDistricts[electorDistrict];
            if (_candidates.Contains(candidate))
            {
                var index = _candidates.IndexOf(candidate);
                districtVotes[index] = districtVotes[index] + 1;
            }
            else
            {
                _candidates.Add(candidate);
                foreach (var (_, votes) in _votesWithDistricts) votes.Add(0);
                districtVotes[_candidates.Count - 1] = districtVotes[_candidates.Count - 1] + 1;
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
            
        foreach (var entry in _votesWithDistricts)
        {
            var districtVotes = entry.Value;
            nbVotes += districtVotes.Select(i => i).Sum();
        }

        for (var i = 0; i < _officialCandidates.Count; i++)
        {
            var index = _candidates.IndexOf(_officialCandidates[i]);
            foreach (var entry in _votesWithDistricts)
            {
                var districtVotes = entry.Value;
                nbValidVotes += districtVotes[index];
            }
        }

        var officialCandidatesResult = new Dictionary<string, int>();
        for (var i = 0; i < _officialCandidates.Count; i++) officialCandidatesResult[_candidates[i]] = 0;
        foreach (var entry in _votesWithDistricts)
        {
            var districtResult = new List<float>();
            var districtVotes = entry.Value;
            for (var i = 0; i < districtVotes.Count; i++)
            {
                float candidateResult = 0;
                if (nbValidVotes != 0)
                    candidateResult = (float) districtVotes[i] * 100 / nbValidVotes;
                var candidate = _candidates[i];
                if (_officialCandidates.Contains(candidate))
                {
                    districtResult.Add(candidateResult);
                }
                else
                {
                    if (_candidates[i] == string.Empty)
                        blankVotes += districtVotes[i];
                    else
                        nullVotes += districtVotes[i];
                }
            }

            var districtWinnerIndex = 0;
            for (var i = 1; i < districtResult.Count; i++)
                if (districtResult[districtWinnerIndex] < districtResult[i])
                    districtWinnerIndex = i;
            officialCandidatesResult[_candidates[districtWinnerIndex]] =
                officialCandidatesResult[_candidates[districtWinnerIndex]] + 1;
        }

        for (var i = 0; i < officialCandidatesResult.Count; i++)
        {
            var ratioCandidate = (float) officialCandidatesResult[_candidates[i]] /
                officialCandidatesResult.Count * 100;
            results[_candidates[i]] = FormatResult(ratioCandidate);
        }
            
        var blankResult = (float) blankVotes * 100 / nbVotes;
        results["Blank"] = FormatResult(blankResult);

        var nullResult = (float) nullVotes * 100 / nbVotes;
        results["Null"] = FormatResult(nullResult);

        var nbElectors = _list.Sum(kv => kv.Value.Count);
        var abstentionResult = 100 - (float) nbVotes * 100 / nbElectors;
        results["Abstention"] = FormatResult(abstentionResult);

        return results;
    }
}
