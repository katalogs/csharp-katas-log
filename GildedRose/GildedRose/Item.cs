namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public override string ToString()
        {
            return Name + ", " + SellIn + ", " + Quality;
        }

        public virtual void UpdateQuality()
        {
            switch (Name)
            {
                
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    DecreaseQuality();

                    DecreaseSellIn();

                    if (IsExpired())
                    {
                        DecreaseQuality();
                    }

                    break;
            }
        }

        internal void DecreaseQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }
        }

        internal void IncrementQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }
        }

        internal bool IsExpired() => this.SellIn < 0;

        internal void DecreaseSellIn() => this.SellIn--;

        internal void DropQuality() => this.Quality=0;
    }
}
