using System;
using System.Collections.Generic;

class UserProgramCode
{
    public static int getDonation(string[] input1, int input2)
    {
        HashSet<string> seen = new HashSet<string>();
        int totalDonation = 0;

        foreach (string s in input1){
            if (!seen.Add(s))
                return -1;

            foreach (char c in s){
                if (!char.IsDigit(c))
                    return -2;
            }

            int location = int.Parse(s.Substring(3, 3));
            int donation = int.Parse(s.Substring(6, 3));

            if (location == input2){
                totalDonation += donation;
            }
        }

        return totalDonation;
    }
}

class Program{
    static void Main(){
        Console.Write("Enter number of donations : ");
        int n = int.Parse(Console.ReadLine()!);
        string[] input1 = new string[n];

        for (int i = 0; i < n; i++){
            Console.Write("Donation " + (i+1) + " : ");
            input1[i] = Console.ReadLine()!;
        }

        Console.Write("Enter Location Code : ");
        int input2 = int.Parse(Console.ReadLine()!);

        int result = UserProgramCode.getDonation(input1, input2);
        Console.WriteLine(result);
    }
}
