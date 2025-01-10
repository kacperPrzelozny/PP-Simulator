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

    public Map? Map {
        get => Map;
        set {
            if (Map == null)
            {
                Map = value;
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
        if (this.level == 10) { return; }

        this.level++;
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

    // static methods
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
