using System;

namespace StringHW5
{
    class Program
    {
        //        Write a program in C# Sharp to count a total number of vowel or consonant in a string. Go to the editor
        //Test Data :
        //Input the string : Welcome to w3resource.com
        //Expected Output :

        //The total number of vowel in the string is : 9 
        //The total number of consonant in the string is : 12 
        static void Main(string[] args)
        {
            string str = "Welcome to w3resource.com";
            var glas = 0;
            var sogl = 0;

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u')
                {
                    glas++;
                }
                else if ((str[i] >= 'a' && str[i] <= 'z'))
                {
                    sogl++;
                }
            }
            Console.Write($"The total number of vowel in the string is : {glas} ");
            Console.Write($" The total number of consonant in the string is : {sogl}");

        }
  
    }
}
