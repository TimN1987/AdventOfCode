using System.Text;

namespace AoC2025.Days;

public static class Day6
{
    public static long PartOne()
    {
        var data = GetData();
        int length = data.First().Count();
        long total = 0;

        for (int i = 0; i < length; i++)
        {
            var calculation = GetCalculation(data, i);
            total += Calculate(calculation);
        }

        return total;
    }

    public static long PartTwo()
    {
        string[] data = GetStrings();
        int length = data[0].Length;

        long total = 0;
        List<int> nums = [];
        char op = ' ';

        for (int i = 0; i < length; i++)
        {
            int result = ScanColumn(data, i, out char tempOp);
            if (tempOp != ' ')
                op = tempOp;

            if (result == -1)
            {
                total += op == '*' ? nums.Aggregate(1L, (a, b) => a * b) : nums.Sum();
                op = ' ';
                nums.Clear();
            }
            else
            {
                nums.Add(result);
            }

            if (i == length - 1)
            {
                total += op == '*' ? nums.Aggregate(1, (a, b) => a * b) : nums.Sum();
            }
        }

        return total;
    }

    // Helper methods

    private static long Calculate(IEnumerable<string> calculation)
    {
        string op = calculation.Last();
        long total = op == "*" ? 1 : 0;
        
        foreach (string num in calculation)
        {
            if (int.TryParse(num, out int n))
            {
                if (op == "*")
                    total *= n;
                else
                    total += n;
            }
        }

        return total;
    }

    private static int ScanColumn(string[] data, int index, out char op)
    {
        int length = data.Length;
        op = data[length - 1][index];
        
        if (data.All(line => line[index] == ' '))
            return -1;

        var num = new StringBuilder();
        foreach (string line in data)
        {
            if (line[index] == ' ' || line[index] == '*' || line[index] == '+')
                continue;
            num.Append(line[index]);
        }

        return int.Parse(num.ToString());
    }

    // Data methods

    private static string[] GetStrings() => File.ReadAllLines("../../Data/2025/day6.txt");

    private static IEnumerable<IEnumerable<string>> GetData() => File
        .ReadAllLines("../../Data/2025/day6.txt")
        .Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries));

    private static IEnumerable<string> GetCalculation(IEnumerable<IEnumerable<string>> data, int index) => data
        .Select(line => line.Skip(index).First());
}