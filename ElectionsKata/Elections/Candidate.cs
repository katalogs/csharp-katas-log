namespace Elections
{
    public record Candidate(string Name)
    {
        public bool HasEmptyName()
        {
            return Name == string.Empty;
        }
    }
}
