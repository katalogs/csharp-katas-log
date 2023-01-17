namespace GildedRoseKata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item("+5 Dexterity Vest", 10, 20),
                new Cheese(Cheese.AgedBrie, 2, 0),
                new Item("Elixir of the Mongoose", 5, 7),
                new LegendaryItem(LegendaryItem.SulfurasHandRagnaros, 0, 80),
                new LegendaryItem(LegendaryItem.SulfurasHandRagnaros, -1,  80),
                new Item(Item.TAFKAL80ETC, 15, 20),
                new Item(Item.TAFKAL80ETC, 10, 49),
                new Item(Item.TAFKAL80ETC, 5, 49),
                // this conjured item does not work properly yet
                new Item("Conjured Mana Cake", 3, 6)
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
