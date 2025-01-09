namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20) {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
        }

        Size = size;
    }
    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        if (Exist(nextPoint)) {
            return nextPoint;
        }
        
        if (nextPoint.X < 0)
        {
            nextPoint = new Point(Size - 1, nextPoint.Y);
        }
        else if (nextPoint.X >= Size)
        {
            nextPoint = new Point(0, nextPoint.Y);
        }
        else if (nextPoint.Y < 0)
        {
            nextPoint = new Point(nextPoint.X, Size - 1);
        }
        else if (nextPoint.Y >= Size)
        {
            nextPoint = new Point(nextPoint.X, 0);
        }

        return nextPoint;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);
        if (Exist(nextPoint))
        {
            return nextPoint;
        }

        var newX = nextPoint.X;
        var newY = nextPoint.Y;

        if (nextPoint.X < 0)
        {
            newX = Size - 1;
        }
        else if (nextPoint.X >= Size)
        {
            newX = 0;
        }

        if (nextPoint.Y < 0)
        {
            newY = Size - 1;
        }
        else if (nextPoint.Y >= Size)
        {
            newY = 0;
        }

        nextPoint = new Point(newX, newY);
        return nextPoint;
    }
}
