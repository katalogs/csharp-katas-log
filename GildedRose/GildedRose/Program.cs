﻿namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = Item.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = Item.SulfurasHandRagnaros, SellIn = 0, Quality = 80},
                new Item {Name = Item.SulfurasHandRagnaros, SellIn = -1, Quality = 80},
                new Item
                {
                    Name = Item.TAFKAL80ETC,
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = Item.TAFKAL80ETC,
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = Item.TAFKAL80ETC,
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
