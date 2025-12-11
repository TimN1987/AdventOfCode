namespace AoC2025.Days;

public static class Day11
{
    private readonly static Dictionary<string, string[]> _data = File.ReadAllLines("../../Data/2025/day11.txt")
        .Select(line => line.Split(" "))
        .ToDictionary(k => k[0][..^1], v => v[1..].ToArray());

    private readonly static Dictionary<(string, bool, bool), long> _dp = [];

    // Solution

    public static int PartOne()
    {
        return FollowPath("you");
    }

    public static long PartTwo()
    {
        bool visitsDac = false, visitsFft = false;
        return FollowPath("svr", visitsDac, visitsFft);
    }

    // Helper methods

    private static int FollowPath(string start)
    {
        if (start == "out")
            return 1;
        
        int total = 0;

        foreach (string s in _data[start])
            total += FollowPath(s);

        return total;
    }

    private static long FollowPath(string start, bool visitsDac, bool visitsFft)
{
        if (start == "dac") visitsDac = true;
        if (start == "fft") visitsFft = true;

        if (start == "out")
            return visitsDac && visitsFft ? 1L : 0L;

        var key = (start, visitsDac, visitsFft);

        if (_dp.TryGetValue(key, out long memo))
            return memo;

        long total = 0;

        foreach (var next in _data[start])
            total += FollowPath(next, visitsDac, visitsFft);

        return _dp[key] = total;
    }

}