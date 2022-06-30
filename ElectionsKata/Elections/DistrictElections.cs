namespace Elections
{
    public class DistrictElections : Elections
    {
        public DistrictElections(Dictionary<string, List<string>> list) : base(list, true)
        {

        }
    }
}
