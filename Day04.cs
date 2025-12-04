using System;

public class Day04 : BaseDay
{
    private readonly string _input;
    private List<string> txt;

    public Day04()
    {
        txt = File.ReadAllText(InputFilePath).Split(System.Environment.NewLine).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int sum = 0;
        for (int i  = 0; i < txt.Count; i++)
        {
            for (int j = 0; j < txt[i].Length; j++)
            {
                if (txt[i][j] == '.')
                {
                    continue;
                }

                int rollCounter = 0;
                for (int k = -1; k < 2; k++)
                {
                    for (int l = -1; l < 2; l++)
                    {
                        if (i+k >= 0 && i+k < txt.Count && j+l >= 0 && j+l < txt[i].Length)
                        {
                            if (txt[i+k][j+l] == '@' && !(k == 0 && l == 0))
                            {
                                rollCounter++;
                            }
                        }
                    }
                }
                if (rollCounter < 4)
                {
                    sum++;
                }
            }
        }
        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int sum = 0;
        int changes = 1;
        string[] txt2 = File.ReadAllText(InputFilePath).Split(System.Environment.NewLine); 

        while (changes > 0)
        {
            changes = 0;
            for (int i = 0; i < txt2.Length; i++)
            {
                for (int j = 0; j < txt2[i].Length; j++)
                {
                    if (txt2[i][j] == '.')
                    {
                        continue;
                    }

                    int rollCounter = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            if (i + k >= 0 && i + k < txt2.Length && j + l >= 0 && j + l < txt2[i].Length)
                            {
                                if (txt2[i + k][j + l] == '@' && !(k == 0 && l == 0))
                                {
                                    rollCounter++;
                                }
                            }
                        }
                    }
                    if (rollCounter < 4)
                    {
                        sum++;
                        changes++;
                        string rest = "";
                        if (j+1 < txt2.Length)
                        {
                            rest = txt2[i].Substring(j + 1);
                        }
                        txt2[i] = txt2[i].Substring(0, j) + '.' + rest;
                    }
                }
            }

        }
        return new(sum.ToString());
    }
}
