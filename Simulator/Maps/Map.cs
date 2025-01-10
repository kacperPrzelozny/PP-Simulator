using Simulator;
using System.Drawing;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int X { get; }
    public int Y { get; }
    public Map(int x, int y)
    {
        if (x < 5 || y < 5) {
            throw new ArgumentOutOfRangeException("Both dimensions must be greater than 5");
        }

        X = x;
        Y = y;
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public abstract bool Exist(Point p);
    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);
    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}