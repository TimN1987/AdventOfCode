namespace AoC2025.Days;

public static class Day2
{
    public static long PartOne()
    {
        long total = 0;

        foreach (string[] s in ParseData())
        {
            total += CalculateRepeatingNumbers(s[0], s[1]);
        }

        return total;
    }

    // Helper methods

    private static long CalculateRepeatingNumbers(string start, string end)
    {
        long numStart = Convert.ToInt64(start);
        long numEnd = Convert.ToInt64(end);
        int startLength = start.Length;
        int endLength = end.Length;

        // Odd length numbers cannot repeat - return 0 if no even length numbers.
        if (startLength == endLength && startLength % 2 == 1)
            return 0;

        // If the start length is odd, increase the number to the next even length number.
        // e.g. 758 is length 3 => 10^3 = 1000
        if (startLength % 2 == 1)
        {
            numStart = (long)Math.Pow(10, startLength);
            startLength++;
            start = Convert.ToString(numStart);
        }

        // If the end length is odd, decrease the number the the previous even length number.
        // e.g. 948 is length 3 => 10^2 - 1 = 99
        if (endLength % 2 == 1)
        {
            endLength--;
            numEnd = (long)Math.Pow(10, endLength) - 1;
            end = Convert.ToString(numEnd);
        }

        if (numStart > numEnd)
            return 0;

        // If all the numbers have the same length, then we only need to check how many start numbers will be reapeated.
        // e.g. 23 -> 84 => 33, 44, 55, 66, 77 - first is 3, last is 7 i.e. 5 options
        // All lengths are now confirmed as even.
        if (startLength == endLength)
        {
            // Find the patterns to be repeated.
            int patternLength = startLength / 2;
            long startPattern = Convert.ToInt64(start[..patternLength]);
            long startRemainder = Convert.ToInt64(start[patternLength..]);
            long endPattern = Convert.ToInt64(end[..patternLength]);
            long endRemainder = Convert.ToInt64(end[patternLength..]);

            // Check if the first and last repeating patterns are in the range.
            long startValue = startRemainder > startPattern ? startPattern + 1 : startPattern;
            long endValue = endRemainder >= endPattern ? endPattern : endPattern - 1;
           
            // Use start and end values to calculate the total of the repeated patterns.
            // Use triangle number formula to get the total - triangle(end) - triangle(start - 1).
            // As this is repeated, it needs to have 1 * total + 10^length * total
            long patternTotal = (endValue * (endValue + 1) / 2) - (startValue * (startValue - 1) / 2);
            long result = patternTotal + (long)Math.Pow(10, patternLength) * patternTotal;
            return result;
        }

        // If the start length and end length are not the same, then there are multiple even length ranges to consider.
        // Split the larger range into smaller valid ranges and use recursion.
        // e.g. lengths 2 and 4 => (startValue, 99), (1000, endValue)
        List<(string, string)> ranges = new();

        long tempEnd = (long)Math.Pow(10, startLength) - 1; // e.g. length 2 => 99
        ranges.Add((start, Convert.ToString(tempEnd)));
        startLength += 2;

        // Find any middle even length ranges where the full range is included.
        while (startLength < endLength)
        {
            // e.g. length 2 => newStart = 10, newEnd = 99
            long newStart = (long)Math.Pow(10, startLength - 1);
            long newEnd = (long)Math.Pow(10, startLength) - 1;
        }

        long tempStart = (long)Math.Pow(10, endLength - 1); //e.g. length 4 => 1000
        ranges.Add((Convert.ToString(tempStart), end));

        long total = 0;

        foreach (var (s, e) in ranges)
        {
            total += CalculateRepeatingNumbers(s, e);
        }

        return total;
    }
    
    // Data methods

    private static string GetData()
    {
        return File.ReadAllText("../../Data/2025/day2.txt");
    }

    private static IEnumerable<string[]> ParseData()
    {
        string[] data = GetData().Split(',');
        
        return data.Select(d => d.Split('-'));
    }
}