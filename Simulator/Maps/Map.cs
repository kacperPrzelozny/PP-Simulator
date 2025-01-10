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

    /// <summary>
    /// Assigns creature to the map and adds it to the list of creatures in the map.
    /// </summary>
    /// <param name="c">Creature.</param>
    /// <param name="p">Initial point.</param>
    public abstract void Add(Creature c, Point p);

    /// <summary>
    /// Removes creature from the map and removes it from the list of creatures in the map.
    /// </summary>
    /// <param name="c">Creature.</param>
    /// <param name="p">Creature position.</param>
    public abstract void Remove(Creature c, Point p);

    /// <summary>
    /// Moves creature from one point to another.
    /// </summary>
    /// <param name="c">Creature.</param>
    /// <param name="from">Starting position.</param>
    /// <param name="to">Target position.</param>
    public abstract void Move(Creature c, Point from, Point to);
    
    /// <summary>
    /// Checks creatures on x,y coordinates.
    /// </summary>
    /// <param name="x">X coordinate to check.</param>
    /// <param name="y">Y coordinate to check.</param>
    /// <returns>List of creatures on these coordinates on map</returns>
    public abstract List<Creature> At(int x, int y);

    /// <summary>
    /// Checks creatures on point.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns>List of creatures on this point on map</returns>
    public abstract List<Creature> At(Point p);
}