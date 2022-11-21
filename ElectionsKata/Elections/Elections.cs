using System.Globalization;

namespace Elections
{
    public abstract class Elections
    {
        protected readonly List<string> OfficialCandidates = new();

        protected readonly List<string> CandidatesAndOthers = new();

        protected readonly Dictionary<string, List<string>> ElectoralList;


        protected Elections(Dictionary<string, List<string>> electoralList)
        {
            ElectoralList = electoralList;
        }

        public virtual void AddCandidate(string candidate)
        {
            OfficialCandidates.Add(candidate);
            CandidatesAndOthers.Add(candidate);
            
        }

        public abstract void VoteFor(string elector, string candidate, string electorDistrict);
        

        public abstract Dictionary<string, string> Results();

        protected static float CalculatePercentage(int partVotes, int totalVotes)
        {
            return (float) partVotes * 100 / totalVotes;
        }

        protected static string FormatResult(float blankResult)
        {
            return string.Format(new CultureInfo("fr-fr"), "{0:0.00}%", blankResult);
        }
    }
}
