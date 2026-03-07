using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        string[] arr = Console.ReadLine().Split();
        int target = int.Parse(Console.ReadLine());

        int[] nums = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            nums[i] = int.Parse(arr[i]);
        }

        int[] result = TwoSum(nums, target);

        Console.WriteLine($"[{result[0]},{result[1]}]");
    }

    static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }

            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }
        }

        return new int[0];
    }
}
