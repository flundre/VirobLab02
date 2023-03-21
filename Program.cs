using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirobLab02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Progression> arr = new List<Progression>();
            arr.Add(new Arithmetic(1, 2, 10));
            arr.Add(new Geometric(1, 2, 10));
            arr.Add(new Arithmetic(-50, 20, 10));
            arr.Add(new Geometric(10, 0.5, 10));
            arr.Add(new Arithmetic(-100, 25, 10));

            while (true)
            {
                Console.WriteLine("What are we doing?");
                Console.WriteLine("1 - Add new progression");
                Console.WriteLine("2 - Print progressions");
                Console.WriteLine("3 - Find the Largest sum");
                Console.WriteLine("4 - Check arithmetic operators");
                Console.WriteLine("5 - Increase N in all progressions");
                Console.WriteLine("6 - Create new Array with all multipliers from Geometric Progressions");
                Console.WriteLine("7 - Exit");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Input Progression type (1 - artihmetic, 2 - geometric): ");
                    int type = int.Parse(Console.ReadLine());
                    Console.WriteLine("Input first elem: ");
                    double fm = double.Parse(Console.ReadLine());
                    Console.WriteLine("Input multiplier or increment: ");
                    double inc = double.Parse(Console.ReadLine());
                    Console.WriteLine("Input N: ");
                    int n = int.Parse(Console.ReadLine());
                    if (type == 1)
                    {
                        arr.Add(new Arithmetic(fm, inc, n));
                    }
                    else if (type == 2)
                    {
                        arr.Add(new Geometric(fm, inc, n));
                    }
                    else { throw new Exception("Wrong type input"); }
                }
                else if(choice == 2)
                {
                    for(int i = 0; i < arr.Count; ++i)
                    {
                        Console.WriteLine(arr[i]);
                        Console.WriteLine();
                    }
                }
                else if(choice == 3)
                {
                    Progression max = arr[0];
                    for(int i = 1; i < arr.Count; ++i)
                    {
                        int temp = max.CompareTo(arr[i]);
                        if (temp == 1)
                        {
                            continue;
                        }
                        else if(temp == -1)
                        {
                            max = arr[i];
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine($"The progression with the largest sum is:\n{max.ToString()}");
                }
                else if(choice == 4)
                {
                    Console.WriteLine($"{arr[0]}\n+\n{arr[2]}\n=\n{arr[0] + arr[2]}\n");
                    Console.WriteLine($"{arr[1]}\n+\n{arr[3]}\n=\n{arr[1] + arr[3]}\n");
                }
                else if(choice == 5)
                {
                    Console.WriteLine("Input n: ");
                    int n = int.Parse(Console.ReadLine());
                    for(int i = 0; i < arr.Count; ++i)
                    {
                        arr[i].N += n;
                    }
                }
                else if(choice == 6)
                {
                    List<double> mult = new List<double>(); ;
                    for(int i = 0; i < arr.Count; ++i)
                    {
                        if(arr[i] is Geometric)
                        {
                            mult.Add(arr[i].IncrementOrMultiplier);
                            Console.WriteLine(arr[i].IncrementOrMultiplier + " ");
                        }
                    }
                    Console.WriteLine();

                }
                else
                {
                    break;
                }

            }
        }
        static void Menu()
        {

        }
    }
}
