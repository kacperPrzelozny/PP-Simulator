using Simulator.Directions;

namespace Simulator.Animals;
public class Birds : Animals
{
    public override string Symbol => CanFly ? "B" : "b";
    public bool CanFly { get; set; } = true;
    public override string Info
    {
        get
        {
            string flyStatus = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyStatus}) <{Size}>";
        }
    }

    public override void Go(Direction direction)
    {
        if (Map == null) { return; }
        if (Position == null) { return; }

        Point currentPosition = new Point(Position.Value.X, Position.Value.Y);
        Point next = new Point(Position.Value.X, Position.Value.Y);

        if (CanFly)
        {
            next = Map.Next(currentPosition, direction);
            next = Map.Next(next, direction);
        }
        else
        {
            next = Map.NextDiagonal(currentPosition, direction);
        }

        if (Map.Exist(next))
        {
            Map.Move(this, currentPosition, next);
            Position = next;
        }
    }
}