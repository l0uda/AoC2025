using System;

public class Day07 : BaseDay
{
    private readonly string _input;
    private List<string> txt;
    private static List<char[]> manifold = [];
    private static int height;
    private static int length;
    private static List<int> depths;
    private static List<int> nodes;
    private static int summ;
    private static long[,] calculated;
    private static long[,] counts;

    public Day07()
    {
        txt = File.ReadAllText(InputFilePath).Split(System.Environment.NewLine).ToList();
        foreach (string line in txt)
        {
            manifold.Add(line.ToCharArray());
        }
        summ = 0;
        height = manifold.Count;
        length = manifold[0].Length;
        depths = new List<int>(new int[(height - 2) / 2]);
        nodes = new List<int>(new int[(height - 2) / 2]);
        calculated = new long[length, height];
        counts = new long[length, height];
        for (int i = 0; i < depths.Count; i++)
        {
            depths[i] = 0;
            nodes[i] = 0;
        }
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                calculated[i, j] = 0;
            }
        }

    }

    private static int beamThis(int y, int x)
    {
        if (y >= height || x < 0 || x >= length)
        {
            return 0;
        }

        if (manifold[y][x] == '.')
        {
            manifold[y][x] = '|';
            return beamThis(y + 1, x);
        }

        if (manifold[y][x] == '^')
        {
            int a = beamThis(y, x + 1);
            int b = beamThis(y, x - 1);
            return 1 + a + b;
        }

        return 0;
    }

    public override ValueTask<string> Solve_1()
    {
        int x = 0;
        int y = 0;
        foreach (char[] line in manifold)
        {
            foreach (char c in line)
            {
                if (c == 'S')
                {
                    return new(beamThis(y + 1, x).ToString());
                }
                x++;
            }
            x = 0;
            y++;
        }
        return new("failed");
    }

    private static long beamThis2(int y, int x)
    {
        if (y >= height || x < 0 || x >= length)
        {
            return 1;
        }

        if (manifold[y][x] == '.' || manifold[y][x] == '|')
        {
            manifold[y][x] = '|';
            return beamThis2(y + 1, x);
        }

        if (manifold[y][x] == '^')
        {
            if (calculated[y, x] == 1){
                return counts[y, x];
            }
            long a = beamThis2(y, x + 1);
            long b = beamThis2(y, x - 1);
            calculated[y, x] = 1;
            counts[y, x] = a + b;
            return a + b;
        }

        return 0;
    }

    public override ValueTask<string> Solve_2()
    {
        int x = 0;
        int y = 0;
        foreach (char[] line in manifold)
        {
            foreach (char c in line)
            {
                if (c == 'S')
                {
                    return new(beamThis2(y + 2, x).ToString());
                }
                x++;
            }
            x = 0;
            y++;
        }
        return new("failed2");
    }
}
