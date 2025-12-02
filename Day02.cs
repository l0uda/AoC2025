public class Day02 : BaseDay
{
    private readonly string _input;
    private readonly List<string> txt;
    public Day02()
    {
        txt = File.ReadAllText(InputFilePath).Replace(System.Environment.NewLine, "").Split(',').ToList();
    }
    public override ValueTask<string> Solve_1()
    {
        long sum = 0;
        foreach (string item in txt)
        {
            List<string> beginend = item.Split('-').ToList();
            long begin = long.Parse(beginend[0]);
            long end = long.Parse(beginend[1]);

            for (long i = begin; i <= end; i++)
            {
                if (Math.Floor(Math.Log10(i)+1) % 2 == 0)
                {
                    string lolol = i.ToString();
                    string lol1 = lolol.Substring(0,lolol.Length/2);
                    string lol2 = lolol.Substring(lolol.Length/2);
                    if (lol1 == lol2)
                    {
                        sum+=i;
                    }
                }
            }

        }
        return new(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        long sum = 0;
        foreach (string item in txt)
        {
            List<string> beginend = item.Split('-').ToList();
            long begin = long.Parse(beginend[0]);
            long end = long.Parse(beginend[1]);
            
            for (long i = begin; i <= end; i++)
            {
                string lolzie = i.ToString();
                for (int j = 1; j <= lolzie.Length/2; j++)
                {
                    string sublolzie = lolzie.Substring(0, j);
                    if (lolzie.Length % j == 0)
                    {
                        int lag = 0;
                        for (int k = j; k < lolzie.Length; k+=j)
                        {
                            if (sublolzie != lolzie.Substring(k, j))
                            {
                                lag = 1;
                            }
                        }
                        if (lag == 0)
                        {
                            //Console.WriteLine(i);
                            sum += i;
                            break;
                        }
                    }
                }
            }
        }
        return new(sum.ToString());
    }
}
