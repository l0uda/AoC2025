using System;

public class Day03 : BaseDay
{
    private readonly string _input;
    private readonly List<string> txt;

    public Day03()
    {
        txt = File.ReadAllText(InputFilePath).Split(System.Environment.NewLine).ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int sum = 0;
        foreach (string s in txt)
        {
            int temp = 0;
            int index1 = 0;

            foreach (char c in s.Substring(0,s.Length-1))
            {
                int current = Int32.Parse(c.ToString());
                if (current > temp)
                {
                    temp = current;
                    index1 = s.IndexOf(c.ToString());
                }
            }
            int first = temp;
            temp = 0;
            string news = s.Substring(index1+1);

            foreach (char c in news)
            {
                int current = Int32.Parse(c.ToString());
                if (current > temp)
                {
                    temp = current;
                }
            }

            sum += int.Parse(first.ToString() + temp.ToString());
        }

        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        long sum = 0;
        foreach (string s in txt)
        {
            string modifieds = s;
            string builder = "";
            for (int i = 12; i > 0; i--)
            {
                int temp = 0;
                int index = 0;
                //Console.WriteLine(modifieds);
                //Console.WriteLine(builder);
                foreach (char c in modifieds.Substring(0, modifieds.Length - i + 1))
                {
                    //Console.WriteLine(modifieds.Substring(0, modifieds.Length - i + 1));
                    int current = Int32.Parse(c.ToString());
                    if (current > temp)
                    {
                        temp = current;
                        index = modifieds.IndexOf(c.ToString());
                    }
                }
                modifieds = modifieds.Substring(index + 1);
                builder += temp.ToString();
            }
            sum += long.Parse(builder);
            //Console.WriteLine(builder);
        }
        return new(sum.ToString());
    }
}
