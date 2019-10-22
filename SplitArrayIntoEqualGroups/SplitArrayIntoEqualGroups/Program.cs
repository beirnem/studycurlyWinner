using System;
using System.Collections.Generic;
using System.Linq;

namespace SplitArrayIntoEqualGroups
{
    class Program
    {
        /// <summary>
        /// Simple algorithm to demonstrate how to split an array such that the sums of each part are equal.
        /// Constraints: Array is composed of 'ints'; the sum of each part of the array should also be whole numbers.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = { 1, 3, 3, 4, 5 };
            int[] arr2 = { 2, 4, 5, 6 };
            int[] arr3 = { 2, 5, 3 };

            int halfSumArray = HalfSumArray(arr);
            int halfSumArray2 = HalfSumArray(arr2);
            int halfSumArray3 = HalfSumArray(arr3);

            var result1 = halfSumArray != 0 ? HasPairWithSum(arr, arr.Length, halfSumArray) : false;
            Console.WriteLine("First Array " + (result1 ? "Success" : "Fail"));

            var result2 = halfSumArray2 != 0 ? HasPairWithSum(arr2, arr2.Length, halfSumArray2) : false;
            Console.WriteLine("Second Array " + (result2 ? "Success" : "Fail"));

            var result3 = halfSumArray3 != 0 ? HasPairWithSum(arr3, arr3.Length, halfSumArray3) : false;
            Console.WriteLine("Third Array " + (result3 ? "Success" : "Fail"));

            Console.ReadLine();

        }

        /// <summary>
        /// Check through the array for a pair of numbers that will add up to the target.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="n"></param>
        /// <param name="target"></param>
        /// <returns>True if the array can be split evenly.</returns>
        public static bool HasPairWithSum(int[] input, int n, int target)
        {
            // This array will store the difference between the target and the elements of the input array.
            int[] complements = new int[n];
            for(var i=0; i<n; i++)
            {
                // If the current number equals the target then we know the array can be split into two
                // One group will be the current number
                if (target - input[i] == 0) return true;

                // If the complements array contains the current number then we know the array can be split.
                // One group will be the current number plus it's compliment
                if (Array.Find(complements, item => item == input[i]) != 0)
                {
                    Console.WriteLine("Compliments " + string.Join(" ", complements));
                    return true;
                }
                complements[i] = target - input[i];
            }
            return false;
        }

        /// <summary>
        /// Get the target number by summing the array and halving it.
        /// If the sum is not even then the array cannot be split evenly.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Half the sum of the array, 0 if the sum is not even</returns>
        public static int HalfSumArray(int[] arr)
        {
            var sum = 0;
            foreach(var num in arr)
            {
                sum += num;
            }
            if(sum % 2 == 0)
            {
                return sum/2;
            }
            else
            {
                return 0;
            }
        }
    }
}
