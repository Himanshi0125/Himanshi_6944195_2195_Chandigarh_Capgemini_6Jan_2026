using System;

namespace MostRepeated
{
    class FindMostRepeated
    {
        public int[] GetMostRepeated(int[] arr)
        {
            int n = arr.Length;
            int[] count = new int[n];

            // Step 1: Count frequency
            for (int i = 0; i < n; i++)
            {
                count[i] = 1;

                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        count[i]++;
                    }
                }
            }

            // Step 2: Find maximum frequency
            int max = count[0];
            for (int i = 1; i < n; i++)
            {
                if (count[i] > max)
                    max = count[i];
            }

            // Step 3: Count how many elements have max frequency
            int size = 0;
            for (int i = 0; i < n; i++)
            {
                if (count[i] == max)
                {
                    bool alreadyAdded = false;

                    for (int k = 0; k < i; k++)
                    {
                        if (arr[i] == arr[k])
                        {
                            alreadyAdded = true;
                            break;
                        }
                    }

                    if (!alreadyAdded)
                        size++;
                }
            }

            // Step 4: Create output array
            int[] output = new int[size];
            int index = 0;

            for (int i = 0; i < n; i++)
            {
                if (count[i] == max)
                {
                    bool alreadyAdded = false;

                    for (int k = 0; k < i; k++)
                    {
                        if (arr[i] == arr[k])
                        {
                            alreadyAdded = true;
                            break;
                        }
                    }

                    if (!alreadyAdded)
                        output[index++] = arr[i];
                }
            }

            return output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 2, 2, 2, 2, 3, 3, 3, 3, 4 };

            FindMostRepeated obj = new FindMostRepeated();
            int[] result = obj.GetMostRepeated(input);

            Console.Write("Output: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
