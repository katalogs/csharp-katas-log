using System.Collections.Generic;

namespace Elections
{
    internal class District
    {
        private string _name;
        private IEnumerable<Elector> _electors;

        public District(string name, IEnumerable<Elector> electors)
        {
            _name = name;
            _electors = new List<Elector>(electors);
        }

        public int GetElectorsCount()
        {
            return _electors.Count();
        }
    }
}
