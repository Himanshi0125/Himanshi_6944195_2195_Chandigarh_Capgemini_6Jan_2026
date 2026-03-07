using System;

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter a string : ");
        string str = Console.ReadLine()!;

        char[] arr = str.ToCharArray();

        int left = 0;
        int right = str.Length-1;

        while(left < right)
        {
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }

        string result = new string(arr);
        Console.WriteLine("Reversed String is : " + result);
    }
}