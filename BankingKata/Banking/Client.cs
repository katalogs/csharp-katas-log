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
            Accounts = new List<IAccount>();
        }

        public IList<IAccount> Accounts { get; private set; }

        public void AddAccount(IAccount account)
        {
            Accounts.Add(account);
        }
    }
}
