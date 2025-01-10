using Simulator.Maps;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";
    public string Description
    {
        get => _description;
        init
        {
            _description = Validator.Shortener(value, 1, 15);
        }
    }
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public Point? Position { get; protected set; }
    public virtual string Symbol => "A";

    public bool IsAssigned;

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

    public void AssignToMap(Map map, Point position)
    {
        if (IsAssigned) { return; }
        if (!map.Exist(position)) { return; }

        Map = map;
        Position = position;
        IsAssigned = true;

        Map.Add(this, position);
    }

    public virtual void Go(Direction direction)
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
}