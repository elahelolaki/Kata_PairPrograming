using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class Calculate
    {
        public List<Item> Items { get; set; }

        public Calculate(List<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        new AgedBrie(item).Update();
                        break;
                    case "Backstage passes":
                        new Backstage(item).Update();
                        break;
                    case "Sulfuras":
                        new Sulfuras(item).Update();
                        break; 
                    default:
                        new CommonItem(item).Update();
                        break;
                }
            }
        }
    }
}
