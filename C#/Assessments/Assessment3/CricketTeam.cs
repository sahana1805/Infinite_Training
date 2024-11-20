using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cricketteam
{
    class CricketTeam
    {
        public void PointsCalculation(int no_of_matches)
        {
            int[] score = new int[no_of_matches];
            int sum = 0;
            double average = 0;
            Console.WriteLine();

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write("Enter the score for match " + (i + 1) + ": ");
                score[i] = Convert.ToInt32(Console.ReadLine());
                sum += score[i];
            }

            average = (double)sum / no_of_matches;

            Console.WriteLine();
            Console.WriteLine("Total number of matches played: " + no_of_matches);
            Console.WriteLine("Sum of scores of matches played: " + sum);
            Console.WriteLine("Average score of matches played: " + average);
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            CricketTeam ct = new CricketTeam();
            Console.Write("Enter the number of matches played: ");
            int no_of_matches = Convert.ToInt32(Console.ReadLine());
            ct.PointsCalculation(no_of_matches);
        }
    }
}
