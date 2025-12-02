namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        string[] txt = File.ReadAllLines("../../../TextFile1.txt");
        int val = 50;
        int res = 0;
        int flag = 0;
        
        foreach (string line in txt)
        {
            int turn = Int32.Parse(line.Substring(1));
            while (turn > 99)
            {
                res++;
                turn -= 100;
            }
            if (turn == 0)
            {
                continue;
            }

            if (line[0] == 'L')
            {
                val -= turn;
                if (val < 0)
                {

                    val = 100 + val;
                    if (flag == 0 && val != 0)
                    {
                        res++;
                    }
                }
            }

            else
            {
                val += turn;
                if (val > 99)
                {
                    val -= 100;
                    if (flag == 0 && val != 0)
                    {
                        res++;
                    }
                }
            }
            flag = 0;
            if (val == 0)
            {
                res++;
                flag = 1;
            }
        }
        Console.WriteLine(res);

    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}
