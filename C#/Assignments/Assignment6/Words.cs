using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList alist = new ArrayList();
            Console.WriteLine("Enter the words separated by spaces");
            string words = Console.ReadLine();
            string[] wordsArray = words.Split(' ');

            foreach(string word in wordsArray)
            {
                alist.Add(word);
            }

            ArrayList newList = new ArrayList();
            foreach(string word in alist)
            {
                if (word.StartsWith("a") && word.EndsWith("m"))
                {
                    newList.Add(word);
                }
            }

            Console.WriteLine("Words starting with 'a' and ending with 'm'");
            foreach (string word in newList)
            {
                Console.WriteLine(word);
            }
        }
    }
}
