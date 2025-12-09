namespace AoC2025.Days;

public static class Day10
{
    

    // Data methods

    private static IEnumerable<IEnumerable<long>> GetData()
        => File.ReadAllLines("../../Data/2025/day10.txt")
               .Select(s => s.Split(',').Select(long.Parse));
}