using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

public class Day06 : BaseDay
{
    private readonly string _input;
    private List<string> txt;
    private Regex trimmer = new Regex(@"\s\s+");

    public Day06()
    {
        txt = File.ReadAllText(InputFilePath).Split(System.Environment.NewLine).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        List<string> operations = [];
        List<string> lines = [];

        int sizeOfRow = trimmer.Replace(txt[0].Trim(), " ").Split(" ").Count();

        List <List<string>> rows = [];
        int index0 = 0;
        foreach (string line in txt)
        {
            List<string> stripped = trimmer.Replace(line.Trim(), " ").Split(" ").ToList();
            if (Char.IsDigit(stripped[0][0]))
            {
                int index = 0;

                foreach (string num in stripped)
                {
                    if (index0 == 0)
                    {
                        rows.Add(new List<string>());
                    }
                    rows[index++].Add(num);
                }
            }
            else
            {
                operations = stripped;
            }
            index0++;
        }
        index0 = 0;
        long sum = 0;
        foreach (List<string> row in rows)
        {
            long subsum = 0;
            long subtimes = 1;
            foreach (string num in row)
            {
                switch (operations[index0])
                {
                    case "*":
                        subtimes *= long.Parse(num);
                        break;
                    case "+":
                        subsum += long.Parse(num);
                        break;
                }
            }
            switch (operations[index0])
            {
                case "*":
                    sum += subtimes;
                    break;
                case "+":
                    sum += subsum;
                    break;
            }
            index0++;
        }
        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<string> operations = [];
        List<string> lines = [];
        int height = txt.Count() - 1;
        int length = txt[0].Length;

        foreach (string row in txt)
        {

            char[] charypico = row.ToCharArray();
            Array.Reverse(charypico);
            lines.Add(new string(charypico));

        }
        List <long> batch = new List<long>();
        long sum = 0;

        for (int j = 0; j < lines[0].Length; j++)
        {
            string creator = "";
            for (int i = 0; i <= height; i++)
            {
                if (lines[i][j] != ' ' && lines[i][j] != '+' && lines[i][j] != '*')
                {
                    creator += lines[i][j];
                }
                if (lines[i][j] == '+' || lines[i][j] == '*')
                {
                    batch.Add(long.Parse(creator));
                    long subsum = 0;
                    long subtimes = 1;
                    foreach (long num in batch)
                    {
                        switch (lines[i][j])
                        {
                            case '*':
                                subtimes *= num;
                                break;
                            case '+':
                                subsum += num;
                                break;
                        }
                    }
                    switch (lines[i][j])
                    {
                        case '*':
                            sum += subtimes;
                            break;
                        case '+':
                            sum += subsum;
                            break;
                    }
                    batch = new List<long>();
                    creator = "";
                }
            }
            if (creator.Length > 0)
            {
                batch.Add(long.Parse(creator));
            }
        }

        return new(sum.ToString());
    }
}
