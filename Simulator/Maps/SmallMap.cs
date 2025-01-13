namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private Dictionary<Point, List<IMappable>> creaturePositions;

    public SmallMap(int x, int y): base(x, y)
    {
        if (x > 20 || y > 20) {
            throw new ArgumentOutOfRangeException("Both dimensions must be lower than 20");
        }

        creaturePositions = new Dictionary<Point, List<IMappable>>();
    }
    public override void Add(IMappable c, Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException("Point is outside the map.");
        if (!creaturePositions.ContainsKey(p))
        {
            creaturePositions[p] = new List<IMappable>();
        }
        creaturePositions[p].Add(c);
        c.AssignToMap(this, p);
    }

    public override void Remove(IMappable c, Point p)
    {
        if (!creaturePositions.ContainsKey(p)) { return; }

        creaturePositions[p].Remove(c);
        if (creaturePositions[p].Count == 0)
        {
            creaturePositions.Remove(p);
        }

    }

    public override void Move(IMappable c, Point from, Point to)
    {
        if (!Exist(to))
        {
            throw new ArgumentOutOfRangeException("Destination point is outside the map.");
        }

        Remove(c, from);
        Add(c, to);
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public override List<IMappable> At(Point p)
    {
        if (!creaturePositions.ContainsKey(p))
        {
            return new List<IMappable>();
        }

        return creaturePositions[p];
    }

    public override Dictionary<Point, char> GetCreaturesFromMap()
    {
        Dictionary<Point, char> symbols = new Dictionary<Point, char>();
        foreach (var position in creaturePositions)
        {
            Point p = position.Key;
            List<IMappable> creaturesAt = At(p);
            char symbol;

            if (creaturesAt.Count > 1)
            {
                symbol = 'X';
            }
            else if (creaturesAt.Count == 1)
            {
                symbol = creaturesAt.First().Symbol[0];
            }
            else continue;
            
            symbols.Add(p, symbol);
        }

        return symbols;
    }
}
