using System;

class TotalMarksValidation
{
    public void CheckMarks(int X, int Y, int N1, int N2, int M)
    {
        for (int t1 = N1; t1 >= 0; t1--)
        {
            int marksFromType1 = t1 * X;
            int remainingMarks = M - marksFromType1;

            if (remainingMarks < 0)
                continue;

            if (remainingMarks % Y == 0)
            {
                int t2 = remainingMarks / Y;

                if (t2 <= N2)
                {
                    Console.WriteLine("Valid");
                    Console.WriteLine(marksFromType1);
                    Console.WriteLine(t2 * Y);
                    return;
                }
            }
        }

        Console.WriteLine("Invalid");
    }
}

class Program
{
    static void Main()
    {
        int X = int.Parse(Console.ReadLine());
        int Y = int.Parse(Console.ReadLine());
        int N1 = int.Parse(Console.ReadLine());
        int N2 = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        TotalMarksValidation obj = new TotalMarksValidation();
        obj.CheckMarks(X, Y, N1, N2, M);
    }
}
