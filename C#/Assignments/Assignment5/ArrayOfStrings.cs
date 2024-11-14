using System;
using System.Collections.Generic;
using System.IO;

namespace File_ArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the number of lines you want to enter");
            int linesCount = Convert.ToInt32(Console.ReadLine());
            string[] lines = new string[linesCount];
            for (int i = 0; i < linesCount; i++)
            {
                Console.WriteLine("Enter a String");
                lines[i] = Console.ReadLine();
            }

            FileStream fs = new FileStream("SampleFile.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for(int i = 0; i < linesCount; i++)
            {
                sw.WriteLine(lines[i]);
            }
     
            sw.Flush();
            sw.Close();
            fs.Close();

        }
    }
}
