namespace AOC2015.Days;

public class Day3
{
    private string data = File.ReadAllText("../../Data/2015/day3.txt");
    private HashSet<(int, int)> visited = [ (0, 0) ];
    private HashSet<(int, int)> roboVisited = [ (0, 0) ];
    private (int i, int j) santaPosition = (0, 0);
    private (int i, int j) newSantaPosition = (0, 0);
    private (int i, int j) roboSantaPosition = (0, 0);
    private bool isRoboTurn = false;
    private Dictionary<char, (int, int)> movement = new() {
        { '^', (-1, 0) },
        { 'v', (1, 0) },
        { '<', (0, -1) },
        { '>', (0, 1) }
    };

    public void Deliver()
    {
        foreach (char c in data)
        {
            (int dx, int dy) = movement[c];

            santaPosition = (santaPosition.i + dx, santaPosition.j + dy);
            visited.Add(santaPosition);

            if (isRoboTurn)
            {
                roboSantaPosition = (roboSantaPosition.i + dx, roboSantaPosition.j + dy);
                roboVisited.Add(roboSantaPosition);
            }
            else
            {
                newSantaPosition = (newSantaPosition.i + dx, newSantaPosition.j + dy);
                roboVisited.Add(newSantaPosition);
            }
            isRoboTurn = !isRoboTurn;
        }

        Console.WriteLine($"The classic Santa delivers to {visited.Count} houses. With robo-Santa's help, he delivers to {roboVisited.Count} houses.");
    }
}