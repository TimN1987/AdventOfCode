namespace AoC2025.Days;

public static class Day1
{
    public static int Part1()
    {
        string[] input = GetData();
        int zeroCount = 0;
        int dialValue = 50;

        foreach (string rotation in input)
        {
            dialValue = Rotate(dialValue, rotation);
            zeroCount += dialValue == 0 ? 1 : 0;
        }

        return zeroCount;
    }

    public static int Part2()
    {
        string[] input = GetData();
        int zeroCount = 0;
        int dialValue = 50;

        foreach (string rotation in input)
        {
            zeroCount += CheckZeroClicks(dialValue, rotation); // Check how many times zero is clicked.
            dialValue = Rotate(dialValue, rotation); // Update dialValue with the rotation.
        }

        return zeroCount;
    }

    public static int Part2B()
    {
        string[] input = GetData();
        int zeroCount = 0;
        int dialValue = 50;

        foreach (string rotation in input)
        {
            zeroCount += BruteForceZeroCount(dialValue, rotation); // Check how many times zero is clicked.
            dialValue = Rotate(dialValue, rotation); // Update dialValue with the rotation.
        }

        return zeroCount;
    }

    private static int Rotate(int startValue, string rotation)
    {
        int distance = Convert.ToInt32(rotation[1..]);

        // Adding distance for 'R' rotation, subtracting for 'L' rotation.
        // Adding 100 (a full circle) for 'L' rotations to keep values positive.
        int newValue = rotation[0] == 'R' ? startValue + distance : startValue - distance + 100;

        return newValue % 100; // Use % 100 to ensure all values in 0 - 99 range.
    }

    private static int CheckZeroClicks(int startValue, string rotation)
    {
        int distance = Convert.ToInt32(rotation[1..]);

        return 0;
    }

    private static int BruteForceZeroCount(int startValue, string rotation)
    {
        int distance = Convert.ToInt32(rotation[1..]);
        int step = rotation[0] == 'R' ? 1 : -1;
        int zeroCount = 0;

        foreach (var _ in Enumerable.Range(0, distance))
        {
            startValue += step;
            startValue %= 100;
            if (startValue == 0)
                zeroCount++;
        }

        return zeroCount;
    }

    // Data methods

    private static string[] GetData()
    {
        return File.ReadAllLines("../../Data/2025/day1.txt");
    }

}