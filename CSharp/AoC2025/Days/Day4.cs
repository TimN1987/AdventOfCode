namespace AoC2025.Days;

public static class Day4
{
    public static int PartOne()
    {
        return TraverseGrid(SetUpGrid());
    }

    public static int PartTwo()
    {
        char[][] grid = SetUpGrid();
        int result = 0;
        while (true)
        {
            int total = TraverseGrid(grid, true);
            if (total == 0)
                break;
            result += total;
        }
        return result;
    }


    // Helper methods

    private static int TraverseGrid(char[][] grid, bool removeRolls = false)
    {
        int height = grid.Length;
        int width = grid[0].Length;
        int result = 0;

        for (int i = 1; i < height - 1; i++)
        {
            for (int j = 1; j < width - 1; j++)
            {
                if (grid[i][j] == '.')
                    continue;
                if (CountNeighbours(i, j, grid) < 4)
                {
                    result++;

                    if (removeRolls)
                        grid[i][j] = '.';
                }
            }
        }
        return result;
    }

    private static int CountNeighbours(int row, int col, char[][] grid)
    {
        int[] deltas = [-1, 0, 1];
        int total = grid[row][col] == '@' ? -1 : 0;
        foreach (int i in deltas)
        {
            foreach (int j in deltas)
            {
                if (grid[row + i][col + j] == '@')
                {
                    total++;
                }
            }
        }
        return total;
    }
    
    // Data methods

    private static string[] GetData()
    {
        return File.ReadAllLines("../../Data/2025/day4.txt");
    }

    private static char[][] SetUpGrid()
    {
        string[] data = GetData();
        string emptyLine = new string('.', data[0].Length + 2);
        return new[] {emptyLine.ToCharArray()}
            .Concat(
                data
                .Select(line => ('.' + line + '.').ToCharArray())
                .ToArray()
            )
            .Concat(
                new[] {emptyLine.ToCharArray()}
            )
            .ToArray();
    }
}