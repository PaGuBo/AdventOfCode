using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    class Program
    {

        static void Main(string[] args)
        {

            var sampleInput = new List<HashSet<Item>> {
                new HashSet<Item> {
                    new Item(Material.HYDROGEN, ItemType.MICROCHIP),
                    new Item(Material.LITHIUM, ItemType.MICROCHIP)},

                new HashSet<Item> {
                    new Item(Material.HYDROGEN, ItemType.GENERATOR)},

                new HashSet<Item> {
                    new Item(Material.LITHIUM, ItemType.GENERATOR)},

                new HashSet<Item> { } };


            var Part1Input = new List<HashSet<Item>> {
                new HashSet<Item> {
                    new Item(Material.THULIUM, ItemType.GENERATOR),
                    new Item(Material.THULIUM, ItemType.MICROCHIP),
                    new Item(Material.PLUTONIUM, ItemType.GENERATOR),
                    new Item(Material.STRONTIUM, ItemType.GENERATOR),},


                new HashSet<Item> {
                    new Item(Material.PLUTONIUM, ItemType.MICROCHIP),
                    new Item(Material.STRONTIUM, ItemType.MICROCHIP)},


                new HashSet<Item> {
                    new Item(Material.PROMETHIUM, ItemType.GENERATOR),
                    new Item(Material.PROMETHIUM, ItemType.MICROCHIP),
                    new Item(Material.RUTHENIUM, ItemType.GENERATOR),
                    new Item(Material.RUTHENIUM, ItemType.GENERATOR),},

                new HashSet<Item> { } };

            var Part2Input = new List<HashSet<Item>> {
                new HashSet<Item> {
                    new Item(Material.THULIUM, ItemType.GENERATOR),
                    new Item(Material.THULIUM, ItemType.MICROCHIP),
                    new Item(Material.PLUTONIUM, ItemType.GENERATOR),
                    new Item(Material.STRONTIUM, ItemType.GENERATOR),
                    new Item(Material.ELERIUM, ItemType.GENERATOR),
                    new Item(Material.ELERIUM, ItemType.MICROCHIP),
                    new Item(Material.DILITHIUM, ItemType.GENERATOR),
                    new Item(Material.DILITHIUM, ItemType.MICROCHIP),},


                new HashSet<Item> {
                    new Item(Material.PLUTONIUM, ItemType.MICROCHIP),
                    new Item(Material.STRONTIUM, ItemType.MICROCHIP)},


                new HashSet<Item> {
                    new Item(Material.PROMETHIUM, ItemType.GENERATOR),
                    new Item(Material.PROMETHIUM, ItemType.MICROCHIP),
                    new Item(Material.RUTHENIUM, ItemType.GENERATOR),
                    new Item(Material.RUTHENIUM, ItemType.GENERATOR),},

                new HashSet<Item> { } };

            Building building = new Building(Part2Input, 0);
            var buildingState = building.State;
            building.History.Add(buildingState);



            var buildingStates = new HashSet<string> { { buildingState } };
            var validSolves = new List<Building>();
            var buildings = new Queue<Building>();
            buildings.Enqueue(building);

            BreadthFirstSolve(buildings, buildingStates, validSolves);
            Console.ReadLine();
        }



        private static void BreadthFirstSolve(Queue<Building> buildings, HashSet<string> buildingStates, List<Building> validSolves)
        {
            Console.WriteLine($"Checking {buildings.Count()} buildings");
            var buildingCandidates = new Queue<Building>();
            //generate the list of all the possible next steps
            int i = 0;
            while (buildings.Count != 0)
            {
                var building = buildings.Dequeue();
                Console.CursorLeft = 0;
                Console.Write($"{i++}         ");
                var combinations = GetAllPossibleCombinations(building.Map[building.ElevatorFloor].ToList());
                foreach (var combo in combinations)
                {
                    if (building.ElevatorFloor > 0 && building.Map[building.ElevatorFloor - 1].Count != 0)
                    {
                        var newBuilding = MoveItems(building, building.ElevatorFloor, building.ElevatorFloor - 1, combo);
                        var newBuildingState = newBuilding.State;
                        if (newBuilding.IsValid() &&
                            !buildingStates.Contains(newBuildingState) &&
                            !newBuilding.History.Contains(newBuildingState))
                        {
                            buildingStates.Add(newBuildingState);
                            newBuilding.History.Add(newBuildingState);
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
                            !buildingStates.Contains(newBuildingState) &&
                            !newBuilding.History.Contains(newBuildingState))
                        {
                            buildingStates.Add(newBuildingState);
                            newBuilding.History.Add(newBuildingState);
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
                Console.WriteLine($"FOUND A SOLUTION IN {solution.First().History.Count()} STEPS");
                validSolves.AddRange(solution);
                return;
            }
            else
            {
                buildings.Clear();
                BreadthFirstSolve(buildingCandidates, buildingStates, validSolves);
            }
        }

        private static List<List<Item>> GetAllPossibleCombinations(List<Item> items)
        {
            var retVal = new List<List<Item>>();
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    retVal.Add(new List<Item> { items[i], items[j] });
                }
            }
            retVal.AddRange(items.Select(x => new List<Item> { x }));
            return retVal;
        }

        public static Building MoveItems(Building building, int fromFloor, int toFloor, List<Item> itemsToMove)
        {
            var newBuilding = (Building) building.Clone();

            //remove items from the current floor
            var fromFloorList = newBuilding.Map[fromFloor].ToList();
            fromFloorList.RemoveAll(x => itemsToMove.Contains(x));
            newBuilding.Map[fromFloor] = new HashSet<Item>(fromFloorList);

            //add items to the new floor
            var toFloorList = newBuilding.Map[toFloor].ToList();
            toFloorList.AddRange(itemsToMove);
            newBuilding.Map[toFloor] = new HashSet<Item>(toFloorList);

            newBuilding.ElevatorFloor = toFloor;
            return newBuilding;
        }
    }
}
