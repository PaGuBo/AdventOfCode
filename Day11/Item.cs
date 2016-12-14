using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Item
    {
        public Item(Material material, ItemType itemType)
        {
            Material = material;
            ItemType = itemType;
        }
        public Material Material;
        public ItemType ItemType;
    }
}
