using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day11
{
    class Program
    {

        static void Main(string[] args)
        {

            //List<List<string>> map1 = new List<List<string>>{ new List<string> {"hydr-chp", "lith-chp" },
            //                                                 new List<string> {"hydr-gen" },
            //                                                 new List<string> {"lith-gen" },
            //                                                 new List<string> () { } };


            //List<List<string>> map1 = new List<List<string>>{ new List<string> { "thul-gen", "thul-chp", "plut-gen", "stro-gen"},
            //                                                 new List<string> { "plut-chp", "stro-chp"},
            //                                                 new List<string> { "prom-gen", "prom-chp", "ruth-gen", "ruth-chp"},
            //                                                 new List<string> (){ } };

            //List<List<string>> map2 = new List<List<string>>{ new List<string> {"hyp", "lip" },
            //                                                 new List<string> {"hyn" },
            //                                                 new List<string> {"lin" },
            //                                                 new List<string> () { } };

            List<List<string>> map2 = new List<List<string>>{ new List<string> { "thn", "thp", "pln", "stn", "eln", "elp", "din", "dip"},
                                                             new List<string> { "plp", "stp"},
                                                             new List<string> { "prn", "prp", "run", "rup"},
                                                             new List<string> (){ } };







            Building building = new Building(map2, 0);
            var buildingState = building.State;
            building.History.Add(buildingState, 0);



            var buildingStates = new Dictionary<string, int> { { buildingState, 0 } };
            var validSolves = new List<Building>();
            var buildings = new Queue<Building>();
            buildings.Enqueue(building);

            BreadthFirstSolve(buildings, buildingStates, validSolves);

            //DepthFirstSolve(new List<Building> { building }, buildingStates, validSolves);
            //DepthFirstSolve(building , buildingStates, validSolves);
            //SolveBuilding(building, validSolves, history);


            foreach (var validSolve in validSolves)
            {
                Console.WriteLine("VALID SOLVE:");
                foreach (var x in validSolve.History)
                {
                    Console.WriteLine(validSolve.History.Count());
                }
            }

            Console.ReadLine();
        }

        //public static void DepthFirstSolve(Building inputBuilding, Dictionary<string, int> buildingStates, List<Building> validSolves)
        //{
        //    var st = new StackTrace();
        //    //Console.CursorTop = st.FrameCount;
        //    Console.WriteLine(st.FrameCount);
        //    //var buildingCandidates = new List<Building>();
        //    //int i = 0;
        //    //foreach (var building in input)
        //    //{
        //    //Console.CursorLeft = 0;
        //    //Console.Write($"{i++}       ");

        //    var combinations = GetAllPossibleCombinations(inputBuilding.Map[inputBuilding.ElevatorFloor]);
        //    foreach (var combo in combinations)
        //    {
        //        if (inputBuilding.ElevatorFloor > 0)
        //        {
        //            var newBuilding = MoveItems(inputBuilding, inputBuilding.ElevatorFloor, inputBuilding.ElevatorFloor - 1, combo);
        //            if (newBuilding.IsSolved())
        //            {
        //                Console.WriteLine("###FOUND ONE####");
        //                validSolves.Add(newBuilding);
        //            }

        //            var newBuildingState = newBuilding.State;

        //            if (newBuilding.IsValid() && 
        //                !buildingStates.ContainsKey(newBuildingState) &&
        //                !newBuilding.History.ContainsKey(newBuildingState))
        //            {
        //                buildingStates.Add(newBuildingState, 0);
        //                newBuilding.History.Add(newBuildingState, 0);
        //                DepthFirstSolve(newBuilding, buildingStates, validSolves);
        //            }
        //        }
        //        if (inputBuilding.ElevatorFloor < 3)
        //        {
        //            var newBuilding = MoveItems(inputBuilding, inputBuilding.ElevatorFloor, inputBuilding.ElevatorFloor + 1, combo);
        //            if (newBuilding.IsSolved())
        //            {
        //                Console.WriteLine("###FOUND ONE####");
        //                validSolves.Add(newBuilding);
        //            }

        //            var newBuildingState = newBuilding.State;

        //            if (newBuilding.IsValid() &&
        //                !buildingStates.ContainsKey(newBuildingState) &&
        //                !newBuilding.History.ContainsKey(newBuildingState))
        //            {
        //                buildingStates.Add(newBuildingState, 0);
        //                newBuilding.History.Add(newBuildingState, 0);
        //                DepthFirstSolve(newBuilding, buildingStates, validSolves);
        //            }
        //        }
        //    }
        //}


        private static void BreadthFirstSolve(Queue<Building> buildings, Dictionary<string, int> buildingStates, List<Building> validSolves)
        {
            Console.WriteLine($"Checking {buildings.Count()} buildings");
            var buildingCandidates = new Queue<Building>();
            //generate the list of all the possible next steps
            int i = 0;
            while(buildings.Count != 0)
            //foreach (var building in buildings)
            {
                var building = buildings.Dequeue();
                Console.CursorLeft = 0;
                Console.Write($"{i++}         ");
                var combinations = GetAllPossibleCombinations(building.Map[building.ElevatorFloor]);
                foreach (var combo in combinations)
                {
                    if (building.ElevatorFloor > 0)
                    {
                        var newBuilding = MoveItems(building, building.ElevatorFloor, building.ElevatorFloor - 1, combo);
                        var newBuildingState = newBuilding.State;
                        if (newBuilding.IsValid() &&
                            !buildingStates.ContainsKey(newBuildingState) &&
                            !newBuilding.History.ContainsKey(newBuildingState))
                        {
                            buildingStates.Add(newBuildingState, 0);
                            newBuilding.History.Add(newBuildingState, 0);
                            buildingCandidates.Enqueue(newBuilding);
                        }
                        else
                        {
                            newBuilding = null;
                        }
                    }
                    if (building.ElevatorFloor < 3)
                    {
                        var newBuilding = MoveItems(building, building.ElevatorFloor, building.ElevatorFloor + 1, combo);
                        var newBuildingState = newBuilding.State;
                        if (newBuilding.IsValid() &&
                            !buildingStates.ContainsKey(newBuildingState) &&
                            !newBuilding.History.ContainsKey(newBuildingState))
                        {
                            buildingStates.Add(newBuildingState, 0);
                            newBuilding.History.Add(newBuildingState, 0);
                            buildingCandidates.Enqueue(newBuilding);
                        }
                        else
                        {
                            newBuilding = null;
                        }
                    }
                }
            }
            Console.WriteLine();
            var solution = buildingCandidates.Where(x => x.IsSolved());
            if (solution.Count() > 0)
            {
                Console.WriteLine("###FOUND ONE####");
                validSolves.AddRange(solution);
                return;
            }
            else
            {
                buildings.Clear();
                BreadthFirstSolve(buildingCandidates, buildingStates, validSolves);
            }
        }

        private static List<List<string>> GetAllPossibleCombinations(List<string> items)
        {
            var retVal = new List<List<string>>();
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    retVal.Add(new List<string> { items[i], items[j] });
                }
            }
            retVal.AddRange(items.Select(x => new List<string> { x }));
            return retVal;
        }



        public static Building MoveItems(Building building, int fromFloor, int toFloor, List<string> itemsToMove)
        {
            var newBuilding = (Building) building.Clone();
            newBuilding.Map[fromFloor].RemoveAll(x => itemsToMove.Contains(x));
            newBuilding.Map[toFloor].AddRange(itemsToMove);
            newBuilding.ElevatorFloor = toFloor;
            return newBuilding;
        }

        static List<List<string>> GetAllPossiblePairs(List<string> items)
        {
            var retVal = new List<List<string>>();
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    retVal.Add(new List<string> { items[i], items[j] });
                }
            }
            return retVal;
        }

    }
}
