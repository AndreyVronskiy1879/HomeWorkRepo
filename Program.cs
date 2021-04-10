using System;

namespace ArraysHW2
{
    class Program
    {
        static void DisplayArray(int[] nums) => Console.WriteLine(string.Join(" ", nums));
        static void ChangeArray(int[] nums) => Array.Reverse(nums);
        static void Main(string[] args)
        {
            int[] nums = { 2, 5, 7 };
            DisplayArray(nums);

            ChangeArray(nums);
            Console.WriteLine("Array nums after the call to ChangeArray:");
            DisplayArray(nums);
            Console.WriteLine();



        }
    }
}
