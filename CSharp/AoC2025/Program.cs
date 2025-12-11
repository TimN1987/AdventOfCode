using AoC2025;
using AoC2025.Days;
using System.Diagnostics;

Stopwatch sw = new();

sw.Start();
int day1Part1Result = Day1.Part1();
int day1Part2Result = Day1.Part2();
int bruteForce = Day1.Part2B();
sw.Stop();

Console.WriteLine($"Day 1:\nPart 1: {day1Part1Result}\nPart 2: {day1Part2Result}\nBrute force: {bruteForce}\nTime: {sw.ElapsedMilliseconds}ms");

sw.Restart();
long day2Part1Result = Day2.PartOne();
long day2Part2Result = Day2.PartTwo();
sw.Stop();

Console.WriteLine($"Day 2:\nPart 1: {day2Part1Result}\nPart 2: {day2Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");

sw.Restart();
long day3Part1Result = Day3.PartOne();
long day3Part2Result = Day3.PartTwo();
sw.Stop();

Console.WriteLine($"Day 3:\nPart 1: {day3Part1Result}\nPart 2: {day3Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");

sw.Restart();
int day4Part1Result = Day4.PartOne();
int day4Part2Result = Day4.PartTwo();
sw.Stop();

Console.WriteLine($"Day 4:\nPart 1: {day4Part1Result}\nPart 2: {day4Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");

sw.Restart();
Day5.Solution(out int day5Part1Result, out long day5Part2Result);
sw.Stop();

Console.WriteLine($"Day 5:\nPart 1: {day5Part1Result}\nPart 2: {day5Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");

sw.Restart();
long day6Part1Result = Day6.PartOne();
long day6Part2Result = Day6.PartTwo();
sw.Stop();

Console.WriteLine($"Day6:\nPart 1: {day6Part1Result}\nPart 2: {day6Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");

Day7.Solution();

sw.Restart();
int day8Part1Result = Day8.PartOne();
int day8Part2Result = Day8.PartTwo();
sw.Stop();

Console.WriteLine($"Day8:\nPart1: {day8Part1Result}\nPart 2: {day8Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");

sw.Restart();
long day9Part1Result = Day9.PartOne();
long day9Part2Result = Day9.PartTwo();
sw.Stop();

Console.WriteLine($"Day 9\nPart 1: {day9Part1Result}\nPart 2: {day9Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");

sw.Restart();
long day10Part1Result = Day10.PartOne();
long day10Part2Result = Day10.PartTwo();
sw.Stop();

Console.WriteLine($"Day 10\nPart 1: {day10Part1Result}\nPart 2: {day10Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");

sw.Restart();
int day11Part1Result = Day11.PartOne();
long day11Part2Result = Day11.PartTwo();
sw.Stop();

Console.WriteLine($"Day 11\nPart 1: {day11Part1Result}\nPart 2: {day11Part2Result}\nTime: {sw.ElapsedMilliseconds}ms");