using Simulator.Directions;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int x, int y): base(x, y)
    {
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < X && p.Y >= 0 && p.Y < Y;
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        if (Exist(nextPoint)) {
            return nextPoint;
        }
        
        if (nextPoint.X < 0)
        {
            nextPoint = new Point(X - 1, nextPoint.Y);
        }
        else if (nextPoint.X >= X)
        {
            nextPoint = new Point(0, nextPoint.Y);
        }
        else if (nextPoint.Y < 0)
        {
            nextPoint = new Point(nextPoint.X, Y - 1);
        }
        else if (nextPoint.Y >= Y)
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
            newX = X - 1;
        }
        else if (nextPoint.X >= X)
        {
            newX = 0;
        }

        if (nextPoint.Y < 0)
        {
            newY = Y - 1;
        }
        else if (nextPoint.Y >= Y)
        {
            newY = 0;
        }

        nextPoint = new Point(newX, newY);
        return nextPoint;
    }
}
