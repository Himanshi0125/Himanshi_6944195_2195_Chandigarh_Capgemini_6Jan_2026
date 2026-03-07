// using System;
// using System.Globalization;
// class Program
// {
//     static void Main()
//     {
//         Console.Write("Enter string : ");
//         string str = Console.ReadLine()!;

//         Console.Write("Enter characters : ");
//         char[] arr = str.ToCharArray();
//         int n = arr.Length;
//         int count = 0;

//         foreach (char ch in arr)
//         {
//             if (ch == '#')
//             {
//                 count++;
//             }
//         }
//         int write = n-1;
//         for(int i = n-1; i >= 0; i--)
//         {
//             if (i != '#')
//             {
//                 arr[j] = arr[i];
//                 j--;
//             }
//         }

//         for(int i = 0; i < count; i++)
//         {
//             arr[i] = '#';
//         }

//         Console.WriteLine("New string is : " new string(arr));

        
//     }
// }