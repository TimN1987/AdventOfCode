namespace AOC2018.Days;

public class Day1
{
    private string[] _data = GetData();

    public int Part1()
    {
        int frequency = 0;
        for (int i = 0; i < _data.Length; ++i)
        {
            frequency += _data[i][0] == '+' ? int.Parse(_data[i][1..]) : - int.Parse(_data[i][1..]);
        }
        return frequency;
    }

    public int Part2()
    {
        HashSet<int> visited = [];
        int frequency = 0, i = 0;
        while (!visited.Contains(frequency))
        {
            visited.Add(frequency);
            frequency += _data[i][0] == '+' ? int.Parse(_data[i][1..]) : - int.Parse(_data[i][1..]);
            i++;
            i = i < _data.Length ? i : 0;
        }
        return frequency;
    }

    private static string[] GetData() => File.ReadAllLines("../../Data/2018/day1.txt");
}