namespace AOC2015.Days;

public class Day1
{
    private readonly string _data = File.ReadAllText("../../Data/2015/day1.txt");
    private bool _basementEntered = false;
    private int _floor = 0;
    private int _timeBasementEntered = 1;

    public void RunLift()
    {
        foreach (char c in _data)
        {
            _floor += c == '(' ? 1 : -1;

            if (_floor == -1)
                _basementEntered = true;
            if (!_basementEntered)
                _timeBasementEntered++;
        }

        Console.WriteLine($"The final floor was {_floor}, and the basement was first entered at {_timeBasementEntered}.");
    }
}