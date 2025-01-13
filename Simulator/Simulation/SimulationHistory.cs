public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.X;
        SizeY = _simulation.Map.Y;
        Run();
    }

    private void Run()
    {
        SimulationTurnLog startLog = new()
        {
            Mappable = "",
            Move = "Pozycje startowe",
            Symbols = _simulation.Map.GetCreaturesFromMap()
        };
        TurnLogs.Add(startLog);

        while (!_simulation.Finished)
        {
            string mappable = _simulation.CurrentCreature.ToString();
            string move = _simulation.CurrentMoveName;
            _simulation.Turn();
            SimulationTurnLog turnLog = new() { 
                Mappable = mappable,
                Move = move,
                Symbols = _simulation.Map.GetCreaturesFromMap()
            };
            TurnLogs.Add(turnLog);
        }
    }
}