using Simulator.Directions;
using Simulator.Maps;
using Simulator.Validators;

namespace Simulator.Creatures;

public abstract class Creature : IMappable
{
    // properties

    private string name = "Unknown";

    public abstract string Symbol { get; }

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

    private Map? map;
    public Map? Map
    {
        get => map;
        set
        {
            if (map == null)
            {
                map = value;
            }
        }
    }

    public Point? Position { get; private set; }

    public bool IsAssigned;

    // constructors

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
        IsAssigned = false;
    }

    public Creature(string name, int level, Map map, Point position)
    {
        Name = name;
        Level = level;
        Map = map;
        Position = position;
        IsAssigned = true;
    }

    // public methods

    public Creature() { }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (level == 10) { return; }

        level++;
    }

    public void AssignToMap(Map map, Point position)
    {
        if (IsAssigned) { return; }
        if (!map.Exist(position)) { return; }

        Map = map;
        Position = position;
        IsAssigned = true;

        Map.Add(this, position);
    }

    public void Go(Direction direction)
    {
        if (Map == null) { return; }
        if (Position == null) { return; }

        Point currentPosition = new Point(Position.Value.X, Position.Value.Y);
        Point next = Map.Next(currentPosition, direction);

        if (Map.Exist(next))
        {
            Map.Move(this, currentPosition, next);
            Position = next;
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    // static methods

    public static void AssignManyCreaturesToMap(Map map, List<IMappable> creatures, List<Point> positions)
    {
        if (creatures.Count() != positions.Count()) { return; }

        for (int i = 0; i < creatures.Count(); i++)
        {
            creatures[i].AssignToMap(map, positions[i]);
        }
    }
}
