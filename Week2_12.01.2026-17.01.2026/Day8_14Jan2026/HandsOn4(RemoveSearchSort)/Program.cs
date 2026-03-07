using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter array size: ");
        int input2 = int.Parse(Console.ReadLine()!);

        int[] output;

        if (input2 < 0)
        {
            output = new int[] { -2 };
            Print(output);
            return;
        }

        int[] input1 = new int[input2];

        Console.WriteLine("Enter array elements:");
        for (int i = 0; i < input2; i++)
        {
            input1[i] = int.Parse(Console.ReadLine()!);

            if (input1[i] < 0)
            {
                output = new int[] { -1 };
                Print(output);
                return;
            }
        }

        Console.Write("Enter search element: ");
        int input3 = int.Parse(Console.ReadLine());

        int pos = -1;
        for (int i = 0; i < input2; i++)
        {
            if (input1[i] == input3)
            {
                pos = i;
                break;
            }
        }

        if (pos == -1)
        {
            output = new int[] { -3 };
            Print(output);
            return;
        }

        // Remove the element
        int[] temp = new int[input2 - 1];
        int k = 0;
        for (int i = 0; i < input2; i++)
        {
            if (i != pos)
            {
                temp[k] = input1[i];
                k++;
            }
        }

        // Sort remaining elements
        for (int i = 0; i < temp.Length - 1; i++)
        {
            for (int j = i + 1; j < temp.Length; j++)
            {
                if (temp[i] > temp[j])
                {
                    int t = temp[i];
                    temp[i] = temp[j];
                    temp[j] = t;
                }
            }
        }

        output = temp;
        Print(output);
    }

    static void Print(int[] arr)
    {
        Console.Write("Output: ");
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}
