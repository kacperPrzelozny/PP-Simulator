namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private Dictionary<string, List<Creature>> creaturePositions;

    public SmallMap(int x, int y): base(x, y)
    {
        if (x > 20 || y > 20) {
            throw new ArgumentOutOfRangeException("Both dimensions must be lower than 20");
        }

        creaturePositions = new Dictionary<string, List<Creature>>();
    }
    public override void Add(Creature c, Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException("Point is outside the map.");
        if (!creaturePositions.ContainsKey(p.ToString()))
        {
            creaturePositions[p.ToString()] = new List<Creature>();
        }
        creaturePositions[p.ToString()].Add(c);
        c.AssignToMap(this, p);
    }

    public override void Remove(Creature c, Point p)
    {
        if (!creaturePositions.ContainsKey(p.ToString())) { return; }

        creaturePositions[p.ToString()].Remove(c);
        if (creaturePositions[p.ToString()].Count == 0)
        {
            creaturePositions.Remove(p.ToString());
        }

    }

    public override void Move(Creature c, Point from, Point to)
    {
        if (!Exist(to))
        {
            throw new ArgumentOutOfRangeException("Destination point is outside the map.");
        }

        Remove(c, from);
        Add(c, to);
    }

    public override List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public override List<Creature> At(Point p)
    {
        if (!creaturePositions.ContainsKey(p.ToString()))
        {
            return new List<Creature>();
        }

        return creaturePositions[p.ToString()];
    }
}
