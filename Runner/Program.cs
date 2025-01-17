﻿using Simulator.Directions;
using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab7a();
    }

    static void Lab5a()
    {
        Console.WriteLine("LAB 5A\n");
        var p1 = new Point(1, 2);
        var p2 = new Point(3, 4);
        var p3 = new Point(5, 6);
        var r1 = new Rectangle(p1, p2);
        Console.WriteLine(r1); // (1, 2):(3, 4)
        Console.WriteLine(r1.Contains(p1)); // True
        Console.WriteLine(r1.Contains(p2)); // True
        Console.WriteLine(r1.Contains(p3)); // False
        Console.WriteLine(r1.Contains(new Point(2, 3))); // True
        Console.WriteLine(r1.Contains(new Point(0, 0))); // False
        Console.WriteLine(r1.Contains(new Point(5, 5))); // False

        // Test moving
        Console.WriteLine("\nMoving test:");
        Console.WriteLine(p1);
        Console.WriteLine(p1.Next(Direction.Up)); // (1, 3)
        Console.WriteLine(p1.Next(Direction.Right)); // (2, 2)
        Console.WriteLine(p1.Next(Direction.Down)); // (1, 1)
        Console.WriteLine(p1.Next(Direction.Left)); // (0, 2)

        // Test diagonal moving
        Console.WriteLine("\nDiagonal moving test:");
        Console.WriteLine(p1);
        Console.WriteLine(p1.NextDiagonal(Direction.Up)); // (2, 3)
        Console.WriteLine(p1.NextDiagonal(Direction.Right)); // (2, 1)
        Console.WriteLine(p1.NextDiagonal(Direction.Down)); // (0, 1)
        Console.WriteLine(p1.NextDiagonal(Direction.Left)); // (0, 3)

        try
        {
            var r2 = new Rectangle(p1, p1);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message); // Rectangle can't have 2 same points
        }
    }

    public static void Lab5b()
    {
        // Test SmallSquareMap - size 6
        SmallSquareMap map = new SmallSquareMap(7, 7);
        Console.WriteLine(map); //SmallSquareMap with size 7x7
        // Test point exist in map
        Point p1 = new Point(0, 0);
        Console.WriteLine($"Point {p1} exists in map: {map.Exist(p1)}"); //Point (0, 0) exists in map: True
        // Test moving point in map
        Point p2 = new Point(3, 3);
        Console.WriteLine($"Test moving point\nStart point: {p2}");
        var nextPoint = map.Next(p2, Direction.Right);
        Console.WriteLine($"Next point in Right direction: {nextPoint}"); //Next point in Right direction: (4, 3)
        nextPoint = map.Next(nextPoint, Direction.Down);
        Console.WriteLine($"Next point in Down direction: {nextPoint}"); //Next point in Right direction: (4, 2)
        nextPoint = map.Next(nextPoint, Direction.Left);
        Console.WriteLine($"Next point in Left direction: {nextPoint}"); //Next point in Right direction: (3, 2)
        nextPoint = map.Next(nextPoint, Direction.Up);
        Console.WriteLine($"Next point in Up direction: {nextPoint}"); //Next point in Right direction: (3, 3)
        // Test moving point diagonally
        Point p3 = new Point(3, 3);
        Console.WriteLine($"Test moving point diagonally\nStart point: {p3}");
        nextPoint = map.NextDiagonal(p2, Direction.Right);
        Console.WriteLine($"Next point in Right direction: {nextPoint}"); //Next point in Right direction: (4, 2)
        nextPoint = map.NextDiagonal(nextPoint, Direction.Down);
        Console.WriteLine($"Next point in Down direction: {nextPoint}"); //Next point in Right direction: (3, 1)
        nextPoint = map.NextDiagonal(nextPoint, Direction.Left);
        Console.WriteLine($"Next point in Left direction: {nextPoint}"); //Next point in Right direction: (2, 2)
        nextPoint = map.NextDiagonal(nextPoint, Direction.Up);
        Console.WriteLine($"Next point in Up direction: {nextPoint}"); //Next point in Right direction: (3, 3)
        //Test moving out of map
        Point p4 = new Point(6, 6);
        Console.WriteLine($"Test moving out of map\nStart point: {p4}");
        nextPoint = map.Next(p4, Direction.Right);
        Console.WriteLine($"Next point in Right direction: {nextPoint}"); //Next point in Right direction: (6, 6)
    }

    public static void Lab7a()
    {
        SmallSquareMap map = new SmallSquareMap(7, 7);
        var p1 = new Point(3, 3);
        var p2 = new Point(4, 4);

        var e = new Elf("Legolas", 5);
        var o = new Orc("Grom", 3);

        Simulation sim = new Simulation(map, new List<IMappable> { e, o },
            new List<Point> { p1, p2 }, "RrLl");

        Console.WriteLine(sim.Map); // SmallSquareMap with size 7x7
        Console.WriteLine(sim.CurrentCreature); // ELF: Legolas, level 5
        Console.WriteLine(sim.CurrentCreature.Position); // (3, 3)
        Console.WriteLine(e.Position);
        Console.WriteLine(sim.CurrentMoveName); // R

        sim.Turn();
        Console.WriteLine(sim.CurrentCreature); // ORC: Grom, level 3
        Console.WriteLine(sim.CurrentCreature.Position); // (4, 4)
        Console.WriteLine(o.Position);
        Console.WriteLine(sim.CurrentMoveName); // R

        sim.Turn();
        Console.WriteLine(sim.CurrentCreature); // ELF: Legolas, level 5
        Console.WriteLine(sim.CurrentCreature.Position); // (4, 3)
        Console.WriteLine(e.Position);
        Console.WriteLine(sim.CurrentMoveName); // L

        sim.Turn();
        Console.WriteLine(sim.CurrentCreature); // ORC: Grom, level 3
        Console.WriteLine(sim.CurrentCreature.Position); // (5, 4)
        Console.WriteLine(o.Position);
        Console.WriteLine(sim.CurrentMoveName); // L

        sim.Turn();
        Console.WriteLine(sim.CurrentCreature); // ELF: Legolas, level 5
        Console.WriteLine(sim.CurrentCreature.Position); // (3, 3)
        Console.WriteLine(e.Position);
        Console.WriteLine(sim.Finished); // True

        try
        {
            sim.Turn();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message); // Simulation is finished.
        }

        var creaturesAt = sim.Map.At(p1);
        Console.WriteLine(creaturesAt.Count); // 1
        Console.WriteLine(creaturesAt[0]); // ELF: Legolas, level 5
        Console.WriteLine(creaturesAt[0].Position); // (3, 3)

        creaturesAt = sim.Map.At(p2);
        Console.WriteLine(creaturesAt.Count); // 1
        Console.WriteLine(creaturesAt[0]); // ORC: Grom, level 3
        Console.WriteLine(creaturesAt[0].Position); // (4, 4)
    }
}
