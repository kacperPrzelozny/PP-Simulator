using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Animals;
using Simulator.Creatures;
using Simulator.Maps;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        public int Turn { get; set; }
        public int MaxTurn { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string MoveDescription { get; set; }
        public Dictionary<Point,char> Symbols { get; set; }

        public void OnGet()
        {
            int turn;
            if (!int.TryParse(Request.Query["turn"], out turn))
            {
                turn = 0;
            }

            SmallTorusMap map = new(8, 6);

            List<IMappable> creatures = [
                new Elf("Elandor"),
                new Orc("Gorbag"),
                new Animals() { Description = "Rabbits", Size = 20 },
                new Birds() {Description = "Eagles", Size = 5, CanFly = true},
                new Birds() {Description = "Ostriches", Size = 5, CanFly = false},
            ];
            List<Point> points = [
                new(2, 2),
                new(3, 1),
                new(4, 5),
                new(0, 1),
                new(1, 0),
            ];
            string moves = "ruldlurdruldlur";

            Simulation simulation = new(map, creatures, points, moves);
            SimulationHistory history = new(simulation);

            if (turn > history.TurnLogs.Count - 1)
            {
                turn = history.TurnLogs.Count - 1;
            }
            else if (turn < 0)
            {
                turn = 0;
            }

            Turn = turn;
            MaxTurn = history.TurnLogs.Count - 1;
            X = map.X;
            Y = map.Y;
            SimulationTurnLog currentTurn = history.TurnLogs[turn];
            MoveDescription = Turn == 0 ? currentTurn.Move : currentTurn.Mappable + " => " + currentTurn.Move;
            Symbols = currentTurn.Symbols;
        }
    }
}
