namespace AoC2025.Days;

public static class Day9
{
    public static long PartOne()
    {
        var ordered = GetOrderedRectangles();
        return ordered.First().area;
    }

    public static long PartTwo()
    {
        HashSet<(long, long)> edge = ScanEdges();
        foreach (var (area, a, b) in GetOrderedRectangles())
        {
            if (CheckRectangle2(a, b, edge))
                return area;
        }

        return 0;
    }

    // Helper methods

    private static List<(long area, IEnumerable<long> a, IEnumerable<long> b)> GetOrderedRectangles()
    {
        List<IEnumerable<long>> data = GetData().ToList();
        int positionsCount = data.Count;
        List<(long area, IEnumerable<long> position1, IEnumerable<long> position2)> ordered = [];

        for (int i = 0; i < positionsCount - 1; i++)
        {
            for (int j = i + 1; j < positionsCount; j++)
            {
                ordered.Add((CalculateRectangle(data[i], data[j]), data[i], data[j]));
            }
        }

        ordered.Sort((a, b) => b.area.CompareTo(a.area));

        return ordered;
    }

    private static long CalculateRectangle(IEnumerable<long> a, IEnumerable<long> b)
    {
        if (a.Count() != 2 || b.Count() != 2)
            throw new ArgumentException("Inputs must have size 2.");

        long width = Math.Abs(a.First() - b.First()) + 1; // Add one as rectangles are inclusive.
        long height = Math.Abs(a.Last() - b.Last()) + 1;

        return width * height;
    }

    private static bool CheckRectangle2(IEnumerable<long> a, IEnumerable<long> b, HashSet<(long, long)> edge)
    {
        long x1 = a.First(), y1 = a.Last(), x2 = b.First(), y2 = b.Last();

        long minY = y1 < y2 ? y1 : y2;
        long maxY = y1 > y2 ? y1 : y2;
        long minX = x1 < x2 ? x1 : x2;
        long maxX = x1 > x2 ? x1 : x2;

        for (long x = minX + 1; x < maxX; x++)
        {
            if (edge.Contains((x, minY + 1)) || edge.Contains((x, maxY - 1)))
                return false;
        }

        for (long y = minY + 1; y < maxY; y++)
        {
            if (edge.Contains((minX + 1, y)) || edge.Contains((maxX - 1, y)))
                return false;
        }

        return true;
    }

    private static bool CheckRectangle(IEnumerable<long> a, IEnumerable<long> b, HashSet<(long, long)> edge)
    {
        long x1 = a.First(), y1 = a.Last(), x2 = b.First(), y2 = b.Last();

        long minY = y1 < y2 ? y1 : y2;
        long maxY = y1 > y2 ? y1 : y2;
        long minX = x1 < x2 ? x1 : x2;
        long maxX = x1 > x2 ? x1 : x2;

        for (long y = minY + 2; y < maxY; y++)
        {
            if (!edge.Contains((minX, y)) && edge.Contains((minX, y - 1)))
            {
                if (edge.Contains((minX + 1, y - 1)))
                    return false;
            }

            if (edge.Contains((minX, y)) && !edge.Contains((minX, y - 1)))
            {
                if (edge.Contains((minX + 1, y)))
                    return false;
            }

            if (!edge.Contains((maxX, y)) && edge.Contains((maxX, y - 1)))
            {
                if (edge.Contains((maxX - 1, y - 1)))
                    return false;
            }

            if (edge.Contains((maxX, y)) && !edge.Contains((maxX, y - 1)))
            {
                if (edge.Contains((maxX - 1, y)))
                    return false;
            } 
        }

        for (long x = minX + 2; x < maxX; x++)
        {
            if (!edge.Contains((x, minY)) && edge.Contains((x - 1, minY)))
            {
                if (edge.Contains((x - 1, minY + 1)))
                    return false;
            }

            if (edge.Contains((x, minY)) && !edge.Contains((x - 1, minY)))
            {
                if (edge.Contains((x, minY + 1)))
                    return false;
            }

            if (!edge.Contains((x, maxY)) && edge.Contains((x - 1, maxY)))
            {
                if (edge.Contains((x - 1, maxY - 1)))
                    return false;
            }

            if (edge.Contains((x, maxY)) && !edge.Contains((x - 1, maxY)))
            {
                if (edge.Contains((x, maxY - 1)))
                    return false;
            }
        }

        return true;
    }

    private static HashSet<(long, long)> ScanEdges()
    {
        HashSet<(long, long)> edge = [];
        List<long[]> coords = GetData().Select(arr => arr.ToArray()).ToList();
        long[] prev = coords[0];
        coords.Add(prev);
        int length = coords.Count;
        long minX = 0, maxX = 0, minY = 0, maxY = 0;
        
        for (int i = 1; i < length; i++)
        {
            long x1 = prev[0], y1 = prev[1];
            long x2 = coords[i][0], y2 = coords[i][1];
            minX = Math.Min(x1, x2);
            maxX = Math.Max(x1, x2);
            minY = Math.Min(y1, y2);
            maxY = Math.Max(y1, y2);

            if (x1 == x2)
            {
                for (long j = minY; j <= maxY; j++)
                {
                    edge.Add((x1, j));
                }
            }
            else if (y1 == y2)
            {

                for (long j = minX; j <= maxX; j++)
                {
                    edge.Add((j, y1));
                }
            }
            prev = coords[i];
        }
        return edge;
    }

    private static void PrintGrid(char[][] grid)
    {
        foreach (var row in grid)
        {
            foreach (var cell in row)
            {
                char printable = cell == 'X' || cell == '#' ? cell : '-';
                Console.Write(printable);
            }
            Console.Write("\n");
        }
    }

    // Data methods

    private static IEnumerable<IEnumerable<long>> GetData() => File.ReadAllLines("../../Data/2025/day9.txt")
        .Select(s => s.Split(',').Select(c => long.Parse(c)));

    private static long MaxCoordinate() => GetData()
        .Select(x => x.Max())
        .Max();
}