using System;

class SortAndInsertElement
{
    public int[] ProcessArray(int[] input1, int input2, int input3)
    {
        // BR-2: Size is negative
        if (input2 < 0)
            return new int[] { -2 };

        // BR-1: Any element is negative
        for (int i = 0; i < input2; i++)
        {
            if (input1[i] < 0)
                return new int[] { -1 };
        }

        // Sort the array (ascending)
        for (int i = 0; i < input2 - 1; i++)
        {
            for (int j = i + 1; j < input2; j++)
            {
                if (input1[i] > input1[j])
                {
                    int temp = input1[i];
                    input1[i] = input1[j];
                    input1[j] = temp;
                }
            }
        }

        // Create new array with size +1
        int[] output = new int[input2 + 1];
        int index = 0;
        bool inserted = false;

        for (int i = 0; i < input2; i++)
        {
            if (!inserted && input3 < input1[i])
            {
                output[index++] = input3;
                inserted = true;
            }
            output[index++] = input1[i];
        }

        // If element is greater than all elements
        if (!inserted)
            output[index] = input3;

        return output;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input2 = int.Parse(Console.ReadLine()!);

        int[] input1 = new int[input2];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < input2; i++)
            input1[i] = int.Parse(Console.ReadLine()!);

        Console.Write("Enter element to insert: ");
        int input3 = int.Parse(Console.ReadLine()!);

        SortAndInsertElement obj = new SortAndInsertElement();
        int[] result = obj.ProcessArray(input1, input2, input3);

        Console.Write("Output: ");
        foreach (int x in result)
            Console.Write(x + " ");
    }
}
