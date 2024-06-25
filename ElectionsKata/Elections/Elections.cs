using System.Globalization;

namespace Elections
{
    public class Elections : IElections
    {
        private readonly bool _withDistrict;
        private readonly WithoutDistrict _electionWithoutDistrict;
        private readonly WithDistrict _electionWithDistrict;

        public Elections(Dictionary<string, List<string>> list, bool withDistrict)
        {
            _electionWithoutDistrict = new WithoutDistrict(list);
            _withDistrict = withDistrict;

            var votesWithDistricts = new Dictionary<string, List<int>>()
            {
                {"District 1", new List<int>()},
                {"District 2", new List<int>()},
                {"District 3", new List<int>()}
            };
            
            _electionWithDistrict = new WithDistrict(list, votesWithDistricts);
        }

        public void AddCandidate(string candidate)
        {
            if (!_withDistrict)
                _electionWithoutDistrict.AddCandidate(candidate);
            else
                _electionWithDistrict.AddCandidate(candidate);
        }

        public void VoteFor(string elector, string candidate, string electorDistrict)
        {
            if (!_withDistrict)
                _electionWithoutDistrict.VoteFor(elector, candidate, electorDistrict);
            else
                _electionWithDistrict.VoteFor(elector, candidate, electorDistrict);
        }

        public Dictionary<string, string> Results()
        {
            return !_withDistrict
                ? _electionWithoutDistrict.Results()
                : _electionWithDistrict.Results();
        }
    }
}
