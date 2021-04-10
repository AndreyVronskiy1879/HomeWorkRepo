using System;

namespace ArraysHW3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[3] { 2, 5, 8 };
            nums[0] = 2;
            nums[1] = 5;
            nums[2] = 8;
            int summ = nums[0] + nums[1] + nums[2];
            Console.WriteLine(summ);
        }
    }
}
