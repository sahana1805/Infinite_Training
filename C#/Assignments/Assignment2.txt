using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1st Program");
            Console.WriteLine("Enter the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Numbers before swapping: num1 = {0}, num2 = {1}", num1, num2);
            int temp = 0;
            temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("Numbers after swapping: num1 = {0}, num2 = {1}", num1, num2);


            Console.WriteLine("2nd Program");
            Console.WriteLine("Enter the number");
            int num3 = Convert.ToInt32(Console.ReadLine());
            for(int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    if(i%2==0)
                    {
                        Console.Write("{0} ", num3);
                    }
                    else
                    {
                        Console.Write("{0}", num3);
                    }
                }
                Console.WriteLine();
            }


            Console.WriteLine("3rd Program");
            Console.WriteLine("Enter a number");
            Char num4 = Convert.ToChar(Console.ReadLine());
            switch(num4)
            {
                case '1': Console.WriteLine("Monday");
                    break;

                case '2':
                    Console.WriteLine("Tuesday");
                    break;

                case '3':
                    Console.WriteLine("Wednesday");
                    break;

                case '4':
                    Console.WriteLine("Thursday");
                    break;

                case '5':
                    Console.WriteLine("Friday");
                    break;

                case '6':
                    Console.WriteLine("Saturday");
                    break;

                case '7':
                    Console.WriteLine("Sunday");
                    break;

                default:
                    Console.WriteLine("Invalid number");
                    break;

            }


            Console.WriteLine("----------------Arrays-----------------");


            Console.WriteLine("1st Array Program");
            int[] arr = new int[] { 5, 9, 2, 7, 4 };
            int sum = 0;
            int min1 = arr[0];
            int max1 = arr[0];
            for(int i=0; i<arr.Length; i++)
            {
                sum += arr[i];
                if(arr[i]<min1)
                {
                    min1 = arr[i];
                }
                if(arr[i]>max1)
                {
                    max1 = arr[i];

                }
            }
            double average1 = (double)sum / arr.Length;
            Console.WriteLine("The average is " + average1);
            Console.WriteLine("The minimum value is " + min1);
            Console.WriteLine("The maximum value is " + max1);


            Console.WriteLine("2nd Array Program");
            double[] marks = new double[10];
            double total = 0;
            double average2 = 0;
            Console.WriteLine("Enter 10 marks");
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = Convert.ToDouble(Console.ReadLine());
            }
            double min2 = marks[0];
            double max2 = marks[0];
            for (int i = 0; i < marks.Length; i++)
            {
                total += marks[i];
                if (marks[i] < min2)
                {
                    min2 = marks[i];
                }
                if (marks[i] > max2)
                {
                    max2 = marks[i];
                }    
                
            }
            average2 = total / marks.Length;
            Console.WriteLine("The total is " + total);
            Console.WriteLine("The average is " + average2);
            Console.WriteLine("The minimum marks is " + min2);
            Console.WriteLine("The maximum marks is " + max2);
            double temp1 = 0;
            for(int i=0;i<marks.Length;i++)
            {
                for(int j=i+1;j<marks.Length;j++)
                {
                    if (marks[j]<marks[i])
                    {
                        temp1 = marks[j];
                        marks[j] = marks[i];
                        marks[i] = temp1;
                    }
                }
            }

            Console.WriteLine("The ascending order is:");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write(marks[i] + " ");
            }
            for (int i = 0; i < marks.Length; i++)
            {
                for (int j = i + 1; j < marks.Length; j++)
                {
                    if (marks[i] < marks[j])
                    {
                        temp1 = marks[j];
                        marks[j] = marks[i];
                        marks[i] = temp1;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("The descending order is:");
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write(marks[i] + " ");
            }
            Console.WriteLine();


            Console.WriteLine("3rd Array Program");
            int[] arr1 = new int[] { 7, 3, 0, 1, 6 };
            int[] arr2 = new int[arr1.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                arr2[i] = arr1[i];
                
            }
            Console.Write("The new array is { ");
            for (int i = 0; i < arr1.Length; i++)
                if(i<arr1.Length - 1)
                    Console.Write(arr2[i] + ", ");
                else
                    Console.Write(arr2[i]);
            Console.Write(" }");
        }
        
    }

}
