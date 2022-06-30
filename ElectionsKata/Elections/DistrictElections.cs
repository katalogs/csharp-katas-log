namespace Elections
{
    public class DistrictElections : Elections
    {
        public DistrictElections(Dictionary<string, List<string>> list) : base(list, true)
        {

        }

        public override void VoteFor(string elector, string candidate, string electorDistrict)
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

    }
}
