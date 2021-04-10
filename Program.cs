using System;

namespace StringHW3
{
    class Program
    {
//        Write a program in C# Sharp to print individual characters of the string in reverse order. Go to the editor
//Test Data :
//Input the string : w3resource.com
//Expected Output :

//The characters of the string in reverse are : 

//m o  c.e c  r u  o s  e r  3  w
        static void Main(string[] args)
        {
            string str = "w3resource.com";
            char[] cStr = str.ToCharArray();
            Array.Reverse(cStr);
            string result = String.Join("  ", cStr);
            Console.WriteLine(result);
        }
    }
}
