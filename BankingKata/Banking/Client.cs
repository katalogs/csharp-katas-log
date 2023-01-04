using System.Collections;

namespace Banking
{
    public class Client
    {
        public readonly string Name;

        public Client(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NotEmptyNameException();

            Name = name;
        }

        public IEnumerable Accounts { get; set; }
    }
}
