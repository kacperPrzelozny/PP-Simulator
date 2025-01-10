using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimConsole;

public class MapVisualiser
{
    private Map map;
    public Map Map { get; set; }

    public MapVisualiser(Map map)
    {
        Map = map;
    }

    public void Draw()
    {
        string[,] mapToDraw = PrepareMap();

        int rows = mapToDraw.GetLength(0);
        int cols = mapToDraw.GetLength(1);

        // Rysowanie górnej krawędzi
        Console.Write(Box.TopLeft);
        for (int col = 0; col < cols; col++)
        {
            Console.Write(new string(Box.Horizontal, 7)); // 7 - szerokość komórki
            Console.Write(col < cols - 1 ? Box.TopMid : Box.TopRight);
        }
        Console.WriteLine();

        // Rysowanie zawartości
        for (int row = 0; row < rows; row++)
        {
            // Wiersz z danymi
            Console.Write(Box.Vertical);
            for (int col = 0; col < cols; col++)
            {
                string value = mapToDraw[row, col];
                Console.Write($" {value,-5} "); // Wyrównanie do lewej w komórce
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            // Rysowanie linii między wierszami (oprócz ostatniego wiersza)
            if (row < rows - 1)
            {
                Console.Write(Box.MidLeft);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(new string(Box.Horizontal, 7));
                    Console.Write(col < cols - 1 ? Box.Cross : Box.MidRight);
                }
                Console.WriteLine();
            }
        }

        // Rysowanie dolnej krawędzi
        Console.Write(Box.BottomLeft);
        for (int col = 0; col < cols; col++)
        {
            Console.Write(new string(Box.Horizontal, 7));
            Console.Write(col < cols - 1 ? Box.BottomMid : Box.BottomRight);
        }
        Console.WriteLine();
    }

    private string[,] PrepareMap()
    {
        int rows = Map.X;
        int cols = Map.Y;

        string[,] array = new string[rows, cols];

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                List<Creature> creaturesAt = Map.At(x, y);
                if (creaturesAt.Count == 0)
                {
                    array[rows - 1 - y, x] = "";
                }
                else if (creaturesAt.Count == 1)
                {
                    array[rows - 1 - y, x] = creaturesAt.First().Symbol;
                }
                else
                {
                    array[rows - 1 - y, x] = "X";
                }
            }
        }

        return array;
    }
}
