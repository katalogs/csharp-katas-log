using System.Globalization;

namespace Elections;

public class WithoutDistrict : IElections
{
    private readonly List<string> _candidates = new List<string>();
    private readonly Dictionary<string, List<string>> _list;
    private readonly List<string> _officialCandidates = new List<string>();
    private readonly List<int> _votesWithoutDistricts = new List<int>();
    private List<string> _ballotBox = new();

    public WithoutDistrict(Dictionary<string, List<string>> list)
    {
        _list = list;
    }

    public static string FormatResult(float percentResult)
        => string.Format(
            new CultureInfo("fr-fr"),
            "{0:0.00}%",
            percentResult);

    public void AddCandidate(string candidate)
    {
        _officialCandidates.Add(candidate);
        _candidates.Add(candidate);
        _votesWithoutDistricts.Add(0);
    }

    public void VoteFor(string elector, string candidate, string electorDistrict)
    {
        _ballotBox.Add(candidate);
        
        if (_candidates.Contains(candidate))
        {
            var index = _candidates.IndexOf(candidate);
            _votesWithoutDistricts[index] = _votesWithoutDistricts[index] + 1;
        }
        else
        {
            _candidates.Add(candidate);
            _votesWithoutDistricts.Add(1);
        }
    }

    public Dictionary<string, string> Results()
    {
        var results = TallyBallotBox();
        var nullVotes = 0;
        var blankVotes = 0;
        var candidateResults = new Dictionary<string, float>();
        var nbVotes = 0;
        var nbValidVotes = 0;

        for (var i = 0; i < _votesWithoutDistricts.Count; i++)
        {
            nbVotes += _votesWithoutDistricts[i];
            var candidate = _candidates[i];

            if (_officialCandidates.Contains(candidate))
            {
                nbValidVotes += _votesWithoutDistricts[i];
                candidateResults[candidate] = _votesWithoutDistricts[i];
            }
            else
            {
                if (_candidates[i] == string.Empty)
                    blankVotes += _votesWithoutDistricts[i];
                else
                    nullVotes += _votesWithoutDistricts[i];
            }
        }

        var nbElectors = _list.Sum(kv => kv.Value.Count);
        var percentResults = new PercentResults(nbVotes, blankVotes, nullVotes, nbElectors, candidateResults, nbValidVotes);
        
        return FormatResults(percentResults);
    }

    private CountResult TallyBallotBox()
    {
        _ballotBox.GroupBy(b => b).ToDictionary(kv => kv.Key, kv => kv.Count());
        //@TODO: Extract official candidate votes
        //@TODO: Extract blank votes
        //@TODO: Extract null votes
        //@TODO: Extract abstention votes
        return new CountResult();
    }

    private Dictionary<string,string> FormatResults(PercentResults percentResults)
    {
        var results = percentResults.CandidateResults.ToDictionary(kv => kv.Key, kv => FormatResult(kv.Value));
        
        results["Blank"] = FormatResult(percentResults.BlankResult);
        results["Null"] = FormatResult(percentResults.NullResult);
        results["Abstention"] = FormatResult(percentResults.AbstentionResult);

        return results;
    }
}

internal class CountResult
{
}
