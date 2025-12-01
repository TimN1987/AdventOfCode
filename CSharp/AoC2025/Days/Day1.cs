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

    private static int Rotate(int startValue, string rotation)
    {
        int distance = Convert.ToInt32(rotation[1..]);

        // Adding distance for 'R' rotation, subtracting for 'L' rotation.
        // Adding 100 (a full circle) for 'L' rotations to keep values positive.
        int newValue = rotation[0] == 'R' ? startValue + distance : startValue - distance + 100;

        return newValue % 100; // Use % 100 to ensure all values in 0 - 99 range.
    }

    // Data methods

    private static string[] GetData()
    {
        return File.ReadAllLines("../../Data/2025/day1.txt");
    }
}