
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;



namespace npuzzle
{
    class Program
    {
        private const char V = ' ';
        public static int N;

        public static bool solvable(int[] puzzle)
        {
            int inversions = 0;
            int row = 0;
            int blankrow = 0;

            for (int i = 0; i < N * N; i++)
            {
                if (i % N == 0)
                {
                    row++; //to know the number of rows 
                }
                if (puzzle[i] == 0)
                {
                    blankrow = row; //to know the blank row
                    continue;
                }
                int j = i + 1;// to know the no.of inversions
                while (j < N * N)
                {
                    if (puzzle[i] > puzzle[j] && puzzle[j] != 0)
                    {
                        inversions++;
                    }
                    j++;
                }
            }
            if (N % 2 != 0) //N is odd
            {
                if (inversions % 2 == 0)//no.of inversions should be even
                    return true;
                else return false;
            }
            else //N is even
            {
                if (blankrow % 2 == 0) //odd row from bottom
                {
                    if (inversions % 2 == 0) //even
                        return true;
                    else return false;
                }
                if (blankrow % 2 != 0)//even row from bottom
                {
                    {
                        if (inversions % 2 != 0)//odd
                            return true;
                        else return false;
                    }
                }               
            }
            return true;
        }
        public static int manhattancost(int[] puzzle)
        {
            int manhattan = 0;

            for (int i = 0; i < N*N; i++)
            {
                if (puzzle[i] == 0)
                    continue;
                int y = Math.Abs((i / N) - ((puzzle[i] - 1) / N)); //goal column
                int x = Math.Abs((i % N) - ((puzzle[i] - 1) % N)); //goal row
                manhattan += y + x;
            }
            return manhattan;
        }
        public static int hammingdistance(int[] puzzle)
        {
            int cost = 0;
            for (int i = 0; i < N * N; i++) 
            {
                if (puzzle[i] == 0)
                    continue;
                if (puzzle[i] != i + 1)
                    cost++;
            }
            return cost;
        }
       
        static void Main(string[] args)
        {
            int[] puzzle = new int[N *N];

            String file = File.ReadAllText("15 Puzzle 5.txt");
            file = file.Replace("\r", " ");
            file = file.Replace("\n", "");
            file = file.Replace("  ", " ");
            puzzle = file.Split(V).Select(i => Int32.Parse(i.ToString())).ToArray();
            N = puzzle[0];
            Console.WriteLine("Puzzle size = " + (N * N - 1));
            puzzle = puzzle.Skip(1).ToArray();

            if (solvable(puzzle))
            {
                Console.WriteLine("Solvable");
                node n = new node(puzzle, 0);
                AStar astar = new AStar();
                  astar.AStar_1(n);
               
            }
            else Console.WriteLine("Not Solvable");
            Console.WriteLine();
            Console.WriteLine();
        }
    }

}
