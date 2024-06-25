namespace Elections;

internal class PercentResults
{
    public readonly float BlankResult;
    public readonly float NullResult;
    public readonly float AbstentionResult;
    public readonly Dictionary<string, float> CandidateResults;

    public PercentResults(int nbVotes, int blankVotes, int nullVotes, int nbElectors,
        Dictionary<string, float> candidateResults, int nbValidVotes)
    {
        CandidateResults = candidateResults.ToDictionary(kv => kv.Key, kv => kv.Value * 100 / nbValidVotes);
        BlankResult = (float) blankVotes * 100 / nbVotes;
        NullResult = (float) nullVotes * 100 / nbVotes;
        AbstentionResult = 100 - (float) nbVotes * 100 / nbElectors;
    }
}
