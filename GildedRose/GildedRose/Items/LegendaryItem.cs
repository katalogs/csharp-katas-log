using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Items
{
    public class LegendaryItem : Item
    {

         public LegendaryItem (String name, int sellIn, int quality) :base (name, sellIn, quality)
    {
        
    }
        public override void UpdateQuality()
        {
        }
    }
}
