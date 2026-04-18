using System.Text;

namespace AOC2018.Days;

public class Day2
{
    private string[] _data = File.ReadAllLines("../../Data/2018/day2.txt");

    public int Part1()
    {
        int twoMatchingCount = 0, threeMatchingCount = 0;
        for (int i = 0; i < _data.Length; ++i)
        {
            CheckRepeatedLetters(_data[i], out bool containsTwo, out bool containsThree);
            twoMatchingCount += containsTwo ? 1 : 0;
            threeMatchingCount += containsThree ? 1 : 0;
        }
        return twoMatchingCount * threeMatchingCount;
    }

    public string Part2()
    {
        for (int i = 0; i < _data.Length - 1; ++i)
        {
            for (int j = i + 1; j < _data.Length; ++j)
            {
                if (HasOneCharacterDifference(_data[i], _data[j]))
                {
                    StringBuilder output = new();
                    for (int k = 0; k < _data[i].Length; ++k)
                    {
                        if (_data[i][k] == _data[j][k])
                            output.Append(_data[i][k]);
                    }
                    return output.ToString();
                }
            }
        }
        return "";
    }

    private static void CheckRepeatedLetters(string id, out bool containsTwo, out bool containsThree)
    {
        containsTwo = false;
        containsThree = false;

        int[] letters = new int[26];

        for (int i = 0; i < id.Length; ++i)
        {
            letters[id[i] - 'a']++;
        }
        for (int i = 0; i < 26; ++i)
        {
            if (letters[i] == 2)
                containsTwo = true;
            if (letters[i] == 3)
                containsThree = true;
            if (containsTwo && containsThree)
                return;
        }
    }

    private static bool HasOneCharacterDifference(string s1, string s2)
    {
        bool differenceFound = false;
        for (int i = 0; i < s1.Length; ++i)
        {
            if (s1[i] == s2[i])
                continue;
            if (differenceFound)
                return false;
            differenceFound = true;
        }
        return differenceFound;
    }
}