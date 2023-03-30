using System.Collections.Generic;

namespace Elections
{
    internal class District
    {
        private string _name;
        private IEnumerable<Elector> _electors;
        private Dictionary<Candidate, int> _canditatesScore;

        public District(string name, IEnumerable<Elector> electors)
        {
            _name = name;
            _electors = new List<Elector>(electors);
            _canditatesScore = new Dictionary<Candidate, int>();
        }

        public int GetElectorsCount()
        {
            return _electors.Count();
        }

        public string GetName()
        {
            return _name;
        }

        internal void AddCandidate(Candidate candidate)
        {
            _canditatesScore.Add(candidate, 0);
        }
    }
}
