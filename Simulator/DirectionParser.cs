namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string directions)
    {
        if (string.IsNullOrWhiteSpace(directions))
        {
            return new Direction[0];
        }

        int count = 0;
        for (int i = 0; i < directions.Length; i++)
        {
            string direction = directions[i].ToString().ToUpper();
            if (direction == "U" || direction == "R" || direction == "D" || direction == "L")
            {
                count++;
            }
        }

        var result = new Direction[count];
        int directionsIndex = 0;
        for (int i = 0; i < directions.Length; i++)
        {
            string direction = directions[i].ToString().ToUpper();
            switch (direction)
            {
                case "U":
                    result[directionsIndex] = Direction.Up;
                    directionsIndex++;
                    break;
                case "R":
                    result[directionsIndex] = Direction.Right;
                    directionsIndex++;
                    break;
                case "D":
                    result[directionsIndex] = Direction.Down;
                    directionsIndex++;
                    break;
                case "L":
                    result[directionsIndex] = Direction.Left;
                    directionsIndex++;
                    break;
            }
        }

        return result;
    }
}
