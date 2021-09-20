﻿using System;

namespace Banking.Domain
{
    internal class Deposit : ITransaction
    {
        public DateTime Date { get; }
        public float Value { get; }
        public float Balance { get; }

        public Deposit(DateTime date, float value, float currentBalance)
        {
            this.Date = date;
            this.Value = value;
            this.Balance = currentBalance + value;
        }
    }
}
