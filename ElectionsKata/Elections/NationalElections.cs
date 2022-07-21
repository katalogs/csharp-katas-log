using System.Globalization;

namespace Elections
{
    public class NationalElections : Elections
    {
        public NationalElections(Dictionary<string, List<string>> list) : base (list, false)
        {

        }

        public override void VoteFor(string elector, string candidate, string electorDistrict)
        {
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

        public override Dictionary<string, string> Results()
        {
            var results = new Dictionary<string, string>();
            var nbVotes = 0;
            var nullVotes = 0;
            var blankVotes = 0;
            var nbValidVotes = 0;
            var cultureInfo = new CultureInfo("fr-fr");

            nbVotes = ResultWithDisctrict(results, ref nullVotes, ref blankVotes, ref nbValidVotes, cultureInfo);

            var blankResult = (float)blankVotes * 100 / nbVotes;
            results["Blank"] = string.Format(cultureInfo, "{0:0.00}%", blankResult);

            var nullResult = (float)nullVotes * 100 / nbVotes;
            results["Null"] = string.Format(cultureInfo, "{0:0.00}%", nullResult);

            var nbElectors = _list.Sum(kv => kv.Value.Count);
            var abstentionResult = 100 - (float)nbVotes * 100 / nbElectors;
            results["Abstention"] = string.Format(cultureInfo, "{0:0.00}%", abstentionResult);

            return results;
        }

        private int ResultWithDisctrict(Dictionary<string, string> results, ref int nullVotes, ref int blankVotes, ref int nbValidVotes, CultureInfo cultureInfo)
        {
            int nbVotes = _votesWithoutDistricts.Select(i => i).Sum();
            for (var i = 0; i < _officialCandidates.Count; i++)
            {
                var index = _candidates.IndexOf(_officialCandidates[i]);
                nbValidVotes += _votesWithoutDistricts[index];
            }

            for (var i = 0; i < _votesWithoutDistricts.Count; i++)
            {
                var candidateResult = (float)_votesWithoutDistricts[i] * 100 / nbValidVotes;
                var candidate = _candidates[i];

                if (_officialCandidates.Contains(candidate))
                {
                    results[candidate] = string.Format(cultureInfo, "{0:0.00}%", candidateResult);
                }
                else
                {
                    if (_candidates[i] == string.Empty)
                        blankVotes += _votesWithoutDistricts[i];
                    else
                        nullVotes += _votesWithoutDistricts[i];
                }
            }

            return nbVotes;
        }
    }
}
