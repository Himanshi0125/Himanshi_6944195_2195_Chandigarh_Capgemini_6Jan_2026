using System;

class SecondLargestElement
{
    public int FindSecondLargest(int[] input1, int input3)
    {
        if (input3 < 0)
            return -2;

        for (int i = 0; i < input3; i++)
        {
            if (input1[i] < 0)
                return -1;
        }

        int largest = int.MinValue;
        int secondLargest = int.MinValue;

        for (int i = 0; i < input3; i++)
        {
            if (input1[i] > largest)
            {
                secondLargest = largest;
                largest = input1[i];
            }
            else if (input1[i] > secondLargest && input1[i] != largest)
            {
                secondLargest = input1[i];
            }
        }

        return secondLargest;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input3 = int.Parse(Console.ReadLine()!);

        int[] input1 = new int[input3];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < input3; i++)
            input1[i] = int.Parse(Console.ReadLine()!);

        SecondLargestElement obj = new SecondLargestElement();
        int output1 = obj.FindSecondLargest(input1, input3);

        Console.WriteLine("Output: " + output1);
    }
}
