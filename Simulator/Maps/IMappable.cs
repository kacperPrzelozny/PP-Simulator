namespace Simulator.Maps;

public interface IMappable
{
    public Point? Position { get; }
    public string Symbol { get; }
    void AssignToMap(Map map, Point position);

    void Go(Direction direction);
}
