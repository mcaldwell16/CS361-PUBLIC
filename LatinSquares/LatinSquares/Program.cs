using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatinSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = false;

            int n = 10;

            int[,] table = new int[n, n];

            List<int> elements = new List<int>();
            for (int i = 0; i < table.GetLength(0); i++)
                    elements.Add(i);
            while (cont != true)
            {
                

                // Fill the table with -1
                Fill(table);

            
                

                // Fill in the latin square
                cont = LatinSquareable(table, elements);
                
                Console.Clear();
            }

            // Print out the matrix
            PrintMatrix(table);

            Console.WriteLine($"is valid? {check(table)}");
            // Halt the program
            Halt();
        }



        public static bool LatinSquareable(int[,] table, List<int> elements)
        {
            List<int> temp = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    temp.Clear();
                    foreach (int e in elements)
                    {
                        temp.Add(e);
                    }

                    for (int col = 0; col < table.GetLength(0); col++)
                        if (table[i, col] != -1)
                            temp.Remove(table[i, col]);

                    for (int row = 0; row < table.GetLength(0); row++)
                        if (table[row, j] != -1)
                            temp.Remove(table[row, j]);

                    if (temp.Count > 0)
                    {
                       /* foreach (int e in temp)
                        {
                            Console.Write(e + ", ");
                        }*/
                       // Console.WriteLine();
                       // Console.ReadLine();
                        table[i, j] = temp.ElementAt<int>(rand.Next(0, temp.Count));
                        temp.Clear();
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public static void Fill(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    m[i, j] = -1;
        }


        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(0) - 1)
                    {
                        if (matrix[i, j] != -1)
                            Console.Write("{0} \n", matrix[i, j]);
                        else
                            Console.Write("_ \n", matrix[i, j]);
                    }
                    else
                    {
                        if (matrix[i, j] != -1)
                            Console.Write("{0} ", matrix[i, j]);
                        else
                            Console.Write("_ ", matrix[i, j]);
                    }
                        
                }
            }
            
        }

        //Helper function to pause the terminal
        public static void Halt()
        {
            Console.WriteLine("..Press Enter to continue..");
            Console.WriteLine(" ");
            do
            { //do nothing while stuck in loop
            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }

        public static bool check(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int validVal = ((n - 1) * (n)) / 2;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                int sum2 = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += matrix[i, j];
                    sum2 += matrix[j, i];
                }
                if (sum != validVal || sum2 != validVal)
                {
                    Console.WriteLine($"validVal is {validVal}");
                    return false;
                }
            }
            Console.WriteLine($"validVal is {validVal}");
            return true;
        }
    }
}
