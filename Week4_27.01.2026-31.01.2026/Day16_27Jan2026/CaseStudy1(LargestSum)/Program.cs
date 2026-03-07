using System;
class UserProgramCode
{
    public static int largestNumber(int[] input1)
    {
        bool hasNegative = false;
        bool hasOutOfRange = false;

        HashSet<int> uniqueNumbers = new HashSet<int>();
        foreach (int num in input1){
            if (num < 0)
                hasNegative = true;
            else if (num == 0 || num > 100)
                hasOutOfRange = true;
            else
                uniqueNumbers.Add(num);
        }

        if (hasNegative && hasOutOfRange)
            return -3;
        if (hasNegative)
            return -1;
        if (hasOutOfRange)
            return -2;

        int sum = 0;

        for (int start = 1; start <= 91; start += 10){
            int end = start + 9;
            int maxInRange = -1;

            foreach (int num in uniqueNumbers){
                if (num >= start && num <= end && num > maxInRange){
                    maxInRange = num;
                }
            }

            if (maxInRange != -1)
                sum += maxInRange;
        }

        return sum;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()!);
        int[] input1 = new int[n];

        for (int i = 0; i < n; i++){
            input1[i] = int.Parse(Console.ReadLine()!);
        }

        int result = UserProgramCode.largestNumber(input1);
        Console.WriteLine(result);
    }
}
