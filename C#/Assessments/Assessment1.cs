using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program1
            Console.WriteLine("Enter the string");
            string word = Console.ReadLine();
            Console.WriteLine("Enter the index");
            int index = Convert.ToInt32(Console.ReadLine());
            removechar(word, index);


            //Program2
            Console.WriteLine("Enter the string");
            string word1 = Console.ReadLine();
            if (word1.Length <= 1)
                Console.WriteLine(word1);
            else
            { 
                char firstcharacter  = word1[0];
                char lastcharacter = word1[word1.Length - 1];
                Console.WriteLine(lastcharacter + word1.Substring(1, word1.Length - 2) + firstcharacter);

            }


            //Program3
            Console.WriteLine("Enter the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the third number");
            int num3 = Convert.ToInt32(Console.ReadLine());
            if (num1 > num2 && num1 > num3)
                Console.WriteLine("Output: " + num1);
            if (num2 > num1 && num2 > num3)
                Console.WriteLine("Output: " + num2);
            else
                Console.WriteLine("Output: " + num3);


            //Program4
            Console.WriteLine("Enter the string");
            string word2 = Console.ReadLine();
            Console.WriteLine("Enter the letter");
            char letter = Convert.ToChar(Console.ReadLine());
            int count = 0;
            for(int i =0;i<word2.Length;i++)
            {
                if (letter == word2[i])
                    count++;
            }
            Console.WriteLine("The number of times it has occured is " + count);

        }

       
        //Function of Program1
        static void removechar(string word, int index)
        {
            for(int i=0;i<word.Length;i++)
            {
                if (i != index)
                    Console.Write(word[i]);
            }
            Console.ReadLine();
        }
    }
}
