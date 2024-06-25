namespace Elections;

public interface IElections
{
    void AddCandidate(string candidate);

    void VoteFor(string elector, string candidate, string electorDistrict);

    Dictionary<string, string> Results();
}
