namespace AoC2025.Days;

public static class Day3
{
    public static long PartOne()
    {
        string[] lines = GetData();
        return lines.Sum(l => FindLargestJoltage(l));
    }

    public static long PartTwo()
    {
        return GetData().Sum(line => FindLargestJoltage12(line));
    }
    
    // Helper methods
    private static int FindLargestJoltage(string line)
    {
        // Iterate in reverse to find the first instance of the largest digit.
        int i = line.Length - 2; // The last digit cannot be the first digit of the joltage value.
        char firstDigit = '0';
        int index = 0;
        while (i >= 0)
        {
            if (line[i] >= firstDigit)
            {
                firstDigit = line[i];
                index = i;
            }
            i--;
        }

        // Iterate over the remaining digits to find the largest second digit.
        i = index + 1; // The second digit must come after the first.
        char secondDigit = '0';
        while (i < line.Length)
        {
            if (line[i] > secondDigit)
            {
                secondDigit = line[i];
            }
            i++;
        }
        
        return 10 * (firstDigit - '0') + (secondDigit - '0');
    }

    private static long FindLargestJoltage12(string line)
    {
        char[] result = new char[12];
        int index = -1; // Allows the first digit to be available.
        for (int i = 0; i < 12; i++)
        {
            result[i] = FindNextDigit(index, i, line, out index);
        }
        return Convert.ToInt64(new string(result));
    }

    private static char FindNextDigit(int previousIndex, int position, string line, out int newIndex) // zero-indexed
    {
        int i = line.Length - 12 + position; // e.g. the first digit has to leave 11 spaces after
        char max = '0';
        newIndex = i;
        
        while (i > previousIndex)
        {
            if (line[i] >= max)
            {
                newIndex = i;
                max = line[i];
            }
            i--;
        }

        return max;
    }

    private static int FindLargestBatterySum(string line, IEnumerable<IEnumerable<int>> indices)
    {
        var possibleLines = indices
            .Select(i => i.Select(x => line[x]))
            .Select(c => new string([..c]))
            .Select(s => SumBatteries(s));
        return possibleLines.Max();
    }

    private static int SumBatteries(string line)
    {
        if (line.Length != 12)
            throw new InvalidOperationException("Line length incorrect for 12 batteries input.");

        int total = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (i % 2 == 0)
                total += 10 * (line[i] - '0');
            else
                total += line[i]  - '0';
        }

        return total;
    }

    private static IEnumerable<IEnumerable<int>> GenerateIndexCombinations()
    {
        return Combinations(Enumerable.Range(0, 100), 24);
    }

    private static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0 
        ? []
        : elements.SelectMany((e, i) => 
            elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] {e}).Concat(c)));
    }

    // Data methods

    private static string[] GetData()
    {
        return File.ReadAllLines("../../Data/2025/day3.txt");
    }
}
