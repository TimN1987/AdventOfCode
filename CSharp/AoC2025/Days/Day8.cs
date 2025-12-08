namespace AoC2025;

public static class Day8
{

    public static int PartOne()
    {
        var lengths = CreateCircuits(1000, false, out int start, out int end)
            .Select(h => h.Count)
            .ToArray();
        lengths.Sort((a, b) => b - a);
        return lengths[0] * lengths[1] * lengths[2];
    }

    public static int PartTwo()
    {
        var _ = CreateCircuits(-1, true, out int start, out int end);
        var data = GetData().ToArray();
        return data[start].First() * data[end].First();
    }
    
    // Helper methods

    private static List<HashSet<int>> CreateCircuits(int length, bool isComplete, out int start, out int end)
    {
        var distances = GetOrderedDistances();
        if (length == -1)
            length = distances.Count;
        List<HashSet<int>> circuits = [[distances[0][1], distances[0][2]]];
        foreach (var distance in distances[1..length])
        {
            start = distance[1];
            end = distance[2];
            List<HashSet<int>> carryOverCircuits = [];
            HashSet<int> mergedCircuits = [start, end];

            foreach (var circuit in circuits)
            {
                if (circuit.Contains(start) || circuit.Contains(end))
                {
                    mergedCircuits.UnionWith(circuit);
                }
                else
                {
                    carryOverCircuits.Add(circuit);
                }
            }

            if (isComplete && carryOverCircuits.Count == 0)
                return [];

            carryOverCircuits.Add(mergedCircuits);
            circuits = carryOverCircuits;
        }
        start = end = -1;
        return circuits;
    }

    // Data methods

    private static IEnumerable<IEnumerable<int>> GetData() => File.ReadAllLines("../../Data/2025/day8.txt")
        .Select(s => s.Split(',').Select(c => int.Parse(c)));

    private static int EuclideanDistance(IEnumerable<int> a, IEnumerable<int> b)
    {
        if (a.Count() != 3 || b.Count() != 3)
            throw new ArgumentException("Coordinates must have exactly x, y, z.");

        long total = Enumerable.Range(0, 3)
            .Select(num => (long)Math.Pow((a.Skip(num).First() - b.Skip(num).First()), 2))
            .Sum();
        return (int)Math.Sqrt(total);
    }

    private static List<int[]> GetOrderedDistances()
    {
        var data = GetData().ToArray();
        List<int[]> distances = [];

        for (int i = 0; i < data.Length - 1; i++)
        {
            for (int j = i + 1; j < data.Length; j++)
            {
                int d = EuclideanDistance(data[i], data[j]);
                int[] distance = [d, i, j];
                distances.Add(distance);
            }
        }

        distances.Sort((a, b) => a[0] - b[0]);
        return distances;
    }
}