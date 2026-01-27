namespace AOC2015.Days;

public class Day2
{
    IEnumerable<int[]> _data = File.ReadAllLines("../../Data/2015/day2.txt")
        .Select(line => line.Split('x')
            .Select(x => int.Parse(x)))
        .Select(nums => nums.OrderBy(n => n).ToArray());

    public void WrapPresents()
    {
        int paper = _data
            .Sum(nums => 3 * nums[0] * nums[1] + 2 * nums[1] * nums[2] + 2 * nums[0] * nums[2]);
        int ribbon = _data
            .Sum(nums => 2 * (nums[0] + nums[1]) + nums[0] * nums[1] * nums[2]);
        Console.WriteLine($"The eleves need {paper} square feet of paper and {ribbon} feet of ribbon.");
    }
}