using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace Simulator;

public abstract class Creature
{
    // properties

    private string name = "Unknown";
    public string Name
    {
        get { return name; }
        init { name = Validator.Shortener(value, 3, 25); }
    }
    private int level;
    public int Level
    {
        get { return level; }
        init { level = Validator.Limiter(value, 1, 10); }
    }

    public abstract string Info { get; }

    public abstract int Power { get; }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    // public methods

    public Creature() { }

    public abstract void SayHi();

    public void Upgrade()
    {
        if (this.level == 10) { return; }

        this.level++;
    }

    public void Go(Direction direction)
    {
        Console.WriteLine($"{name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }

    // static methods
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
