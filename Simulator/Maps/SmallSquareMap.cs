using Simulator.Directions;

namespace Simulator.Maps;
public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int x, int y) : base(x, y)
    {
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < X && p.Y >= 0 && p.Y < Y;
    }
    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        if (!Exist(nextPoint))
            return p;
        return nextPoint;
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);
        if (!Exist(nextPoint))
            return p;
        return nextPoint;
    }
    public override string ToString()
    {
        return $"SmallSquareMap with size {X}x{Y}";
    }
}