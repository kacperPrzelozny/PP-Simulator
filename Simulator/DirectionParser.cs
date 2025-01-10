namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string directions)
    {
        List<Direction> result = new List<Direction>();
        foreach (char direction in directions)
        {
            switch (direction.ToString().ToUpper())
            {
                case "U":
                    result.Add(Direction.Up);
                    break;
                case "R":
                    result.Add(Direction.Right);
                    break;
                case "D":
                    result.Add(Direction.Down);
                    break;
                case "L":
                    result.Add(Direction.Left);
                    break;
            }
        }

        return result;
    }
}
