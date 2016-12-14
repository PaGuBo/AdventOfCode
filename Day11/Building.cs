﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Building : ICloneable
    {
        public List<List<string>> Map { get; private set; }
        public Dictionary<string, int> History { get; set; }
        public int ElevatorFloor { get; set; }

        public Building(List<List<string>> map, int elevatorFloor) : this(map, elevatorFloor, new Dictionary<string, int>())
        {

        }
        public Building(List<List<string>> map, int elevatorFloor, Dictionary<string, int> history)
        {
            Map = map;
            ElevatorFloor = elevatorFloor;
            History = history;
        }
        public string State
        {
            get
            {
                var sb = new StringBuilder();
                for(int i = 0; i < Map.Count; i++)
                {
                    sb.Append($"F{i}:");
                    foreach (var item in Map[i].OrderBy(x => x))
                    {
                        sb.Append($"{item} ");
                    }
                    
                }
                sb.Append($"E:{ElevatorFloor}");
                return sb.ToString().Trim();
            }
        }

        

        public bool IsValid()
        {
            //foreach (var floor in Map)
            //{
            //    if (floor.All(x => x.Substring(4) == "-chp") || //this floor only has chips 
            //        floor.All(x => x.Substring(4) == "-gen"))   //or only has generators
            //    {
            //        continue;
            //    }
            //    //find all the chips
            //    //then for all the chips make sure there's a generator on the floor
            //    else if (floor.Where(x => x.Substring(4) == "-chp") 
            //                  .All(x => floor.Where(y => y.Substring(4) == "-gen")
            //                                 .Any(y => y.Substring(0, 4) == x.Substring(0, 4))))
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            ////check to make sure that the building doesn't have duplicate history
            ////this means elevator went back to a previus identical state, which we don't want
            //if (History.Count() != History.Distinct().Count())
            //{
            //    return false;
            //}
            //if (History.Count > 10000)
            //{
            //    return false;
            //}
            //return true;



            foreach (var floor in Map)
            {
                if (floor.All(x => x[2] == 'p') || //this floor only has chips 
                    floor.All(x => x[2] == 'n'))   //or only has generators
                {
                    continue;
                }
                //find all the chips
                //then for all the chips make sure there's a generator on the floor
                else if (floor.Where(x => x[2] == 'p')
                              .All(x => floor.Where(y => y[2] == 'n')
                                             .Any(y => y.Substring(0, 2) == x.Substring(0, 2))))
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
                (Map[3].Where(x => x[2] == 'p')
                              .All(x => Map[3].Where(y => y[2] == 'n')
                                             .Any(y => y.Substring(0, 2) == x.Substring(0, 2))));
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
            var map = new List<List<string>>();
            foreach(var floor in Map)
            {
                var items = new List<string>();
                items.AddRange(floor);
                map.Add(items);
            }
            var history = new Dictionary<string, int>();
            foreach (var x in History)
            {
                history.Add(x.Key, x.Value);
            }
            

            return new Building(map, ElevatorFloor, history);
        }


    }

}