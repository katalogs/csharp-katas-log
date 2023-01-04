using System;
using System.Collections;
using System.Collections.Generic;

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
            Accounts = new List<Account>();
        }

        public IEnumerable Accounts { get; set; }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
