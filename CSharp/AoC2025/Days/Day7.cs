namespace AoC2025.Days;

public static class Day7
{
    public static void Solution()
    {
        char[][] data = GetData();
        long[][] grid = CreateGrid();

        int height = data.Length;
        int width = data[0].Length;

        for (int i = 1; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (data[i][j] == '.')
                {
                    grid[i][j] += grid[i - 1][j];
                }
                else if (data[i][j] == '^' && grid[i - 1][j] > 0)
                {
                    data[i][j] = 'X';
                }
            }

            for (int j = 0; j < width; j++)
            {
                if (data[i][j] == '^' || data[i][j] == 'X')
                {
                    if (j > 0)
                    {
                        grid[i][j - 1] += grid[i - 1][j]; 
                    }
                    if (j < width - 1)
                    {
                        grid[i][j + 1] += grid[i - 1][j];
                    }
                }
            }
        }

        long partOne = data.Select(arr => arr.Count(c => c == 'X')).Sum();
        long partTwo = grid.Last().Sum();

        Console.WriteLine("Day 7");
        Console.WriteLine($"Part 1: {partOne}");
        Console.WriteLine($"Part 2: {partTwo}");
    }

    // Data methods

    private static char[][] GetData() => File.ReadAllLines("../../Data/2025/day7.txt")
        .Select(s => s.ToArray())
        .ToArray();

    private static long[][] CreateGrid() => GetData()
            .Select(arr => arr.Select(c => c == 'S' ? 1L : 0L).ToArray())
            .ToArray();
}