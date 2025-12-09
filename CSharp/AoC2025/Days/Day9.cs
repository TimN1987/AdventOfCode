namespace AoC2025.Days;

public static class Day9
{
    private static Dictionary<long, int> _xMap = new();
    private static Dictionary<long, int> _yMap = new();
    private static List<(int x, int y)> _compressedPositions = new();

    public static long PartOne()
    {
        var ordered = GetOrderedRectangles();
        return ordered.First().area;
    }

    public static long PartTwo()
    {
        BuildCompressedPositions();

        HashSet<(int, int)> edge = ScanEdges();
        foreach (var (area, a, b) in GetCompressedRectangles())
        {
            if (CheckRectangle2(a, b, edge))
                return area;
        }

        return 0;
    }

    // Helper methods

    private static List<(long area, IEnumerable<long> a, IEnumerable<long> b)> GetOrderedRectangles()
    {
        var data = GetData().Select(arr => arr.ToArray()).ToList();
        int positionsCount = data.Count;
        var ordered = new List<(long, IEnumerable<long>, IEnumerable<long>)>();

        for (int i = 0; i < positionsCount - 1; i++)
        {
            for (int j = i + 1; j < positionsCount; j++)
            {
                ordered.Add((CalculateRectangle(data[i], data[j]), data[i], data[j]));
            }
        }

        ordered.Sort((a, b) => b.Item1.CompareTo(a.Item1));
        return ordered;
    }

    private static List<(long area, (int x, int y) a, (int x, int y) b)> GetCompressedRectangles()
    {
        var positions = GetCompressedPositions();
        var original = GetData().Select(arr => arr.ToArray()).ToList();

        int n = positions.Count;
        var rectangles = new List<(long, (int, int), (int, int))>();

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                long width = Math.Abs(original[i][0] - original[j][0]) + 1;
                long height = Math.Abs(original[i][1] - original[j][1]) + 1;
                long area = width * height;

                rectangles.Add((area, positions[i], positions[j]));
            }
        }

        rectangles.Sort((r1, r2) => r2.Item1.CompareTo(r1.Item1));
        return rectangles;
    }

    private static long CalculateRectangle(IEnumerable<long> a, IEnumerable<long> b)
    {
        long width = Math.Abs(a.First() - b.First()) + 1;
        long height = Math.Abs(a.Last() - b.Last()) + 1;
        return width * height;
    }

    private static bool CheckRectangle2((int x, int y) a, (int x, int y) b, HashSet<(int, int)> edge)
    {
        int minX = Math.Min(a.x, b.x);
        int maxX = Math.Max(a.x, b.x);
        int minY = Math.Min(a.y, b.y);
        int maxY = Math.Max(a.y, b.y);

        for (int x = minX + 1; x < maxX; x++)
        {
            if (edge.Contains((x, minY + 1)) || edge.Contains((x, maxY - 1)))
                return false;
        }

        for (int y = minY + 1; y < maxY; y++)
        {
            if (edge.Contains((minX + 1, y)) || edge.Contains((maxX - 1, y)))
                return false;
        }

        return true;
    }

    private static HashSet<(int, int)> ScanEdges()
    {
        var edge = new HashSet<(int, int)>();
        var coords = GetCompressedPositions().ToList();
        var prev = coords[0];
        coords.Add(prev);

        for (int i = 1; i < coords.Count; i++)
        {
            var current = coords[i];
            int minX = Math.Min(prev.x, current.x);
            int maxX = Math.Max(prev.x, current.x);
            int minY = Math.Min(prev.y, current.y);
            int maxY = Math.Max(prev.y, current.y);

            if (prev.x == current.x)
            {
                for (int j = minY; j <= maxY; j++)
                    edge.Add((prev.x, j));
            }
            else if (prev.y == current.y)
            {
                for (int j = minX; j <= maxX; j++)
                    edge.Add((j, prev.y));
            }

            prev = current;
        }

        return edge;
    }

    private static void PrintGrid(char[][] grid)
    {
        foreach (var row in grid)
        {
            foreach (var cell in row)
                Console.Write(cell == 'X' || cell == '#' ? cell : '-');
            Console.WriteLine();
        }
    }

    // Coordinate compression

    private static void BuildCompressedPositions()
    {
        var positions = GetData().Select(arr => arr.ToArray()).ToList();

        var uniqueX = positions.Select(p => p[0]).Distinct().OrderBy(x => x).ToList();
        var uniqueY = positions.Select(p => p[1]).Distinct().OrderBy(y => y).ToList();

        _xMap = uniqueX.Select((v, i) => new { v, i }).ToDictionary(x => x.v, x => x.i);
        _yMap = uniqueY.Select((v, i) => new { v, i }).ToDictionary(y => y.v, y => y.i);

        _compressedPositions = positions
            .Select(p => (_xMap[p[0]], _yMap[p[1]]))
            .ToList();
    }

    private static List<(int x, int y)> GetCompressedPositions()
    {
        if (_compressedPositions == null || !_compressedPositions.Any())
            BuildCompressedPositions();
        return _compressedPositions ?? [];
    }

    // Data methods

    private static IEnumerable<IEnumerable<long>> GetData()
        => File.ReadAllLines("../../Data/2025/day9.txt")
               .Select(s => s.Split(',').Select(long.Parse));

    private static long MaxCoordinate()
        => GetData().Select(x => x.Max()).Max();
}

