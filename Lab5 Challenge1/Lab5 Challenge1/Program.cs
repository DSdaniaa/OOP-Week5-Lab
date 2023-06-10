using Lab5_Challenge1.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyPoint start = new MyPoint();
            MyPoint end = new MyPoint();
            MyLine line = new MyLine(start, end);
            string choice;
            MyPoint result;
            int startX, startY, endX, endY;
            do
            {
                choice = mainMenu();
                if (choice == "1")
                {
                    
                    Console.Write("Enter the X-coordinate of the starting point: ");
                    startX = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Y-coordinate of the starting point: ");
                    startY = int.Parse(Console.ReadLine());
                    Console.Write("Enter the X-coordinate of the ending point: ");
                    endX = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Y-coordinate of the ending point: ");
                    endY = int.Parse(Console.ReadLine());
                    start.setXY(startX,startY);
                    end.setXY(endX,endY);
                    line.setBegin(start);
                    line.setEnd(end);
                    clear();


                }
                else if (choice == "2")
                {
                    Console.Write("Enter the X-coordinate of the starting point: ");
                    startX = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Y-coordinate of the starting point: ");
                    startY = int.Parse(Console.ReadLine());
                    start.setXY(startX, startY);
                    line.setBegin(start);
                    clear();
                }
                else if (choice == "3")
                {
                    Console.Write("Enter the X-coordinate of the ending point: ");
                    endX = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Y-coordinate of the ending point: ");
                    endY = int.Parse(Console.ReadLine());
                    end.setXY(endX, endY);
                    line.setEnd(end);
                    clear();
                }
                else if (choice == "4")
                {
                    Console.Write("Begin Point: ");
                    result = line.getBegin();
                    Console.WriteLine("(" + result.x+","+result.y+")");
                    clear();
                }
                else if (choice == "5")
                {
                    Console.Write("End Point: ");
                    result = line.getEnd();
                    Console.WriteLine("("+result.x + "," + result.y+")");
                    clear();
                }
                else if (choice == "6")
                {
                    Console.Write("Length: ");
                    Console.WriteLine(line.getLength());
                    clear();
                }
                else if (choice == "7")
                {
                    Console.Write("Gradient: ");
                    Console.WriteLine(line.getGradient());
                    clear();
                }
                else if (choice == "8")
                {
                    Console.Write("Distance of begin point from zero coordinates: ");
                    Console.WriteLine(start.distanceFromZero());
                    clear();
                }
                else if (choice == "9")
                {
                    Console.Write("Distance of end point from zero coordinates:");
                    Console.WriteLine(end.distanceFromZero());
                    clear();
                }

            } while (choice != "10");
        }
        static string mainMenu()
        {
            string option;
            Console.WriteLine("1.Make a Line");
            Console.WriteLine("2.Update the begin point");
            Console.WriteLine("3.Update the end point");
            Console.WriteLine("4.Show the begin Point");
            Console.WriteLine("5.Show the end point");
            Console.WriteLine("6.Get the Length of the line");
            Console.WriteLine("7.Get the Gradient of the Line");
            Console.WriteLine("8.Find the distance of begin point from zero coordinates");
            Console.WriteLine("9.Find the distance of end point from zero coordinates");
            Console.WriteLine("10.Exit");
            Console.Write("Enter Your Choice: ");
            option = Console.ReadLine();
            Console.Clear();
            return option;
        }
        static void clear()
        {
            Console.WriteLine("Press Enter To Contiune..... ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
