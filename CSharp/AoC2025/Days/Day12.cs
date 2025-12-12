namespace AoC2025.Days;

public static class Day12
{
    // Data methods

    private readonly static string[] _data = File.ReadAllLines("../../Data/2025/day12.txt");

    // Solution

    public static int PartOne()
    {
        Dictionary<int, int> size = [];

        int num = 0, present = 0, region = 0, total = 0;
        foreach (var line in _data)
        {
            if (line == "")
            {
                size[num] = present;
                present = 0;
            }
            else if (line.Length == 2)
                num = int.Parse(line[0].ToString());
            else if (line.Contains('#'))
                present += line.Where(x => x == '#').Count();
            else
            {
                var nums = line.Split(' ');
                region = int.Parse(nums[0][..2]) * int.Parse(nums[0][3..5]);
                int space = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    space += int.Parse(nums[i]) * size[i - 1];
                }
                total += space <= region ? 1 : 0;
            }
        }
        return total;
    }

    public static string PartTwo()
    {
        return "Merry Christmas";
    }
}