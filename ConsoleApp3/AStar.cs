using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace npuzzle
{
    class AStar
    {
        public static priorityqueue pq;
        node n;
        public static Stopwatch sw = new Stopwatch();

        public void AStar_1(node root)
        {
            pq = new priorityqueue();
            pq.enqueue(root);
            

            while (!pq.empty())
            {
                sw.Start();
                n = pq.dequeue();
                if (n.manhattanDistance == 0)// reach the goal state
                {
                    if (Program.N == 3)// if n==3 print the path 
                    {
                        Console.Write("\n");
                        Console.WriteLine("Initial state: ");
                        node[] n2 = new node[n.level];
                        node newnode = n;
                        int i = 0;
                        for (; newnode.parent != null; i++)
                        {
                            newnode = newnode.parent;
                            n2[i] = newnode;
                        }
                        for (int j = i - 1; j >= 0; j--)
                        {

                            for (int k = 0; k < n.puzzle.Length; k++)
                            {
                                if (k % Program.N == 0)
                                {
                                    Console.Write("\n");
                                }
                                Console.Write(n2[j].puzzle[k] + " ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Goal state: ");

                        for (int j = 0; j < n.puzzle.Length; j++)
                        {
                            if (j % Program.N == 0)
                            {
                                Console.Write("\n");
                            }
                            Console.Write(n.puzzle[j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine("#steps: " + n.level);
                    sw.Stop();
                    Console.WriteLine("Execution Time: "+sw.Elapsed);
                    break;
                }
                
                n.nextmove(n);
                for (int i = 0; i < n.Node.Count(); i++)
                {
                    node front = n.Node[i];
                    pq.enqueue(front);
                } 
            }
        }
    }
}
