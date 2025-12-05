using System;
using System.Collections.Generic;

public class Day05 : BaseDay
{
    private readonly string _input;
    private List<string> txt;
    
    public Day05()
    {
        txt = File.ReadAllText(InputFilePath).Split(System.Environment.NewLine).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        long flag = 0;
        long freshCounter = 0;
        List<(long, long)> ranges = [];

        foreach (string s in txt)
        {
            if (flag == 1)
            {
                long ingredientID = long.Parse(s);
                foreach ((long, long) tupel in ranges)
                {
                    if (tupel.Item1 <= ingredientID && ingredientID <= tupel.Item2)
                    {
                        freshCounter++;
                        break;
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(s))
                {
                    flag = 1;
                    continue;
                }
                string[] splits = s.Split('-');
                ranges.Add((long.Parse(splits[0]), long.Parse(splits[1])));
            }
        }
        return new(freshCounter.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<long> freshList = [];
        List<(long, long)> ranges = [];

        foreach (string s in txt)
        {
            if (string.IsNullOrEmpty(s))
            {
                break;
            }
            string[] splits = s.Split('-');
            (long, long) range = (long.Parse(splits[0]), long.Parse(splits[1]));
            ranges.Add(range);
        }
        List<(long, long)> newRanges = [];
        for (int i = 0; i < ranges.Count; i++)
        {
            int flag = 1;
            for (int j = i+1; j < ranges.Count; j++)
            {
                if (ranges[i].Item1 <= ranges[j].Item2 && ranges[j].Item1 <= ranges[i].Item2)
                {
                    (long, long) newRange = (ranges[i].Item1 < ranges[j].Item1 ? ranges[i].Item1 : ranges[j].Item1, ranges[i].Item2 > ranges[j].Item2 ? ranges[i].Item2 : ranges[j].Item2);
                    ranges[j] = newRange;
                    flag = 0;
                    break;
                }
            }
            if (flag == 1)
            {
                newRanges.Add(ranges[i]);
            }
        }
        long summarino = 0;
        foreach((long, long) range in newRanges)
        {
            //Console.WriteLine(range.Item1.ToString() + '-' + range.Item2.ToString());
            summarino += range.Item2 - range.Item1 + 1;
        }
        return new(summarino.ToString());
    }
}
