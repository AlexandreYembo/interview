using System;
using System.Collections.Generic;
using Interview.Factory;
using Interview.Helpers;

namespace Interview.Code.DataStructures.Arrays
{
    /* Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
       You may assume that each input would have exactly one solution, and you may not use the same element twice.
        You can return the answer in any order.

        Example 1:
        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

        Example 2:
        Input: nums = [3,2,4], target = 6
        Output: [1,2]

        Example 3:
        Input: nums = [3,3], target = 6
        Output: [0,1]

        Constraints:

        2 <= nums.length <= 104
        -109 <= nums[i] <= 109
        -109 <= target <= 109
        Only one valid answer exists.*/
    public class TwoSum : ICode
    {
        public void Run()
        {
            Print.PrintLine();
            Print.PrintRow("Given the array. Example: 1 2 4 5");
            var arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);

            Print.PrintRow("and the target of sum. Example: 4");
            var target = int.Parse(Console.ReadLine());

            var result = twoSum(arr, target);
            ConsoleHelper.PrintOutput("The result of the two sum is the index of: [" + string.Join(",", result) + "] from the given array");
        }

        private int[] twoSum(int[] nums, int target)
        {
            var arrLength = nums.Length;

            //Validations
            if (nums == null || arrLength < 2)
                return Array.Empty<int>();

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < arrLength; i++)
            {
                int firstNum = nums[i];
                //Take the sum (target) - firstNum. The result of the operation will be used to try to find a value that exist on the dictionary
                int secondNum = target - firstNum;

                ///It will check in the dictionary when the second number exist on the list, it will take the index and will return the value
                if (dictionary.TryGetValue(secondNum, out int index))
                    return new[] { index, i };

                dictionary[firstNum] = i;
            }

            return Array.Empty<int>();
        }
    }
}
