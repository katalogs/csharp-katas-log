using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Items
{
    public class LegendaryItem : Item
    {
        public LegendaryItem(string name,int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }
        public override void UpdateQuality()
        {
        }
    }
}
