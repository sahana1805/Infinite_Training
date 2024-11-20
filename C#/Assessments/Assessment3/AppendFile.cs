using System;
using System.IO;


namespace AppendFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = "SampleFile.txt";
            Console.WriteLine("Input the text to append");
            string input = Console.ReadLine();

            try
            {
                if(File.Exists(FilePath))
                {
                    using (StreamWriter sw = new StreamWriter(FilePath, append: true))
                    {
                        sw.WriteLine(input);
                    }

                    Console.WriteLine("Text appended successfully");
                }

                else
                {
                    using (StreamWriter sw = new StreamWriter(FilePath, append: false))
                    {
                        sw.WriteLine(input);
                    }

                    Console.WriteLine("File created & text appended sucessfully");
                }
            }

            catch(Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
        }
    }
}
