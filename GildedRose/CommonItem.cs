using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class CommonItem : Item
    {
        public CommonItem(Item item) : base(item.Name, item.SellIn, item.Quality)
        {
        }

        public override void Update()
        {
            SellIn -= 1;
            Quality -= 1; 
            if (SellIn < 0)
                Quality -= 1;
            if (Quality <0)
                Quality = 0;
        }

    }
}
