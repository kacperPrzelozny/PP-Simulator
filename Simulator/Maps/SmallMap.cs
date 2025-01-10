namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public SmallMap(int x, int y): base(x, y)
    {
        if (x > 20 || y > 20) {
            throw new ArgumentOutOfRangeException("Both dimensions must be lower than 20");
        }
    }
}
