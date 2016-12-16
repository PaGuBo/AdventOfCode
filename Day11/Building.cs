using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Building : ICloneable
    {
        public List<HashSet<Item>> Map { get; private set; }
        public HashSet<string> History { get; set; }
        public int ElevatorFloor { get; set; }

        public Building(List<HashSet<Item>> map, int elevatorFloor) : this(map, elevatorFloor, new HashSet<string>())
        {

        }
        public Building(List<HashSet<Item>> map, int elevatorFloor, HashSet<string> history)
        {
            Map = map;
            ElevatorFloor = elevatorFloor;
            History = history;
        }
        //i could probably save a lot of time by figuring out a better way to serialize the data
        public string State
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append($"({ElevatorFloor}) ");
                for (int i = 0; i < Map.Count; i++)
                {
                    sb.Append($"F{i}:");

                    var groupedItems = Map[i].GroupBy(x => x.Material)
                                           .Select(g => new {
                                               Material = g.Key, 
                                               Count = g.Count(),
                                               Type = g.Count() == 2 ? 0 : g.FirstOrDefault().ItemType
                                           }).ToList();
                    //add all the pairs
                    sb.Append($"P{groupedItems.Where(x => x.Count == 2).Count()}");
                    foreach(var item in groupedItems.Where(x => x.Count == 1).OrderBy(x => x.Material))
                    {
                        sb.Append($"[{(byte) item.Material},{(byte) item.Type}] ");
                    }
                }
                return sb.ToString().Trim();
            }
        }



        public bool IsValid()
        {
            foreach (var floor in Map)
            {
                if (floor.All(x => x.ItemType == ItemType.GENERATOR) || //this floor only has chips 
                    floor.All(x => x.ItemType == ItemType.MICROCHIP))   //or only has generators
                {
                    continue;
                }
                //find all the chips
                //then for all the chips make sure there's a generator on the floor
                else if (floor.Where(x => x.ItemType == ItemType.MICROCHIP)
                              .All(x => floor.Where(y => y.ItemType == ItemType.GENERATOR)
                                             .Any(y => y.Material == x.Material)))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            //check to make sure that the building doesn't have duplicate history
            //this means elevator went back to a previus identical state, which we don't want
            if (History.Count() != History.Distinct().Count())
            {
                return false;
            }
            if (History.Count > 10000)
            {
                return false;
            }
            return true;
        }
        public bool IsSolved()
        {
            return Map[0].Count == 0 && Map[1].Count == 0 && Map[2].Count == 0 &&
                (Map[3].Where(x => x.ItemType == ItemType.MICROCHIP)
                              .All(x => Map[3].Where(y => y.ItemType == ItemType.GENERATOR)
                                             .Any(y => y.Material == x.Material)));
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            //sb.AppendLine(this.History.Count().ToString());

            //for (int i = 0; i < Map.Count; i++)
            //{
            //    if (i == ElevatorFloor)
            //    {
            //        sb.Append($"{new String(' ', this.History.Count())}[E] F{i}: ");
            //    }
            //    else
            //    {
            //        sb.Append($"{new String(' ', this.History.Count())}    F{i}: ");
            //    }
            //    foreach(var item in Map[i].OrderBy(x => x))
            //    {
            //        sb.Append($"[{item}]");
            //    }
            //    sb.Append($"\n");
            //}
            return sb.ToString();
        }

        public object Clone()
        {
            var map = new List<HashSet<Item>>();
            foreach (var floor in Map)
            {
                var items = new HashSet<Item>(floor);
                //items.AddRange(floor);
                map.Add(items);
            }
            var history = new HashSet<string>();
            history.UnionWith(History);

            return new Building(map, ElevatorFloor, history);
        }


    }

}
