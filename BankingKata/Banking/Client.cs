using System.Collections.Generic;

namespace Banking
{
    public class Client
    {
        public readonly string Name;
        private string name;

        public Client(string name)
        {
            this.name = name;
        }
    }
}
