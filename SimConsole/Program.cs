﻿using Simulator;
using Simulator.Animals;
using Simulator.Creatures;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        //Console.OutputEncoding = Encoding.UTF8;
        //Lab8();
        Lab10a();
        //SmallSquareMap map = new(5, 5);
        //List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        //List<Point> points = [new(2, 2), new(3, 1)];
        //string moves = "dlrludl";

        //Simulation simulation = new(map, creatures, points, moves);
        //MapVisualiser mapVisualizer = new(simulation.Map);

        //mapVisualizer.Draw();
        //while (!simulation.Finished)
        //{
        //    Console.WriteLine(simulation.CurrentMoveName);
        //    Console.WriteLine(simulation.CurrentCreature);
        //    simulation.Turn();
        //    mapVisualizer.Draw();
        //}


        //map = new(10, 12);
        //creatures = [
        //    new Orc("Gorbag"),
        //    new Elf("Elandor"),
        //    new Orc("Orc1"),
        //    new Elf("Legolas"),
        //    new Orc("Orc2"),
        //    new Elf("Elf1"),
        //];
        //points = [
        //    new(2, 2),
        //    new(3, 1),
        //    new(4, 5),
        //    new(5, 6),
        //    new(6, 7),
        //    new(7, 8),
        //];
        //moves = "ruldlurdruldlurdruldlurd";

        //simulation = new(map, creatures, points, moves);
        //mapVisualizer = new(simulation.Map);

        //Console.Clear();
        //mapVisualizer.Draw();
        //Console.WriteLine(simulation.CurrentMoveName);
        //Console.WriteLine($"{simulation.CurrentCreature}, {simulation.CurrentCreature.Position}");
        //Console.WriteLine("Press any key to continue...");
        //Console.ReadKey();
        //while (!simulation.Finished)
        //{
        //    Console.Clear();
        //    simulation.Turn();
        //    mapVisualizer.Draw();
        //    Console.WriteLine(simulation.CurrentMoveName);
        //    Console.WriteLine($"{simulation.CurrentCreature}, {simulation.CurrentCreature.Position}");
        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        //}
    }

    static void Lab8()
    {
        SmallTorusMap map = new(8, 6);

        List<IMappable> creatures = [
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals() { Description = "Rabbits", Size = 20 },
            new Birds() {Description = "Eagles", Size = 5, CanFly = true},
            new Birds() {Description = "Ostriches", Size = 5, CanFly = false},
        ];
        List<Point> points = [
            new(2, 2),
            new(3, 1),
            new(4, 5),
            new(0, 1),
            new(1, 0),
        ];
        string moves = "ruldlurdruldlur";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualiser mapVisualizer = new(simulation.Map);

        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine(simulation.CurrentMoveName);
        Console.WriteLine($"{simulation.CurrentCreature}, {simulation.CurrentCreature.Position}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        while (!simulation.Finished)
        {
            Console.Clear();
            simulation.Turn();
            mapVisualizer.Draw();
            Console.WriteLine(simulation.CurrentMoveName);
            Console.WriteLine($"{simulation.CurrentCreature}, {simulation.CurrentCreature.Position}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void Lab10a()
    {
        SmallTorusMap map = new(8, 6);

        List<IMappable> creatures = [
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals() { Description = "Rabbits", Size = 20 },
            new Birds() {Description = "Eagles", Size = 5, CanFly = true},
            new Birds() {Description = "Ostriches", Size = 5, CanFly = false},
        ];
        List<Point> points = [
            new(2, 2),
            new(3, 1),
            new(4, 5),
            new(0, 1),
            new(1, 0),
        ];
        string moves = "ruldlurdruldlur";

        Simulation simulation = new(map, creatures, points, moves);
        SimulationHistory history = new(simulation);
        foreach (SimulationTurnLog turn in history.TurnLogs)
        {
            Console.WriteLine(turn.Mappable);
            Console.WriteLine(turn.Move);
            foreach (var position in turn.Symbols)
            {
                Console.WriteLine($"{position.Key.ToString()} => {position.Value}");
            }

        }
    }
}
