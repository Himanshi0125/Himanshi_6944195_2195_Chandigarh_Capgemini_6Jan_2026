using System;

class UserProgramCode{
    public static string nextString(string input1){
        string vowelsLower = "aeiou";
        string vowelsUpper = "AEIOU";
        string result = "";

        foreach (char ch in input1){
            if (!char.IsLetter(ch))
                return "Invalid input";

            if (vowelsLower.Contains(ch)){
                int index = vowelsLower.IndexOf(ch);
                char nextConsonant = ch;

                do{
                    nextConsonant++;
                    if (nextConsonant > 'z')
                        nextConsonant = 'a';
                }
                while (vowelsLower.Contains(nextConsonant));

                result += nextConsonant;
            }
            else if (vowelsUpper.Contains(ch)){
                int index = vowelsUpper.IndexOf(ch);
                char nextConsonant = ch;

                do{
                    nextConsonant++;
                    if (nextConsonant > 'Z')
                        nextConsonant = 'A';
                }
                while (vowelsUpper.Contains(nextConsonant));

                result += nextConsonant;
            }
            else{
                char lower = char.ToLower(ch);
                char nextVowel = 'a';

                if (lower <= 'a') nextVowel = 'a';
                else if (lower <= 'e') nextVowel = 'e';
                else if (lower <= 'i') nextVowel = 'i';
                else if (lower <= 'o') nextVowel = 'o';
                else nextVowel = 'u';

                result += char.IsUpper(ch) ? char.ToUpper(nextVowel) : nextVowel;
            }
        }

        return result;
    }
}

class Program{
    static void Main()
    {
        Console.Write("Enter String : ");
        string input = Console.ReadLine()!;
        string output = UserProgramCode.nextString(input);
        Console.WriteLine(output);
    }
}
