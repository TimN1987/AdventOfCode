namespace AoC2025.Days;

public static class Day5
{
    public static void Solution(out int partOne, out long partTwo)
    {
        ParseData(out List<(long, long)> ranges, out List<long> available);
        Console.WriteLine(ranges.Count);
        partOne = PartOne(ranges, available);
        partTwo = PartTwo(ranges);
    }

    private static int PartOne(List<(long start, long end)> ranges, List<long> available)
    {
        return available
            .Count(num => 
                ranges.Any(r => num >= r.start && num < r.end));
    }

    private static long PartTwo(List<(long start, long end)> ranges)
    {
        return ranges
            .Select(range => range.end - range.start)
            .Sum();
    }

    // Data methods

    private static string[] GetData() => File.ReadAllLines("../../Data/2025/day5.txt");

    private static void ParseData(out List<(long start, long end)> ranges, out List<long> available)
    {
        ranges = [];
        available = [];

        string[] data = GetData();
        bool isRange = true;

        foreach (string s in data)
        {
            if (s == "")
            {
                isRange = false;
                continue;
            }

            if (isRange)
            {
                string[] range = s.Split('-');
                long start = Convert.ToInt64(range[0]);
                long end = Convert.ToInt64(range[1]) + 1; // For simple range calculation.
                ranges.Add((start, end));
            }
            else
            {
                available.Add(Convert.ToInt64(s));
            }          
        }
        ranges.Sort((a, b) => a.start.CompareTo(b.start));
        ranges = CombineRanges(ranges);
    }

    private static List<(long, long)> CombineRanges(List<(long, long)> ranges)
    {
        List<(long, long)> combinedRanges = [];
        long start = 0, end = 0;

        foreach (var (s, e) in ranges)
        {
            if (s > end)
            {
                combinedRanges.Add((start, end));
                start = s;
                end = e;
            }
            else
            {
                end = Math.Max(end, e);
            }
        }

        combinedRanges.Add((start, end));

        return combinedRanges;
    }
}