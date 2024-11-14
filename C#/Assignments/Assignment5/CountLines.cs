using System;
using System.Collections.Generic;
using System.IO;

namespace File_CountLines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filepath = "SampleFile.txt";
                if (File.Exists(filepath))
                {
                    int lineCount = 0;
                    using (StreamReader reader = new StreamReader(filepath))
                    {
                        while (reader.ReadLine() != null)
                        {
                            lineCount++;
                        }
                    }
                    Console.WriteLine("The number of lines in the file is: " + lineCount);
                }
                else
                {
                    Console.WriteLine("The file does not exist");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);

            }
        }
    }
}
