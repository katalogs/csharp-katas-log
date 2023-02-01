namespace Banking
{

    /// <summary>
    /// The wallet account class
    /// </summary>
    /// <seealso cref="Account"/>
    public class WalletAccount : Account
    {
        /// <inheritdoc />
        public long Id { get; set; }
    }

}
