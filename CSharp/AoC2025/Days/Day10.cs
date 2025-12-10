using Microsoft.Z3;

namespace AoC2025.Days;

public static class Day10
{
    public static long PartOne()
    {
        List<(int[] lights, int[][] buttons, int[] joltage)> data = ParseData();
        long total = 0;

        foreach ((int[] lights, int[][] buttons, int[] _) in data)
        {
            int n = buttons.Length;
            int min = int.MaxValue;
            int max = (int)Math.Pow(2, n);
            for (int i = 1; i < max; i++)
            {
                var combo = Enumerable.Range(0, n)
                    .Where(n => ((i >> n) & 1) != 0)
                    .Select(n => buttons[n]);
                if (MatchLights(combo, lights))
                    min = Math.Min(min, combo.Count());
            }

            total += min;
        }

        return total;
    }

    public static long PartTwo()
    {
        List<(int[] lights, int[][] buttons, int[] joltage)> data = ParseData();
        
        long total = 0;

        foreach ((int[] _, int[][] buttons, int[] joltage) in data)
        {
            total += SolveWithZ3(joltage, buttons);
        }

        return total;
    }

    // Helper methods

    private static bool MatchLights(IEnumerable<int[]> combo, int[] lights)
    {
        int length = lights.Length;
        int[] pattern = new int[length];

        foreach (int[] button in combo)
            foreach (int b in button)
                pattern[b] = pattern[b] == 0 ? 1 : 0; // Toggle switch

        for (int i = 0; i < length; i++)
            if (pattern[i] != lights[i])
                return false;

        return true;
    }

    // Z3 implementation

    public static long SolveWithZ3(int[] target, int[][] buttons)
    {
        using var ctx = new Context();
        Optimize opt = ctx.MkOptimize();

        int numButtons = buttons.Length;
        int numLights = target.Length;

        IntExpr[] x = new IntExpr[numButtons];
        for (int i = 0; i < numButtons; i++)
            x[i] = ctx.MkIntConst($"x_{i}");

        for (int light = 0; light < numLights; light++)
        {
            ArithExpr sum = ctx.MkInt(0);
            for (int btn = 0; btn < numButtons; btn++)
                if (buttons[btn].Any(b => b == light))
                    sum = ctx.MkAdd(sum, x[btn]);

            opt.Add(ctx.MkEq(sum, ctx.MkInt(target[light])));
        }

        for (int i = 0; i < numButtons; i++)
            opt.Add(ctx.MkGe(x[i], ctx.MkInt(0)));

        ArithExpr total = ctx.MkAdd(x);
        opt.MkMinimize(total);

        if (opt.Check() != Status.SATISFIABLE)
            throw new Exception("No solution found");

        Model model = opt.Model;

        long sumPresses = 0;
        for (int i = 0; i < numButtons; i++)
        {
            IntNum val = model.Evaluate(x[i], true) as IntNum;
            sumPresses += val.Int64;
        }

        return sumPresses;
    }

    
    // Data methods

    private static IEnumerable<string[]> GetData()
        => File.ReadAllLines("../../Data/2025/day10.txt")
            .Select(line => line.Split(' ').ToArray());

    private static List<(int[], int[][], int[])> ParseData()
    {
        var data = GetData();
        List<(int[], int[][], int[])> parsed = [];

        foreach (var line in data)
        {
            int[] lights = ParseLights(line[0]);
            int[][] buttons = ParseButtons(line[1..^1]);
            int[] joltage = ParseJoltage(line[^1]);

            parsed.Add((lights, buttons, joltage));
        }

        return parsed;
    }

    private static int[] ParseLights(string lights)
    {
        int[] parsed = new int[lights.Length - 2]; //Ignore brackets.

        for (int i = 0; i < lights.Length - 2; i++)
            parsed[i] = lights[i + 1] == '#' ? 1 : 0;

        return parsed;
    }

    private static int[][] ParseButtons(string[] buttons) => buttons
            .Select(b => 
                b[1..^1]
                    .Split(',')
                    .Select(s => int.Parse(s))
                    .ToArray()
            )
            .ToArray();

    private static int[] ParseJoltage(string joltage)  
        => joltage[1..^1]
            .Split(',')
            .Select(s => int.Parse(s))
            .ToArray();
}