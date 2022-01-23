using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class Backstage : Item
    {
        public Backstage(Item item) : base(item.Name, item.SellIn, item.Quality)
        {
        }

        public override void Update()
        {
            SellIn -= 1;
            Quality += 1;
            if (SellIn <= 10)
                Quality += 1;
            if (SellIn <= 5)
                Quality += 1;
            if (SellIn < 0)
                Quality += 1;
            if (Quality > 50)
                Quality = 50; 
        }
    }
}
