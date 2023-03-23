namespace Elections
{
    public class Candidate
    {
        public string Name { get;}

        public Candidate(string candidateName)
        {
            this.Name = candidateName;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Candidate);
        }

        public bool Equals(Candidate? candidate)
        {
            return candidate != null && Name == candidate?.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
