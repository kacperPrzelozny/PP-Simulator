using Simulator;
namespace TestSimulator;
public class PointTests
{

    [Fact]
    public void Constructor_ValidValues_ShouldSetProperties()
    {
        // Arrange
        int x = 5;
        int y = 10;
        // Act
        var point = new Point(x, y);
        // Assert
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(1, 1, Direction.Up, 1, 2)]
    [InlineData(1, 1, Direction.Right, 2, 1)]
    [InlineData(1, 1, Direction.Down, 1, 0)]
    [InlineData(1, 1, Direction.Left, 0, 1)]
    public void Next_ValidDirections_ShouldMove(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var result = point.Next(dir);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData(1, 1, Direction.Up, 2, 2)]
    [InlineData(1, 1, Direction.Right, 2, 0)]
    [InlineData(1, 1, Direction.Down, 0, 0)]
    [InlineData(1, 1, Direction.Left, 0, 2)]
    public void NextDiagonal_ValidDirections_ShouldMove(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var result = point.NextDiagonal(dir);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }
}