using System;
using System.Text;

class Strings
{
    static void Main()
    {
        //String
        string str1 = "";
        for(int i = 0; i < 5; i++){
            str1 += i;
        }
        Console.WriteLine("The String is (using String) : " + str1);

        // StringBuilder
        StringBuilder str2 = new StringBuilder();
        for (int i = 0; i < 5; i++)
        {
            str2.Append(i);
        }
        Console.WriteLine("The String is (using StringBuilder) : " + str2);

        // Trim()
        string str3 = "   Hello C#  ";
        Console.WriteLine("Trim : " + str3.Trim());

        // Substring()
        string str4 = "Hello CU C#";
        Console.WriteLine("SubString : " + str4.Substring(6, 2));

        // Split()
        String[] splitString = str4.Split(" ");
        Console.WriteLine("Split : " + splitString[2]);

        // Replace()
        string str5 = "Have a good day.";
        str5 = str5.Replace("good", "great");
        Console.WriteLine("Replace : " + str5);

        // Contains(), StartWith(), EndWith()
        Console.WriteLine("Contains : " + str5.Contains("day"));
        Console.WriteLine("Start With : " + str5.StartsWith("hello"));
        Console.WriteLine("End With : " + str5.Contains("day."));

        string str6 = "heLLo";
        str6 = str6.ToUpper();
        Console.WriteLine("Uppercase : " + str6);
        str6 = str6.ToLower();
        Console.WriteLine("Lowercase : " + str6);

    }
    
}