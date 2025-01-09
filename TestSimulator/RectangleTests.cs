using Simulator;
namespace TestSimulator;
public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates()
    {
        int x1 = 1, y1 = 2, x2 = 3, y2 = 6;
        var r = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(x1, r.X1);
        Assert.Equal(y1, r.Y1);
        Assert.Equal(x2, r.X2);
        Assert.Equal(y2, r.Y2);
    }

    [Fact]
    public void Constructor_InvalidCoordinates()
    {
        int x1 = 0, y1 = 0, x2 = 0, y2 = 5;
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Fact]
    public void Constructor_PointConstructor()
    {
        var p1 = new Point(1, 1);
        var p2 = new Point(2, 2);
        var r = new Rectangle(p1, p2);
        Assert.Equal(1, r.X1);
        Assert.Equal(1, r.Y1);
        Assert.Equal(2, r.X2);
        Assert.Equal(2, r.Y2);
    }

    [Fact]
    public void Constructor_PointConstructor_ReversedPoints()
    {
        var p1 = new Point(1, 1);
        var p2 = new Point(2, 2);
        var r = new Rectangle(p2, p1);
        Assert.Equal(1, r.X1);
        Assert.Equal(1, r.Y1);
        Assert.Equal(2, r.X2);
        Assert.Equal(2, r.Y2);
    }

    [Theory]
    [InlineData(3, 3, false)]
    [InlineData(0, 0, true)]
    [InlineData(6, 6, false)]
    public void Contains_CheckCoordinates(int x, int y, bool expected)
    {
        var rect = new Rectangle(0, 0, 2, 2);
        var point = new Point(x, y);

        Assert.Equal(expected, rect.Contains(point));
    }

    [Fact]
    public void ToString_CheckString_ShouldWork()
    {
        var rect = new Rectangle(1, 2, 4, 6);
        var result = rect.ToString();
        Assert.Equal("(1, 2):(4, 6)", result);
    }
}
