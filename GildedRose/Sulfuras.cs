using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class Sulfuras : Item
    {
        public Sulfuras(Item item) : base(item.Name, item.SellIn, item.Quality)
        {
        }

        public override void Update()
        {
        }
    }
}
