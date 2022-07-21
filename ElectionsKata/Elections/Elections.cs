namespace Elections
{
    public abstract class Elections
    {
        protected readonly List<string> _candidates = new List<string>();
        protected readonly Dictionary<string, List<string>> _list;
        protected readonly List<string> _officialCandidates = new List<string>();
        protected readonly Dictionary<string, List<int>> _votesWithDistricts;
        protected readonly List<int> _votesWithoutDistricts = new List<int>();
        protected readonly bool _withDistrict;

        public Elections(Dictionary<string, List<string>> list, bool withDistrict)
        {
            _list = list;
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
            _candidates.Add(candidate);
            _votesWithoutDistricts.Add(0);
            _votesWithDistricts["District 1"].Add(0);
            _votesWithDistricts["District 2"].Add(0);
            _votesWithDistricts["District 3"].Add(0);
        }

        public abstract void VoteFor(string elector, string candidate, string electorDistrict);
        public abstract Dictionary<string, string> Results();
    }
}
