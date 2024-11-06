using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringPrograms

            Console.WriteLine("Length of a word program");
            Console.WriteLine("Enter a word");
            string word1 = Console.ReadLine();
            int length = word1.Length;
            Console.WriteLine("The length of the word is {0}", length);


            Console.WriteLine("Reverse of a word program");
            Console.WriteLine("Enter a word");
            string word2 = Console.ReadLine();
            string reverseword = new String (word2.Reverse().ToArray());
            Console.WriteLine("The reversed string is " + reverseword);


            Console.WriteLine("Compare two words program");
            Console.WriteLine("Enter the first word");
            string word3 = Console.ReadLine();
            Console.WriteLine("Enter the second word");
            string word4 = Console.ReadLine();
            if(word3.ToLower()==word4.ToLower())
            {
                Console.WriteLine("The words are the same");
            }
            else
            {
                Console.WriteLine("The words are not the same");
            }
        }
    }
}
